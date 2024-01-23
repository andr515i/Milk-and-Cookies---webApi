using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Milk_and_Cookies.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class Opgave1Controller : Controller
	{


		[HttpGet("GetFavoriteMilkshakeFromCookie")]
		public async Task<ActionResult<String>> GetFavoriteMilkshake()
		{
			if (Request.Cookies["testCookie"] != null)
			{
				return Request.Cookies["testCookie"];
			}
			return "unknown";
		}

		[HttpGet("GetFavoriteMilkshake")]
		public async Task<ActionResult<String>> GetFavoriteMilkshake(string favMilkshake)
		{
			try
			{
				CookieOptions options = new CookieOptions();
				options.MaxAge = TimeSpan.FromHours(1);
				Response.Cookies.Append("testCookie", favMilkshake, options);
				return Ok(favMilkshake);

			}
			catch (Exception ex)
			{

				return BadRequest("exception caught: " + ex.Message);
			}
		}

	}
}

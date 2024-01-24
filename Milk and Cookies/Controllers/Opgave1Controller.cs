using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Milk_and_Cookies.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class Opgave1Controller : Controller
	{


		[HttpGet("GetFavoriteMilkshakeFromCookie")]
		public ActionResult<string> GetFavoriteMilkshakeFromCookie()
		{
			if (Request.Cookies["testCookie"] != null)
			{
				return Request.Cookies["testCookie"];
			}
			return "unknown";
		}

		[HttpGet("GetFavoriteMilkshake")]
		public ActionResult<string> GetFavoriteMilkshake(string favMilkshake)
		{
			try
			{
				CookieOptions options = new CookieOptions();
				options.MaxAge = TimeSpan.FromMinutes(5);  // set cookie expire age after 5 minutes
				Response.Cookies.Append("testCookie", favMilkshake, options); // create the cookie
				return Ok(favMilkshake);

			}
			catch (Exception ex) 
			{
				Response.StatusCode = 404;
				return BadRequest("exception caught: " + ex.Message);
			}
		}

	}
}

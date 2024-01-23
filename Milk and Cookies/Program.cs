
namespace Milk_and_Cookies
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			// Add distributed memory cache service
			builder.Services.AddDistributedMemoryCache();

			//builder.Services.AddSession(options =>
			//{
			//	options.Cookie.Name = "test.session";
			//	options.IdleTimeout = TimeSpan.FromHours(1);
			//	options.Cookie.IsEssential = true;
			//});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseAuthorization();

			//app.UseSession();

			app.MapControllers();

			app.Run();
		}
	}
}

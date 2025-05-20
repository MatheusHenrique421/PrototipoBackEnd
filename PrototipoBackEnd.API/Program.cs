using PrototipoBackEnd.API.WebApplicationExtensions;
using PrototipoBackEnd.Infrastructure.IoC;
using PrototipoBackEnd.API.Extensions;

namespace PrototipoBackEnd.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Adiciona a inje��o de depend�ncia da camada Infrastructure
			builder.Services
				.AddInfrastructure(builder.Configuration)
				.AddConfiguredControllers()
				.AddSwaggerDocumentation()
				.AddFrontendCors();
			
			var app = builder.Build();

			app.UseCustomMiddlewares();

			app.MapControllers();

			app.Run();
		}
	}
}

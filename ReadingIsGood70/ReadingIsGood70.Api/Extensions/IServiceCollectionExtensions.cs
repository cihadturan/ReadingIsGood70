using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using ReadingIsGood70.BusinessLayer.Options;
using ReadingIsGood70.Utils.Swagger;

namespace ReadingIsGood70.Api.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void ConfigureSwagger(
            this IServiceCollection service,
            SwaggerOptions swaggerOptions,
            OpenApiInfo info = null,
            string tokenType = "Bearer",
            OpenApiSecurityScheme keyScheme = null
            )
        {
            if (swaggerOptions == null)
            {
                return;
            }

            service.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    swaggerOptions.Version,
                    info ?? new OpenApiInfo
                    {
                        Title = swaggerOptions.Name,
                        Version = swaggerOptions.Version,
                        Description = swaggerOptions.Description
                        /*,
                        TermsOfService = "None",
                        Contact = new Contact
                        {
                            Name = "Mr. X.",
                            Email = String.Empty,
                            GameUrlZip = "https://appsfactory.de"
                        },
                        License = new License
                        {
                            Name = "Use some Lizenz",
                            GameUrlZip = "Some URL"
                        }*/
                    });

                var asm = System.Reflection.Assembly.GetEntryAssembly();

                if (!string.IsNullOrEmpty(tokenType) && keyScheme != null)
                {
                    c.AddSecurityDefinition("Bearer", keyScheme);
                }
                
                c.OperationFilter<RemoveVersionFromParameter>();
                c.DocumentFilter<ReplaceVersionWithExactValueInPath>();
                c.SchemaFilter<SwaggerExcludeFilter>();
            });
        }
    }
}

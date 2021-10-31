using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using LearningPlatformWebAPI.Configurations;
using MicroElements.Swashbuckle.NodaTime;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NodaTime;
using NodaTime.Serialization.JsonNet;
using NodaTime.Serialization.SystemTextJson;

namespace LearningPlatformWebAPI
{
    public class Startup
    {
        // USING NewtonsoftJson settings as PropertyNamingPolicy for System.Text.Json
        private const bool UseNewtonsoftJsonAsNamingPolicy = true;

        // JsonProvider
        private static readonly JsonProvider _useJsonProvider = JsonProvider.SystemTextJson;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppContext>();
            ConfigureJsonOptions(services);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "LearningPlatformWebAPI", Version = "v1"});

                if (_useJsonProvider == JsonProvider.NewtonsoftJson)
                    c.ConfigureForNodaTime(configureSerializerSettings: ConfigureNewtonsoftJsonSerializerSettings);

                if (_useJsonProvider == JsonProvider.SystemTextJson)
                {
                    var jsonSerializerOptions = new JsonSerializerOptions();
                    ConfigureSystemTextJsonSerializerSettings(jsonSerializerOptions);
                    c.ConfigureForNodaTimeWithSystemTextJson(jsonSerializerOptions);
                }
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LearningPlatformWebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private static void ConfigureJsonOptions(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.IgnoreNullValues = true;
                options.JsonSerializerOptions.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);
            });
        }

        private void ConfigureNewtonsoftJsonSerializerSettings(JsonSerializerSettings serializerSettings)
        {
            // Use DefaultContractResolver or CamelCasePropertyNamesContractResolver;
            // serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            serializerSettings.ContractResolver = new DefaultContractResolver
            {
                //NamingStrategy = new DefaultNamingStrategy()
                //NamingStrategy = new CamelCaseNamingStrategy()
                //NamingStrategy = new SnakeCaseNamingStrategy()
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            // Configures JsonSerializer to properly serialize NodaTime types.
            serializerSettings.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);
            serializerSettings.DateParseHandling = DateParseHandling.None;
        }

        private void ConfigureSystemTextJsonSerializerSettings(JsonSerializerOptions serializerOptions)
        {
            if (UseNewtonsoftJsonAsNamingPolicy)
            {
                // USING NewtonsoftJson settings as PropertyNamingPolicy for System.Text.Json
                var jsonSerializerSettings = new JsonSerializerSettings();
                ConfigureNewtonsoftJsonSerializerSettings(jsonSerializerSettings);
                serializerOptions.PropertyNamingPolicy = new NewtonsoftJsonNamingPolicy(jsonSerializerSettings);
            }

            // Configures JsonSerializer to properly serialize NodaTime types.
            serializerOptions.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);

            serializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
        }

        private enum JsonProvider
        {
            NewtonsoftJson,
            SystemTextJson
        }
    }
}
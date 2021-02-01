using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SIGO.Common.Data;
using SIGO.Consultorias.Data;
using SIGO.Domain.Common;
using SIGO.Domain.Consultorias;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace SIGO.Consultorias
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRepository<Empresa>, EmpresaRepository>();
            services.AddTransient<IRepository<Contrato>, ContratoRepository>();

            #region ApiVersion
            // Api Versioning
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service  
                // note: the specified format code will format the version as "'v'major[.minor][-status]"  
                options.GroupNameFormat = "'v'VVV";

                // note: this option is only necessary when versioning by url segment. the SubstitutionFormat  
                // can also be used to control the format of the API version in route templates  
                options.SubstituteApiVersionInUrl = true;
            });
            #endregion

            #region Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(sha256.ComputeHash(Encoding.UTF8.GetBytes(Configuration["Jwt:Secret"])))
                    };
                }
            });
            #endregion

            services.AddControllers().AddXmlSerializerFormatters();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("JwtToken", new OpenApiSecurityScheme
                {
                    Name = "Bearer",
                    Description = "Specify the JWT authorization token.",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "JwtToken"
                            }
                        },
                        new string[] { }
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseEnvironmentPathBase();

            using (var db = new SqlConnection(Configuration.GetConnectionString("ConsultoriasConnection")))
            {
                DataHelper.CreateTableIfNotExists<Empresa>(db, "Empresa", "empresas_seed.json");
                DataHelper.CreateTableIfNotExists<Contrato>(db, "Contrato", "contratos_seed.json");
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./v1/swagger.json", "v1");
            });

            app.UseRouting();

            // global cors policy
            app.UseCors(options =>
            {
                options.SetIsOriginAllowed(_ => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
            });

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

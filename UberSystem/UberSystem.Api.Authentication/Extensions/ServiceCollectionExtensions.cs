using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using UberSystem.Domain.Contracts;
using UberSystem.Domain.Contracts.Repositories;
using UberSystem.Domain.Contracts.Services;
using UberSystem.Dto;
using UberSystem.Infrastructure;
using UberSystem.Infrastructure.Repositories;
using UberSystem.Service;

namespace UberSystem.Api.Authentication.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "UberSystem.Api.Authentication",
                    Description = "An ASP.NET Core Web API for authenticating user in Uber System",
                    TermsOfService = new Uri("https://lms-hcmuni.fpt.edu.vn/course/view.php?id=2110"),
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Contact",
                        Url = new Uri("https://lms-hcmuni.fpt.edu.vn/course/view.php?id=2110")
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "License",
                        Url = new Uri("https://lms-hcmuni.fpt.edu.vn/course/view.php?id=2110")
                    }
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                opt.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
            // Jwt configuration
            var jwtSettings = configuration.GetSection("JwtSettings");
            var key = Encoding.ASCII.GetBytes(jwtSettings["SecretKey"]);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            // DI for application services and repositories
            services.AddApplicationServices();
            // DI for database connection
            var connectionString = configuration.GetConnectionString("Default") ?? 
                throw new InvalidOperationException("The connection is invalid! Please check again.");
            services.AddDatabase(connectionString);

            // Email configuration
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            
            // AutoMapper configuration
            services.AddAutoMapper(typeof(MappingProfileExtension));
            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(TokenService));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<ICabRepository, CabRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<ITripRepository, TripRepository>();

            return services;
        }

        private static IServiceCollection AddDatabase(this IServiceCollection services, string connection)
        {
            services.AddDbContext<UberSystemDbContext>(opt =>
            {
                opt.UseSqlServer(connection, sqlOptions =>
                {
                    sqlOptions.CommandTimeout(120);
                });
            });
            return services;
        }
    }
}

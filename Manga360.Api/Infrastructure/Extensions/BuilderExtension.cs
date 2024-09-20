namespace Manga360.Api.Infrastructure.Extensions
{
    public static class BuilderExtension
    {
        public static void AddCorsBuilder4(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    }
                );
            });
        }
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers().AddJsonOptions(x =>
                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();
        }
        public static void AddSwaggerGenBuilder3(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(
            c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Manga360.Api", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = @"JWT Authorization header usando o schema Bearer
                                    \r\n\r\n Informe 'Bearer'[Space].
                                    Examplo: \'Bearer 1234abcdef'\",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            }
    );
        }
        public static void AddConnectionDB(this WebApplicationBuilder builder)
        {
            var connection = builder.Configuration.GetConnectionString("DefaultConnections");
            builder.Services.AddDbContext<AppDbContext>
                    (
                    options => options.UseSqlServer(connection, b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName))
                    );
        }
        public static void AddServicesBuilder(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            builder.Services.AddScoped<IMangaRepository, MangaRepository>();

            builder.Services.AddAutoMapper(typeof(DomainToDTOProfile));
        }
        public static void AddAuthenticationBuilder1(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
            option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
                    )
                };
            }
            );
        }
        public static void AddIdentityDBBuilder2(this WebApplicationBuilder builder)
        {
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();
        }
    }
}
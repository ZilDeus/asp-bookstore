using System.Text;
using BookStoreApi.Entities;
using BookStoreApi.Presistence;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);
{
  builder.Services.AddEndpointsApiExplorer();
  builder.Services.AddControllers();
  builder.Services.AddScoped<IUserService, UserService>();
  builder.Services.AddScoped<IAuthService, AuthService>();
  builder.Services.AddScoped<IBookService, BookService>();
  builder.Services.AddScoped<IAuthorService, AuthorService>();
  builder.Services.AddScoped<IReportService, ReportService>();
  builder.Services.AddScoped<IReviewService, ReviewService>();
  builder.Services.AddRouting(options => options.LowercaseUrls = true);

  builder.Services.AddSwaggerGen(c =>
  {
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
      Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
      Name = "Authorization",
      In = ParameterLocation.Header,
      Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
      {
        new OpenApiSecurityScheme {
          Reference = new OpenApiReference {
            Type = ReferenceType.SecurityScheme,
              Id = "Bearer"
          }
        },
        new string[] {}
      }
    });
  });

  builder.Services.AddDbContext<BookStoreDbContext>(opsBuilder =>
      opsBuilder.UseSqlite(builder.Configuration.GetConnectionString("sqlite"))
      );

  builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<BookStoreDbContext>()
    .AddDefaultTokenProviders();

  builder.Services.Configure<IdentityOptions>(options =>
      {
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 5;
        options.Password.RequiredUniqueChars = 0;
      });

  builder.Services.AddAuthentication(x =>
      {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(x =>
        {
          x.SaveToken = true;
          x.RequireHttpsMetadata = false;
          x.TokenValidationParameters = new TokenValidationParameters
          {
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey
          (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
            ClockSkew = TimeSpan.Zero,
            ValidateLifetime = true,
            ValidateIssuer = true,
            ValidateAudience = false,
          };
        });
  builder.Services.AddAuthorization();
}

var app = builder.Build();
{
  // Configure the HTTP request pipeline.
  //if (app.Environment.IsDevelopment())
  //{
  app.UseSwagger();
  app.UseSwaggerUI(c =>
  {
    c.DocExpansion(DocExpansion.None);
  });
  //}
  app.MapControllers();
  app.UseHttpsRedirection();

  app.UseAuthentication();
  app.UseAuthorization();

  //SeedData.PopulateDb(app);

  app.Run();
}

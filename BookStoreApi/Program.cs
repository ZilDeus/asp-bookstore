using System.Text;
using BookStoreApi.Entities;
using BookStoreApi.Presistence;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;



//TODO: edit the ./Services/AuthService.cs to use the IdentityUser methods
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
  builder.Services.AddDbContext<BookStoreDbContext>(optionsBuilder =>
      optionsBuilder.UseSqlite(builder.Configuration.GetConnectionString("sqlite"))
      );
  builder.Services.AddRouting(options => options.LowercaseUrls = true);

  builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<BookStoreDbContext>()
    .AddSignInManager()
    .AddRoles<IdentityRole>();
  builder.Services.AddAuthentication(options =>
      {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(options =>
      {
        options.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuer = true,
          ValidateActor = true,
          ValidateIssuerSigningKey = true,
          ValidateLifetime = true,
          ValidIssuer = builder.Configuration["Jwt:Issuer"],
          ValidAudience = builder.Configuration["Jwt:Audience"],
          IssuerSigningKey = new SymmetricSecurityKey
          (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
      });
  builder.Services.AddSwaggerGen(swagger =>
      {
        swagger.SwaggerDoc("v1", new OpenApiInfo { Version = "v1" });
        swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
          Name = "Authorization",
          Type = SecuritySchemeType.ApiKey,
          Scheme = "Bearer",
          BearerFormat = "JWT",
          In = ParameterLocation.Header
        });
        //what the absolute fucking fuck is this shit???? 
        swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
          {
            new OpenApiSecurityScheme
            {
              Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              }
            },Array.Empty<String>()
          }
        });
      });
}

var app = builder.Build();
{
  // Configure the HTTP request pipeline.
  if (app.Environment.IsDevelopment())
  {
    app.UseSwagger();
    app.UseSwaggerUI();
  }
  app.UseAuthorization();
  app.UseAuthentication();
  app.MapControllers();
  app.UseHttpsRedirection();
  app.Run();
}

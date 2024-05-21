using BookStoreApi.Presistence;
using BookStoreApi.Services;
using Microsoft.EntityFrameworkCore;

var configuration = new ConfigurationBuilder().
  AddJsonFile("./appsettings.json")
  .Build();


var builder = WebApplication.CreateBuilder(args);
{
  builder.Services.AddEndpointsApiExplorer();
  builder.Services.AddSwaggerGen();
  builder.Services.AddControllers();
  builder.Services.AddScoped<IUserService, UserService>();
  builder.Services.AddScoped<IAuthService, AuthService>();
  builder.Services.AddScoped<IBookService, BookService>();
  builder.Services.AddScoped<IAuthorService, AuthorService>();
  builder.Services.AddScoped<IReportService, ReportService>();
  builder.Services.AddScoped<IReviewService, ReviewService>();
  builder.Services.AddDbContext<BookStoreDbContext>(opsBuilder =>
      opsBuilder.UseNpgsql(configuration["dbConnectionUrl"])
      opsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("postgres"))
      );
  builder.Services.AddRouting(options => options.LowercaseUrls = true);
}

var app = builder.Build();
{
  // Configure the HTTP request pipeline.
  if (app.Environment.IsDevelopment())
  {
    app.UseSwagger();
    app.UseSwaggerUI();
  }
  app.MapControllers();
  app.UseHttpsRedirection();
  app.Run();

}

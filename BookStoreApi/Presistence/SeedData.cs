using BookStoreApi.Entities;
using Bogus;
namespace BookStoreApi.Presistence
{
  public static class SeedData
  {
    public static void PopulateDb(IApplicationBuilder app)
    {
      using var serviceScope = app.ApplicationServices.CreateScope();
      AddInitialData(serviceScope.ServiceProvider.GetService<BookStoreDbContext>()!);
    }

    private static void AddInitialData(BookStoreDbContext context)
    {
      Console.WriteLine("seeding DB");
      if (context.Authors.Count() == 0)
      {
        var testAuthors = new Faker<Author>()
          .RuleFor(o => o.Name, f => f.Name.FullName())
          .RuleFor(o => o.City, f => f.Address.City())
          .RuleFor(o => o.Country, f => f.Address.Country())
          .RuleFor(o => o.BirthYear, f => f.Random.Int())
          .Ignore("Id")
          .Ignore("Rating")
          .Ignore("Books")
          .Ignore("Reports")
          .Ignore("Reviews");
        context.Authors.AddRange(testAuthors.GenerateBetween(10, 20).ToList());
        context.SaveChanges();
      }
    }
  }
}

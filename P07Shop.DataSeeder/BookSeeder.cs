using P06Shop.Shared.Services.ProductService;
using P06Shop.Shared.Shop;
using P06Shop.Shared;
using P07Shop.DataSeeder;
using Bogus;

namespace P07Shop.DataSeeder
{
    public class BookSeeder
    {
        public static List<Book> GenerateBookData()
        {
            int productId = 1;
            Random r = new Random();
            var bookFaker = new Faker<Book>()
                .RuleFor(x => x.Title, x => x.Commerce.ProductName())
                .RuleFor(x => x.Description, x => x.Commerce.ProductDescription())
                .RuleFor(x => x.Pages, x => r.Next(0, 512))
                .RuleFor(x => x.Id, x => productId++);

            return bookFaker.Generate(10).ToList();
        }

        public static Book GenerateOneBookData()
        {
            Random r = new Random();
            var bookFaker = new Faker<Book>()
                .RuleFor(x => x.Title, x => x.Commerce.ProductName())
                .RuleFor(x => x.Description, x => x.Commerce.ProductDescription())
                .RuleFor(x => x.Pages, x => r.Next(0, 512))
                .RuleFor(x => x.Id, x => 0);

            return bookFaker.Generate(1)[0];
        }
    }
}
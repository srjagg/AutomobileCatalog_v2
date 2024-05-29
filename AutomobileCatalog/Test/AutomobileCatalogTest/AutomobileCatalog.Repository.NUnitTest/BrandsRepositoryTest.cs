using AutomobileCatalog.Persistense;
using AutomobileCatalog.Repositories.RepositoryImplement;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace AutomobileCatalog.Repository.NUnitTest
{
    [TestFixture]
    public class BrandsRepositoryTest
    {
        private AutomobileCatalogDbContext _context;
        private BrandsRepository _brandsRepository

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AutomobileCatalogDbContext>()
                .UseInMemoryDatabase(databaseName: "FoodShopTestDatabase")
                .Options;

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddInMemoryCollection()
                .Build();

            _context = new AutomobileCatalogDbContext(configuration, options);

            _foodRepository = new FoodRepository(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        [Order(1)]
        public async Task AddCarAsync_ShouldAddNewCar()
        {
            // Arrange
            var food = new Brands
            {
                Name = "TEST",
            };

            // Act
            var result = await _brandsRepository.AddBrandAsync(food);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(0));
                Assert.That(_context.Brands.Count(), Is.EqualTo(1));
            });
        }
    }
}

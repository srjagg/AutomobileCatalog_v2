using AutomobileCatalog.Models.Models;
using AutomobileCatalog.Persistense;
using AutomobileCatalog.Repositories.RepositoryImplement;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AutomobileCatalog.Repository.NUnitTest
{
    [TestFixture]
    public class BrandsRepositoryTest
    {
        private AutomobileCatalogDbContext _context;
        private BrandsRepository _brandsRepository;

        [SetUp]
        public void Setup()
        {
            var inMemorySettings = new Dictionary<string, string> {
                {"ConnectionStrings:DBCnxSqlServer", "FakeConnectionString"}
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            var options = new DbContextOptionsBuilder<AutomobileCatalogDbContext>()
                .UseInMemoryDatabase(databaseName: "AutomobileCatalogTestDatabase")
                .Options;

            _context = new AutomobileCatalogDbContext(configuration, options);
            _brandsRepository = new BrandsRepository(_context);
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
                Nombre = "TEST",
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

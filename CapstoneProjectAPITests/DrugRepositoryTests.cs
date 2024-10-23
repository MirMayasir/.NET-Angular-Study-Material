using CapstoneProjectAPI.Models;
using CapstoneProjectAPI.Repositery;
using Moq;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProjectAPI.Tests
{
    [TestFixture]
    public class DrugRepositoryTests
    {
        private DrugRepository _drugRepository;
        private Mock<CapstoneProjectContext> _mockContext;
        private Mock<DbSet<Drug>> _mockDbSet;

        [SetUp]
        public void SetUp()
        {
            _mockContext = new Mock<CapstoneProjectContext>();
            _mockDbSet = new Mock<DbSet<Drug>>();

            // Set up mock context behavior for Drugs DbSet
            _mockContext.Setup(c => c.Drugs).Returns(_mockDbSet.Object);

            // Instantiate the repository with the mock context
            _drugRepository = new DrugRepository(_mockContext.Object);
        }

        [Test]
        public async Task GetAllDrugsAsync_ReturnsAllDrugs()
        {
            // Arrange
            var drugs = new List<Drug>
            {
                new Drug { DrugId = 1, Name = "Drug1" },
                new Drug { DrugId = 2, Name = "Drug2" }
            }.AsQueryable();

            // Mock the behavior of the DbSet to return the drugs
            _mockDbSet.As<IQueryable<Drug>>().Setup(m => m.Provider).Returns(drugs.Provider);
            _mockDbSet.As<IQueryable<Drug>>().Setup(m => m.Expression).Returns(drugs.Expression);
            _mockDbSet.As<IQueryable<Drug>>().Setup(m => m.ElementType).Returns(drugs.ElementType);
            _mockDbSet.As<IQueryable<Drug>>().Setup(m => m.GetEnumerator()).Returns(drugs.GetEnumerator());

            // Act
            var result = await _drugRepository.GetAllDrugsAsync();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First().Name, Is.EqualTo("Drug1"));
        }

        [Test]
        public async Task GetDrugByIdAsync_ExistingId_ReturnsDrug()
        {
            // Arrange
            var drug = new Drug { DrugId = 1, Name = "Drug1" };
            _mockDbSet.Setup(m => m.FindAsync(1)).ReturnsAsync(drug);

            // Act
            var result = await _drugRepository.GetDrugByIdAsync(1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.DrugId, Is.EqualTo(1));
            Assert.That(result.Name, Is.EqualTo("Drug1"));
        }

        [Test]
        public async Task GetDrugByIdAsync_NonExistingId_ReturnsNull()
        {
            // Arrange
            _mockDbSet.Setup(m => m.FindAsync(999)).ReturnsAsync((Drug)null);

            // Act
            var result = await _drugRepository.GetDrugByIdAsync(999);

            // Assert
            Assert.That(result, Is.Null);
        }
    }
}

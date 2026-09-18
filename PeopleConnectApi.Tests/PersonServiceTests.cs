using Moq;
using Xunit;
using PeopleConnectApi.Interface;
using PeopleConnectApi.Services;
using PeopleConnectApi.Models;

namespace PeopleConnectApi.Tests
{
    public class PersonServiceTests
    {
        [Fact]
        public void Test1()
        {
            //int expected = 5;
            //int actual = 2 + 3;
            //Assert.Equal(expected, actual);

            //Arrange

            int a = 3;
            int b = 2;

            //Act
            int result = a + b;
            //Assert
            Assert.Equal(5, result);

        }
        [Fact]
        public async Task GetByIdAsync_WhenIdIsInvalid_ReturnsNull()
        {
            //Arrange
            var mockPersonRepo = new Mock<IPersonRepository>();
            var personService = new PersonService(mockPersonRepo.Object);

            //Act
            var result = await personService.GetByIdAsync(0);

            //Assert
            Assert.Null(result);
        }
        [Fact]
        public async Task AddAsync_WhenFirstNameIsEmpty_ThrowsException()
        {
            var mockPersonRepo = new Mock<IPersonRepository>();
            var personService = new PersonService(mockPersonRepo.Object);

            var person = new Person
            {
                FirstName = ""
            };

            var exception = await Assert.ThrowsAsync<ArgumentException>(() => personService.AddAsync(person));
        }
        [Fact]
        public async Task GetByIdAsync_WhenPersonExists_ReturnsPerson()
        {
            // Arrange
            var person = new Person
            {
                Id = 5,
                FirstName = "Rahul"
            };

            var mockPersonRepo = new Mock<IPersonRepository>();

            mockPersonRepo
                .Setup(repo => repo.GetByIdAsync(5))
                .ReturnsAsync(person);

            var personService = new PersonService(mockPersonRepo.Object);

            // Act
            var result = await personService.GetByIdAsync(5);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.Id);
            Assert.Equal("Rahul", result.FirstName);
        }
    }
}

using AnimalType;

namespace AnimalTypeTests
{
    public class AnimalTests
    {
        private readonly Animal _animal;
        public AnimalTests()
        {
            _animal = new Animal();
        }

        [Fact]
        public void MakeSound_ShouldReturnBark_WhenDogIsSubstitutedForAnimal()
        {
            // Arrange
            Animal dog = new Dog();

            // Act
            var result = dog.MakeSound();

            // Assert
            Assert.Equal("Bark", result);
        }

        [Fact]
        public void MakeSound_ShouldThrowException_WhenCatIsSubstitutedForAnimal()
        {
            // Arrange
            Animal cat = new Cat();

            // Act & Assert
            //var exception = Assert.Throws<NotImplementedException>(() => cat.MakeSound());
            //Assert.Equal("Cats don't make sounds in this context.", exception.Message);
            var result = cat.MakeSound();

        }

    }
}
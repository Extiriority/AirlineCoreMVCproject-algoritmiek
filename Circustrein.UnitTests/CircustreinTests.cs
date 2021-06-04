using Microsoft.VisualStudio.TestTools.UnitTesting;
using S2Circustrein;

namespace Circustrein.UnitTests
{
    [TestClass]
    public class CircustreinTests
    {
        //algemene test
        [TestMethod]
        public void AddToCarriage_WhenCarriageIsEmpty_ReturnsTrue()
        {
            Animal animal = new Animal("test", AnimalSize.big, AnimalDiet.carnivore);
            Carriage carriage = new Carriage();

            var result = carriage.animalsInCarriageCheck(animal);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddToCarriage_WhenCarriageIsFull_ReturnsFalse()
        {
            Animal animal = new Animal("giraffe", AnimalSize.big, AnimalDiet.herbivore);
            Carriage carriage = new Carriage();

            carriage.animalCarriage.Add(new Animal
            {
                name = "test",
                size = AnimalSize.big,
                type = AnimalDiet.herbivore
            });
            carriage.animalCarriage.Add(new Animal
            {
                name = "test",
                size = AnimalSize.big,
                type = AnimalDiet.herbivore
            });

            var result = carriage.animalsInCarriageCheck(animal);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddToCarriage_WhenCarriageContainsCarnivore_ReturnsFalse()
        {
            Animal animal = new Animal("giraffe", AnimalSize.big, AnimalDiet.herbivore);
            Carriage carriage = new Carriage();

            carriage.animalCarriage.Add(new Animal
            {
                name = "test",
                size = AnimalSize.big,
                type = AnimalDiet.carnivore
            });

            var result = carriage.animalsInCarriageCheck(animal);

            Assert.IsFalse(result);
        }
    }
}
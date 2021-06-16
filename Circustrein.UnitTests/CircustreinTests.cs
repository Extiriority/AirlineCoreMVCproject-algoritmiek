using System.IO.Compression;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using S2Circustrein;

namespace Circustrein.UnitTests
{
    [TestClass]
    public class CircustreinTests
    {
        //algemene test
        private readonly Animal bear = new("Bear", AnimalSize.big, AnimalDiet.carnivore);
        private readonly Animal tiger = new("Tiger", AnimalSize.medium, AnimalDiet.carnivore);
        private readonly Animal giraffe = new("Giraffe", AnimalSize.big, AnimalDiet.herbivore);
        private readonly Animal elephant = new("Elephant", AnimalSize.big, AnimalDiet.herbivore);
        private readonly Animal ostrich = new("Ostrich", AnimalSize.medium, AnimalDiet.herbivore);

        [TestMethod]
        public void AddToCarriage_WhenCarriageIsEmpty_ReturnsTrue()
        {
            Carriage carriage = new();

            var result = carriage.IsEligible(bear);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddToCarriage_WhenCarriageIsFull_ReturnsFalse()
        {          
            Carriage carriage = new();
            
            carriage.animalCarriage.Add(elephant);
            carriage.animalCarriage.Add(ostrich);
            var result = carriage.IsEligible(giraffe);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddBigHerbivoreToCarriage_WhenCarriageContainsBigCarnivore_ReturnsFalse()
        {
            Carriage carriage = new();

            carriage.animalCarriage.Add(bear);
            var result = carriage.IsEligible(giraffe);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddMediumHerbivoreToCarriage_WhenCarriageContainsMediumCarnivore_ReturnsFalse()
        {
            Carriage carriage = new();

            carriage.animalCarriage.Add(tiger);
            var result = carriage.IsEligible(ostrich);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddMediumHerbivoreToCarriage_WhenCarriageContainsBigCarnivore_ReturnsTrue()
        {
            Carriage carriage = new();

            carriage.animalCarriage.Add(giraffe);
            var result = carriage.IsEligible(bear);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddBigHerbivoreToCarriage_WhenCarriageContainsMediumCarnivore_ReturnsTrue()
        {
            Carriage carriage = new();
            
            carriage.animalCarriage.Add(tiger);
            var result = carriage.IsEligible(giraffe);

            Assert.IsTrue(result);
        }
    }
}

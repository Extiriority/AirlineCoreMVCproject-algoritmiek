using System.Collections.Generic;
using System.IO.Compression;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using S2Circustrein;

namespace Circustrein.UnitTests
{
    [TestClass]
    public class CircustreinOverallTests
    {
        public List<Animal> testAnimals = new()
        {
            new Animal("Giraffe", AnimalSize.big, AnimalDiet.herbivore),
            new Animal("Parrot", AnimalSize.small, AnimalDiet.herbivore),
            new Animal("Parrot", AnimalSize.small, AnimalDiet.herbivore),
            new Animal("Bear", AnimalSize.big, AnimalDiet.carnivore),
            new Animal("Bear", AnimalSize.big, AnimalDiet.carnivore),
            new Animal("tiger", AnimalSize.medium, AnimalDiet.carnivore),
            new Animal("tiger", AnimalSize.medium, AnimalDiet.carnivore),
            new Animal("leopard", AnimalSize.medium, AnimalDiet.carnivore),
            new Animal("Alpaca", AnimalSize.medium, AnimalDiet.herbivore),
            new Animal("Dog", AnimalSize.small, AnimalDiet.carnivore),
            new Animal("Dog", AnimalSize.small, AnimalDiet.carnivore),
            new Animal("Elephant", AnimalSize.big, AnimalDiet.herbivore),
            new Animal("Elephant", AnimalSize.big, AnimalDiet.herbivore),
            new Animal("Bear", AnimalSize.big, AnimalDiet.carnivore),
            new Animal("ostrich", AnimalSize.medium, AnimalDiet.herbivore),           
            new Animal("horse", AnimalSize.medium, AnimalDiet.herbivore),
            new Animal("Giraffe", AnimalSize.big, AnimalDiet.herbivore),
            new Animal("Bear", AnimalSize.big, AnimalDiet.carnivore),
            new Animal("Giraffe", AnimalSize.big, AnimalDiet.herbivore),
            new Animal("Giraffe", AnimalSize.big, AnimalDiet.herbivore),
            new Animal("Monkey", AnimalSize.small, AnimalDiet.herbivore),
            new Animal("Dog", AnimalSize.small, AnimalDiet.carnivore),
            new Animal("Dog", AnimalSize.small, AnimalDiet.carnivore),
            new Animal("Elephant", AnimalSize.big, AnimalDiet.herbivore),
            new Animal("Elephant", AnimalSize.big, AnimalDiet.herbivore),
            new Animal("Elephant", AnimalSize.big, AnimalDiet.herbivore)
        };



        [TestMethod]
        public void AddAllToTrain_WhenSortedAndIsSameAsCarriage_AreEqual()
        {
            int expected = 13;
            Train testTrain = new Train();

            testTrain.placeAnimal(testAnimals);
            int actual = testTrain.carriages.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddToCarriage_IsEligible_AreEqual()
        {
            bool expected = true;
            Carriage testCarriage = new Carriage();
            testCarriage.Add(new Animal(testAnimals[1].name, testAnimals[1].size, testAnimals[1].type));
            testCarriage.Add(new Animal(testAnimals[6].name, testAnimals[6].size, testAnimals[6].type));

            bool actual = testCarriage.IsEligible(new Animal(testAnimals[9].name, testAnimals[9].size, testAnimals[9].type));

            Assert.AreEqual(expected, actual);
        }


            
        [TestMethod]
        public void CheckCarriage_WhenEligible_AreEqual()
        {
            Train testTrain = new Train();
            Carriage carriage = new Carriage();

            testTrain.placeAnimal(testAnimals);            
        }
    }
}

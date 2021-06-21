using System.Collections.Generic;
using System.IO.Compression;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using S2Circustrein;
using System.Collections.Immutable;
using System.Linq;

namespace Circustrein.UnitTests
{
    [TestClass]
    public class CircustreinOverallTests //R: overall test hoeft alleen lijst met dieren in trein te stoppen en te controleren of wagons aan allee voorwaarden voldoen.
    {
        List<Animal> testAnimals = new()
        {
            new("Dog", AnimalSize.small, AnimalDiet.carnivore),
            new("Dog", AnimalSize.small, AnimalDiet.carnivore),
            new("Elephant", AnimalSize.big, AnimalDiet.herbivore),
            new("Elephant", AnimalSize.big, AnimalDiet.herbivore),
            new("Bear", AnimalSize.big, AnimalDiet.carnivore),
            new("ostrich", AnimalSize.medium, AnimalDiet.herbivore),
            new("horse", AnimalSize.medium, AnimalDiet.herbivore),
            new("Giraffe", AnimalSize.big, AnimalDiet.herbivore),
            new("Bear", AnimalSize.big, AnimalDiet.carnivore),
            new("Giraffe", AnimalSize.big, AnimalDiet.herbivore),
            new("Giraffe", AnimalSize.big, AnimalDiet.herbivore),
            new("Monkey", AnimalSize.small, AnimalDiet.herbivore),
            new("Dog", AnimalSize.small, AnimalDiet.carnivore),
            new("Dog", AnimalSize.small, AnimalDiet.carnivore),
            new ("Giraffe", AnimalSize.big, AnimalDiet.herbivore),
            new ("Parrot", AnimalSize.small, AnimalDiet.herbivore),
            new ("Parrot", AnimalSize.small, AnimalDiet.herbivore),
            new ("Bear", AnimalSize.big, AnimalDiet.carnivore),
            new ("Bear", AnimalSize.big, AnimalDiet.carnivore),
            new ("tiger", AnimalSize.medium, AnimalDiet.carnivore),
            new ("tiger", AnimalSize.medium, AnimalDiet.carnivore),
            new ("leopard", AnimalSize.medium, AnimalDiet.carnivore),
            new ("Alpaca", AnimalSize.medium, AnimalDiet.herbivore),
            new ("Dog", AnimalSize.small, AnimalDiet.carnivore),
            new ("Dog", AnimalSize.small, AnimalDiet.carnivore),
            new ("Elephant", AnimalSize.big, AnimalDiet.herbivore),
            new ("Elephant", AnimalSize.big, AnimalDiet.herbivore),
            new ("Bear", AnimalSize.big, AnimalDiet.carnivore),
            new ("ostrich", AnimalSize.medium, AnimalDiet.herbivore),
            new ("horse", AnimalSize.medium, AnimalDiet.herbivore),
            new ("Giraffe", AnimalSize.big, AnimalDiet.herbivore),
            new ("Bear", AnimalSize.big, AnimalDiet.carnivore),
            new ("Giraffe", AnimalSize.big, AnimalDiet.herbivore),
            new ("Giraffe", AnimalSize.big, AnimalDiet.herbivore),
            new ("Monkey", AnimalSize.small, AnimalDiet.herbivore),
            new ("Dog", AnimalSize.small, AnimalDiet.carnivore),
            new ("Dog", AnimalSize.small, AnimalDiet.carnivore),
            new ("Elephant", AnimalSize.big, AnimalDiet.herbivore),
            new ("Elephant", AnimalSize.big, AnimalDiet.herbivore),
            new ("Elephant", AnimalSize.big, AnimalDiet.herbivore)
        };


        [TestMethod]
        public void AddAllTestAnimalsToTrain_CheckCriteriaPerCarriage_AreEqualAndTrueOrFalse()
        {
            //Arrange
            Train testTrain = new();
            int expectedTotalCarriages = 19;
            bool checkMaxCapacityIsTrueOrFalse;
            bool checkIfOnlyOneCarnivoreIsTrueOrFalse;
            bool checkCompatibilityCarnivoreWithHerbivoreIsTrueOrFalse;
            //Act & Assert
            testTrain.placeAnimal(testAnimals);
            int actualTotalCarriages = testTrain.carriages.Count;

            foreach (Carriage carriage in testTrain.carriages) {
                if (carriage.carriageSize <= carriage.maxCapacity) { // check if the total animal size per carriage is less than 10 carriage max capacity
                    checkMaxCapacityIsTrueOrFalse = true;
                    var carnivoresInCarriage = carriage.animalCarriage.Where(animal => animal.type == AnimalDiet.carnivore).ToList();
                    var herbivoresInCarriage = carriage.animalCarriage.Where(animal => animal.type == AnimalDiet.herbivore).ToList();

                    if (carriage.animalCarriage.Count != herbivoresInCarriage.Count) //Only herbivores in carriage, so only max capacity check
                        for (int i = 0; i < herbivoresInCarriage.Count; i++) {
                            if (carnivoresInCarriage.Count == 1) { // Only one carnivore check per carriage, because if more = death
                                checkIfOnlyOneCarnivoreIsTrueOrFalse = true;
                                if (carnivoresInCarriage.Any(c => herbivoresInCarriage[i].size > c.size)) checkCompatibilityCarnivoreWithHerbivoreIsTrueOrFalse = true; // Check if this carnivore doesn't eat other herbivores in carriage
                                else checkCompatibilityCarnivoreWithHerbivoreIsTrueOrFalse = false;
                                Assert.IsTrue(checkCompatibilityCarnivoreWithHerbivoreIsTrueOrFalse);
                            }                               
                            else checkIfOnlyOneCarnivoreIsTrueOrFalse = false;
                            Assert.IsTrue(checkIfOnlyOneCarnivoreIsTrueOrFalse);
                        }                           
                }
                else checkMaxCapacityIsTrueOrFalse = false;
                Assert.IsTrue(checkMaxCapacityIsTrueOrFalse);
            }           
            Assert.AreEqual(expectedTotalCarriages, actualTotalCarriages);
        }
    }
}
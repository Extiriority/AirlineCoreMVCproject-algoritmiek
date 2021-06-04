using System;
using System.Collections.Generic;

namespace S2Circustrein
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> circusAnimals = new()
            {
                new Animal("Elephant", AnimalSize.big, AnimalDiet.herbivore),
                new Animal("Elephant", AnimalSize.big, AnimalDiet.herbivore ),
                new Animal("Elephant", AnimalSize.big, AnimalDiet.herbivore ),
                new Animal("Bear", AnimalSize.big, AnimalDiet.carnivore ),
                new Animal("Bear", AnimalSize.big, AnimalDiet.carnivore ),
                new Animal("Giraffe", AnimalSize.big, AnimalDiet.herbivore ),
                new Animal("Giraffe", AnimalSize.big, AnimalDiet.herbivore ),
                new Animal("tiger", AnimalSize.medium, AnimalDiet.carnivore ),
                new Animal("tiger", AnimalSize.medium, AnimalDiet.carnivore ),
                new Animal("leopard", AnimalSize.medium, AnimalDiet.carnivore ),
                new Animal("lion", AnimalSize.medium, AnimalDiet.carnivore ),
                new Animal("lion", AnimalSize.medium, AnimalDiet.carnivore ),
                new Animal("camel", AnimalSize.medium, AnimalDiet.herbivore ),
                new Animal("camel", AnimalSize.medium, AnimalDiet.herbivore ),
                new Animal("lama", AnimalSize.medium, AnimalDiet.herbivore ),
                new Animal("Alpaca", AnimalSize.medium, AnimalDiet.herbivore ),
                new Animal("ostrich", AnimalSize.medium, AnimalDiet.herbivore ),
                new Animal("ostrich", AnimalSize.medium, AnimalDiet.herbivore ),
                new Animal("kangaroo", AnimalSize.medium, AnimalDiet.herbivore ),
                new Animal("horse", AnimalSize.medium, AnimalDiet.herbivore ),
                new Animal("horse", AnimalSize.medium, AnimalDiet.herbivore ),
                new Animal("horse", AnimalSize.medium, AnimalDiet.herbivore ),
                new Animal("Parrot", AnimalSize.small, AnimalDiet.herbivore ),
                new Animal("Parrot", AnimalSize.small, AnimalDiet.herbivore ),
                new Animal("Parrot", AnimalSize.small, AnimalDiet.herbivore ),
                new Animal("Dove", AnimalSize.small, AnimalDiet.herbivore ),
                new Animal("Dove", AnimalSize.small, AnimalDiet.herbivore ),
                new Animal("Dove", AnimalSize.small, AnimalDiet.herbivore ),
                new Animal("Dove", AnimalSize.small, AnimalDiet.herbivore ),
                new Animal("Dove", AnimalSize.small, AnimalDiet.herbivore ),
                new Animal("Monkey", AnimalSize.small, AnimalDiet.herbivore ),
                new Animal("Monkey", AnimalSize.small, AnimalDiet.herbivore ),
                new Animal("Monkey", AnimalSize.small, AnimalDiet.herbivore ),
                new Animal("Monkey", AnimalSize.small, AnimalDiet.herbivore ),
                new Animal("Dog", AnimalSize.small, AnimalDiet.carnivore),
                new Animal("Dog", AnimalSize.small, AnimalDiet.carnivore)
            };
            Train train = new Train();
            train.placeAnimal(circusAnimals);
            Console.WriteLine("36 total circus animals to transport");
            Console.Write(train);
            Console.ReadKey();
        }
    }
}
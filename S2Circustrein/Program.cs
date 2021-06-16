using System;
using System.Collections.Generic;

namespace S2Circustrein {
    class Program {     
        static void Main(string[] args) {
        string title = @"
          ██████╗██╗██████╗  ██████╗██╗   ██╗███████╗    ████████╗██████╗ ███████╗██╗███╗   ██╗
         ██╔════╝██║██╔══██╗██╔════╝██║   ██║██╔════╝    ╚══██╔══╝██╔══██╗██╔════╝██║████╗  ██║
         ██║     ██║██████╔╝██║     ██║   ██║███████╗       ██║   ██████╔╝█████╗  ██║██╔██╗ ██║
         ██║     ██║██╔══██╗██║     ██║   ██║╚════██║       ██║   ██╔══██╗██╔══╝  ██║██║╚██╗██║
         ╚██████╗██║██║  ██║╚██████╗╚██████╔╝███████║       ██║   ██║  ██║███████╗██║██║ ╚████║
          ╚═════╝╚═╝╚═╝  ╚═╝ ╚═════╝ ╚═════╝ ╚══════╝       ╚═╝   ╚═╝  ╚═╝╚══════╝╚═╝╚═╝  ╚═══╝                                                                                     
                        ";
            List<Animal> circusAnimals = new() {
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
                new Animal("Dog", AnimalSize.small, AnimalDiet.carnivore ),
                new Animal("Dog", AnimalSize.small, AnimalDiet.carnivore )
            };
            Train train = new();
            train.placeAnimal(circusAnimals);

            Console.WriteLine(title);
            Console.WriteLine($"{circusAnimals.Count} total circus animals to be transported");

            foreach (Carriage carriage in train.carriages) { 
                Console.Write($" Carriage {train.carriages.IndexOf(carriage)+1}: Total animal = {carriage.animalCarriage.Count}, Total space taken:{carriage.carriageSize}/{carriage.maxCapacity} = " );
                for (int i = 0; i < carriage.animalCarriage.Count; i++)               
                    Console.Write(carriage.animalCarriage[i].name + ", ");                
                Console.WriteLine();
            }
        }
    }
}
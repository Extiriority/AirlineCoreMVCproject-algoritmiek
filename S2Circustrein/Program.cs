using System;
using System.Collections.Generic;

namespace S2Circustrein {
    public class Program {     
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
                new ("Elephant", AnimalSize.big, AnimalDiet.herbivore),
                new ("Elephant", AnimalSize.big, AnimalDiet.herbivore ),
                new ("Elephant", AnimalSize.big, AnimalDiet.herbivore ),
                new ("Bear", AnimalSize.big, AnimalDiet.carnivore ),
                new ("Bear", AnimalSize.big, AnimalDiet.carnivore ),
                new ("Giraffe", AnimalSize.big, AnimalDiet.herbivore ),
                new ("Giraffe", AnimalSize.big, AnimalDiet.herbivore ),
                new ("tiger", AnimalSize.medium, AnimalDiet.carnivore ),
                new ("tiger", AnimalSize.medium, AnimalDiet.carnivore ),
                new ("leopard", AnimalSize.medium, AnimalDiet.carnivore ),
                new ("lion", AnimalSize.medium, AnimalDiet.carnivore ),
                new ("lion", AnimalSize.medium, AnimalDiet.carnivore ),
                new ("camel", AnimalSize.medium, AnimalDiet.herbivore ),
                new ("camel", AnimalSize.medium, AnimalDiet.herbivore ),
                new ("lama", AnimalSize.medium, AnimalDiet.herbivore ),
                new ("Alpaca", AnimalSize.medium, AnimalDiet.herbivore ),
                new ("ostrich", AnimalSize.medium, AnimalDiet.herbivore ),
                new ("ostrich", AnimalSize.medium, AnimalDiet.herbivore ),
                new ("kangaroo", AnimalSize.medium, AnimalDiet.herbivore ),
                new ("horse", AnimalSize.medium, AnimalDiet.herbivore ),
                new ("horse", AnimalSize.medium, AnimalDiet.herbivore ),
                new ("horse", AnimalSize.medium, AnimalDiet.herbivore ),
                new ("Parrot", AnimalSize.small, AnimalDiet.herbivore ),
                new ("Parrot", AnimalSize.small, AnimalDiet.herbivore ),
                new ("Parrot", AnimalSize.small, AnimalDiet.herbivore ),
                new ("Dove", AnimalSize.small, AnimalDiet.herbivore ),
                new ("Dove", AnimalSize.small, AnimalDiet.herbivore ),
                new ("Dove", AnimalSize.small, AnimalDiet.herbivore ),
                new ("Dove", AnimalSize.small, AnimalDiet.herbivore ),
                new ("Dove", AnimalSize.small, AnimalDiet.herbivore ),
                new ("Monkey", AnimalSize.small, AnimalDiet.herbivore ),
                new ("Monkey", AnimalSize.small, AnimalDiet.herbivore ),
                new ("Monkey", AnimalSize.small, AnimalDiet.herbivore ),
                new ("Monkey", AnimalSize.small, AnimalDiet.herbivore ),
                new ("Dog", AnimalSize.small, AnimalDiet.carnivore ),
                new ("Dog", AnimalSize.small, AnimalDiet.carnivore )
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
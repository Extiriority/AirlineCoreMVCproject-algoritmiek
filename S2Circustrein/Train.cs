using System.Collections.Generic;
using System.Linq;

namespace S2Circustrein
{
    public class Train {
        public List<Carriage> carriages = new List<Carriage>();
        public Train() {
            this.carriages = new List<Carriage>();
        }
        public void placeAnimal(IEnumerable<Animal> circusAnimals) {
            IEnumerable<Animal> carnivores = circusAnimals.Where(animal => animal.type == AnimalDiet.carnivore);
            List<Animal> herbivores = circusAnimals.Where(animal => animal.type == AnimalDiet.herbivore).ToList();

            foreach (Animal carnivore in carnivores) {
                Carriage carriage = new();
                carriage.animalCarriage.Add(carnivore);
                if (carnivore.size != AnimalSize.big)             
                    for (int i = herbivores.Count - 1; i >= 0; i--)                    
                        if (carriage.IsEligible(herbivores[i])) {
                            carriage.animalCarriage.Add(herbivores[i]);
                            herbivores.RemoveAt(i);
                        }                    
              this.carriages.Add(carriage);
            }
            foreach (Animal herbivore in herbivores)            
                placeAnimal(herbivore);           
        }
        private void placeAnimal(Animal herbivore) {
            foreach (Carriage carriage in this.carriages)           
                if (carriage.IsEligible(herbivore)) {
                    carriage.animalCarriage.Add(herbivore);
                    return;
                }            
            this.carriages.Add(new Carriage(herbivore));
        }
    }
}

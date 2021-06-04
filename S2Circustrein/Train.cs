using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2Circustrein
{
    class Train
    {
        public List<Carriage> carriages { get; set; }
        string rtn = string.Empty;

        public Train()
        {
            this.carriages = new List<Carriage>();
        }
        public void placeAnimal(IEnumerable<Animal> circusAnimals)
        {
            IEnumerable<Animal> carnivores = circusAnimals
                .Where(animal => animal.type == AnimalDiet.carnivore);
            List<Animal> herbivores = circusAnimals
                .Where(animal => animal.type == AnimalDiet.herbivore)
                .ToList();

            foreach (Animal carnivore in carnivores)
            {
                Carriage carriage = new Carriage();
                carriage.animalCarriage.Add(carnivore);
                for (int i = herbivores.Count - 1; i >= 0; i--)
                {
                    if (carriage.IsEligible(herbivores[i]))
                    {
                        carriage.animalCarriage.Add(herbivores[i]);
                        herbivores.RemoveAt(i);
                    }
                }
                this.carriages.Add(carriage);
            }

            foreach (Animal herbivore in herbivores)
            {
                placeAnimal(herbivore);
            }
        }
        private void placeAnimal(Animal animal)
        {
            foreach (Carriage carriage in this.carriages)
            {
                if (carriage.IsEligible(animal))
                {
                    carriage.animalCarriage.Add(animal);
                    return;
                }
            }
            this.carriages.Add(new Carriage(animal));
        }
        public override string ToString()
        {         
            foreach (Carriage carriage in carriages) { rtn += carriage.ToString() + "\n"; } return rtn;
        }
    }
}

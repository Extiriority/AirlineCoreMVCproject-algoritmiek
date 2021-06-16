using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2Circustrein
{
    public class Carriage : List<Animal>
    {
        public List<Animal> animalCarriage = new List<Animal>();

        public int carriageSize => this.animalCarriage.Sum(animal => (int)animal.size);

        public int maxCapacity = 10;
        public int maximumCapacity => maxCapacity;

        public Carriage(){ 
            this.animalCarriage = new List<Animal>(); 
        }

        public Carriage(Animal firstAnimal) {
            this.animalCarriage = new List<Animal> {
                firstAnimal
            };
        }

        public bool IsEligible(Animal animal) {
            IEnumerable<Animal> carnivoresInCarriage = this.animalCarriage.Where(animal => animal.type == AnimalDiet.carnivore);
            if ((int)animal.size > this.maximumCapacity - this.carriageSize || carnivoresInCarriage.Any(c => animal.size <= c.size)) return false;
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2Circustrein
{
    public class Carriage
    {
        public List<Animal> animalCarriage { get; set; }
        public int carriageSize => this.animalCarriage.Sum(animal => (int)animal.size);

        private const int maxCapacity = 10;
        public int maximumCapacity => maxCapacity;

        public Carriage()
        {
            this.animalCarriage = new List<Animal>();
        }

        public Carriage(Animal firstAnimal)
        {
            this.animalCarriage = new List<Animal>
            {
                firstAnimal
            };
        }

        public bool IsEligible(Animal animal)
        {
            IEnumerable<Animal> carnivoresInCarriage = this.animalCarriage.Where(animal => animal.type == AnimalDiet.carnivore);
            if ((int)animal.size > this.maximumCapacity - this.carriageSize || carnivoresInCarriage.Any(c => animal.size <= c.size)) return false;

            return true;
        }
        public override string ToString()
        {

            switch (animalCarriage.Count)
            {
                case 1:
                    return string.Format($"{this.animalCarriage.Count} Total animal, Total space taken:{this.carriageSize}/{maxCapacity} = {this.animalCarriage[0].name}");
                case 2:
                    return string.Format($"{this.animalCarriage.Count} Total animal, Total space taken:{this.carriageSize}/{maxCapacity} = {this.animalCarriage[0].name} {this.animalCarriage[1].name}");
                case 3:                                                        
                    return string.Format($"{this.animalCarriage.Count} Total animal, Total space taken:{this.carriageSize}/{maxCapacity} = {this.animalCarriage[0].name} {this.animalCarriage[1].name} {this.animalCarriage[2].name}  ");
                case 4:                                                                                   
                    return string.Format($"{this.animalCarriage.Count} Total animal, Total space taken:{this.carriageSize}/{maxCapacity} = {this.animalCarriage[0].name} {this.animalCarriage[1].name} {this.animalCarriage[2].name} {this.animalCarriage[3].name}  ");
                case 5:                                                                                   
                    return string.Format($"{this.animalCarriage.Count} Total animal, Total space taken:{this.carriageSize}/{maxCapacity} = {this.animalCarriage[0].name} {this.animalCarriage[1].name} {this.animalCarriage[2].name} {this.animalCarriage[3].name} {this.animalCarriage[4].name}  ");
                case 6:                                                                                 
                    return string.Format($"{this.animalCarriage.Count} Total animal, Total space taken:{this.carriageSize}/{maxCapacity} = {this.animalCarriage[0].name} {this.animalCarriage[1].name} {this.animalCarriage[2].name} {this.animalCarriage[3].name} {this.animalCarriage[4].name} {this.animalCarriage[5].name}  ");
                case 7:                                                                                
                    return string.Format($"{this.animalCarriage.Count} Total animal, Total space taken:{this.carriageSize}/{maxCapacity} = {this.animalCarriage[0].name} {this.animalCarriage[1].name} {this.animalCarriage[2].name} {this.animalCarriage[3].name} {this.animalCarriage[4].name} {this.animalCarriage[5].name} {this.animalCarriage[6].name} ");
                case 8:                                                                              
                    return string.Format($"{this.animalCarriage.Count} Total animal, Total space taken:{this.carriageSize}/{maxCapacity} = {this.animalCarriage[0].name} {this.animalCarriage[1].name} {this.animalCarriage[2].name} {this.animalCarriage[3].name} {this.animalCarriage[4].name} {this.animalCarriage[5].name} {this.animalCarriage[6].name} {this.animalCarriage[7].name}  ");
                case 9:                                                                              
                    return string.Format($"{this.animalCarriage.Count} Total animal, Total space taken:{this.carriageSize}/{maxCapacity} = {this.animalCarriage[0].name} {this.animalCarriage[1].name} {this.animalCarriage[2].name} {this.animalCarriage[3].name} {this.animalCarriage[4].name} {this.animalCarriage[5].name} {this.animalCarriage[6].name} {this.animalCarriage[7].name} {this.animalCarriage[8].name}  ");
                case 10:                                                                            
                    return string.Format($"{this.animalCarriage.Count} Total animal, Total space taken:{this.carriageSize}/{maxCapacity} = {this.animalCarriage[0].name} {this.animalCarriage[1].name} {this.animalCarriage[2].name} {this.animalCarriage[3].name} {this.animalCarriage[4].name} {this.animalCarriage[5].name} {this.animalCarriage[6].name} {this.animalCarriage[7].name} {this.animalCarriage[8].name} {this.animalCarriage[9].name}  ");
                default:
                    string msg = string.Format("'{0}' is an invalid format string");
                    throw new ArgumentException(msg);
            }
        }
    }
}

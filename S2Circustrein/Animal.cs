using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2Circustrein
{
    public class Animal
    {
        public string name { get; }
        public AnimalSize size { get; }
        public AnimalDiet type { get; }

        public Animal(string name, AnimalSize size, AnimalDiet type) {
            this.name = name;
            this.size = size;
            this.type = type;
        }

        public Animal(){ }
    }
}

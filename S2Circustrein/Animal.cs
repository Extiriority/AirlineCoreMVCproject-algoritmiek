using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2Circustrein
{
    public class Animal
    {
        public string name { get; set; }
        public AnimalSize size { get; set; }
        public AnimalDiet type { get; set; }

        public Animal(string name, AnimalSize size, AnimalDiet type)
        {
            this.name = name;
            this.size = size;
            this.type = type;
        }

        public Animal()
        {

        }
    }
}

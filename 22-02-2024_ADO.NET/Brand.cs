using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22_02_2024_ADO.NET
{
    internal class Brand
    {
        public Brand()
        {
            staticId++;
            Id = staticId;
        }

        public Brand(string name, int Year):this()
        {
            this.Name = name;
            this.Year = Year;
        }

        private static int staticId = 0;
        public int Id;
        public string Name;
        public int Year;

        public override string ToString()
        {
            return $"Id - {Id}, Name - {Name}, Year - {Year}";
        }

    }
}

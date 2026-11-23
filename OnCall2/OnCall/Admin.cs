using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnCall
{
    internal class Admin
    {
        public string Name { get; set; }

        public int Satisfaction { get; set; }

        public Admin(string name)
        {
            Name = name;
            Satisfaction = 80;
        }
    }
}

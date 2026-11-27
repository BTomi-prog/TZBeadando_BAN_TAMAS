using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnCall
{
    internal class Admin
    {
        public string Name { get; }
        public int Satisfaction { get; private set; }

        public Admin(string name, int startSatisfaction = 80)
        {
            Name = name;
            Satisfaction = startSatisfaction;
        }

        public void ChangeSatisfaction(int delta)
        {
            Satisfaction = Satisfaction + delta;

            if (Satisfaction > 100)
            {
                Satisfaction = 100;
            }
            if (Satisfaction < 0)
            {
                Satisfaction = 0;
            }
        }
    }
}s
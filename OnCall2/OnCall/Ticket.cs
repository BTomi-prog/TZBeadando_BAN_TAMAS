using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnCall
{
    internal class Ticket
    {
        public string Title { get; }
        public int Priority { get; }       
        public int RemainingWork { get; private set; }
        public int Deadline { get; }      
        public int Reward { get; }
        public int Penalty { get; }

        
        public bool IsClosed
        {
            get { return RemainingWork <= 0; }
        }

        public Ticket(string title, int priority, int remainingWork, int deadline, int reward, int penalty)
        {
            Title = title;
            Priority = priority;
            RemainingWork = remainingWork;
            Deadline = deadline;
            Reward = reward;
            Penalty = penalty;
        }

        
        public void Work()
        {
            if (IsClosed)
            {
                throw new InvalidOperationException("Lezárt jegyen nem lehet dolgozni.");
            }
            RemainingWork = RemainingWork - 1;
        }

        public bool IsOverdue(int time)
        {
            return Deadline <= time;
        }

        public string PriorityName()
        {
            if (Priority == 0)
            {
                return "Alacsony";
            }
            if (Priority == 1)
            {
                return "Normál";
            }
            if (Priority == 2)
            {
                return "Magas";
            }
            return "Kritikus";
        }
    }
}
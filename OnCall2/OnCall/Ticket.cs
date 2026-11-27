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

        public bool ExpiredCounted { get; set; }


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

        public static string NameOf(int priority)
        {
            if (priority == 0)
            {
                return "Alacsony";
            }
            if (priority == 1)
            {
                return "Normál";
            }
            if (priority == 2)
            {
                return "Magas";
            }
            return "Kritikus";
        }

        public string PriorityName()
        {
            return NameOf(Priority);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnCall
{
    internal static class DeadlineRules
    {
       
        public static int CalculatePenalty(List<Ticket> tickets, int time)
        {
            int total = 0;

            foreach (Ticket ticket in tickets)
            {
                if (ticket.IsOverdue(time))
                {
                    total = total + ticket.Penalty;
                }
            }

            return total;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnCall
{
    internal class GameStats
    {
       
        public int[] Closed { get; } = new int[4];
        public int[] Expired { get; } = new int[4];

        public void RecordClosed(Ticket ticket)
        {
            Closed[ticket.Priority]++;
        }

        
        public void RecordExpired(List<Ticket> tickets, int time)
        {
            foreach (Ticket ticket in tickets)
            {
                if (ticket.IsOverdue(time) && !ticket.ExpiredCounted)
                {
                    ticket.ExpiredCounted = true;
                    Expired[ticket.Priority]++;
                }
            }
        }
    }
}
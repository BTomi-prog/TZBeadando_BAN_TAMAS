using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnCall
{
    internal static class TicketFactory
    {
        
        private static readonly int[] MinWork = { 1, 1, 2, 2 };
        private static readonly int[] MaxWork = { 1, 2, 2, 2 };
        private static readonly int[] DeadlineHours = { 16, 8, 4, 3 };
        private static readonly int[] Rewards = { 1, 2, 4, 6 };
        private static readonly int[] Penalties = { 1, 2, 4, 8 };

        private static readonly string[][] Titles =
        {
            Texts.LowTickets,
            Texts.NormalTickets,
            Texts.HighTickets,
            Texts.CriticalTickets
        };

        
        public static Ticket TrySpawn(int openedAt, Random random)
        {
            if (random.Next(100) >= 50)
            {
                return null;
            }

            int priority = PriorityFromRoll(random.Next(100));
            return Create(priority, openedAt, random);
        }

        
        public static int PriorityFromRoll(int roll)
        {
            if (roll < 40)
            {
                return 0;
            }
            if (roll < 70)
            {
                return 1;
            }
            if (roll < 90)
            {
                return 2;
            }
            return 3;
        }

        
        public static Ticket Create(int priority, int openedAt, Random random)
        {
            string[] titles = Titles[priority];
            string title = titles[random.Next(titles.Length)];

            int work = random.Next(MinWork[priority], MaxWork[priority] + 1);
            int deadline = openedAt + DeadlineHours[priority];

            return new Ticket(title, priority, work, deadline, Rewards[priority], Penalties[priority]);
        }
    }
}
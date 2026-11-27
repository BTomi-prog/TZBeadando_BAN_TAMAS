using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnCall
{
    internal class ConsoleUI
    {
        public string ReadName()
        {
            Console.WriteLine("Add meg a neved:");
            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Add meg a neved:");
                name = Console.ReadLine();
            }
            return name.Trim();
        }

        
        public int ReadNumber(int min, int max)
        {
            while (true)
            {
                Console.Write("> ");
                string input = Console.ReadLine();

                int number;
                bool ok = int.TryParse(input, out number);

                if (ok && number >= min && number <= max)
                {
                    return number;
                }

                Console.WriteLine("Érvénytelen választás. Adj meg egy számot " + min + " és " + max + " között.");
            }
        }

        public void ShowStatus(Admin admin, int time, int openTickets)
        {
            Console.WriteLine();
            Console.WriteLine(admin.Name + " | " + GameTime.DayName(time) + " " + GameTime.HourOf(time) +
                              ":00 | Elégedettség " + admin.Satisfaction + "/100 | Nyitott jegyek: " + openTickets);
        }

        
        public int ShowMenu(List<Ticket> sortedTickets, int now)
        {
            for (int i = 0; i < sortedTickets.Count; i++)
            {
                Ticket t = sortedTickets[i];
                string prio = "[" + t.PriorityName() + "]";
                Console.WriteLine((i + 1) + ") " + prio.PadRight(11) + " " + t.Title.PadRight(32) + " " +
                                  t.RemainingWork + " óra munka, határidő " + GameTime.FormatDeadline(t.Deadline, now));
            }
            Console.WriteLine((sortedTickets.Count + 1) + ") Kávészünet");
            Console.WriteLine((sortedTickets.Count + 2) + ") Kilépés");

            return ReadNumber(1, sortedTickets.Count + 2);
        }

        public void ShowMessage(string text)
        {
            Console.WriteLine(text);
        }

        public void ShowSummary(Admin admin, GameStats stats)
        {
            Console.WriteLine();
            Console.WriteLine("--- Összegzés ---");
            Console.WriteLine("Elégedettség: " + admin.Satisfaction + "/100");

            for (int priority = 0; priority < stats.Closed.Length; priority++)
            {
                Console.WriteLine(Ticket.NameOf(priority).PadRight(10) +
                                  " lezárt: " + stats.Closed[priority] +
                                  ", lejárt: " + stats.Expired[priority]);
            }
        }

        public void ShowNewTicket(Ticket ticket)
        {
            Console.WriteLine();
            Console.WriteLine("Új jegy: [" + ticket.PriorityName() + "] " + ticket.Title);
        }
    }
}

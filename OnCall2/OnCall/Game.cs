using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace OnCall
{
    internal class Game
    {
        public void Run()
        {
            Console.OutputEncoding = Encoding.UTF8; 
            Console.WriteLine(Texts.Title);
            Console.WriteLine();
            Console.WriteLine(Texts.Intro);
            Console.WriteLine();

            ConsoleUI ui = new ConsoleUI();
            Admin admin = new Admin(ui.ReadName());
            Random random = new Random();
            List<Ticket> tickets = new List<Ticket>();
            int time = 0;  
            bool running = true;

            while (running && time < GameTime.WeekEnd)
            {
                
                Ticket newTicket = TicketFactory.TrySpawn(time, random);
                if (newTicket != null)
                {
                    tickets.Add(newTicket);
                    ui.ShowNewTicket(newTicket);
                }

                
                List<Ticket> sorted = tickets
                    .OrderBy(t => t.Deadline)
                    .ThenByDescending(t => t.Priority)
                    .ToList();

                ui.ShowStatus(admin, time, tickets.Count);
                int choice = ui.ShowMenu(sorted, time);

                if (choice == sorted.Count + 2)
                {
                    running = false;  
                }
                else
                {
                    time++;   
                }
            }

            Console.WriteLine("Nyomj meg egy billentyűt a kilépéshez.");
            Console.ReadKey(true);
        }
    }
}

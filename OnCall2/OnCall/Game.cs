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
            int time = 0;  

           
            List<Ticket> tickets = new List<Ticket>
            {
                new Ticket("Leállt a webshop", 3, 2, 5),
                new Ticket("Nem megy a második monitor", 1, 2, 8),
                new Ticket("Recseg a hangszóró", 0, 1, 41),
            };

            
            List<Ticket> sorted = tickets
                .OrderBy(t => t.Deadline)
                .ThenByDescending(t => t.Priority)
                .ToList();

            ui.ShowStatus(admin, time, tickets.Count);
            int choice = ui.ShowMenu(sorted, time);
            ui.ShowMessage("Választás: " + choice);

            Console.WriteLine("Nyomj meg egy billentyűt a kilépéshez.");
            Console.ReadKey(true);
        }
    }
}

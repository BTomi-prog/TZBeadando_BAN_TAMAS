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
            int time = 0;   // hétfő 8:00
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

                bool hourPassed = false;

                if (choice == sorted.Count + 2)
                {
                    
                    ui.ShowMessage(Texts.QuitText);
                    running = false;
                }
                else if (choice == sorted.Count + 1)
                {
                   
                    ui.ShowMessage(Texts.CoffeeTexts[random.Next(Texts.CoffeeTexts.Length)]);
                    hourPassed = true;
                }
                else
                {
                    
                    Ticket ticket = sorted[choice - 1];
                    ticket.Work();

                    if (ticket.IsClosed)
                    {
                        admin.ChangeSatisfaction(ticket.Reward);
                        tickets.Remove(ticket);
                        ui.ShowMessage(Texts.DoneTexts[random.Next(Texts.DoneTexts.Length)] +
                                       " +" + ticket.Reward + " elégedettség");
                    }
                    else
                    {
                        ui.ShowMessage(Texts.WorkTexts[random.Next(Texts.WorkTexts.Length)] +
                                       " Még " + ticket.RemainingWork + " óra munka van vele.");
                    }
                    hourPassed = true;
                }

                if (hourPassed)
                {
                    
                    int penalty = DeadlineRules.CalculatePenalty(tickets, time);
                    if (penalty > 0)
                    {
                        admin.ChangeSatisfaction(-penalty);
                        ui.ShowMessage(Texts.LateTexts[random.Next(Texts.LateTexts.Length)] +
                                       " -" + penalty + " elégedettség");
                    }
                    time++;
                }
            }

            Console.WriteLine("Nyomj meg egy billentyűt a kilépéshez.");
            Console.ReadKey(true);
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OnCall.Tests
{
    [TestClass]
    public class GameTests
    {
        // TODO: ide kerülnek a tesztek (K3, K4, K5 és az A4).
        // Futtatás: Test menü → Run All Tests (Test Explorer).


        [TestMethod]
        public void Create_HighTicketOpenedAt10_DeadlineIsSameDay14()
        {
            int openedAt = 2;   

            Ticket ticket = TicketFactory.Create(2, openedAt, new Random(1));

            Assert.AreEqual(6, ticket.Deadline);               
            Assert.AreEqual(14, GameTime.HourOf(ticket.Deadline));
            Assert.AreEqual(0, GameTime.DayOf(ticket.Deadline));
        }

        [TestMethod]
        public void Work_OneHourTicket_ClosesAfterOneHour()
        {
            
            Ticket ticket = new Ticket("Új egér kell", 0, 1, 16, 1, 1);

            ticket.Work();

            Assert.IsTrue(ticket.IsClosed);
        }

        [TestMethod]
        public void CalculatePenalty_OverdueNormalTicket_ReducesSatisfactionByTwo()
        {
            Admin admin = new Admin("Teszt");   
            List<Ticket> tickets = new List<Ticket>
    {
        
        new Ticket("Nem nyomtat a nyomtató", 1, 2, 6, 2, 2)
    };

            int penalty = DeadlineRules.CalculatePenalty(tickets, 6);   
            admin.ChangeSatisfaction(-penalty);

            Assert.AreEqual(78, admin.Satisfaction);
        }

        [TestMethod]
        public void CalculatePenalty_NotYetOverdueTicket_NoPenalty()
        {
            List<Ticket> tickets = new List<Ticket>
    {
        new Ticket("Nem nyomtat a nyomtató", 1, 2, 6, 2, 2)
    };

            int penalty = DeadlineRules.CalculatePenalty(tickets, 5);  

            Assert.AreEqual(0, penalty);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketPlanner
{
    class Program
    {
        static void Main(string[] args)
        {
            string textFloorPlan = @"6 6
3 5 5 3
4 6 6 4
2 8 8 2
6 6";
           

            string textPatrons = @"Smith 2
Jones 5
Davis 6
Wilson 100
Johnson 3
Williams 4
Brown 8
Miller 12";

            CinemaFloorPlan floorPlan = new CinemaFloorPlan(textFloorPlan);
            PreSaleCollection preSoldTickets = new PreSaleCollection(textPatrons);

            floorPlan.AllocatePreSaleSeating(preSoldTickets);

            preSoldTickets.Print(floorPlan);


            // Optional output (Comment out the block below when not debugging)
            // ----------------------------------------------

            Console.WriteLine();
            Console.WriteLine();
            floorPlan.Print(false);
            Console.WriteLine();
            Console.WriteLine();
            floorPlan.Print(true);

            // ----------------------------------------------

            Console.Read();

        }
    }
}

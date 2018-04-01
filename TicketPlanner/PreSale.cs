using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketPlanner
{
    class PreSale
    {
        public string PatronName { get; set; }
        public int PartySize { get; set; }
        public List<CinemaSeat> Seats { get; set; }

        public PreSale(string patronName, int partySize)
        {
            Seats = new List<CinemaSeat>();
            PatronName = patronName;
            PartySize = partySize;
        }

        public void Print(CinemaFloorPlan floorPlan)
        {
            String seats = string.Empty;
            if (Seats.Count > 0)
            {
                seats = "Row " + Seats[0].Section.Row.RowNumber.ToString() + " Section " + Seats[0].Section.SectionNumber.ToString();
                Console.WriteLine(string.Format("{0} {2}", PatronName, PartySize, seats));
            }
            else
            {
                if(PartySize > floorPlan.MaxPartySize)
                {
                    Console.WriteLine(string.Format("{0} {2}", PatronName, PartySize, "Sorry, we can't handle your party."));
                } else
                {
                    Console.WriteLine(string.Format("{0} {2}", PatronName, PartySize, "Call to split party."));
                }
                
            }
                

            
        }
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TicketPlanner
{
    /// <summary>
    /// A section which is part of a CinemaRow. There are multiple sections in a row. 
    /// </summary>
    class CinemaSection
    {
        
        public Dictionary<int, CinemaSeat> Seats { get; set; } = new Dictionary<int, CinemaSeat>();
        public CinemaRow Row { get; }
        public int SectionNumber { get; }

        public CinemaSection(CinemaRow row, int sectionNumber, int seatCount)
        {
            SectionNumber = sectionNumber;
            Row = row;
            for (int i = 0; i < seatCount; i++)
            {
                Seats.Add(i + 1, new CinemaSeat(i+1, this));
            }
        }

        public void Print(bool printPatronNames)
        {
            for (int s = 0; s < Seats.Count; s++)
            {
                if (printPatronNames)
                    Seats[s + 1].PrintPatronNames();
                else
                    Seats[s + 1].PrintOpenSeats();
            }
            Console.Write(" ");
            
        }

        public bool reserveSeats(PreSale preSale)
        {
            bool reservationMade = false;
            int reservationCount = 0;

            if (availableSeats() >= preSale.PartySize)
            {
                foreach (var seat in Seats)
                {
                    if(!seat.Value.Reserved)
                    {
                        if(reservationCount < preSale.PartySize)
                        {
                            seat.Value.Reserve(preSale);
                            reservationCount++;
                            reservationMade = true;
                        }
                    }
                    
                }
            }

            return reservationMade;
        }

        public int availableSeats()
        {
            return Seats.Where(item => item.Value.Reserved == false).Count();
        }

    }
}

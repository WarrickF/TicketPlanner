using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TicketPlanner
{


    class CinemaRow
    {
        //private Dictionary<int, CinemaSection> _sections = new Dictionary<int, CinemaSection>();
        public Dictionary<int, CinemaSection> Sections { get; set; } = new Dictionary<int, CinemaSection>();

        public int RowNumber { get; }

        public CinemaRow(int rowNumber)
        {
            RowNumber = rowNumber;
        }

        public void addSection(CinemaSection section)
        {
            var sectionCount = Sections.Count();
            Sections.Add(section.SectionNumber, section);
        }

        public void Print(bool printPatronNames)
        {
            Console.WriteLine("");
            var sectionCount = Sections.Count;
            for (int i = 0; i < sectionCount; i++)
            {
                Sections[i+1].Print(printPatronNames);
            }
            
        }


        public int SeatCount
        {
            get
            {
                int seatCount = 0;

                foreach (var section in Sections)
                {
                    seatCount = seatCount + section.Value.Seats.Count;
                }

                return seatCount;

            }
        }

        public bool reserveSeats(PreSale preSale)
        {
            bool reservationMade = false;

            foreach (var section in Sections)
            {
                if(section.Value.reserveSeats(preSale))
                {
                    reservationMade = true;
                    break;
                }
            }

            return reservationMade;
        }

    }
}

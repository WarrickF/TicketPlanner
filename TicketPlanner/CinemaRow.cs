using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TicketPlanner
{


    /// <summary>
    /// A class representing a row in the cinema. There are multiple rows which are normally part of a CinemaFloorPlan instance. 
    /// </summary>
    class CinemaRow
    {
        //private Dictionary<int, CinemaSection> _sections = new Dictionary<int, CinemaSection>();
        public Dictionary<int, CinemaSection> Sections { get; set; } = new Dictionary<int, CinemaSection>();
        public int RowNumber { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CinemaRow"/> class.
        /// </summary>
        /// <param name="rowNumber">The row number of this instance</param>
        public CinemaRow(int rowNumber)
        {
            RowNumber = rowNumber;
        }

        /// <summary>
        /// Adds a section to the row. Each row can have mutiple sections. 
        /// </summary>
        /// <param name="section">The section.</param>
        public void addSection(CinemaSection section)
        {
            var sectionCount = Sections.Count();
            Sections.Add(section.SectionNumber, section);
        }

        /// <summary>
        /// Prints the row. This is normally used as part of the Print() process when printing a floor plan. 
        /// </summary>
        /// <param name="printPatronNames">if set to <c>true</c> [print patron names].</param>
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

        /// <summary>
        /// Reserves the seats. Takes as input a preSold ticket and tries to calculate the best reservation. 
        /// </summary>
        /// <param name="preSale">preSale</param>
        /// <returns></returns>
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketPlanner
{
    /// <summary>
    /// This class represents the floor plan of a cinema. 
    /// </summary>
    class CinemaFloorPlan
    {

        Dictionary<int, CinemaRow> Rows { get; set; } = new Dictionary<int, CinemaRow>();


        /// <summary>
        /// Initializes a new instance of the <see cref="CinemaFloorPlan"/> class.
        /// </summary>
        /// <param name="floorPlan">The floor plan in text fomat. See the readme file or an example of this format in the Main() function. </param>
        public CinemaFloorPlan(string floorPlan)
        {
           
            using (StringReader reader = new StringReader(floorPlan))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var row = ParseRow(line);
                    Rows.Add(row.RowNumber, row);
                }
            }

        }

        /// <summary>
        /// Parses the row of seating supplied in text format. 
        /// </summary>
        /// <param name="row">The row in text format. Example "6 5 4" - Where each number represents a section and the number of seats in that section.</param>
        /// <returns></returns>
        CinemaRow ParseRow(string row)
        {
            CinemaRow cinemaRow = new CinemaRow(Rows.Count + 1);

            string[] sections = row.Split(' ');
            foreach (var seatCountStr in sections)
            {
                int seatCount = Int32.Parse(seatCountStr);
                CinemaSection section = new CinemaSection(cinemaRow, cinemaRow.Sections.Count+1, seatCount);
                cinemaRow.addSection(section);

            }

            return cinemaRow;
        }

        /// <summary>
        /// Prints the floor plan, showing which seats are reserved and which are open.
        /// </summary>
        /// <param name="printPatronNames">if set to <c>true</c> [print patron names].</param>
        public void Print(bool printPatronNames)
        {
            var rowCount = Rows.Count;
            for (int i = 1; i < rowCount+1; i++)
            {
                Rows[i].Print(printPatronNames);
            }

        }

        /// <summary>
        /// Gets the maximum size of the party.
        /// </summary>
        /// <value>
        /// The maximum size of the party.
        /// </value>
        public int MaxPartySize
        {
            get {
                int max = 0;
                foreach (var row in Rows)
                {
                    if (row.Value.SeatCount > max)
                    {
                        max = row.Value.SeatCount;
                    }
                }
                return max;
            }
        }

        /// <summary>
        /// Allocates the pre sale seating.
        /// </summary>
        /// <param name="preSaleCollection">The pre sale collection. This is an object which holds the details of all preSold tickets.</param>
        public void AllocatePreSaleSeating(PreSaleCollection preSaleCollection)
        {
            // Start with the largest parties so that we have maximum contiguous blocks of seating
            var sortedPreSales = preSaleCollection.PreSales.OrderByDescending(o => o.Value.PartySize);
            foreach (var preSale in sortedPreSales)
            {
                foreach (var row in Rows)
                {
                    bool reserved = row.Value.reserveSeats(preSale.Value);
                    if (reserved)
                    {
                        break;
                    }
                }
            }
                
                
        }

    }
}

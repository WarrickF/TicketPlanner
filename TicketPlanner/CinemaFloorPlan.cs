using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketPlanner
{
    class CinemaFloorPlan
    {

        Dictionary<int, CinemaRow> _rows = new Dictionary<int, CinemaRow>();

        public CinemaFloorPlan(string floorPlan)
        {

            // The last line is the 1st row, so reverse the string so that we start with row 1. 
            //String reverseFloorPlan = string.Join("\r\n", floorPlan.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Reverse());

            using (StringReader reader = new StringReader(floorPlan))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var row = ParseRow(line);
                    _rows.Add(row.RowNumber, row);
                }
            }

        }

        CinemaRow ParseRow(string row)
        {
            CinemaRow cinemaRow = new CinemaRow(_rows.Count + 1);

            string[] sections = row.Split(' ');
            foreach (var seatCountStr in sections)
            {
                int seatCount = Int32.Parse(seatCountStr);
                CinemaSection section = new CinemaSection(cinemaRow, cinemaRow.Sections.Count+1, seatCount);
                cinemaRow.addSection(section);

            }

            return cinemaRow;
        }

        public void Print(bool printPatronNames)
        {
            var rowCount = _rows.Count;
            /*
            for (int i = rowCount; i > 0; i--)
            {
                _rows[i].Print();
                
            }
            */
            for (int i = 1; i < rowCount+1; i++)
            {
                _rows[i].Print(printPatronNames);
            }

        }

        public int MaxPartySize
        {
            get {
                int max = 0;
                foreach (var row in _rows)
                {
                    if (row.Value.SeatCount > max)
                    {
                        max = row.Value.SeatCount;
                    }
                }
                return max;
            }
        }

        public void AllocatePreSaleSeating(PreSaleCollection preSaleCollection)
        {
            // Start with the largest parties so that we have maximum contiguous blocks of seating
            var sortedPreSales = preSaleCollection.PreSales.OrderByDescending(o => o.Value.PartySize);
            foreach (var preSale in sortedPreSales)
            {
                foreach (var row in _rows)
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

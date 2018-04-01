using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketPlanner
{
    class CinemaSeat
    {

        public CinemaSection Section { get; }
        public int SeatNumber { get; }

        public CinemaSeat(int seatNumber, CinemaSection section)
        {
            SeatNumber = seatNumber;
            Section = section;
        }


        public void PrintOpenSeats()
        {
            if(Reserved)
                Console.Write("1");
            else
                Console.Write("0");
        }

        public void PrintPatronNames()
        {
            if (Reserved)
                Console.Write(string.Format("[{0}]", _patronName));
            else
                //Console.Write("0");
                Console.Write(string.Format("[{0}]", "Empty"));
        }


        private bool _reserved { get; set; }
        private string _patronName { get; set; }

        public bool Reserved
        {
            get { return _reserved; }
        }

        public void Reserve(PreSale preSale)
        {
            _reserved = true;
            _patronName = preSale.PatronName;
            preSale.Seats.Add(this);
        }

        public void unReserve()
        {
            _reserved = false;
            _patronName = string.Empty;
        }
    }


}

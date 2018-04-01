using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketPlanner
{
    class PreSaleCollection
    {
        Dictionary<int, PreSale> _preSales = new Dictionary<int, PreSale>();

        public Dictionary<int, PreSale> PreSales
        {
            get { return _preSales; }
            set { _preSales = value; }
        }

        public PreSaleCollection(String patronOrders)
        {
            
            using (StringReader reader = new StringReader(patronOrders))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var patron = ParsePreSale(line);
                    _preSales.Add(_preSales.Count + 1, patron);
                }
            }
        }

        public PreSale ParsePreSale(String patronOrders)
        {
            var parts = patronOrders.Split(' ');
            String patronName = parts[0];
            int partySize = int.Parse(parts[1]);
            PreSale sale = new PreSale(patronName, partySize);
            return sale;
        }

        public void Print(CinemaFloorPlan floorPlan)
        {
            foreach (var patron in _preSales)
            {
                patron.Value.Print(floorPlan);
            }
        }

    }
}

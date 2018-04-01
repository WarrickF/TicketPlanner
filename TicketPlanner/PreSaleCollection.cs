using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketPlanner
{
    /// <summary>
    /// This class represents a collection of preSold tickets. 
    /// </summary>
    class PreSaleCollection
    {
        Dictionary<int, PreSale> _preSales = new Dictionary<int, PreSale>();

        public Dictionary<int, PreSale> PreSales
        {
            get { return _preSales; }
            set { _preSales = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PreSaleCollection"/> class. Concerts the string format into instance that can easily be worked with. 
        /// </summary>
        /// <param name="patronOrders">The patron orders. See the Main() method and Readme for examples of the expected format of this text input.</param>
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

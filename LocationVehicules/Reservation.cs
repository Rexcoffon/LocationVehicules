using System;
using System.Collections.Generic;
using System.Text;

namespace LocationVehicules
{
    public class Reservation
    {
        public Customer Customer { get; set; }
        public Vehicule Vehicule { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

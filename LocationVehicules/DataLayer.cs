using System;
using System.Collections.Generic;
using System.Text;

namespace LocationVehicules
{
    internal class DataLayer : IDataLayer
    {
        public List<Customer> Customers { get; private set; }

        public List<Vehicule> Vehicules { get; private set; }

        public DataLayer()
        {
            Customers = new List<Customer>();
            Vehicules = new List<Vehicule>();
        }
    }
}


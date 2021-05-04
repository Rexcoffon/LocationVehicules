using System;
using System.Collections.Generic;
using System.Text;

namespace LocationVehicules
{
    internal class DataLayer : IDataLayer
    {
        public List<Client> Clients { get; private set; }

        public List<Vehicule> Vehicules { get; private set; }

        public DataLayer()
        {
            Clients = new List<Client>();
            Vehicules = new List<Vehicule>();
        }
    }
}


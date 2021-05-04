using System;
using System.Collections.Generic;
using System.Text;

namespace LocationVehicules.Specs.Features.Fake
{
    public class FakeDataLayer : IDataLayer
    {
        public List<Client> Clients { get; set; }

        public List<Vehicule> Vehicules  { get; set; }

        public FakeDataLayer()
        {
            this.Clients = new List<Client>();

            this.Vehicules = new List<Vehicule>();
        }
    }
}

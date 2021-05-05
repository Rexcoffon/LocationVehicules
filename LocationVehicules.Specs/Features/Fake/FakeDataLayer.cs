using System;
using System.Collections.Generic;
using System.Text;

namespace LocationVehicules.Specs.Features.Fake
{
    public class FakeDataLayer : IDataLayer
    {
        public List<Customer> Customers { get; set; }

        public List<Vehicule> Vehicules  { get; set; }

        public FakeDataLayer()
        {
            this.Customers = new List<Customer>();

            this.Vehicules = new List<Vehicule>();
        }
    }
}

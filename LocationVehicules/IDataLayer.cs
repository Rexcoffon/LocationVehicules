using System;
using System.Collections.Generic;
using System.Text;

namespace LocationVehicules
{
    public interface IDataLayer
    {
        List<Customer> Customers { get; }

        List<Vehicule> Vehicules { get; }
    }
}

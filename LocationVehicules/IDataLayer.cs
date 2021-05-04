using System;
using System.Collections.Generic;
using System.Text;

namespace LocationVehicules
{
    public interface IDataLayer
    {
        List<Client> Clients { get; }

        List<Vehicule> Vehicules { get; }
    }
}

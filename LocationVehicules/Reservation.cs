using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocationVehicules
{
    public class Reservation
    {
        private IDataLayer _dataLayer;

        public bool UserConnected { get; set; }

        public Reservation()
        {
            /// si on utilisais la librairie au travers d'une application
            _dataLayer = new DataLayer();
        }

        public Reservation(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }

        public string ConnectUser(string username, string password)
        {
            string result = string.Empty;
            Client client = this._dataLayer.Clients.SingleOrDefault(_ => _.Username == username);
            if (client == null)
            {
                this.UserConnected = false;
                result= "Username not recognized";
            }
            else
            {
                if (client.Password == password)
                {
                    this.UserConnected = true;
                }
                else
                {
                    this.UserConnected = false;
                    result = "Incorrect password";
                }
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocationVehicules
{
    public class Rental
    {
        private IDataLayer _dataLayer;

        public bool UserConnected { get; set; }

        private Customer Client { get; set; }
        private DateTime StartDate { get; set; }
        private DateTime EndDate { get; set; }
        private string LicenceNum { get; set; }

        public Rental()
        {
            /// si on utilisais la librairie au travers d'une application
            _dataLayer = new DataLayer();
        }

        public Rental(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }

        public string ConnectUser(string username, string password)
        {
            string result = string.Empty;
            Client = _dataLayer.Customers.SingleOrDefault(_ => _.Username == username);
            if (Client == null)
            {
                UserConnected = false;
                result = "Username not recognized";
            }
            else
            {
                if (Client.Password == password)
                {
                    UserConnected = true;
                }
                else
                {
                    UserConnected = false;
                    result = "Incorrect password";
                }
            }

            return result;
        }

        public void SetDates(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public List<Vehicule> GetAvailableVehicules()
        {
            return _dataLayer.Vehicules;
        }

        public void SetSelectedVehicule(string licenceNum)
        {
            LicenceNum = licenceNum;
        }

        public Reservation CreateReservation()
        {
            return new Reservation
            {
                Customer = Client,
                Vehicule = _dataLayer.Vehicules.FirstOrDefault(_ => _.Immatriculation == LicenceNum),
                StartDate = StartDate,
                EndDate = EndDate,
            };
        }
    }
}

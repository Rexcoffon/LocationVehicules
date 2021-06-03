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
        private int EstimateKm { get; set; }

        public Reservation Reservation { get; set; }

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
            List<Vehicule> result = new List<Vehicule>();
            int age = GetAge(Client.DateNaissance);
            if (age < 21)
            {
                result = _dataLayer.Vehicules.FindAll(v => v.Cv <= 8);
            }
            else if (age <= 25 && age >= 21)
            {
                result = _dataLayer.Vehicules.FindAll(v => v.Cv <= 13);
            }
            else
            {
                result = _dataLayer.Vehicules;
            }

            return result;
        }

        public void SetSelectedVehicule(string licenceNum)
        {
            LicenceNum = licenceNum;
        }

        public string CreateReservation()
        {
            string error = string.Empty;
            if (GetAge(Client.DateNaissance) >= 18)
            {
                if (!string.IsNullOrEmpty(Client.NumPermis))
                {
                    var vehicule = _dataLayer.Vehicules.FirstOrDefault(_ => _.Immatriculation == LicenceNum);
                    double price = vehicule.PrixRes + vehicule.PrixKilo * EstimateKm;

                    Reservation = new Reservation
                    {
                        Customer = Client,
                        Vehicule = vehicule,
                        StartDate = StartDate,
                        EndDate = EndDate,
                        EstimateKm = EstimateKm,
                        Price = price,
                    };
                }
                else
                {
                    error = "Driver must have a license";
                }
            }
            else
            {
                error = "Driver is too young";
            }

            return error;
        }

        private int GetAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;

            var a = (today.Year * 100 + today.Month) * 100 + today.Day;
            var b = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

            return (a - b) / 10000;
        }

        public void SetEstimateKm(int estimateKm)
        {
            EstimateKm = estimateKm;
        }
    }
}

using FluentAssertions;
using LocationVehicules.Specs.Features.Fake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace LocationVehicules.Specs.Steps
{
    [Binding]
    public sealed class ReservationStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        private string _username;
        private string _password;
        private string _lastErrorMessage;
        private Rental _target;
        private FakeDataLayer _fakeDataLayer;
        private List<Vehicule> _vehicules;
        Reservation _reservation;

        public ReservationStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _fakeDataLayer = new FakeDataLayer();
            _target = new Rental(_fakeDataLayer);
            _vehicules = new List<Vehicule>();
        }

        [Given(@"following cars")]
        public void GivenFollowingCars(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                _fakeDataLayer.Vehicules.Add(new Vehicule()
                {
                    Immatriculation = row[0],
                    Marque = row[1],
                    Modele = row[2],
                    Couleur = row[3],
                    PrixRes = double.Parse(row[4]),
                    PrixKilo = double.Parse(row[5]),
                    Cv = int.Parse(row[6])
                });
            }
        }

        [Given(@"following existing clients")]
        public void GivenFollowingExistingClients(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                _fakeDataLayer.Customers.Add(new Customer()
                {
                    Nom = row[0],
                    Prenom = row[1],
                    DateNaissance = DateTime.Parse(row[2]),
                    NumPermis = row[3],
                    Username = row[4],
                    Password = row[5],
                });
            }
        }

        [Given(@"my username is ""(.*)""")]
        public void GivenMyUsernameIs(string username)
        {
            _username = username;
        }

        [Given(@"my password is ""(.*)""")]
        public void GivenMyPasswordIs(string password)
        {
            _password = password;
        }

        [When(@"I try to connect to my account")]
        public void WhenITryToConnectToMyAccount()
        {
            _lastErrorMessage = _target.ConnectUser(_username, _password);
        }

        [Then(@"the connection is refused")]
        public void ThenTheConnectionIsRefused()
        {
            _target.UserConnected.Should().BeFalse();
        }

        [Then(@"the error message is ""(.*)""")]
        public void ThenTheErrorMessageIs(string errorMessage)
        {
            _lastErrorMessage.Should().Be(errorMessage);
        }

        [Then(@"the connection is established")]
        public void ThenTheConnectionIsEstablished()
        {
            _target.UserConnected.Should().BeTrue();
        }

        [Given(@"Select these reservation dates")]
        public void GivenSelectTheseReservationDates(Table table)
        {
            var dates = table.Rows[0];
            _target.SetDates(DateTime.Parse(dates[0]), DateTime.Parse(dates[1]));
        }

        [When(@"Validate reservation dates")]
        public void WhenValidateReservationDates()
        {
            _vehicules = _target.GetAvailableVehicules();
        }

        [Then(@"The vehicle list should be")]
        public void ThenTheVehicleListShouldBe(Table table)
        {
            List<Vehicule> vehiculesData = new List<Vehicule>();

            foreach (TableRow row in table.Rows)
            {
                vehiculesData.Add(new Vehicule()
                {
                    Immatriculation = row[0],
                    Marque = row[1],
                    Modele = row[2],
                    Couleur = row[3],
                    PrixRes = double.Parse(row[4]),
                    PrixKilo = double.Parse(row[5]),
                    Cv = int.Parse(row[6])
                });
            }

            _vehicules.Should().BeEquivalentTo(vehiculesData);
        }

        [Given(@"the selected vehicle is ""(.*)""")]
        public void GivenTheSelectedVehicleIs(string licenceNum)
        {
            _target.SetSelectedVehicule(licenceNum);
        }

        [When(@"Create a reservation")]
        public void WhenCreateAReservation()
        {
            _lastErrorMessage = _target.CreateReservation();
            _reservation = _target.Reservation;
        }

        [Then(@"The reservation should be")]
        public void ThenTheReservationShouldBe(Table table)
        {
            var data = table.Rows[0];

            var reservationData = new Reservation
            {
                Customer = _fakeDataLayer.Customers.FirstOrDefault(_ => _.Nom == data[0] && _.Prenom == data[1]),
                Vehicule = _fakeDataLayer.Vehicules.FirstOrDefault(_ => _.Immatriculation == data[2]),
                StartDate = DateTime.Parse(data[3]),
                EndDate = DateTime.Parse(data[4]),
                EstimateKm = int.Parse(data[5]),
                Price = double.Parse(data[6]),
            };

            _reservation.Should().BeEquivalentTo(reservationData);
        }

        [Given(@"estimate the number of km to (.*)")]
        public void GivenEstimateTheNumberOfKmTo(int estimateKm)
        {
            _target.SetEstimateKm(estimateKm);
        }

    }
}

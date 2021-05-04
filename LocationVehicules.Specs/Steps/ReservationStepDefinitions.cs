using FluentAssertions;
using LocationVehicules.Specs.Features.Fake;
using System;
using System.Collections.Generic;
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
        private Reservation _target;
        private FakeDataLayer _fakeDataLayer;

        public ReservationStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _fakeDataLayer = new FakeDataLayer();
            _target = new Reservation(_fakeDataLayer);
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
                _fakeDataLayer.Clients.Add(new Client() { 
                Nom = row[0],
                Prenom = row[1],
                DateNaissance = DateTime.Parse(row[2]),
                NumPermis = int.Parse(row[3]),
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

    }
}

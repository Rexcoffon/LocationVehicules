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

        public ReservationStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}

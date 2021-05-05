﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.7.0.0
//      SpecFlow Generator Version:3.7.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace LocationVehicules.Specs.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.7.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("Reservation", Description=@"	En tant que client de l'API  je souhaite éffectuer une réservation de véhicule
	Pour cela :
	- association entre un client et un véhicule
	- le client doit au moins avoir 18 ans et posséder le permis de conduire
	- un conducteur de moins de 21 ans ne peut pas louer un véhicule 
	  possédant 8 chevaux fiscaux ou plus
	- un conducteur entre 21 et 25 ans ne peut louer que des véhicules de moins de 13 chevaux fiscaux
	- prix location = prix de base + prix au km * nb de km", SourceFile="Features\\Reservation.feature", SourceLine=0)]
    public partial class ReservationFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "Reservation.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Reservation", @"	En tant que client de l'API  je souhaite éffectuer une réservation de véhicule
	Pour cela :
	- association entre un client et un véhicule
	- le client doit au moins avoir 18 ans et posséder le permis de conduire
	- un conducteur de moins de 21 ans ne peut pas louer un véhicule 
	  possédant 8 chevaux fiscaux ou plus
	- un conducteur entre 21 et 25 ans ne peut louer que des véhicules de moins de 13 chevaux fiscaux
	- prix location = prix de base + prix au km * nb de km", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [TechTalk.SpecRun.FeatureCleanup()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        [TechTalk.SpecRun.ScenarioCleanup()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 11
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Immat",
                        "Marque",
                        "Modele",
                        "Couleur",
                        "PrixRes",
                        "PrixKilo",
                        "Cv"});
            table1.AddRow(new string[] {
                        "nf552cd",
                        "Citroen",
                        "C3",
                        "Blanche",
                        "150",
                        "0,40",
                        "5"});
            table1.AddRow(new string[] {
                        "as202lk",
                        "Renault",
                        "Clio",
                        "Rouge",
                        "155",
                        "0.39",
                        "5"});
            table1.AddRow(new string[] {
                        "ef168ml",
                        "Audi",
                        "A3",
                        "Grisse",
                        "220",
                        "0.45",
                        "7"});
#line 12
 testRunner.Given("following cars", ((string)(null)), table1, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Nom",
                        "Prenom",
                        "DateNaissance",
                        "NumPermis",
                        "Username",
                        "Password"});
            table2.AddRow(new string[] {
                        "Dusse",
                        "Jean-Claude",
                        "11/08/1952",
                        "010101",
                        "jcd",
                        "toto"});
            table2.AddRow(new string[] {
                        "Cruchot",
                        "Ludovic",
                        "04/01/1971",
                        "546545",
                        "lcruchot",
                        "tata"});
#line 17
 testRunner.And("following existing clients", ((string)(null)), table2, "And ");
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Client connection - Username not recognized", SourceLine=22)]
        public virtual void ClientConnection_UsernameNotRecognized()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Client connection - Username not recognized", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 23
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 11
this.FeatureBackground();
#line hidden
#line 24
 testRunner.Given("my username is \"bob\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 25
 testRunner.And("my password is \"titi\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 26
 testRunner.When("I try to connect to my account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 27
 testRunner.Then("the connection is refused", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 28
 testRunner.And("the error message is \"Username not recognized\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Client connection - Username recognized", SourceLine=29)]
        public virtual void ClientConnection_UsernameRecognized()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Client connection - Username recognized", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 30
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 11
this.FeatureBackground();
#line hidden
#line 31
 testRunner.Given("my username is \"jcd\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 32
 testRunner.And("my password is \"toto\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 33
 testRunner.When("I try to connect to my account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 34
 testRunner.Then("the connection is established", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Client connection - Username recognized but incorrect password", SourceLine=35)]
        public virtual void ClientConnection_UsernameRecognizedButIncorrectPassword()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Client connection - Username recognized but incorrect password", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 36
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 11
this.FeatureBackground();
#line hidden
#line 37
 testRunner.Given("my username is \"jcd\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 38
 testRunner.And("my password is \"toto111\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 39
 testRunner.When("I try to connect to my account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 40
 testRunner.Then("the connection is refused", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 41
 testRunner.And("the error message is \"Incorrect password\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Client reservation - simple revervation without check and billing", SourceLine=43)]
        public virtual void ClientReservation_SimpleRevervationWithoutCheckAndBilling()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Client reservation - simple revervation without check and billing", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 44
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 11
this.FeatureBackground();
#line hidden
#line 45
 testRunner.Given("my username is \"jcd\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 46
 testRunner.And("my password is \"toto\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 47
 testRunner.When("I try to connect to my account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 48
 testRunner.Then("the connection is established", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "StartDate",
                            "EndDate"});
                table3.AddRow(new string[] {
                            "05/05/2021",
                            "10/05/2021"});
#line 49
 testRunner.Given("Select these reservation dates", ((string)(null)), table3, "Given ");
#line hidden
#line 52
 testRunner.When("Validate reservation dates", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "Immat",
                            "Marque",
                            "Modele",
                            "Couleur",
                            "PrixRes",
                            "PrixKilo",
                            "Cv"});
                table4.AddRow(new string[] {
                            "nf552cd",
                            "Citroen",
                            "C3",
                            "Blanche",
                            "150",
                            "0,40",
                            "5"});
                table4.AddRow(new string[] {
                            "as202lk",
                            "Renault",
                            "Clio",
                            "Rouge",
                            "155",
                            "0.39",
                            "5"});
                table4.AddRow(new string[] {
                            "ef168ml",
                            "Audi",
                            "A3",
                            "Grisse",
                            "220",
                            "0.45",
                            "7"});
#line 53
 testRunner.Then("The vehicle list should be", ((string)(null)), table4, "Then ");
#line hidden
#line 58
 testRunner.Given("the selected vehicle is \"as202lk\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 59
 testRunner.When("Create a reservation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                            "Nom",
                            "Prenom",
                            "Immat",
                            "StartDate",
                            "EndDate"});
                table5.AddRow(new string[] {
                            "Dusse",
                            "Jean-Claude",
                            "as202lk",
                            "05/05/2021",
                            "10/05/2021"});
#line 60
 testRunner.Then("The reservation should be", ((string)(null)), table5, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

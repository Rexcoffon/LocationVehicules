Feature: Reservation
	En tant que client de l'API  je souhaite éffectuer une réservation de véhicule
	Pour cela :
	- association entre un client et un véhicule
	- le client doit au moins avoir 18 ans et posséder le permis de conduire
	- un conducteur de moins de 21 ans ne peut pas louer un véhicule 
	  possédant 8 chevaux fiscaux ou plus
	- un conducteur entre 21 et 25 ans ne peut louer que des véhicules de moins de 13 chevaux fiscaux
	- prix location = prix de base + prix au km * nb de km

Background:
	Given following cars
		| Immat   | Marque   | Modele | Couleur | PrixRes | PrixKilo | Cv | Kilometrage |
		| nf552cd | Citroen  | C3     | Blanche | 150     | 0,40     | 5  | 55632       |
		| as202lk | Renault  | Clio   | Rouge   | 155     | 0.39     | 5  | 98145       |
		| ef168ml | Audi     | A3     | Grisse  | 220     | 0.45     | 9  | 18963       |
		| ac523cq | Maclaren | P1     | Jaune   | 450     | 0.60     | 95 | 8740        |
	And following existing clients
		| Nom     | Prenom      | DateNaissance | NumPermis | Username  | Password |
		| Dusse   | Jean-Claude | 08/11/1952    | 010101    | jcd       | toto     |
		| Cruchot | Ludovic     | 01/04/1971    | 546545    | lcruchot  | tata     |
		| Paul    | Mineur      | 12/30/2014    | 755252    | pmineur   | titi     |
		| Dexter  | Mandrark    | 12/11/1990    |           | dmandrark | tutu     |
		| Bob     | Lejeun      | 05/24/2001    | 564546    | blejeun   | azerty   |
		| Pierre  | Calcaire    | 01/24/1998    | 586324    | pcalcaire | azerty   |

# Connection
Scenario: Client connection - Username not recognized
	Given my username is "bob"
	And my password is "titi"
	When I try to connect to my account
	Then the connection is refused
	And the error message is "Username not recognized"

Scenario: Client connection - Username recognized
	Given my username is "jcd"
	And my password is "toto"
	When I try to connect to my account
	Then the connection is established

Scenario: Client connection - Username recognized but incorrect password
	Given my username is "jcd"
	And my password is "toto111"
	When I try to connect to my account
	Then the connection is refused
	And the error message is "Incorrect password"

# Reservation
Scenario: Client reservation - Simple revervation without check and billing
	Given my username is "jcd"
	And my password is "toto"
	When I try to connect to my account
	Then the connection is established
	Given Select these reservation dates
		| StartDate  | EndDate    |
		| 05/05/2021 | 10/05/2021 |
	When Validate reservation dates
	Then The vehicle list should be
		| Immat   | Marque   | Modele | Couleur | PrixRes | PrixKilo | Cv | Kilometrage |
		| nf552cd | Citroen  | C3     | Blanche | 150     | 0,40     | 5  | 55632       |
		| as202lk | Renault  | Clio   | Rouge   | 155     | 0.39     | 5  | 98145       |
		| ef168ml | Audi     | A3     | Grisse  | 220     | 0.45     | 9  | 18963       |
		| ac523cq | Maclaren | P1     | Jaune   | 450     | 0.60     | 95 | 8740        |
	Given the selected vehicle is "as202lk"
	When Create a reservation
	Then The reservation should be
		| Nom   | Prenom      | Immat   | StartDate  | EndDate    | EstimateKm | Price |
		| Dusse | Jean-Claude | as202lk | 05/05/2021 | 10/05/2021 | 0          | 155   |

Scenario: Client reservation - Simple revervation without check
	Given my username is "jcd"
	And my password is "toto"
	When I try to connect to my account
	Then the connection is established
	Given Select these reservation dates
		| StartDate  | EndDate    |
		| 05/05/2021 | 10/05/2021 |
	When Validate reservation dates
	Then The vehicle list should be
		| Immat   | Marque   | Modele | Couleur | PrixRes | PrixKilo | Cv | Kilometrage |
		| nf552cd | Citroen  | C3     | Blanche | 150     | 0,40     | 5  | 55632       |
		| as202lk | Renault  | Clio   | Rouge   | 155     | 0.39     | 5  | 98145       |
		| ef168ml | Audi     | A3     | Grisse  | 220     | 0.45     | 9  | 18963       |
		| ac523cq | Maclaren | P1     | Jaune   | 450     | 0.60     | 95 | 8740        |
	Given the selected vehicle is "as202lk"
	And estimate the number of km to 150
	When Create a reservation
	Then The reservation should be
		| Nom   | Prenom      | Immat   | StartDate  | EndDate    | EstimateKm | Price |
		| Dusse | Jean-Claude | as202lk | 05/05/2021 | 10/05/2021 | 150        | 213.5 |

Scenario: Client reservation - Simple revervation with customer checks - Too young
	Given my username is "pmineur"
	And my password is "titi"
	When I try to connect to my account
	Then the connection is established
	Given Select these reservation dates
		| StartDate  | EndDate    |
		| 05/05/2021 | 10/05/2021 |
	When Validate reservation dates
	Then The vehicle list should be
		| Immat   | Marque  | Modele | Couleur | PrixRes | PrixKilo | Cv | Kilometrage |
		| nf552cd | Citroen | C3     | Blanche | 150     | 0,40     | 5  | 55632       |
		| as202lk | Renault | Clio   | Rouge   | 155     | 0.39     | 5  | 98145       |
	Given the selected vehicle is "as202lk"
	And estimate the number of km to 150
	When Create a reservation
	Then the error message is "Driver is too young"

Scenario: Client reservation - Simple revervation with customer checks - Doesn't have a license
	Given my username is "dmandrark"
	And my password is "tutu"
	When I try to connect to my account
	Then the connection is established
	Given Select these reservation dates
		| StartDate  | EndDate    |
		| 05/05/2021 | 10/05/2021 |
	When Validate reservation dates
	Then The vehicle list should be
		| Immat   | Marque   | Modele | Couleur | PrixRes | PrixKilo | Cv | Kilometrage |
		| nf552cd | Citroen  | C3     | Blanche | 150     | 0,40     | 5  | 55632       |
		| as202lk | Renault  | Clio   | Rouge   | 155     | 0.39     | 5  | 98145       |
		| ef168ml | Audi     | A3     | Grisse  | 220     | 0.45     | 9  | 18963       |
		| ac523cq | Maclaren | P1     | Jaune   | 450     | 0.60     | 95 | 8740        |
	Given the selected vehicle is "as202lk"
	And estimate the number of km to 150
	When Create a reservation
	Then the error message is "Driver must have a license"

Scenario: Client reservation - Revervation with customer checks - Customer < 18
	Given my username is "blejeun"
	And my password is "azerty"
	When I try to connect to my account
	Then the connection is established
	Given Select these reservation dates
		| StartDate  | EndDate    |
		| 05/05/2021 | 10/05/2021 |
	When Validate reservation dates
	Then The vehicle list should be
		| Immat   | Marque  | Modele | Couleur | PrixRes | PrixKilo | Cv | Kilometrage |
		| nf552cd | Citroen | C3     | Blanche | 150     | 0,40     | 5  | 55632       |
		| as202lk | Renault | Clio   | Rouge   | 155     | 0.39     | 5  | 98145       |

Scenario: Client reservation - Revervation with customer checks - Customer < 25
	Given my username is "pcalcaire"
	And my password is "azerty"
	When I try to connect to my account
	Then the connection is established
	Given Select these reservation dates
		| StartDate  | EndDate    |
		| 05/05/2021 | 10/05/2021 |
	When Validate reservation dates
	Then The vehicle list should be
		| Immat   | Marque  | Modele | Couleur | PrixRes | PrixKilo | Cv | Kilometrage |
		| nf552cd | Citroen | C3     | Blanche | 150     | 0,40     | 5  | 55632       |
		| as202lk | Renault | Clio   | Rouge   | 155     | 0.39     | 5  | 98145       |
		| ef168ml | Audi    | A3     | Grisse  | 220     | 0.45     | 9  | 18963       |
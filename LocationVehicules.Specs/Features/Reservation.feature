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
		| Immat   | Marque  | Modele | Couleur | PrixRes | PrixKilo | Cv |
		| nf552cd | Citroen | C3     | Blanche | 150     | 0,40     | 5  |
		| as202lk | Renault | Clio   | Rouge   | 155     | 0.39     | 5  |
		| ef168ml | Audi    | A3     | Grisse  | 220     | 0.45     | 7  |
	And following existing clients
		| Nom     | Prenom      | DateNaissance | NumPermis | Username | Password |
		| Dusse   | Jean-Claude | 11/08/1952    | 010101    | jcd      | toto     |
		| Cruchot | Ludovic     | 04/01/1971    | 546545    | lcruchot | tata     |

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
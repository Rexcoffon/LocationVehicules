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
	Given Les vehicules suivants
	| Immat   | Marque  | Modele | Couleur | PrixRes | PrixKilo | Cv |
	| nf552cd | Citroen | C3     | Blanche | 150     | 0,40     | 5  |
	| as202lk | Renault | Clio   | Rouge   | 155     | 0.39     | 5  |
	| ef168ml | Audi    | A3     | Grisse  | 220     | 0.45     | 7  |
	And Les clients suivants
	| Nom     | Prenom      | DateNaissance | NumPermis |
	| Dusse   | Jean-Claude | 11/08/1952    | 010101    |
	| Cruchot | Ludovic     | 04/01/1971    | 546545    |

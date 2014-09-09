 SELECT Persons.FirstName, Persons.Lastname, Addresses.Address, Towns.Name, Countries.Name
 FROM Persons INNER JOIN Addresses
    ON Persons.AddressID= Addresses.AddressID INNER JOIN Towns 
	ON Towns.TonwID= Addresses.TownID INNER JOIN Countries
	ON Countries.CountryID= Towns.CountryID  INNER JOIN Continents
	ON Continents.ContinentID=Countries.ContinentID
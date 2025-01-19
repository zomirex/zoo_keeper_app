using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer;
using zoo_keeper_app.Databases;

//                    how to use this app
//add animals
ZooAnimalsSaver.AddAnimals(new Parrot { name = "jigar", age = 2 });
ZooAnimalsSaver.AddAnimals(new Tiger { name = "pirooz", age = 2 });
ZooAnimalsSaver.AddAnimals(new Lions { name = "leo", age = 10 });
ZooAnimalsSaver.AddAnimals(new Cats { name = "pashmakk", age = 5 });
//refres data 
await ZooAnimalsSaver.RefreshData();
// Show all data 
ZooAnimalsSaver.Show.ShowAll();
// show specific animal by id or name
Console.ReadLine();
Console.Clear();
ZooAnimalsSaver.Show.Animal("leo");
ZooAnimalsSaver.Show.Animal(28);
// show the number of specific animal
Console.ReadLine();

Console.Clear();
ZooAnimalsSaver.Show.Count(Genus.cats);
//edit animall data
ZooAnimalsSaver.EditAnimal(pervname:"jigarr",name:"sartalla",age:5);
//delete animall
ZooAnimalsSaver.DeleteAnimal(3);
ZooAnimalsSaver.DeleteAnimal("leo");
//refresh data again
await ZooAnimalsSaver.RefreshData();
//show finall data
Console.ReadLine();
Console.Clear();
ZooAnimalsSaver.Show.ShowAll();


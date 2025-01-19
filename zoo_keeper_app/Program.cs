using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer;
using zoo_keeper_app.Databases;

// this is how to show 
//var awaiter =  SqlDB.AnimalsList().GetAwaiter();
//awaiter.OnCompleted(() =>
//{
//    foreach (var item in awaiter.GetResult())
//    {
//        Console.WriteLine($"|\tid : {item.id}\t|\tname : {item.name}\t| age:{item.age}\t| genus:{item.Genus}\t|");
//        Console.WriteLine("".PadLeft(100, '_'));
//    }

//});

//var x= ZooAnimalsSaver.RefreshData().GetAwaiter();
//x.OnCompleted(() =>
//{
//    foreach (var item in ZooAnimalsSaver.list)
//    {
//        Console.WriteLine($"|\tid : {item.id}\t|\tname : {item.name}\t| age:{item.age}\t| genus:{item.Genus}\t|");
//        Console.WriteLine("".PadLeft(100, '_'));
//    }
//});

//var awaiter2 = SqlDB.AddAnimal(new animalList()
//{
//    id = 10,
//    name = "Test",
//    age = 1,
//    Genus = Genus.snakes,
//    ability = Ability.toxic

//}).GetAwaiter().GetResult();
//Console.WriteLine(awaiter2);
//var test1 = new animalList()
//{

//    name = "leo",
//    age = 1,
//    Genus = Genus.snakes,
//    ability = Ability.toxic
//};
//ZooAnimalsSaver.AddAnimals(test1);

//ZooAnimalsSaver.EditAnimal(id: 240, age:1,name:"pashmak");
await ZooAnimalsSaver.RefreshData();
ZooAnimalsSaver.Show.ShowAll();
Console.WriteLine();
Console.WriteLine();
ZooAnimalsSaver.Show.Count(Genus.parrot);
ZooAnimalsSaver.Show.Animal("gg");
Console.ReadLine();
Console.Clear();

//ZooAnimalsSaver.AddAnimals(new animalList() {name="gg",age=12,Genus=Genus.cats });
//ZooAnimalsSaver.AddAnimals(new animalList() { name = "ggfg", age = 12, Genus = Genus.cats });

//ZooAnimalsSaver.AddAnimals(new animalList() { name = "ggafds", age = 12234, Genus = Genus.lions });
//ZooAnimalsSaver.AddAnimals(new animalList() { name = "ggatrewt", age = 1324, Genus = Genus.tigers });
//ZooAnimalsSaver.AddAnimals(new animalList() { name = "ggsdfwead", age = 12342, Genus = Genus.snakes });

ZooAnimalsSaver.Show.ShowAll();

ZooAnimalsSaver.Show.Count(Genus.cats);
ZooAnimalsSaver.Show.Count(Genus.lions);
ZooAnimalsSaver.Show.Count(Genus.tigers);

Console.ReadLine();

using zoo_keeper_app.Databases;
static class ZooAnimalsSaver 
{
    static private Dictionary<Genus, int> AnimalCount = new() {
        { Genus.lions, 0 },
        { Genus.cats, 0 },
        { Genus.snakes, 0 },
        { Genus.tigers, 0 },
        { Genus.bears, 0 },
        { Genus.parrot, 0 },
        { Genus.fish, 0 }
    };
    public static List<animalList> list = new();
    //add animals with constractor
    //public ZooAnimalsSaver()
    //{
    //    ID += 11;
    //    kindCount(base.Genus, true);
    //    this.id = ID;
    //}
    //public ZooAnimalsSaver(int age, string name, Genus genus, Ability ability)
    //{
    //    ID += 11;
    //    this.age = age;
    //    this.name = name;
    //    this.Genus = genus;
    //    this.ability = ability;
    //    this.id = ID;
    //    kindCount(base.Genus, true);
    //}
    //add animals and insert it in data base  succesfully work
    public static async void AddAnimals(animalList animal1)
    {
        var animal = new animalList()
        {
            name= animal1.name,
            age = animal1.age,
            //ability = animal1.ability,
            Genus=animal1.Genus
        };
        
        
        var res = await SqlDB.AddAnimal(animal);
        if(res)
        kindCount(animal.Genus, false);
        else
            Console.WriteLine("some errore catched");
        
    }
    //get data from database worked
    public static  Task RefreshData()
    {
        try
        {
            var NewAnimalListawait = SqlDB.AnimalsList().GetAwaiter().GetResult();

            list = NewAnimalListawait;
            Console.WriteLine("data refreshd succesfully !!");
            foreach (var item in list)
            {
                //Console.WriteLine(item.Genus);
                kindCount(item.Genus, false);
            }
        }
        catch (Exception ex) { Console.WriteLine($"we got a error {ex}"); }
        return Task.CompletedTask;
    }
    //delete animale and remove it in database  checked
    public static  void DeleteAnimal(string name)
    {
        var genus = SqlDB.FindAnimal(name:name).GetAwaiter().GetResult();
        var res = SqlDB.DeleteAnimal(name).GetAwaiter().GetResult();
        // if the sql.DeleteAnimal was  true then you can do kindCount(currentAnimal, true);
        if (res)
            kindCount(genus.Genus, true);
        else
            Console.WriteLine("your name does'nt Exist");
    }
    public static void DeleteAnimal(int id)
    {
        var genus =SqlDB.FindAnimal(id).GetAwaiter().GetResult();
        var res = SqlDB.DeleteAnimal(id).GetAwaiter().GetResult();
        // if the sql.DeleteAnimal was  true then you can do kindCount(currentAnimal, true);
        if (res)
            kindCount(genus.Genus, true);
        else
            Console.WriteLine("your id does'nt Exist");
        // if the sql.DeleteAnimal was  true then you can do kindCount(currentAnimal, true);
        

    }
    // show specific data not checked
    public static class Show
    {
        public static void ShowAll()
        {
            var animallist = SqlDB.AnimalsList().GetAwaiter();
                animallist.OnCompleted(() => 
            {
                foreach (var item in animallist.GetResult())
                {
                    Console.WriteLine($"|Id:{item.id}\t|Name:{item.name}\t|Age:{item.age}\t|genus:{item.Genus}\t|");
                }
            });
            
        }
        public static void Count(Genus genus)
        {
            Console.WriteLine("".PadLeft(50,'_'));
            Console.WriteLine($"Genus:\t{genus}\t,Count:{AnimalCount[genus]}");
            Console.WriteLine("".PadLeft(50,'_'));

        }
        public static void Animal(int id)
        {
            var animal = SqlDB.FindAnimal(id).GetAwaiter().GetResult();
            Console.WriteLine($"|ID:{animal.id}\t|Name:{animal.name}\t|Age:{animal.age}\t|Genus:{animal.Genus}\t|");
        }
        public static void Animal(string name)
        {
            var animal = SqlDB.FindAnimal(name:name).GetAwaiter().GetResult();
            Console.WriteLine($"|ID:{animal.id}\t|Name:{animal.name}\t|Age:{animal.age}\t|Genus:{animal.Genus}\t|");
        }
    }
    //edit animal data and save it in data base ** worked
    public static void EditAnimal(int id=0, string pervname="", string name="",Genus genus=Genus.def,int age=0)
    {
        if (name != "")
        {
            SqlDB.EditAnimalName(name, id,pervname);
            Console.WriteLine($"name {pervname} succesfully changed");

        }
        if (genus!=Genus.def) 
        {
            var x = SqlDB.EditAnimalAge(age, pervname, id).GetAwaiter().GetResult();
            SqlDB.EditAnimalGenus(genus, pervname, id);
            if (x)
                kindCount(genus, false);
            Console.WriteLine($"genus {pervname} succesfully changed");

        }
        if (age!=0)
        {
            Console.WriteLine($"age {pervname} succesfully changed");
        }
        else
            Console.WriteLine($"pls {pervname} atleast fill one field");

    }    
    private static void kindCount(Genus genus, bool add)
    {
        int x = add ? -1 : 1;
        switch (genus)
        {
            case Genus.lions:
                AnimalCount[Genus.lions]+=x; break;
            case Genus.cats:
                AnimalCount[Genus.cats]+=x; break;
            case Genus.snakes:
                AnimalCount[Genus.snakes] += x; break;
            case Genus.parrot:
                AnimalCount[Genus.parrot] += x; break;
            case Genus.bears:
                AnimalCount[Genus.bears] += x; break;
            case Genus.tigers:
                AnimalCount[Genus.tigers] += x; break;
            case Genus.fish:
                    AnimalCount[Genus.fish] += x; break;
            default:
                throw new Exception("the kind is'nt availibale");
        }
    }

}

public abstract class Animals
{
    protected int id { get; set; }
    public int age { get; set; }
    public string? name { get; set; }
    public Genus Genus { get; set; }
    
}
public class animalList:Animals
{
    new public int id { get; set; }
}
public class Lions : animalList
{
    public readonly List<Ability> abilities = new List<Ability> {Ability.wild,Ability.fast };
}
public class Cats : animalList
{
    public readonly List<Ability> abilities = new List<Ability> { Ability.dumb, Ability.fast };

}
public class Bears : animalList
{
    public readonly List<Ability> abilities = new List<Ability> { Ability.wild };
}
public class Parrot : animalList
{
    public readonly List<Ability> abilities = new List<Ability> { Ability.fly};

}
public class Snakes : animalList
{
    public readonly List<Ability> abilities = new List<Ability> { Ability.toxic, Ability.fast };

}
public class Fish: animalList
{
    public readonly List<Ability> abilities = new List<Ability> { Ability.swim };

}
public class Tiger : animalList
{
    public readonly List<Ability> abilities = new List<Ability> { Ability.wild, Ability.fast };

}
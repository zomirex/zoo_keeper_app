public abstract class Animals
{
    protected int id { get; set; }
    public int age { get; set; }
    public string? name { get; set; }
    
    
}
public class animalList:Animals
{
    new public int id { get; set; }
    public Genus Genus { get; set; }
}
public class Lions : animalList
{
    public readonly List<Ability> abilities = new List<Ability> { Ability.wild, Ability.fast };
    public Lions()
    {
        base.Genus= Genus.lions;
    }
}
public class Cats : animalList
{
    public readonly List<Ability> abilities = new List<Ability> { Ability.dumb, Ability.fast };
    
    public Cats()
    {
        base.Genus= Genus.cats;
    }
}
public class Bears : animalList
{
    public readonly List<Ability> abilities = new List<Ability> { Ability.wild };
    public Bears()
    {
        base.Genus = Genus.bears;
    }
}
public class Parrot : animalList
{
    public readonly List<Ability> abilities = new List<Ability> { Ability.fly};
    public Parrot()
    {
        Genus = Genus.parrot;
    }
}
public class Snakes : animalList
{
    public readonly List<Ability> abilities = new List<Ability> { Ability.toxic, Ability.fast };
    public Snakes()
    {
        Genus = Genus.snakes;
    }
}
public class Fish: animalList
{
    public readonly List<Ability> abilities = new List<Ability> { Ability.swim };
    public Fish()
    {
        Genus = Genus.fish;
    }
}
public class Tiger : animalList
{
    public readonly List<Ability> abilities = new List<Ability> { Ability.wild, Ability.fast };
    public Tiger()
    {
        Genus = Genus.tigers;
    }

}
namespace zoo_keeper_app.Databases
{
    public interface ISqldatabase
    {
        public static List<Animals> AnimalsList()
        {
            return new List<Animals>();
        }
        public static bool AddAnimal(Animals animals)
        {
            return true;
        }
        public static bool EditAnimal(Animals animals)
        {
            return true;
        }
    }
}
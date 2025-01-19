using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoo_keeper_app.Databases
{
    class SqlDB : ISqldatabase
    {
        private static readonly string connectionString = "Data Source=.;Initial Catalog=zookeeper;Integrated Security=True;Encrypt=False";
        // this method must worked and show all of the db datas
        public static Task<List<animalList>> AnimalsList()
        {
            var res = Task.Run(() =>
            {
                try
                {
                    using (SqlConnection connection = new(connectionString))
                    {
                        string cmdstring = "SELECT * FROM T_animals";
                        SqlCommand command = new(cmdstring, connection);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        List<animalList> Animals = new List<animalList>();
                        while (reader.Read())
                        {

                            Animals.Add(new animalList()
                            {
                                id = (int)reader[reader.GetName(0)],
                                name = (string)reader[reader.GetName(1)],
                                age = (int)reader[reader.GetName(2)],
                                Genus = (Genus)reader[reader.GetName(3)],
                                
                            });
                            
                            // check for working
                            //Console.WriteLine("".PadLeft(100, '-'));
                            //Console.WriteLine((string)reader[1]);
                        }
                        //Console.WriteLine("".PadLeft(100, '-'));
                        return Animals;
                    }

                }
                catch (Exception ex) 
                {
                    Console.WriteLine($"error :{ex}");
                    return new List<animalList>();
                }
            });

            return res;



        }
        public static Task<bool> AddAnimal(animalList animal)
        {
            var res = Task.Run(() =>
            {
                try
                {
                    using (SqlConnection connection = new(connectionString))
                    {
                        string cmdstring = "Insert INTO T_animals (name,age,genus) VALUES (@name,@age,@genus)";
                        SqlCommand command = new(cmdstring, connection);
                        connection.Open();
                        //command.Parameters.AddWithValue("@id", animal.id);
                        command.Parameters.AddWithValue("@name", animal.name);
                        command.Parameters.AddWithValue("@age", animal.age);
                        command.Parameters.AddWithValue("@genus", animal.Genus);                       
                        command.ExecuteNonQuery();

                        Console.WriteLine("".PadLeft(100, '-'));
                        Console.WriteLine("animal added succesfully");
                    }

                    return true;


                }
                catch(Exception ex) 
                {
                    Console.WriteLine(ex);
                    return false;
                }
            });
            return res;

        }
        public static Task<bool> EditAnimalName( string name, int id=0, string pervname="")
        {
            
            var res = Task.Run(() =>
            {
            using (SqlConnection connection = new(connectionString))
                {
                    string query = $"UPDATE T_animals SET name='{name}' WHERE id='{id}' OR name='{pervname}'";
                    SqlCommand command= new(query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }

                    return true;
            });
            return res;
        }
        public static Task<bool> EditAnimalAge( int age, string name = "",int id=0)
        {
            
            var res = Task.Run(() =>
            {
                using (SqlConnection connection = new(connectionString))
                {
                    string query = $"UPDATE T_animals SET age='{age}' WHERE id='{id}' OR name='{name}'";
                    SqlCommand command = new(query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                
                return true;
            });
            return res;
        }
        public static Task<bool> EditAnimalGenus( Genus genus, string name = "", int id=0)
        {
            
            var res = Task.Run(() =>
            {
                
                using (SqlConnection connection = new(connectionString))
                {
                    string query = $"UPDATE T_animals SET genus='{(int)genus}' WHERE id='{id}' OR name='{name}'";
                    SqlCommand command = new(query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return true;
            });
            return res;
        }
        //public static Task<bool> DeleteAnimal(animalList animal)
        //{
        //    try
        //    {
        //        using (SqlConnection connection = new(connectionString))
        //        {
        //            string cmdstring = $"SELECT * FROME T_animals WHERE name ='{animal.name}' or id='{animal.id}'";
        //            SqlCommand command = new(cmdstring, connection);
        //            connection.Open();
        //            command.ExecuteNonQuery();

        //            Console.WriteLine("".PadLeft(100, '-'));
        //            Console.WriteLine("animal deleted succesfully");
        //        }




        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex + "delete animal animal type ");

        //    }

        //    var res = Task.Run(() =>
        //    {
        //        try
        //        {
        //            using (SqlConnection connection = new(connectionString))
        //            {
        //                string cmdstring = $"DELETE FROME T_animals WHERE name ='{animal.name}'";
        //                SqlCommand command = new(cmdstring, connection);
        //                connection.Open();
        //                command.ExecuteNonQuery();

        //                Console.WriteLine("".PadLeft(100, '-'));
        //                Console.WriteLine("animal deleted succesfully");
        //            }

        //            return true;


        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex+ "delete animal animal type ");
        //            return false;
        //        }
        //    });
        //    return res;
        //}
        public static Task<bool> DeleteAnimal(string name)
        {
            var res = Task.Run(() =>
            {
                try
                {
                    using (SqlConnection connection = new(connectionString))
                    {
                        string cmdstring = $"DELETE FROM T_animals WHERE name ='{name}'";
                        SqlCommand command = new(cmdstring, connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                        Console.WriteLine("".PadLeft(100, '-'));
                        Console.WriteLine("animal deleted succesfully");
                    }
                    return true;


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex+"delete animal string");
                    return false;
                }
            });
            return res;
        }
        public static Task<bool> DeleteAnimal(int id)
        {
            var res = Task.Run(() =>
            {
                try
                {
                    using (SqlConnection connection = new(connectionString))
                    {
                        string cmdstring = $"DELETE FROM T_animals WHERE id ='{id}'";
                        SqlCommand command = new(cmdstring, connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                        Console.WriteLine("".PadLeft(100, '-'));
                        Console.WriteLine("animal deleted succesfully");
                    }
                    return true;


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex + "delete animal string");
                    return false;
                }
            });
            return res;
        }
        public static Task<animalList> FindAnimal(int id=0 ,string name="" )
        {
            
            var res = Task.Run(() => 
            {
                var findedAnimal = new animalList();
                try
                {
                   
                    using (SqlConnection connection = new(connectionString))
                    {
                        string cmdstring = $"SELECT * FROM T_animals WHERE name ='{name}' or id='{id}'";
                        SqlCommand command = new(cmdstring, connection);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {   findedAnimal.id = (int)reader[reader.GetName(0)];
                            findedAnimal.name =(string) reader[reader.GetName(1)];
                            findedAnimal.age =(int) reader[reader.GetName(2)];
                            findedAnimal.Genus=(Genus) reader[reader.GetName(3)];
                            //findedAnimal.id=(int) reader[reader.GetName(0)];
                            Console.WriteLine("".PadLeft(100, '-'));
                            if ((int)reader[reader.GetName(0)] != 0)
                                Console.WriteLine("animal find succesfully");
                            else
                                Console.WriteLine("animalList notfind");
                        }
                        
                        
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex + "find  animal type ");

                }
                return findedAnimal;
            });
            return res;
        }

    }
}

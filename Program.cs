using System;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace Pizzeria
{
    public class Program
    {
        public static void Main(string[] args)

        {

            string connStr = "server=localhost;user=root;database=pizzeria;port=3306;password=Root";

            MySqlConnection conn = new MySqlConnection(connStr);

            try

            {
                Console.WriteLine("Connecting to MySQL...\n");
                conn.Open();
                Console.WriteLine("Base de datos de Pizzeria\n");
                Console.Write("List Ingredients: ");
                string sql = "SELECT id,Name, price from ingredients;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Console.WriteLine(rdr[1]);
                }
                rdr.Close();
                string query = "SELECT Id,Name, price from ingredients WHERE Name=@Ingredient;";
                MySqlCommand mySqlCommand = new MySqlCommand(query, conn);
                Console.WriteLine("Enter a Ingredient: ");
                string user_input = Console.ReadLine();
                mySqlCommand.Parameters.AddWithValue("@Ingredient", user_input);
                rdr = mySqlCommand.ExecuteReader();
                while (rdr.Read())
                {
                    Console.WriteLine("Ingrediente: " + rdr["Name"] + ", precio: " + rdr["Price"]);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Conexion cerrada.");
        }
    }
}

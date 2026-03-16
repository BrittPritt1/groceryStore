using MySql.Data.MySqlClient;

namespace GroceryStore
{
    internal class Program 
    {
        static void Main(string[] args) 
        {
            //1 connection string
            string connectionString = "server=localhost;user=root;password=Spot1234;database=groceryStore;";
            
            //MySqlConnection
            using(MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                //new MySqlCommand("CREATE DATABASE groceryStore;", connection).ExecuteNonQuery();

                string createCmdText = "CREATE TABLE products (id INT PRIMARY KEY, name VARCHAR(100), category VARCHAR(100), price FLOAT, stock_quantity INT)";
                var createCmd = new MySqlCommand(createCmdText, connection);

                createCmd.ExecuteNonQuery();
            }
        }
    }   
}

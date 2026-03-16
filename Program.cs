using System.Reflection.Metadata;
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
                try
                {
                    connection.Open();

                    //new MySqlCommand("CREATE DATABASE groceryStore;", connection).ExecuteNonQuery();

                    //string createCmdText = "CREATE TABLE products (id INT PRIMARY KEY, name VARCHAR(100), category VARCHAR(100), price FLOAT, stock_quantity INT)";
                    //var createCmd = new MySqlCommand(createCmdText, connection);
                    //createCmd.ExecuteNonQuery();


                    /* string createStoreCmdText = "CREATE TABLE store (id INT PRIMARY KEY AUTO_INCREMENT, name VARCHAR(100), category VARCHAR(100), price FLOAT, stock_quantity INT)";
                    var createStoreCmd = new MySqlCommand(createStoreCmdText, connection);
                    createStoreCmd.ExecuteNonQuery();

                    object[,] groceryItemsData = new object[,]
                    {
                        {"Bananas", "Fruits",0.99f,150},
                        {"Apples", "Fruits",1.49f,100},
                        {"Carrots", "Vegetables",0.79f,200},
                        {"Potatoes", "Vegetables",1.29f,180},
                        {"Milk", "Dairy",2.49f,80},
                        {"Eggs", "Dairy",1.99f,120},
                        {"Bread", "Bakery",1.99f,90}, 
                        {"Chicken", "Meat",4.99f,50},
                        {"Rice", "Grains",3.99f,120},
                        {"Pasta", "Grains",1.49f,150},
                    };

                    for(int i = 0; i < groceryItemsData.GetLength(0); i++)
                    {
                        string name = (string)groceryItemsData[i,0];
                        string category = (string)groceryItemsData[i,1];
                        float price = (float)groceryItemsData[i,2];
                        int stock = (int)groceryItemsData[i,3];
                        new MySqlCommand($"INSERT INTO store (name, category, price, stock_quantity) VALUES ('{name}','{category}',{price},{stock});",connection).ExecuteNonQuery(); 
                    } */

                    //SELECT WHERE quantity < 100
                    string selectCmdText = "SELECT * FROM store WHERE stock_quantity < 100;";
                    var selectCmd = new MySqlCommand(selectCmdText, connection);

                    using(MySqlDataReader reader = selectCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            string name = reader.GetString("name");
                            string category = reader.GetString("category");
                            float price = reader.GetFloat("price");
                            int stock = reader.GetInt32("stock_quantity");

                            //display: id, name, category, price, quantity
                            Console.WriteLine($"{id}, {name}, {category}, {price}, {stock}");
                        }
                    }

                    //update quantity to 200 where < 100
                    string updateCmdText = "UPDATE store SET stock_quantity=200 WHERE stock_quantity < 100;";
                    var updateCmd = new MySqlCommand(updateCmdText, connection);
                    updateCmd.ExecuteNonQuery();

                    //Delete rows where category = vegetables
                    string deleteCmdText = "DELETE FROM store WHERE category = 'Vegetables'";
                    var deleteCmd = new MySqlCommand(deleteCmdText, connection);
                    deleteCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }   
}

using Azure;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FruitsRestSystem.Models
{
    public class Applications
    {
        Response response = new Response();

        public Response AddFruit(SqlConnection con, Fruits fruit)
        {
            try {

                string Query = "Insert into Fruits values(@ProductName,@ProductID,@Amount,@Price)";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@ProductName", fruit.ProductName);
                cmd.Parameters.AddWithValue("@ProductID", fruit.ProductID);
                
                cmd.Parameters.AddWithValue("@Amount", fruit.Amount);
                cmd.Parameters.AddWithValue("@Price", fruit.Price);
                con.Open();
                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    response.statusCode = 200;
                    response.message = "added successfully";
                    response.fruit = fruit;
                    response.fruits = null;
                }
                else
                {
                    response.statusCode = 100;
                    response.message = "faild";
                    response.fruit = null;
                    response.fruits = null;
                }
            } catch (SqlException ex)
            {
                response.statusCode = 500; // Internal Server Error
                response.message = "Error occurred while adding the fruit: " + ex.Message;
                response.fruit = null;
                response.fruits = null;
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        public Response GetAllFruits(SqlConnection con)
        {
            try
            {
                string Query = "select * from Fruits";
                SqlDataAdapter da = new SqlDataAdapter(Query,con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Fruits> _fruits = new List<Fruits>();

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Fruits fruit = new Fruits();
                        fruit.ProductName = (string)dt.Rows[i]["ProductName"];
                        fruit.ProductID = (int)dt.Rows[i]["ProductID"];
                        fruit.Amount = (decimal)dt.Rows[i]["Amount"];
                        fruit.Price = (decimal)dt.Rows[i]["Price"];

                        _fruits.Add(fruit);
                    }
                }
                if(_fruits.Count > 0)
                {response.statusCode = 200;
                    response.message = "retrieved successfully";
                    response.fruit = null;
                    response.fruits = _fruits;

                }
                                    
                else
                {
                    response.statusCode = 100;
                    response.message = "faild";
                    response.fruit = null;
                    response.fruits = null;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;
        }

        public Response GetFruitByProductID(SqlConnection con,int ProductID)
        {
            try
            {
                string Query = "select * from Fruits where ProductID = @ProductID";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Fruits fruits = new Fruits();
                if (dt.Rows.Count > 0)
                {
                   
                        Fruits fruit = new Fruits();
                        fruit.ProductName = (string)dt.Rows[0]["ProductName"];
                        fruit.ProductID = (int)dt.Rows[0]["ProductID"];
                        fruit.Amount = (decimal)dt.Rows[0]["Amount"];
                        fruit.Price = (decimal)dt.Rows[0]["Price"];

                    response.statusCode = 200;
                    response.message = "retrieved successfully";
                    response.fruit = fruit;
                    response.fruits = null;

                }
                else
                {
                    fruits = null;
                    response.statusCode = 100;
                    response.message = "faild";
                    response.fruit = null;
                    response.fruits = null;
                }
               
            }
            catch(SqlException ex)
            {
                response.statusCode = 500; // Internal Server Error
                response.message = "Error occurred : " + ex.Message;
                response.fruit = null;
                response.fruits = null;
                Console.WriteLine(ex.ToString());
            } 
            return response;
        }

        public Response GetFruitUpdateByProductID(SqlConnection con,Fruits fruit)
        {
            try
            {
                string Query =  "UPDATE Fruits SET ProductName = @ProductName, Amount = @Amount, Price = @Price WHERE ProductID = @ProductID";
                SqlCommand cmd = new SqlCommand(Query, con);
               

                cmd.Parameters.AddWithValue("@Amount", fruit.Amount);
                cmd.Parameters.AddWithValue("@Price", fruit.Price);
                cmd.Parameters.AddWithValue("@ProductName", fruit.ProductName);
                cmd.Parameters.AddWithValue("@ProductID", fruit.ProductID);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (rowsAffected > 0)
                {

                    response.statusCode = 200;
                    response.message = "Updated successfully";
                    response.fruit = fruit;
                    response.fruits = null;

                    

                }
                else
                {
                    response.statusCode = 100;
                    response.message = "Failed: No fruit found with the given ProductID";
                    response.fruit = null;
                    response.fruits = null;
                }

            }
            catch (SqlException ex)
            {
                response.statusCode = 500; // Internal Server Error
                response.message = "Error occurred : " + ex.Message;
                response.fruit = null;
                response.fruits = null;
                Console.WriteLine(ex.ToString());
            }
            return response;
        }
         public Response DeleteFruitByProductID(SqlConnection con, int ProductID)
        {
            try
            {
                con.Open();
                
                string Query = "Delete from Fruits where ProductID = @ProductID";
                
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    response.statusCode = 200;
                    response.message = "Deleted successfully";
                    response.fruit = null;
                    response.fruits = null;
                }
                else
                {
                    response.statusCode = 100;
                    response.message = "Deleted Fail";
                    response.fruit = null;
                    response.fruits = null;
                }
            }
            catch (SqlException ex)
            {
                response.statusCode = 500; // Internal Server Error
                response.message = "Error occurred : " + ex.Message;
                response.fruit = null;
                response.fruits = null;
                Console.WriteLine(ex.ToString());
            }
            return response;
        }

        public Response GetFruitSaleByProductIDAndWeight(SqlConnection con, int productID, decimal weight)
        {
            try
            {
                // 查询数据库以获取水果信息，计算销售金额
                string query = "SELECT * FROM Fruits WHERE ProductID = @ProductID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductID", productID);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // 从数据库中获取必要的信息，包括价格（Price）
                    string productName = (string)reader["ProductName"];
                    decimal price = (decimal)reader["Price"];

                    decimal itemSale = weight * price;

                    // 调用 Fruits 类中的静态方法更新总销售金额
                    Fruits.AddToTotalSale(itemSale);

                    // 将获取到的价格设置到 Fruits 对象中
                    Fruits fruit = new Fruits();
                    fruit.ProductName = productName;
                    fruit.ProductID = productID;
                    fruit.Price = price;

                    // 更新 Response 对象中的 Fruits 属性
                    response.statusCode = 200;
                    response.message = "successful";
                    response.fruit = fruit;
                    response.fruits = null;

                    // 更新数据库中水果的数量
                    decimal currentAmount = (decimal)reader["Amount"];
                    decimal newAmount = currentAmount - weight;

                    reader.Close();

                    // 更新数据库
                    string updateQuery = "UPDATE Fruits SET Amount = @NewAmount WHERE ProductID = @ProductID";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                    updateCmd.Parameters.AddWithValue("@NewAmount", newAmount);
                    updateCmd.Parameters.AddWithValue("@ProductID", productID);

                    updateCmd.ExecuteNonQuery();
                }

                con.Close();
            }
            catch (SqlException ex)
            {
                response.statusCode = 500; // 内部服务器错误
                response.message = "error：" + ex.Message;
                response.fruit = null;
                response.fruits = null;
                Console.WriteLine(ex.ToString());
            }

            return response;
        }
    }
}


using System.Data.SqlClient;
using NLog;

namespace First_Project
{
    public class DAL
    {
       
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        String connection = @"Data Source=DESKTOP-7GRMVB5;Initial Catalog=school;Integrated Security=True;Encrypt=false;TrustServerCertificate=true";
  

        public void Insert()
        {
            
            SqlConnection sqlConnection = new SqlConnection(connection);
            try
            {
                logger.Info("Connection Established");
                sqlConnection.Open();
                Console.WriteLine("Class Name:");
                int class_name = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("No of Desks:");
                int No_of_Desks = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("No of Tables:");
                int No_of_Tables = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("No of Cupboard:");
                int No_of_Cupboard = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("No of Chairs:");
                int No_of_chairs = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("No of BlackBoards:");
                int No_of_Blackboard = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Boys count:");
                int No_of_girls = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Girls count:");
                int No_of_Boys = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Total count:");
                int Total = Convert.ToInt32(Console.ReadLine());
                
                string Insertcommand = "Insert into Class_Details(class_name,No_of_Desks,No_of_Tables,No_of_Cupboard,No_of_chairs,No_of_Blackboard,No_of_girls,No_of_Boys,Total) values('" + class_name + "','" + No_of_Desks + "','" + No_of_Tables + "','" + No_of_Cupboard + "','" + No_of_chairs + "','" + No_of_Blackboard + "','" + No_of_girls + "','" + No_of_Boys + "','" + Total + "')";
                SqlCommand Insert_command = new SqlCommand(Insertcommand,sqlConnection);
                Insert_command.ExecuteNonQuery();
                logger.Info("Row Inserted", DateTime.Now);

                
                Console.ReadKey();
            
            }

            catch (Exception ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error("Error:Unable to Insert", ex, DateTime.Now);

            }

            finally
            {
                sqlConnection.Close();
            }
        }
        public void Read()
        {
            
            SqlConnection sqlConnection = new SqlConnection(connection);
            string query = "SELECT * FROM Class_Details";
            SqlCommand queryCommand = new SqlCommand(query, sqlConnection);

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = queryCommand.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"class_name: {reader["class_name"]}, No_of_Desks: {reader["No_of_Desks"]},No_of_Tables: {reader["No_of_Tables"]}, No_of_Cupboard: {reader["No_of_Cupboard"]}, No_of_chairs: {reader["No_of_chairs"]},No_of_Blackboard: {reader["No_of_Blackboard"]}, No_of_girls: {reader["No_of_girls"]}, No_of_Boys: {reader["No_of_Boys"]},Total: {reader["Total"]}");
                    logger.Info("Successfully Read Data", DateTime.Now);
                }
            }
            catch (Exception ex)
            {

                logger.Error("Error:Unable to Read", ex, DateTime.Now);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void Update()
        {
           
            SqlConnection sqlConnection = new SqlConnection(connection);
            // Parameters
            Console.WriteLine("No of Desks:");
            int No_of_Desks = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Class Name:");
            int class_name = Convert.ToInt32(Console.ReadLine());
            string updateSql = "UPDATE Class_Details SET No_of_Desks='" + No_of_Desks + "' WHERE class_name = '" + class_name + "'";
            SqlCommand updateCommand = new SqlCommand(updateSql,sqlConnection);
            try
            {
                sqlConnection.Open();
                int rowsAffected = updateCommand.ExecuteNonQuery();
                logger.Info($"Updated {rowsAffected} row(s)!", DateTime.Now);
            }
            catch (Exception ex)
            {
                logger.Error("Error:Unable to update", ex, DateTime.Now);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void Delete()
        {
            
            SqlConnection sqlConnection = new SqlConnection(connection);
            Console.WriteLine("class_name:");
            string? class_name = Console.ReadLine();
            // Parameter
            string deleteSql = "DELETE FROM Class_Details WHERE class_name = '" + class_name + "'";
            SqlCommand deleteCommand = new SqlCommand(deleteSql, sqlConnection);


            try
            {
                sqlConnection.Open();
                int rowsAffected = deleteCommand.ExecuteNonQuery();
                logger.Info($"Deleted {rowsAffected} row(s)!", DateTime.Now);
               
            }
            catch (Exception ex)
            {
                logger.Error("Error:Unable to Delete", ex, DateTime.Now);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}

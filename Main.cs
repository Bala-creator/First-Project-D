using System.Data.SqlClient;
using NLog;

namespace First_Project
{
  
    public class Class_Details
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private static SqlConnection sqlConnection;
        private static string connection;
        private static int? options;

        public static void Main(string[] args)
        {
            DAL dAL = new DAL();
            Console.WriteLine("1.Insert");
            Console.WriteLine("2.Update");
            Console.WriteLine("3.Delete");
            Console.WriteLine("4.Read");

            Console.WriteLine("Please choose the option:", options);
            options= Convert.ToInt32(Console.ReadLine());


            switch (options)
                {
                    case 1:
                        dAL.Insert();
                        break;
                    case 2:
                        dAL.Update();
                        break;
                    case 3:
                        dAL.Delete();
                        break;
                    case 4:
                        dAL.Read();
                        break;

                    default:
                        Console.WriteLine("Default option");
                        break;

                }
            
        
        }
    }
}

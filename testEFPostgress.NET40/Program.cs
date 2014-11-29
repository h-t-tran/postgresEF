
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace testEFPostgress.NET40
{
    class Program
    {

        public class DB : DbContext
        {

            //User ID=root;Password=myPassword;Host=localhost;Port=5432;Database=myDataBase;
            //Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0;


            //        connectionString="Server=[myserver];Database=MusicStore;
            //User Id=[myusername];Password=[mypassword];" providerName="Npgsql" 

            public DB() :
                base(nameOrConnectionString: "custconnstring")
            //base("Server=localhost;User Id=postgres;Password=root;Database=nm;")

    //            base("Server=localhost;Port=5432;User Id=postgres;Password=root;Database=nm;")
            //base("server=localhost;user id=postgres;password=root;database=nm")
            // base("nm")
            {

            }
            public DbSet<Customer> Customers { get; set; }

        };

        [Table("customer", Schema = "public")]
        public class Customer
        {
            [Column("custid")]
            [Key]
            public int CustId { get; set; }
            [Column("lastname")]
            public string LastName { get; set; }
            [Column("age")]
            public int Age { get; set; }
        }

        private static void testEf()
        {
            try
            {
                var db = new DB();
                foreach (var cust in db.Customers)
                {
                    Console.Out.WriteLine("cust name " + cust.LastName + " age " + cust.Age);
                }
            }
            catch (Exception e)
            {

            }
        }

        static void Main(string[] args)
        {
            testEf();
        }
    }
}

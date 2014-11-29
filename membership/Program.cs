using Membership.DataAccess;
using Membership.Models;
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

namespace Membership
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
        public DbSet<Pet> Pets { get; set; }
        
    };

    [Table("customer", Schema="public")]
    public class Customer
    {
        [Column("custid")]
        [Key]
        public int CustId { get; set; }
        [Column("lastname")]
        public string LastName { get; set; }
        [Column("age")]
        public int Age {get; set;}
    }

    [Table("pets", Schema = "public")]
    public class Pet
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("ssn")]
        public int ssn { get; set; }
    }

  class Program
  {
      private static void testEf()
      {
          try
          {
              var db = new DB();
              foreach (var cust in db.Pets)
              {
                  Console.Out.WriteLine("pet name " + cust.Name);
              }
          }
          catch (Exception e)
          {
  
          }
      }

      private static void testOdbc()
      {
          try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                // PostgeSQL-style connection string
                string connstring = String.Format("Server={0};Port={1};" + 
                    "User Id={2};Password={3};Database={4};",
                    "localhost", "5432", "postgres", 
                    "root", "nm" );
                // Making connection with Npgsql provider
                NpgsqlConnection conn = new NpgsqlConnection(connstring);
                conn.Open();
                // quite complex sql statement
                string sql = "SELECT * FROM pets";
                // data adapter making request from our connection
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                // i always reset DataSet before i do
                // something with it.... i don't know why :-)
                ds.Reset();
                // filling DataSet with result from NpgsqlDataAdapter
                da.Fill(ds);
                // since it C# DataSet can handle multiple tables, we will select first
                dt = ds.Tables[0];
                // connect grid to DataTable

                string insertQuery = "insert into pets (id, name, ssn) VALUES (20, 'dog20', 100)";
                //string insertQuery = "INSERT INTO npdata VALUES (@key, @ndata)";
                //ar cmdSql = new NpgsqlCommand(insertQuery, conn);
                //da = new NpgsqlDataAdapter(insertQuery, conn);
              
                //da.InsertCommand = new NpgsqlCommand(insertQuery, conn);


                NpgsqlCommand insertCmd = new NpgsqlCommand(insertQuery, conn);
                insertCmd.ExecuteScalar();

                // since we only showing the result we don't need connection anymore
                conn.Close();
            }
            catch (Exception msg)
            {

            }
      }
    static void Main(string[] args)
    {
        testOdbc();
        testEf();
        

      //var db = new CommandRunner("dvds");
      // follow along here...
   
      Console.Read();
    }
  }
}

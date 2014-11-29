using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
using System.Data;


namespace testEFPostgresDotnet40
{
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

    public class DB : DbContext
    {

        public DB() : base(nameOrConnectionString: "custconnstring")
        {

        }
        public DbSet<Customer> Customers { get; set; }

      
    };

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var db = new DB();
                foreach (var cust in db.Customers)
                {
                    Console.Out.WriteLine("cust name " + cust.LastName + " age " + cust.Age);
                }
            }
            catch (System.Exception e)
            {

            }
        }
    }
}

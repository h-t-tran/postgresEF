
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

namespace testEFPostgres
{
    class Program
    {

        public class DB : DbContext
        {
            public DB() :
                base(nameOrConnectionString: "custconnstring")
            {

            }

            //protected override void OnModelCreating(DbModelBuilder modelBuilder)
            //{
            //    base.OnModelCreating(modelBuilder);

            //    modelBuilder.Entity<Customer>()
            //        .Property(e => e.custid)
            //        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //}
            public DbSet<Customer> Customers { get; set; }

        };

        [Table("customers", Schema = "public")]
        public class Customer
        {
            [Key]
            [Column("custid")]            
            public int CustId { get; set; }
            
            [Column("lastname")]
            public string lastname { get; set; }
           
            [Column("age")]
            public int age { get; set; }
        }

        private static void testEf()
        {
            try
            {
                using (var db = new DB())
                {
                    foreach (var cust in db.Customers)
                    {
                        Console.Out.WriteLine("cust name " + cust.lastname + " age " + cust.age);
                    }

                    //var newCust = new Customer
                    //{
                    //    custid = 4,
                    //    //lastname = "bill",
                    //    //age = 20
                    //};
                    var match = db.Customers.FirstOrDefault(cust => cust.CustId == 1);
                    //match.age = 99;
                    //db.Customers.Remove(match);

                    var c = new Customer
                    {
                        CustId = 40,
                        lastname = "bill",
                        age = 20
                    };
                    db.Customers.Add(c);
                    db.SaveChanges();
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

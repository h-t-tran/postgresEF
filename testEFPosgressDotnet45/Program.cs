using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Npgsql;

namespace testEFPosgressDotnet45
{

    [Table("Blog", Schema = "public")]
    public class Blog
    {
        [Key]
        [Column("BlogId")]
        public int BlogIdent { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("ssn")]
        public int ssn { get; set; }

    }
    [Table("pets", Schema = "public")]
    public class Pet
    {
        [Key]
        [Column("pid")]
        public int ID { get; set; }

        //[Column("name")]
        //public string Name { get; set; }

        //[Column("ssn")]
        //public int ssn { get; set; }
    }

    [Table("Blog2", Schema = "public")]
    public class Blog2
    {
        [Key]
        [Column("BlogId")]
        public int ID { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("ssn")]
        public int ssn { get; set; }
    }

    public class DB : DbContext
    {
        public DB() : base(nameOrConnectionString: "MonkeyFist") { }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Blog2> Blogs2 { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }


      
    class Program
    {

        private static void testOdbc()
        {
            try
            {
                // PostgeSQL-style connection string
                string connstring = String.Format("Server={0};Port={1};" +
                    "User Id={2};Password={3};Database={4};",
                    "localhost", "5432", "postgres",
                    "root", "nm");
                // Making connection with Npgsql provider
                NpgsqlConnection conn = new NpgsqlConnection(connstring);
                conn.Open();


                string insertQuery = string.Format(
     //               "insert into pets (name, ssn) VALUES ('dog20', 100)", DateTime.Now.Second);
                    "insert into pets (id, name, ssn) VALUES (20{0}, 'dog20', 100)", DateTime.Now.Second);

                NpgsqlCommand insertCmd = new NpgsqlCommand(insertQuery, conn);
                insertCmd.ExecuteScalar();

                // since we only showing the result we don't need connection anymore
                conn.Close();
            }
            catch (Exception msg)
            {

            }
        }
        private static void TestPets()
        {
            try
            {
                var db = new DB();

                var pets = db.Blogs2;
                foreach (var p in pets)
                {
                    if (p != null)
                        Console.WriteLine(string.Format("id {0}", p.ID));
                    //Console.WriteLine(string.Format("id {0}, name {1}", p.ID, p.Name));
                }

                var pet = new Blog2
                {
                    ID = (int)DateTime.Now.Ticks
                    ,
                    Name = "blog" + DateTime.Now.Ticks.ToString()
                    ,
                    ssn = 99 
                };
                db.Blogs2.Add(pet);
                db.SaveChanges();

                Console.WriteLine("** afer insert");
                pets = db.Blogs2;
                foreach (var p in pets)
                {
                    if (p != null)
                        Console.WriteLine(string.Format("id {0}", p.ID));
                    //Console.WriteLine(string.Format("id {0}, name {1}", p.ID, p.Name));
                }

            }
            catch (Exception e)
            {

            }
        }

        static void testBlog2()
        {
            try
            {
                var db = new DB();

                var blogs = db.Blogs2;
                foreach (var p in blogs)
                {
                    if (p != null)
                        Console.WriteLine(string.Format("id {0}", p.ID));
                }

                var pet = new Blog2
                {
                    ID = (int)DateTime.Now.Ticks
                    ,
                    Name = "blog" + DateTime.Now.Ticks.ToString()
                    ,
                    ssn = 99
                };
                db.Blogs2.Add(pet);
                db.SaveChanges();

                Console.Out.WriteLine("------------ after insert");
                blogs = db.Blogs2;
                foreach (var p in blogs)
                {
                    if (p != null)
                        Console.WriteLine(string.Format("id {0} name {1}", p.ID, p.Name));
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("*** got exception ***");
            }
            Console.Read();
        }

        static void testBlog()
        {
            try
            {
                var db = new DB();

                var blogs = db.Blogs;
                foreach (var p in blogs)
                {
                    if (p != null)
                        Console.WriteLine(string.Format("id {0}", p.BlogIdent));
                }

                var pet = new Blog
                {
                    BlogIdent = (int)DateTime.Now.Ticks
                    ,Name = "blog" + DateTime.Now.Ticks.ToString()
                    , ssn = 99 
                };
                db.Blogs.Add(pet);
                db.SaveChanges();

                Console.Out.WriteLine("------------ after insert");
                blogs = db.Blogs;
                foreach (var p in blogs)
                {
                    if (p != null)
                        Console.WriteLine(string.Format("id {0} name {1}", p.BlogIdent, p.Name));
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("*** got exception ***");
            }
            Console.Read();
        }
        static void Main(string[] args)
        {
            //testOdbc();x
            testBlog();
            //testBlog2();
            //TestPets();
              Console.Read();
    
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEFSqlServer
{
    class Program
    {
        static void Main(string[] args)
        {

            testModelFirstPet();
            //testDbfirstPet2SimilarToPostgres();
        }
        private static void testDbfirstPet2SimilarToPostgres()
        {

            using (var ctx = new pet2Entities())
            {
                ctx.pets2.Add(new pets2
                {
                    id=20,
                    name="cat",
                    ssn=99
                });

                ctx.SaveChanges();
            }
        }
        private static void testModelFirstPet()
        {
            using (var ctx = new Model1Container())
            {
                ctx.Employees.Add(new Employee
                {
                    //Id = 2,
                    Name = "dog"
                });

                ctx.Employees.Add(new Employee
                {
                    //Id = 2,
                    Name = "cat"
                });
                ctx.SaveChanges();
            }
        }
    }
}

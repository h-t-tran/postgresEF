using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testEFSqlServer2
{
    class Program
    {
        //private static void testModelFirstPet()
        //{
        //    using (var ctx = new Model1Container())
        //    {
        //        ctx.e.Add(new Employee
        //        {
        //            //Id = 2,
        //            Name = "dog"
        //        });

        //        ctx.Employees.Add(new Employee
        //        {
        //            //Id = 2,
        //            Name = "cat"
        //        });
        //        ctx.SaveChanges();
        //    }
        //}
        static void Main(string[] args)
        {
            using (var ctx = new Model1Container())
            {
                //ctx.Employees.Add(new Employee
                //    {
                //        Name = "john"
                //        ,Id = 10
                //    });


                ctx.Metadatas.Add(new Metadata
                {
                   Id = 100,
                   Age= 20,
                   When = DateTime.Now,
                   Hobby = "soccer"
                });
                
                ctx.SaveChanges();
            }

        }
    }
}

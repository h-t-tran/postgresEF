using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testEFSqlServer4
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new Model1Container())
            {
                var newEmpl = new Employee
                    {
                        Name = "bill"
                        ,
                        Id = 12
                    };
                newEmpl.Infoes.Add(new Info
                            {
                               // EmployeeId = 11,  <<<< no need for this  EF will fill this in.
                                InfoId = 2,
                                Age = 998
                            });

                ctx.Employees.Add(newEmpl);


                //ctx.Infoes.Add(new Info
                //{
                //    EmployeeId = 10,
                //    InfoId = 1,
                //    Age = 99
                //});

                ctx.SaveChanges();
            }
        }
    }
}

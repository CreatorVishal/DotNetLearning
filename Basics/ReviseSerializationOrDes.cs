using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Basics
{
    internal class ReviseSerializationOrDes
    {
        public ReviseSerializationOrDes()
        {
            //pretty json
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            Employee3 empp1 = new Employee3()
            {
                Id = 104,
                Name = "Sunil",
                Salary = 50000

            };
            string Json = JsonSerializer.Serialize(empp1, options);
            WriteLine(Json);

            //-----------------Deserialization-----------
            Employee3 res = JsonSerializer.Deserialize<Employee3>(Json);
            WriteLine($"Id: {res.Id}, Name: {res.Name}, Salary: {res.Salary}");

            //------------------------------LIST Serialization
            List<Employee3> empList =new List<Employee3>()
            {
                new Employee3(){
                    Id = 1,
                    Name = "Vishal",
                    Salary = 50000   
                },


             new Employee3()
             {
                 Id = 2,
                 Name = "Sunil",
                 Salary = 60000
             }
            };

            string json =
            JsonSerializer.Serialize(
            empList,
            options
            );

            WriteLine(json);

            //-----------Json file save
                File.WriteAllText("Employee6.json",json);
            //Read
            string data =File.ReadAllText("Employee6.json");

            WriteLine(data);

            //------------------Json->object 
//            List<Employee3> employees =
//JsonSerializer.Deserialize<List<Employee3>>(data);

//            foreach (var emp in employees)
//            {
//                WriteLine(
//                $"{emp.Id} {emp.Name} {emp.Salary}"
//                );
//            }
        }
    }
    public class Employee3
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Salary { get; set; }
    }
}

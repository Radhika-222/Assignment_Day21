using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System.Xml.Serialization;

namespace Assignmet_Serialization
{
    public class Program
    {
        static void Main(string[] args)
        {
            Employee obj = new Employee()
            {
                Id = 09,
                FirstName = "John",
                LastName = "Verma",
                Salary = 25000.00
            };

            //Binary Serialization and Deserialization
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(@"E:\Mphasis_LVC\Day21\Assignment\employee.bin",
                FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, obj);
            stream.Close();

            stream = new FileStream(@"E:\Mphasis_LVC\Day21\Assignment\employee.bin",
               FileMode.Open, FileAccess.Read);

            Employee emp = (Employee)formatter.Deserialize(stream);
            Console.WriteLine("*** Binary Deserialized Employee ***");
            Console.WriteLine(emp.Id);
            Console.WriteLine(emp.FirstName);
            Console.WriteLine(emp.LastName);
            Console.WriteLine(emp.Salary);

            //XML Serialization and Deserialization
            XmlSerializer serializer = new XmlSerializer(typeof(Employee));
            using (TextWriter writer = new StreamWriter("employee.Xml"))
            {
                serializer.Serialize(writer, obj);
            }

            using (TextReader reader = new StreamReader("employee.xml"))
            {
                Employee deserializedEmployee = (Employee)serializer.Deserialize(reader);
                Console.WriteLine("\n*** XML Deserialized Employee ***");
                Console.WriteLine($"Id:{deserializedEmployee.Id}, FirstName: {deserializedEmployee.FirstName}, LastName: {deserializedEmployee.LastName}, Salary: {deserializedEmployee.Salary}");
            }
            Console.ReadKey();
        }
    }
}
       

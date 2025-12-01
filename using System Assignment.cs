using System;

namespace OperatorOverloadAssignment
{
    // Employee class containing three properties:
    // Id, FirstName, and LastName
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Overloading the "==" operator
        // This allows us to compare two Employee objects based on their Id values
        public static bool operator ==(Employee emp1, Employee emp2)
        {
            // If both are null, they are equal
            if (ReferenceEquals(emp1, emp2))
                return true;

            // If one is null and the other is not, they are not equal
            if (emp1 is null || emp2 is null)
                return false;

            // Compare by Id property
            return emp1.Id == emp2.Id;
        }

        // Overloading the "!=" operator
        // MUST be overloaded when "==" is overloaded
        public static bool operator !=(Employee emp1, Employee emp2)
        {
            return !(emp1 == emp2);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate first Employee object
            Employee employee1 = new Employee()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe"
            };

            // Instantiate second Employee object
            Employee employee2 = new Employee()
            {
                Id = 1,
                FirstName = "Jane",
                LastName = "Smith"
            };

            // Compare both employees using overloaded == operator
            bool areEqual = employee1 == employee2;

            // Display comparison result
            Console.WriteLine("Are the two employees equal? " + areEqual);

            // Optional: Compare using != operator
            bool areNotEqual = employee1 != employee2;

            Console.WriteLine("Are the two employees NOT equal? " + areNotEqual);

            // Keep console open
            Console.ReadLine();
        }
    }
}

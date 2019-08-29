using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haskFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Define person data
            // Person 1 : Lucie 0312 897 654
            // Person 2 : Nancy 0436 123 987
            // Person 3 : Jamie 0412 345 789
            // Person 4 : Davis 0326 654 321
            // Person 5 : Marissa 0415 888 999
            PersonRecord[] record = new PersonRecord[5];
            record[0] = new PersonRecord("Lucie", "0312 897 654");
            record[1] = new PersonRecord("Nancy", "0436 123 987");
            record[2] = new PersonRecord("Jamie", "0412 345 789");
            record[3] = new PersonRecord("Davis", "0326 654 321");
            record[4] = new PersonRecord("Marissa", "0415 888 999");

            //2. Display each person data from array of record 
            Console.WriteLine("List of person data record in our system");

            // Using foreach to get each person data in our record
            foreach ( PersonRecord temp in record){
                Console.WriteLine(temp.name + "  " + temp.phone);
            }

            // Hask funtion declaration
            List<PersonRecord>[] haskFunctionRecord = new List<PersonRecord>[27];

            // Initialize the record list for each table in the hask table
            for (int i=0; i< haskFunctionRecord.Length; i++)
            {
                haskFunctionRecord[i] = new List<PersonRecord>();
            }

            //3. Store person data in hask table for each column follow by first letter of name
            int index=0;
            foreach ( PersonRecord temp in record)
            {
                index = Num(temp.name);
                haskFunctionRecord[index].Add(temp);
            }

            //4. Display person record from hask table
            Console.WriteLine("\nDisplay person record from hask system");
            for (int i=0; i<haskFunctionRecord.Length; i++)
            {
                foreach(PersonRecord temp in haskFunctionRecord[i])
                {
                    Console.WriteLine($"[{i}]Name: {temp.name}  Phone: {temp.phone}");
                }
            }

            //5. Search name to display specific contact information
            Console.Write("\nEnter name for searching: ");
            string searchName = Console.ReadLine();
            searchName = char.ToUpper(searchName[0]) + searchName.Substring(1);
            PersonRecord found = null;
            index = Num(searchName);
            bool find = false;
            foreach (PersonRecord temp in haskFunctionRecord[index])
            {
                if (temp.name == searchName)
                {
                    find = true;
                    found = temp;
                    break;
                }
            }

            if(find)
            {
                Console.WriteLine("Contact information you are searching for");
                Console.WriteLine($"Name: {found.name}  Phone: {found.phone}");
            }
            else Console.WriteLine($"Cannot find {searchName} in our system");
            


            Console.ReadLine();
        }

        public static int Num(string name)
        {
            int index = 0;

            // Declare firstLetter to store first letter of name parameter
            char firstLetter = char.ToUpper(name[0]);

            // use if statement to get index num from firstLetter 
            if (firstLetter >= 65 && firstLetter <= 90)
            {
                // We us (int)firstLetter to covert char datatype to int
                index = (int)firstLetter - 64;
            }

            return index;
        }

        
    }
    class PersonRecord
    {
        // variable declaration
        public string name;
        public string phone;

        // Default constructer 
        public PersonRecord()
        {
            this.name = "Thai";
            this.phone = "0435 538 583";
        }

        // Constructer with parameter
        public PersonRecord(string name, string phone)
        {
            this.name = name;
            this.phone = phone;
        }
    }
}

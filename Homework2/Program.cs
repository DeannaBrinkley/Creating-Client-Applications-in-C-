using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            // find and display all entries where password is "hello"
            var findHello = users.Where (t => t.Password == "hello");
            foreach (Models.User user in findHello)
            {
                Console.WriteLine("{0}'s password is {1}", user.Name, user.Password);
            }
            Console.WriteLine("");
               
            // remove all entries where password is a lower-case version of name
            users.RemoveAll(t => t.Password == t.Name.ToLower());

            // remove first entry where password is "hello"
            users.Remove(users.First(t => t.Password == "hello"));

            // display remaining entries
            foreach (Models.User user in users) 
            {
                Console.WriteLine("remaining entries: name={0}  password={1}", user.Name, user.Password);
            }

            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;  
using System.Threading.Tasks;
using System.Text.Json;

namespace Selenium
{
    public class UserManager
    {
        string path;

        public int countUsers = 0;

        public List<User> users = new List<User>(); 
        public UserManager(string path)
        {
            this.path = path;
            StreamReader f = new StreamReader(path);
            while (!f.EndOfStream)
            {
                string line = f.ReadLine();
                var values = line.Split(',');

                User user = new User(values[0], values[1], values[2], values[3], values[4]);
                users.Add(user); 
            }
            countUsers = users.Count;
        }
    }
}

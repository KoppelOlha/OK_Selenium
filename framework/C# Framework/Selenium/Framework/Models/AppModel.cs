using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium.Framework.Models;

namespace Selenium.Framework.Models
{
    public class AppModel
    {
        public string title { get; set; }
        public string description { get; set; } 
        public AppCategory category { get; set; }
       
        public AppAuthor author { get; set; }

        public int numberOfDownloads {  get; set; }

        public AppModel(string title, string description, AppCategory category, AppAuthor author, int numberOfDownloads) {
            this.title = title;
            this.description = description;
            this.category = category;
            this.author = author;
            this.numberOfDownloads = numberOfDownloads;
        
        }

        public bool IsEqualAsNext(AppModel appModel)
        {
            bool result = this.title == appModel.title &&
                this.description == appModel.description &&
                this.category.title == appModel.category.title &&
                this.author.name == appModel.author.name &&
                this.numberOfDownloads == appModel.numberOfDownloads - 1;
            return result;

        }

    }


    public class AppCategory
    {
        public string title { get; set; }
        public string id { get; set; }

        public AppCategory(string title) {
            this.title = title;
            id = "";
        }
    }

    public class AppAuthor
    {
        public string name { get; set; }

        public AppAuthor(string name)
        {
            this.name = name;
        }
    }
}



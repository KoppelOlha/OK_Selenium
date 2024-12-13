using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Selenium.Framework.Models;
using System.Net.Http;


namespace Selenium.Pages
{
    public class AppJSON : BasePage
    {
        private HttpClient client;

        string jsonValue;
        public AppJSON(IWebDriver driver) : base(driver)
        {
            client = new HttpClient();
        }
        public IWebElement jsonForm => Driver.FindElement(By.ClassName("json-formatter-container"));
        string JSONText => Driver.FindElement(By.XPath("//pre")).Text;

        #region Methods
        public bool isJsonFormFound => jsonForm != null;
        public AppModel AppJSONModel()
        {
            GetJson();
            var a = jsonValue;
            AppModel appModel = JsonSerializer.Deserialize<AppModel>(JSONText);
            return appModel;
        }
        public async void GetJson()
        {
            string url = Driver.Url;
            var json = await client.GetStringAsync(url);
            jsonValue = json.ToString();
        }
        #endregion
    }
}

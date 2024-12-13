using System;
using OpenQA.Selenium;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace Selenium.Pages
{
    public class AddNewAppScreen : BasePage
    {
        public AddNewAppScreen(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement NewApplicationTitle => Driver.FindElement(By.XPath("//div[@class='content']/h1"));
        public IWebElement TitleField => Driver.FindElement(By.XPath("//div[@class='content']//table//td//input[@type='text']"));
        public IWebElement DescriptionField => Driver.FindElement(By.XPath("//div[@class='content']//table//td//textarea[@name='description']"));
        public IWebElement CategoryDropdown => Driver.FindElement(By.XPath("//div[@class='content']//table//td//select[@name='category']"));
        public IWebElement InfoOption => Driver.FindElement(By.XPath("//div[@class='content']//table//td//select/option[@value='673bbcca6ddefc1839e9b32b']"));
        public IWebElement FunOption => Driver.FindElement(By.XPath("//div[@class='content']//table//td//select/option[@value='673bbcca6ddefc1839e9b32c']"));
        public IWebElement MapsOption => Driver.FindElement(By.XPath("//div[@class='content']//table//td//select/option[@value='673bbcca6ddefc1839e9b32d']"));
        public IWebElement GamesOption => Driver.FindElement(By.XPath("//div[@class='content']//table//td//select/option[@value='673bbcca6ddefc1839e9b32e']"));
        public IWebElement NewsOption => Driver.FindElement(By.XPath("//div[@class='content']//table//td//select/option[@value='673bbcca6ddefc1839e9b32f']"));
        public IWebElement DevelopmentOption => Driver.FindElement(By.XPath("//div[@class='content']//table//td//select/option[@value='673bbcca6ddefc1839e9b330']"));
        public IWebElement ImageSelect => Driver.FindElement(By.XPath("//div[@class='content']//table//td//input[@name='image']"));
        public IWebElement IconSelect => Driver.FindElement(By.XPath("//div[@class='content']//table//td//input[@name='icon']"));
        public IWebElement CreateButton => Driver.FindElement(By.XPath("//div[@class='content']//p//input[@value='Create']"));
        public IWebElement ErrorMessage => Driver.FindElement(By.XPath("//div[@class='content']//p[@class='error']"));
        public IWebElement LastElement => Driver.FindElement(By.XPath("//div[@class='app'] [last()]"));

        string titleText = "Application_OK_7";

        string descriptionText = "Description_Text_OK_7";

        #region Methods
        public AppsList RefreshPage(IWebDriver driver)
        {
            driver.Navigate().Refresh();
            return new AppsList(Driver);
        }
        public void CategoryInfoSelection()
        {
            SelectElement dropdownInfoRole = new SelectElement(CategoryDropdown);
            dropdownInfoRole.SelectByValue("673bbcca6ddefc1839e9b32b");
        }
        public void CategoryFunSelection()
        {
            SelectElement dropdownFunRole = new SelectElement(CategoryDropdown);
            dropdownFunRole.SelectByValue("673bbcca6ddefc1839e9b32c");
        }
        public void CategoryMapsSelection()
        {
            SelectElement dropdownMapsRole = new SelectElement(CategoryDropdown);
            dropdownMapsRole.SelectByValue("673bbcca6ddefc1839e9b32d");
        }
        public void CategoryNewsSelection()
        {
            SelectElement dropdownNewsRole = new SelectElement(CategoryDropdown);
            dropdownNewsRole.SelectByValue("673bbcca6ddefc1839e9b32f");
        }
        public void CategoryDevelopmentSelection()
        {
            SelectElement dropdownDevelopmentRole = new SelectElement(CategoryDropdown);
            dropdownDevelopmentRole.SelectByValue("673bbcca6ddefc1839e9b330");
        }
        public void CategoryGamesSelection()
        {
            SelectElement dropdownGamesRole = new SelectElement(CategoryDropdown);
            dropdownGamesRole.SelectByValue("673bbcca6ddefc1839e9b32e");
        }
        public void FillTable()
        {
            TitleField.SendKeys(titleText);
            DescriptionField.SendKeys(descriptionText);
        }
        public AppsList CreateDefaultNewApp(IWebDriver driver)
        {
            FillTable();
            CreateButton.Click();
            return new AppsList(driver);
        }
        public AppsList CreateAppWithImageAndIcon(IWebDriver driver) {
            FillTable();
            ImageSelect.SendKeys("C:\\Users\\okoppel\\Source\\Repos\\okoppel-aut15\\framework\\C# Framework\\Selenium\\Framework\\TestData\\OK_Image.jpg");
            IconSelect.SendKeys("C:\\Users\\okoppel\\Source\\Repos\\okoppel-aut15\\framework\\C# Framework\\Selenium\\Framework\\TestData\\OK_Icon.jpg");
            CreateButton.Click();
            return new AppsList(driver);
        }
        public bool IsAppAdded()
        {
            FillTable();
            CreateButton.Click();
            RefreshPage(Driver);
            string text = LastElement.Text;
            bool isAppPresent = text.Contains(titleText);
            return isAppPresent;
        }
        #endregion
    }
}

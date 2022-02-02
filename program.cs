using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection.Metadata;
using System.Threading;

namespace Bonkers
{
	class Program
	{
        static void Main()
        {

            var driver = new ChromeDriver();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(300));

            driver.Navigate().GoToUrl("https://www.bonkers.ie/compare-gas-electricity-prices/dual-fuel/");

            Thread.Sleep(3000);

            driver.FindElement(By.XPath("/html/body/div[5]/div[3]/div/div[1]/div/div[2]/div/button[2]")).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("/html/body/div[2]/div[1]/form/fieldset[2]/div[1]/div[1]/div[2]/span[6]/input")).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("/html/body/div[2]/div[1]/form/fieldset[2]/div[2]/div[1]/div[2]/span[3]/input")).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("/html/body/div[2]/div[1]/form/fieldset[2]/div[3]/div[1]/div[2]/div/span[1]/label")).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("/html/body/div[2]/div[1]/form/fieldset[2]/div[3]/div[2]/div[2]/div/span[1]/label")).Click();
            Thread.Sleep(10000);

            //IWebElement SearchResult = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='new_search']/fieldset[2]/div[4]/div[2]/input")));
            IWebElement SearchResult = wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div[1]/form/fieldset[2]/div[4]/div[2]/input")));

            //Thread.Sleep(1000);

            SearchResult.Click();


            //Search for div results and grab title , electrcitiy charges , gas charges estimated annnual bill and save

            IWebElement result = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.ClassName("result-set__cards")));

            ReadOnlyCollection<IWebElement> lists = driver.FindElements(By.ClassName("result-card"));

            //Find links to details for each power outage notification
            foreach (IWebElement listEle in lists)
            {

                string company = listEle.FindElement(By.TagName("img")).GetAttribute("alt");

                String heading = driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[1]/div[1]/div[1]")).GetAttribute("innerHTML");


            }
            driver.Quit();

        }
    }
}

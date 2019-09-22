using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;
using System;

namespace TestWebApp
{
    public class TestandoBuscaNoGoogle
    {
        private IWebDriver driver;
        private IWebElement element;
        private string baseURL;
        private string driverPath = @"C:\Users\omehe\source\repos\workshop_automation_test\src\project\tests\TestWebApp\";

        public IWebDriver Driver
        {
            get { return driver; }

            set { driver = value; }
        }

        public IWebElement Element
        {
            get { return element; }

            set { element = value; }
        }


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(driverPath);
            baseURL = "http://www.google.com.br/";
        }

        [Test]
        public void BuscandoPorSelenium()
        {
            Driver.Navigate().GoToUrl(baseURL);

            // Encontra o elemento que pretende trabalhar
            IWebElement query = driver.FindElement(By.Name("q"));
    
            // Entra com as informa��es que deseja buscar
            query.SendKeys("Selenium");
    
            // Executa a fun��o de enter
            query.Submit();
    
            // Aguarda a renderiza��o dos dados na tela
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Title.StartsWith("Selenium", StringComparison.OrdinalIgnoreCase));

            // Should see: "Cheese - Google Search" (for an English locale)
            //Console.WriteLine("Page title is: " + driver.Title);

            Driver.Close();
            Driver.Quit();

            

        }
    }
}
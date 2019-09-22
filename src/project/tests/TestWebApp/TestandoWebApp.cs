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
    public class TestandoWebApp
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
            Driver = new ChromeDriver(driverPath);
            baseURL = "http://localhost:64161/";
            Driver.Navigate().GoToUrl(baseURL);
        }

        [Test]
        public void Entrar_Na_Pagina_De_Listagem_De_Carro()
        {
            IWebElement query = Driver.FindElement(By.LinkText("Carros"));

            query.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Title.StartsWith("Lista", StringComparison.OrdinalIgnoreCase));

            Assert.AreEqual("Lista Carros - LocadoraDeAutos", Driver.Title);

            Driver.Close();
            Driver.Quit();
        }

        [Test]
        public void Cadastrar_Novo_Carro()
        {
            // Para cada componente da tela é crio um novo IWebElement
            // para que no momento de buscar o element o driver não se perca 
            IWebElement menu = Driver.FindElement(By.LinkText("Carros"));
            menu.Click();

            // Aguarda a renderizaco dos dados na tela
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Title.StartsWith("Lista", StringComparison.OrdinalIgnoreCase));

            Assert.AreEqual("Lista Carros - LocadoraDeAutos", Driver.Title);

            IWebElement link = Driver.FindElement(By.Id("LinkCreate"));
            link.Click();

            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Title.StartsWith("Create", StringComparison.OrdinalIgnoreCase));

            Assert.AreEqual("Create - LocadoraDeAutos", Driver.Title);

            IWebElement nome = Driver.FindElement(By.Id("Nome"));
            nome.Clear();
            nome.SendKeys("C4");

            IWebElement modelo = Driver.FindElement(By.Name("Modelo"));
            modelo.Clear();
            modelo.SendKeys("Cactus");

            IWebElement marca = Driver.FindElement(By.Id("Marca"));
            marca.Clear();
            marca.SendKeys("Cactus");

            IWebElement preco = Driver.FindElement(By.Name("Preco"));
            preco.Clear();
            preco.SendKeys("60");

            IWebElement btn = Driver.FindElement(By.ClassName("btn-primary"));
            btn.Click();

            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Title.StartsWith("Lista", StringComparison.OrdinalIgnoreCase));

            Assert.AreEqual("Lista Carros - LocadoraDeAutos", Driver.Title);

            Driver.Close();
            Driver.Quit();
        }
    }
}
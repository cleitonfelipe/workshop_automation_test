# Workshop Automation Test

>Projeto de exemplo para workshop de automação de testes em .Net Core com Selenium realizado no Campus da Universidade Positivo de Curitiba no dia 17/09/2019

## Projetos

| Nome | Template |
| ---- | ---- |
| Calculadora| Console|
| TestConsoleMsTest| Unit Test Project(mstest) |
| TestConsoleNunit | NUnit 3 Test Project(nunit)|
| TestConsoleXUnit | xUnit Test Project(xunit) |
| TestWebApp| NUnit 3 Test Project(nunit) |
| Locadora de Autos| ASP.NET Core Web App MVC|

## Pacotes utilizados

### Testes Unitários

| Projeto | Package Name | Version |
| ------- | ------------ | ------- |
| TestConsoleMsTest | Microsoft.NET.Test.Sdk | 16.0.1 |
| TestConsoleMsTest | MSTest.TestAdapter | 1.4.0 |
| TestConsoleMsTest | MSTest.TestFramework | 1.4.0 |
| TestConsoleNunit | nunit | 3.11.0|
| TestConsoleNunit | NUnit3TestAdapter | 3.11.0 |
| TestConsoleNunit | Microsoft.NET.Test.Sdk | 15.9.0 |
| TestConsoleXUnit | Microsoft.NET.Test.Sdk | 16.0.1 |
| TestConsoleXUnit | xunit | 2.4.0 |
| TestConsoleXUnit | xunit.runner.visualstudio | 2.4.0 |
| TestWebApp | nunit | 3.11.0 |
| TestWebApp | NUnit3TestAdapter | 3.11.0 |
| TestWebApp | Microsoft.NET.Test.Sdk | 15.9.0 |
| TestWebApp | Selenium.Support | 3.141.0 |
| TestWebApp | Selenium.WebDriver | 3.141.0 |

***Exemplo de teste com Selenium***

```csharp
/// TestandoBuscaNoGoogle.cs
public class TestandoBuscaNoGoogle
    {
        private IWebDriver driver;
        private IWebElement element;
        private string baseURL;
        private string driverPath = @"[Endereço Driver Selenium]";

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
    
            // Executa a função de enter
            query.Submit();
    
            // Aguarda a renderização dos dados na tela
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Title.StartsWith("Selenium", StringComparison.OrdinalIgnoreCase));

            Driver.Close();
            Driver.Quit();
        }
    }
```

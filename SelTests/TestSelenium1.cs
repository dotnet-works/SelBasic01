using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SelBasic01.SelTests;

class TestSelenium1{
    
    IWebDriver driver;

    [SetUp]
    public void init(){
       driver = new ChromeDriver();
       driver.Navigate().GoToUrl("https://www.amazon.in/");
       driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(2500);
       driver.Manage().Window.Maximize();
    }
   
    [TearDown]
    public void finshTests(){
       driver.Quit();
       driver.Dispose();
    }

    [Test]
    public void Test1(){
        IWebElement searchTextBox = driver.FindElement(By.Id("twotabsearchtextbox"));
        searchTextBox.SendKeys("men's denim");
        driver.FindElement(By.Id("nav-search-submit-text")).Click();
        String _totalResults = driver.FindElement(By.CssSelector("div.a-section.a-spacing-small.a-spacing-top-small")).Text;
        Console.WriteLine(String.Format("Results Found: {0}",_totalResults));
    }

    // [Test]
    // public void Test2(){
        
    // }






}
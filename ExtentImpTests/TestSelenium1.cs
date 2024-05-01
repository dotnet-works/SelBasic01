using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SelBasic01.ExtentImpTests;

[Parallelizable]
public class TestSelenium1 : BaseTest{
    

    [Test]
    public void Test1(){
        IWebElement searchTextBox = driver.FindElement(By.Id("twotabsearchtextbox"));
        searchTextBox.SendKeys("men's denim");
        driver.FindElement(By.Id("nav-search-submit-text")).Click();
        String _totalResults = driver.FindElement(By.CssSelector("div.a-section.a-spacing-small.a-spacing-top-small")).Text;
        Console.WriteLine(String.Format("Results Found: {0}",_totalResults));
    }

   






}
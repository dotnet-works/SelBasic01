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
        Thread.Sleep(5000);
        // string _totalResults = driver.FindElement(By.CssSelector("div.a-section.a-spacing-small.a-spacing-top-small")).Text;
        string _totalResults = driver.FindElement(By.XPath("//span[@data-component-type='s-result-info-bar']/div/h1/div/div[1]")).Text;
        Console.WriteLine(String.Format("Results Found: {0}",_totalResults));
    }

   






}
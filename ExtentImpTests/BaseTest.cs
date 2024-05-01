using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SelBasic01.SelUtil;

namespace SelBasic01.ExtentImpTests;

public class BaseTest{
    public IWebDriver driver;
    private string baseURL = "https://www.calculator.net/";
    public const string BROWSER="CHROME";


    [OneTimeSetUp]
    public void GlobalSetUp(){
        
        ExtentTestManager.CreateParentTest(GetType().Name);
    }

    [OneTimeTearDown]
    public void GlobalTestTearDown(){
        ExtentService.GetExtent().Flush();
    }

    [SetUp]
    public void InitSetUp(){
        ExtentTestManager.CreateTest(TestContext.CurrentContext.Test.Name);
        ChromeOptions _chromeOptions = new ChromeOptions();
        _chromeOptions.AddArgument("--disable-dev-shm-usage");
        _chromeOptions.AddArgument("--no-sandbox");
        _chromeOptions.AddArgument("--log-level=3");
        _chromeOptions.AddArgument("--headless");
        driver = new ChromeDriver(_chromeOptions);
        driver.Navigate().GoToUrl("https://www.amazon.in/");
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(2500);
        driver.Manage().Window.Maximize();
        
    }

    [TearDown]
    public void TestTearDown(){
        driver.Close();
        driver.Dispose();
    }
}
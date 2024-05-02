using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
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
        
        var user = Environment.GetEnvironmentVariable("TestUser");
        Console.WriteLine(String.Format("CMD Pass User {0}",user));
        

        // ChromeOptions _chromeOptions = new ChromeOptions();
        // _chromeOptions.AddArguments("--disable-dev-shm-usage");
        // _chromeOptions.AddArguments("--no-sandbox");
        // _chromeOptions.AddArguments("--log-level=3");
        // // _chromeOptions.AddArguments("--headless");
        // driver = new ChromeDriver(_chromeOptions);

        
        FirefoxOptions _ffOptions = new FirefoxOptions();
        
        _ffOptions.LogLevel = FirefoxDriverLogLevel.Fatal;
        _ffOptions.SetLoggingPreference(LogType.Browser, LogLevel.Off); //.All);
        _ffOptions.AddArguments("--headless");
        driver = new FirefoxDriver(_ffOptions);

        driver.Navigate().GoToUrl("https://www.amazon.in/");
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(2500);
        driver.Manage().Window.Maximize();
        
    }

    [TearDown]
    public void TestTearDown(){
        driver.Quit();
        driver.Dispose();
    }
}
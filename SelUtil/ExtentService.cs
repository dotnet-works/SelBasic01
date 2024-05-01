using System.Runtime.CompilerServices;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;


using SelBasic01.SelUtil;

public class ExtentService{
    public static ExtentReports extent;

    public static ExtentReports GetExtent(){

        if(extent==null){
            extent = new ExtentReports();
            string reportDir = Path.Combine(Util.GetProjectBaseDir(),"Reports");
            if(!Directory.Exists(reportDir)){
               Directory.CreateDirectory(reportDir);
            
            String path = Path.Combine(reportDir,"index.html");
            ExtentSparkReporter reporter = new ExtentSparkReporter(path);
            extent.AttachReporter(reporter);
           }
        }
        return extent;          
    }
}

public static class ExtentTestManager{

    [ThreadStatic]
    private static ExtentTest   parentTest;

    [ThreadStatic]
    private static ExtentTest childTest;

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static ExtentTest CreateParentTest(string testName,string description = null){
        
        parentTest = ExtentService.GetExtent().CreateTest(testName,description);
        return parentTest;
    }


    [MethodImpl(MethodImplOptions.Synchronized)]
    public static ExtentTest CreateTest(string testName,string description = null){
        
        childTest = parentTest.CreateNode(testName,description);
        return childTest;
    }

    public static ExtentTest GetExtentTest(){
       return childTest;
    }





}


namespace SelBasic01.SelUtil;

public class Util{

   public static string GetProjectBaseDir(){
       string projDir = Directory.GetCurrentDirectory().Split("bin")[0];
       return projDir;
   }



}
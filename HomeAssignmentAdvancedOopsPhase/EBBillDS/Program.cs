using System;
namespace EBBillDS;   //File scoped
class Program
{
    public static void Main(string[] args)
    {
        FileHandling files=new FileHandling();
        files.Create();
        Operations operate=new Operations();
        //operate.Default();
        files.ReadFromCSV();
        operate.MainMenu();
        files.WriteToCSV();
    }
}

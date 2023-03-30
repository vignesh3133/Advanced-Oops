using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBBillDS
{
    public class FileHandling
    {
        public void Create()
        {
            if(!Directory.Exists("EBBillDS"))
            {
                Console.WriteLine("Creating folder...");
                Directory.CreateDirectory("EBBillDS");
            }
            if(!File.Exists("EBBillDS/EBMeterDetails.csv"))
            {
                Console.WriteLine("Creating file EBMeterDetails");
                File.Create("EBBillDS/EBMeterDetails.csv").Close();
            }
            if(!File.Exists("EBBillDS/UserDetails.csv"))
            {
                Console.WriteLine("Creating file UserDetails");
                File.Create("EBBillDS/UserDetails.csv").Close();
            }
        }

        public void WriteToCSV()
        {
            string [] entries=new string [Operations.entryList.Count];
            for(int i=0;i<Operations.entryList.Count;i++)
            {
                var entry=Operations.entryList[i];
                /*s_entryID++;
            EntryID=""+s_entryID;
            CustomerID=customerID;
            UnitUsed=unitUsed;
            MeterTarrifType=meter;
            BillDate=billMonth;
            Status=PaymentStatus.Unpaid;
            */
                entries[i]=entry.EntryID+","+entry.CustomerID+","+entry.UnitUsed+","+entry.MeterTarrifType+","+entry.BillDate+","+entry.Status+","+entry.BillAmount;
            }
            File.WriteAllLines("EBBillDS/EBMeterDetails.csv",entries);

            string [] users=new string[Operations.userList.Count];
            for(int i=0;i<Operations.userList.Count;i++)
            {

                /*s_customerID++;
            CustomerID="EB"+s_customerID;
            Name=name;
            Phone=phone;
            Address=address;

            */
                var user=Operations.userList[i];
                users[i]=user.CustomerID+","+user.Name+","+user.Phone+","+user.Address+","+user.Balance;
            }
            File.WriteAllLines("EBBillDS/UserDetails.csv",users);
        }

        public void ReadFromCSV()
        {
            string [] users=File.ReadAllLines("EBBillDS/UserDetails.csv");
            for(int i=0;i<users.Length;i++)
            {
                Operations.userList.Add(new UserDetails(users[i]));
            }
            string [] entries=File.ReadAllLines("EBBillDS/EBMeterDetails.csv");
            for(int i=0;i<entries.Length;i++)
            {
                Operations.entryList.Add(new EBMeterDetails(entries[i]));
            }
        }
    }
}
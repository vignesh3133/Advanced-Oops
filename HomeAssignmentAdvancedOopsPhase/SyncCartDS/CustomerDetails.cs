using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncCartDS
{
    public class CustomerDetails
    {
       /* •	CustomerID (Auto Increment -CID1000)
•	Name
•	City
•	MobileNumber
•	WalletBalance
•	EmailID
*/
        private static int s_customerID=1000;
        public string CustomerID{get;}
        public string Name{get;set;}
        public string City{get;set;}
        public string MobileNumber{get;set;}
        private double _walletBalance;
        public double WalletBalance{get{return _walletBalance;}}
        public string EmailID{get;set;}


        public CustomerDetails(string name,string city,string mobileNumber,string emailID,double walletBalance)
        {
            s_customerID++;
            CustomerID="CID"+s_customerID;
            Name=name;
            City=city;
            MobileNumber=mobileNumber;
            EmailID=emailID;
            _walletBalance=walletBalance;
        }

        public CustomerDetails(string user)
        {
             /*s_customerID++;
            CustomerID="CID"+s_customerID;
            Name=name;
            City=city;
            MobileNumber=mobileNumber;
            EmailID=emailID;
            _walletBalance=walletBalance;*/

            string []values=user.Split(",");
            CustomerID=values[0];
            s_customerID=int.Parse(values[0].Remove(0,3));
            Name=values[1];
            City=values[2];
            MobileNumber=values[3];
            EmailID=values[4];
            _walletBalance=double.Parse(values[5]);
        }
        public void WalletRecharge(double amount)
        {
            _walletBalance+=amount;
        }

        public void DeductBalance(double amount)
        {
            _walletBalance-=amount;
        }
    }
}
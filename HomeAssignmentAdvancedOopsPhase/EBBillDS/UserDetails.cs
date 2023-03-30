using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBBillDS
{
    public class UserDetails
    {
         private static int s_customerID=1000;
         public string CustomerID { get; }
        public string Name { get; set; }
        public string Phone { get; set; }
        private double _balance;
        public double Balance{get{return _balance;}}
        public string Address { get; set; }

        public UserDetails(string name,string phone,string address)
        {
            s_customerID++;
            CustomerID="EB"+s_customerID;
            Name=name;
            Phone=phone;
            Address=address;
        }

        public UserDetails(string user)
        {
            string []values=user.Split(",");
            CustomerID=values[0];
            s_customerID=int.Parse(values[0].Remove(0,2));
            Name=values[1];
            Phone=values[2];
            Address=values[3];
            _balance=double.Parse(values[4]);
        }
        public void Recharge(double amount)
        {
          _balance+=amount;
        }
        public void DeductBalance(double amount)
        {
            
            _balance-=amount;
        }
    }
}
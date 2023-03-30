using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBBillDS
{
    public enum MeterType{Select,Commercial,Domestic}
    public enum PaymentStatus{Select,Paid,Unpaid}
    public class EBMeterDetails
    {
        private static int s_entryID=1000;
        public string EntryID { get; }
        public string CustomerID { get; set;}
         public int UnitUsed { get; set; }
        public double BillAmount { get; set; }
        public string BillDate { get; set; }
        public MeterType MeterTarrifType { get; set; }
        public PaymentStatus Status { get; set; }
        public EBMeterDetails(string customerID,int unitUsed,MeterType meter,string billMonth)
        {
            s_entryID++;
            EntryID=""+s_entryID;
            CustomerID=customerID;
            UnitUsed=unitUsed;
            MeterTarrifType=meter;
            BillDate=billMonth;
            Status=PaymentStatus.Unpaid;
            
            CalculateBill();
        }

        public EBMeterDetails(string entry)
        {
            string [] values=entry.Split(",");
            EntryID=values[0];
            s_entryID=int.Parse(values[0]);
            CustomerID=values[1];
            UnitUsed=int.Parse(values[2]);
            MeterTarrifType=Enum.Parse<MeterType>(values[3]);
            BillDate=values[4];
            Status=Enum.Parse<PaymentStatus>(values[5]);
            BillAmount=double.Parse(values[6]);

        }
        public void CalculateBill()
        {
         if(MeterTarrifType==MeterType.Commercial)
         {
            BillAmount=UnitUsed*5;
         }
         else if(MeterTarrifType==MeterType.Domestic)
         {
            BillAmount=UnitUsed*2.5;
         }
        }
        public void Pay()
        {
            Status=PaymentStatus.Paid;
        }

    }
}
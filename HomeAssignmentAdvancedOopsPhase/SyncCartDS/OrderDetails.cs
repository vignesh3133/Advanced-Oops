using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncCartDS
{
    public enum OrderStatus {Default,Ordered,Cancelled}
    public class OrderDetails
    {
          /*Properties: 
•	OrderID (Auto Increment – OID1001)
•	CustomerID
•	ProductID
•	TotalPrice 
•	PurchaseDate
•	Quantity
•	OrderStatus – (Enum- Default, Ordered, Cancelled)
*/
       private static int s_orderID=1000;
       public string OrderID{get;}
       public string CustomerID{get;set;}
       public string ProductID{get;set;}
       public Double TotalPrice{get;set;}
       public DateTime PurchaseDate{get;set;}
       public int Quantity{get;set;}
       public  OrderStatus Status{get;set;}

       public OrderDetails(string customerID,string productID,Double totalPrice,DateTime purchaseDate,int quantity,OrderStatus status )
       {
            s_orderID++;
            OrderID="OID"+s_orderID;
            CustomerID=customerID;
            ProductID=productID;
            TotalPrice=totalPrice;
            PurchaseDate=purchaseDate;
            Quantity=quantity;
            Status=status;

       }

       public OrderDetails(string order)
       {
         /* s_orderID++;
            OrderID="OID"+s_orderID;
            CustomerID=customerID;
            ProductID=productID;
            TotalPrice=totalPrice;
            PurchaseDate=purchaseDate;
            Quantity=quantity;
            Status=status; */
        string []values=order.Split(",");
        OrderID=values[0];
        s_orderID=int.Parse(values[0].Remove(0,3));
        CustomerID=values[1];
        ProductID=values[2];
        TotalPrice=double.Parse(values[3]);
        PurchaseDate=DateTime.Parse(values[4]);
        Quantity=int.Parse(values[5]);
        Status=Enum.Parse<OrderStatus>(values[6]);

       }
    }
}
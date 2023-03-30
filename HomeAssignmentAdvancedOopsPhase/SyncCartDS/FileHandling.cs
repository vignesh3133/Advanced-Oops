using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncCartDS
{
    public class FileHandling
    {
        public static void Create()
        {
            if(!Directory.Exists("SyncCartDS"))
            {
                Console.WriteLine("Creating folder...");
                Directory.CreateDirectory("SyncCartDS");
            }
            if(!File.Exists("SyncCartDS/CustomerDetails.csv"))
            {
                Console.WriteLine("Creating file CustomerDetails");
                File.Create("SyncCartDS/CustomerDetails.csv").Close();
            }
            if(!File.Exists("SyncCartDS/ProductDetails.csv"))
            {
                Console.WriteLine("Creating file ProductDetails");
                File.Create("SyncCartDS/ProductDetails.csv").Close();
            }
            if(!File.Exists("SyncCartDS/OrderDetails.csv"))
            {
                Console.WriteLine("Creating file OrderDetails");
                File.Create("SyncCartDS/OrderDetails.csv").Close();
            }
        }

        public static void WriteToCSV()
        {
            string [] customers=new string [Operations.customerList.Count];
            for(int i=0;i<Operations.customerList.Count;i++)
            {
                var customer=Operations.customerList[i];
                /*s_customerID++;
            CustomerID="CID"+s_customerID;
            Name=name;
            City=city;
            MobileNumber=mobileNumber;
            EmailID=emailID;
            _walletBalance=walletBalance;*/

                customers[i]=customer.CustomerID+","+customer.Name+","+customer.City+","+customer.MobileNumber+","+customer.EmailID+","+customer.WalletBalance;
            }
            File.WriteAllLines("SyncCartDS/CustomerDetails.csv",customers);

            string [] products=new string[Operations.productList.Count];
            for(int i=0;i<Operations.productList.Count;i++)
            {
                var product=Operations.productList[i];
                /*s_productID++;
        ProductID="PID"+s_productID;
        Name=name;
        Price=price;
        Stock=stock;
        ShippingDuration=shippingDuration;
                products[i]=product.*/
                products[i]=product.ProductID+","+product.Name+","+product.Price+","+product.Stock+","+product.ShippingDuration;

            }
            File.WriteAllLines("SyncCartDS/ProductDetails.csv",products);

            string [] orders=new string[Operations.orderList.Count];
            for(int i=0;i<Operations.orderList.Count;i++)
            {
                var order=Operations.orderList[i];

                /* s_orderID++;
            OrderID="OID"+s_orderID;
            CustomerID=customerID;
            ProductID=productID;
            TotalPrice=totalPrice;
            PurchaseDate=purchaseDate;
            Quantity=quantity;
            Status=status; */

                orders[i]=order.OrderID+","+order.CustomerID+","+order.ProductID+","+order.TotalPrice+","+order.PurchaseDate+","+order.Quantity+","+order.Status;
            }
            File.WriteAllLines("SyncCartDS/orderDetails.csv",orders);

        }

        public static void ReadFromCSV()
        {
            string [] customers=File.ReadAllLines("SyncCartDS/CustomerDetails.csv");
            for(int i=0;i<customers.Length;i++)
            {
                Operations.customerList.Add(new CustomerDetails(customers[i]));
            }
            string [] products=File.ReadAllLines("SyncCartDS/ProductDetails.csv");
            for(int i=0;i<products.Length;i++)
            {
                Operations.productList.Add(new ProductDetails(products[i]));
            }
            string [] orders=File.ReadAllLines("SyncCartDS/OrderDetails.csv");
            for(int i=0;i<orders.Length;i++)
            {
                Operations.orderList.Add(new OrderDetails(orders[i]));
            }
        }
    }
}
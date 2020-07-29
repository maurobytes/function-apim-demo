using System;
using System.Collections.Generic;
using System.Text;

namespace function_apim_demo.Models
{
    class Order
    {
        public int Id { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public double Total { get; set; }
        public bool Shipped { get; set; }

        public Order GetOrder(string customerLastName)
        {
            //This method simulates returning an order,
            //e.g. from a database
            Order returnedOrder = new Order();

            switch (customerLastName)
            {
                case "Henri":
                    returnedOrder.Id = 56224;
                    returnedOrder.CustomerFirstName = "Pascale";
                    returnedOrder.CustomerLastName = "Henri";
                    returnedOrder.Total = 307.98;
                    returnedOrder.Shipped = true;
                    break;
                case "Chiba":
                    returnedOrder.Id = 72945;
                    returnedOrder.CustomerFirstName = "Yuki";
                    returnedOrder.CustomerLastName = "Chiba";
                    returnedOrder.Total = 442.50;
                    returnedOrder.Shipped = false;
                    break;
                case "Barriclough":
                    returnedOrder.Id = 34723;
                    returnedOrder.CustomerFirstName = "Alison";
                    returnedOrder.CustomerLastName = "Barriclough";
                    returnedOrder.Total = 150.99;
                    returnedOrder.Shipped = true;
                    break;
                default:
                    returnedOrder = null;
                    break;
            }

            return returnedOrder;
        }
    }
}

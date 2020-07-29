using System;
using System.Collections.Generic;
using System.Text;

namespace function_apim_demo.Models
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string PartNumber { get; set; }

        public Product GetProduct(string id)
        {
            //This method simulates returning a product,
            //e.g. from a database
            Product returnedProduct = new Product();

            switch (id)
            {
                case "1":
                    returnedProduct.Id = 1;
                    returnedProduct.Name = "Smart Speaker";
                    returnedProduct.PartNumber = "SM562";
                    returnedProduct.Price = 130.00;
                    break;
                case "2":
                    returnedProduct.Id = 2;
                    returnedProduct.Name = "Home Security Camera";
                    returnedProduct.PartNumber = "SC967";
                    returnedProduct.Price = 105.99;
                    break;
                case "3":
                    returnedProduct.Id = 3;
                    returnedProduct.Name = "Smart Dimmer Switch";
                    returnedProduct.PartNumber = "DS728";
                    returnedProduct.Price = 59.99;
                    break;
                default:
                    returnedProduct = null;
                    break;
            }

            return returnedProduct;
        }
    }
}

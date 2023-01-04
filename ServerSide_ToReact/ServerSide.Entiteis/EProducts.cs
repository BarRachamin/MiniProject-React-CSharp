using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


using ServerSide.Modul;

namespace ServerSide.Entiteis
{
    public class EProducts
    {


        //Global Dictionary
        public Dictionary<string, MProducts> ProductsList = new Dictionary<string, MProducts>();


        //Get the product fron the DB
        public Dictionary<string, MProducts> getProductFromDB()
        {
           Data.Sql.ProductsDB product = new Data.Sql.ProductsDB();
            ProductsList = (Dictionary<string, MProducts>)product.SendSqlQueryToReadFromDB();
            return ProductsList;
        }


        // Get the product from Db by ID
        public MProducts getProductByIDFromDB(string productID)
        {
            Data.Sql.ProductsDB product = new Data.Sql.ProductsDB();
            return (Modul.MProducts)product.SendSqlQueryToReadFromDBForOneProduct(productID);


        }

        //Updatethe Product in the DB
        public void UpdateAProductInDb(int productID, int categoryID, int unitsInStock)
        {
            Data.Sql.ProductsDB product = new Data.Sql.ProductsDB();
            product.UpdateAProduct(productID, categoryID, unitsInStock);
        }


        //Delete the product(all the row) in the DB by ID
        public void DeleteAProductByProductID(int productID)
        {
            Data.Sql.ProductsDB product = new Data.Sql.ProductsDB();
            product.DeleteProduct(productID);
        }


    }
}

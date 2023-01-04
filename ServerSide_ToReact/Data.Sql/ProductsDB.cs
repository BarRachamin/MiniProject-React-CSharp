using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Data.Sql
{
    public class ProductsDB
    {
        public Dictionary<string, ServerSide.Modul.MProducts> ReadFromDb(SqlDataReader reader)
        {
            Dictionary<string, ServerSide.Modul.MProducts> ProductsList = new Dictionary<string, ServerSide.Modul.MProducts>();

            //Clear Hashtable Before Inserting Information From Sql Server
            ProductsList.Clear();

            while (reader.Read())
            {
                ServerSide.Modul.MProducts product = new ServerSide.Modul.MProducts();
                product.ProductID = reader.GetInt32(0);
                product.ProductName = reader.GetString(1);
                product.SupplierID = reader.GetInt32(2);
                product.CategoryID = reader.GetInt32(3);
                product.QuantityPerUnit = reader.GetString(4);
                product.UnitPrice = reader.GetDecimal(5);
                product.UnitsInStock = reader.GetInt16(6);
                product.UnitsOnOrder = reader.GetInt16(7);
                product.ReorderLevel = reader.GetInt16(8);
                product.Discontinued= reader.GetBoolean(9);


                //Cheking If Hashtable contains the key
                if (ProductsList.ContainsKey(product.ProductName))
                {
                    //key already exists
                }
                else
                {
                    //Filling a hashtable
                    ProductsList.Add(product.ProductName, product);
                }

            }
            return ProductsList;
        }

        //Function that Read one row from DB
        public ServerSide.Modul.MProducts ReadOneFromDb(SqlDataReader reader)
        {

            ServerSide.Modul.MProducts product = new ServerSide.Modul.MProducts();
            while (reader.Read())
            {

                product.ProductID = reader.GetInt32(0);
                product.ProductName = reader.GetString(1);
                product.SupplierID = reader.GetInt32(2);
                product.CategoryID = reader.GetInt32(3);
                product.QuantityPerUnit = reader.GetString(4);
                product.UnitPrice = reader.GetDecimal(5);
                product.UnitsInStock = reader.GetInt16(6);
                product.UnitsOnOrder = reader.GetInt16(7);
                product.ReorderLevel = reader.GetInt16(8);
                product.Discontinued = reader.GetBoolean(9);


            }
            return product;
        }

        //function that send Sql Query to Read from The DB
        public object SendSqlQueryToReadFromDB()
        {
            string SqlQuery = "select * from newProducts";
            object retDict = null;
            retDict = ServerSide.Dal.DB_Connection.StartReadFromDB(SqlQuery, ReadFromDb);
            return retDict;
        }

        //Function that Send Sql Query to Read from DB for one product by ID
        public object SendSqlQueryToReadFromDBForOneProduct(string productID)
        {
            string SqlQuery = "select * from newProducts where ProductID = '" + productID + "'";
            object retObject = ServerSide.Dal.DB_Connection.StartReadFromDB(SqlQuery, ReadOneFromDb);
            return retObject;


        }

        //Function that Update the Category and Units in Stock by ProductID
        public void UpdateAProduct(int productID, int categoryID, int unitsInStock)
        {


            string updateQuery = "update newProducts set CategoryID = @categoryID, UnitsInStock = @unitsInStock where ProductID = @productID";
            ServerSide.Dal.DB_Connection.UpdateRowById(updateQuery, productID, categoryID, unitsInStock);

        }


        //Function that Delete Product Row by ProductID
        public void DeleteProduct(int productID)
        {


            string deleteQuery = "delete from newProducts where ProductID = @productID ";
            ServerSide.Dal.DB_Connection.DeleteFromSqlServer(deleteQuery, productID);


        }
    }
}

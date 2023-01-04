import React, { useState, useEffect } from "react";
import { deleteProductFromDb, getProducts } from "../../services/service";
import "./products.css";
import { ClockLoader } from "react-spinners";
import { useNavigate } from "react-router-dom";

export const ProductsPage = () => {
  const [productsData, setProductsData] = useState([]);
  const navigate = useNavigate();

  //get the products from the DB
  const getProductsFromDB = async () => {
    let res = await getProducts();
    setProductsData(res);
  };

  useEffect(() => {
    setTimeout(() => {
      getProductsFromDB();
    }, 3000);

    console.log(productsData);
  }, []);

  const [expanded, setExpanded] = useState(false);
  const [key, setKey] = useState();

  function handleClick(productKey) {
    setExpanded(!expanded);
    setKey(productKey);
    //console.log("try");
  }

  const handleUpadate = (product, ProductID, ProductName) => {
    navigate("/editProduct", {
      state: {
        product,
        ProductID,
        ProductName,
      },
    });
  };

  const handleDelete = (ProductID) => {
    deleteProductFromDb(ProductID);
  };

  return (
    <div className="my-tbl">
      <table className="table table-striped">
        <thead>
          <tr>
            <th scope="col">#</th>
            <th scope="col">Product Name</th>
            <th scope="col">Price</th>
            <th scope="col">Units In Stock</th>
            <th scope="col"></th>
            <th scope="col"></th>
          </tr>
        </thead>
        <tbody>
          {productsData && productsData.length > 0 ? (
            productsData.map((product) => {
              return (
                <>
                  <tr onClick={() => handleClick(product.ProductID)}>
                    <th scope="row">{product.ProductID}</th>
                    <td>{product.ProductName}</td>
                    <td>{product.UnitPrice}$</td>
                    <td>{product.UnitsInStock}</td>
                    <td>
                      <button
                        className="btn btn-primary"
                        onClick={() =>
                          handleUpadate(
                            product,
                            product.ProductID,
                            product.ProductName
                          )
                        }
                      >
                        Edit
                      </button>
                    </td>
                    <td>
                      <button
                        className="btn btn-danger"
                        onClick={() => handleDelete(product.ProductID)}
                      >
                        Delete
                      </button>
                    </td>
                  </tr>
                  {expanded && product.ProductID === key ? (
                    <tr className="expanded">
                      <td colSpan={4} className="expanded">
                        <h4>{product.ProductName} Description : </h4>
                        {product.QuantityPerUnit}
                      </td>
                    </tr>
                  ) : null}
                </>
              );
            })
          ) : (
            <tr className="clock--tr">
              <td className="clock--td" colSpan={4}>
                <ClockLoader color="#99a7f3" size={86} />
              </td>
            </tr>
          )}
        </tbody>
      </table>
    </div>
  );
};

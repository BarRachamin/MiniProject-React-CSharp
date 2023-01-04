import React, { useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { UpdateProductsById } from "../../services/service";
import "./updatePage.css";

export const UpdateProductPage = () => {
  const [UnitPrice, setUnitPrice] = useState("");
  const [UnitInstock, setUnitInstock] = useState("");

  const navigate = useNavigate();

  const location = useLocation();

  const { product, productID, productName } = location.state;

  //To handle the Uapdate by ProductID
  const handleSubmit = async (event) => {
    event.preventDefault();
    if (UnitPrice === "" || UnitInstock === "") {
      alert("Please enter all required");
    } else {
      const updatedProduct = {
        ...product,
        CategoryID: parseInt(UnitPrice),
        UnitsInStock: parseInt(UnitInstock),
      };
      console.log(updatedProduct);
      await UpdateProductsById(updatedProduct, productID);
      navigate("/Products");
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <h1>update a Product </h1>
      <div className="form-group">
        <label className="formLbl" htmlFor="name">
          Product ID:
        </label>
        <input
          type="text"
          className="form-control"
          id="name"
          defaultValue={productID}
        />
      </div>
      <div className="form-group">
        <label className="formLbl" htmlFor="message">
          Product Name:
        </label>
        <textarea
          className="form-control"
          id="message"
          defaultValue={productName}
        />
      </div>
      <div className="form-group">
        <label className="formLbl" htmlFor="phone">
          Category ID:
        </label>
        <input
          type="tel"
          className="form-control"
          id="phone"
          value={UnitPrice}
          onChange={(event) => setUnitPrice(event.target.value)}
        />
      </div>
      <div className="form-group">
        <label className="formLbl" htmlFor="email">
          Units In Stock:
        </label>
        <input
          type="number"
          className="form-control"
          id="number"
          value={UnitInstock}
          onChange={(event) => setUnitInstock(event.target.value)}
        />
      </div>

      <button type="submit" className="btn btn-primary">
        Submit
      </button>
    </form>
  );
};

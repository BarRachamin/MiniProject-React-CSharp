import axios from "axios";

//Get all products from server
export const getProducts = async () => {
  return await axios
    .get("http://localhost:7185/api/Users/GET")
    .then((response) => {
      return Object.values(response.data);
    })
    .catch((error) => {
      console.log(error);
    });
};

//To add a Message
export const addMessage = async (CostumerMessage) => {
  console.log(CostumerMessage);
  await axios.post("http://localhost:7185/api/Users/ADD", CostumerMessage);
};

//To get product by ID
export const getProductsById = async (ProductId) => {
  return await axios
    .get(`http://localhost:7185/api/Users/ADD/${ProductId}`)
    .then((response) => {
      return Object.values(response.data);
    })
    .catch((error) => {
      console.log(error);
    });
};

//To update Productd
export const UpdateProductsById = async (ProductToUpdate) => {
  await axios.post(
    "http://localhost:7185/api/Users/UpdateOne",
    ProductToUpdate
  );
};

//To Delete Product
export const deleteProductFromDb = async (ProductID) => {
  try {
    console.log(ProductID);
    let endpoint = `http://localhost:7185/api/Users/DELETE/${ProductID}`;
    await axios.delete(endpoint);
  } catch (error) {
    console.error(error);
  }
};

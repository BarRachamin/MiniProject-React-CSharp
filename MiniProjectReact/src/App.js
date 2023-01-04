import { useAuth0 } from "@auth0/auth0-react";
import { Routes, Route } from "react-router-dom";
import "./App.css";
import { NavBarComponent } from "./components/navBar/navBar.component";
import { AboutPage } from "./Pages/aboutPage/about.Page";
import { ContactUsForm } from "./Pages/contactUsPage/contactus.form.Page";
import { HomePage } from "./Pages/homePage/home.Page";
import { LoginPage } from "./Pages/loginPage/loginPage";
import { ProductsPage } from "./Pages/ProductsPage/products.Page";
import { Profile } from "./Pages/profilePage/profilePage.Page";
import { UpdateProductPage } from "./Pages/oneProductUpdate/updateProductPage";

export const App = () => {
  const { isAuthenticated, isLoading } = useAuth0();

  if (!isLoading) {
    if (isAuthenticated) {
      return (
        <div className="App">
          <NavBarComponent />
          <Routes>
            <Route path="/" element={<HomePage />}></Route>
            <Route path="/about" element={<AboutPage />}></Route>
            <Route path="/contactus" element={<ContactUsForm />}></Route>
            <Route path="/products" element={<ProductsPage />}></Route>
            <Route path="/profile" element={<Profile />}></Route>
            <Route path="/editProduct" element={<UpdateProductPage />}></Route>
          </Routes>
        </div>
      );
    } else {
      return <LoginPage />;
    }
  } else {
    <h1>loading</h1>;
  }
};

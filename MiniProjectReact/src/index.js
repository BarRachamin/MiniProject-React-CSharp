import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import { App } from "./App";
import "../node_modules/bootstrap/dist/css/bootstrap.css";
import { BrowserRouter } from "react-router-dom";
import { Auth0Provider } from "@auth0/auth0-react";

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <React.StrictMode>
    <BrowserRouter>
      <Auth0Provider
        domain="dev-4ekxh54lhtl10rwj.us.auth0.com"
        clientId="to8ThLxAK1pnzo4ub4IAF88wR7Gke0K5"
        redirectUri={window.location.origin}
      >
        <App />
      </Auth0Provider>
    </BrowserRouter>
  </React.StrictMode>
);

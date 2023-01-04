import React from "react";
import { Link } from "react-router-dom";
import HomeIcon from "@mui/icons-material/Home";
import InfoIcon from "@mui/icons-material/Info";
import CallIcon from "@mui/icons-material/Call";
import MeetingRoomIcon from "@mui/icons-material/MeetingRoom";
import RedeemIcon from "@mui/icons-material/Redeem";
import FaceIcon from "@mui/icons-material/Face";
import { useAuth0 } from "@auth0/auth0-react";
import "./navbar.css";

//remote the page with the route
export const NavBarComponent = (props) => {
  const { user, logout } = useAuth0();
  return (
    <div className="container">
      <ul className="menu">
        <li>
          <Link to="/">
            <HomeIcon />
            <label className="navLbl">Home</label>
          </Link>
        </li>
        <li>
          <Link to="/about">
            <InfoIcon />
            <label className="navLbl">About</label>
          </Link>
        </li>
        <li>
          <Link to="/contactus">
            <CallIcon />
            <label className="navLbl">Contact Us</label>
          </Link>
        </li>
        <li>
          <Link to="/products">
            <RedeemIcon />
            <label className="navLbl">Products</label>
          </Link>
        </li>
        <li className="user-li">
          <Link to="/profile">
            <img className="img" src={user.picture} alt={user.name} />
            <label className="navLbl">{user.name}</label>
          </Link>
        </li>
        <li className="loguot">
          <Link to="/logout">
            <MeetingRoomIcon />
            <label
              className="navLbl"
              onClick={() => logout({ returnTo: window.location.origin })}
            >
              Logout
            </label>
          </Link>
        </li>
      </ul>
    </div>
  );
};

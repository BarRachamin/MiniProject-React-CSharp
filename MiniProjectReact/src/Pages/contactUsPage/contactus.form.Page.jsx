import React, { useState } from "react";
import { addMessage } from "../../services/service";
import "./contactus.css";

export const ContactUsForm = () => {
  const [Name, setName] = useState("");
  const [Message, setMessage] = useState("");
  const [CellPhone, setPhone] = useState("");
  const [Email, setEmail] = useState("");

  //To handle the User Message
  const handleSubmit = (event) => {
    event.preventDefault();
    const costumerMessage = { Name, Message, CellPhone, Email };
    if (Name === "" || Message === "" || CellPhone === "" || Email === "") {
      alert("Please enter all required");
    } else {
      addMessage(costumerMessage);
      alert("we recive your comment, thanks for it");
      setName("");
      setMessage("");
      setPhone("");
      setEmail("");
    }
  };

  return (
    <div className="containerContactUS">
      <h1>We want to hear from you</h1>
      <div className="form-group">
        <label className="formLbl" htmlFor="name">
          Costumer Name:
        </label>
        <input
          type="text"
          className="form-control"
          id="name"
          value={Name}
          onChange={(event) => setName(event.target.value)}
        />
      </div>
      <div className="form-group">
        <label className="formLbl" htmlFor="message">
          Message:
        </label>
        <textarea
          className="form-control"
          id="message"
          value={Message}
          onChange={(event) => setMessage(event.target.value)}
        />
      </div>
      <div className="form-group">
        <label className="formLbl" htmlFor="phone">
          Phone Number:
        </label>
        <input
          type="tel"
          className="form-control"
          id="phone"
          value={CellPhone}
          onChange={(event) => setPhone(event.target.value)}
        />
      </div>
      <div className="form-group">
        <label className="formLbl" htmlFor="email">
          Email Address:
        </label>
        <input
          type="email"
          className="form-control"
          id="email"
          value={Email}
          onChange={(event) => setEmail(event.target.value)}
        />
      </div>

      <button onClick={handleSubmit} type="submit" className="btn btn-primary">
        Submit
      </button>
    </div>
  );
};

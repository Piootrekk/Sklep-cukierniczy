import React from "react";
import classes from "./UserMenu.module.css";
import Input from "../UI/Input";
import { useRef, useState } from "react";

const Register  = (props) => {
    const nameRef = useRef();
    const emailRef = useRef();
    const passwordRef = useRef();
  
    const [registrationData, setRegistrationData] = useState({
      name: "",
      email: "",
      password: "",
    });
  
    const handleInputChange = (event) => {
      const { name, value } = event.target;
      setRegistrationData((prevData) => ({
        ...prevData,
        [name]: value,
      }));
    };
  
    const handleSubmit = (event) => {
      event.preventDefault();
      // Handle form submission logic here
      console.log(registrationData);
      // Reset form fields
      setRegistrationData({
        name: "",
        email: "",
        password: "",
      });
      // Focus on the first input field
      nameRef.current.focus();
    };
  
    return (
        <div className={classes.total}>
      <form onSubmit={handleSubmit}>
        <Input
          ref={nameRef}
          label="Nazwa"
          input={{
            id: "name",
            type: "text",
            name: "name",
            value: registrationData.name,
            onChange: handleInputChange,
          }}
        />
        <Input
          ref={emailRef}
          label="Email"
          input={{
            id: "email",
            type: "email",
            name: "email",
            value: registrationData.email,
            onChange: handleInputChange,
          }}
        />
        <Input
          ref={passwordRef}
          label="Hasło"
          input={{
            id: "password",
            type: "password",
            name: "password",
            value: registrationData.password,
            onChange: handleInputChange,
          }}
        />
        <button type="submit">Register</button>
      </form>
        </div>
    );
  };

export default Register;

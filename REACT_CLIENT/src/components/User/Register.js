import React, { useRef, useState } from "react";
import classes from "./UserMenu.module.css";
import Input from "../UI/Input";

const Register = (props) => {
  const nameRef = useRef();
  const emailRef = useRef();
  const passwordRef = useRef();
  const confirmPasswordRef = useRef();

  const [registrationData, setRegistrationData] = useState({
    name: "",
    email: "",
    password: "",
    confirmPassword: "",
  });

  const [errors, setErrors] = useState({
    name: "",
    email: "",
    password: "",
    confirmPassword: "",
  });

  const [isButtonDisabled, setIsButtonDisabled] = useState(true);

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setRegistrationData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const handleInputBlur = (field) => {
    let error = "";

    switch (field) {
      case "name":
        if (registrationData.name.trim() === "") {
          error = "Pole jest wymagane!";
        } else if (
          registrationData.name.length < 8 ||
          registrationData.name.length > 30
        ) {
          error = "Login musi mieć od 8 do 30 znaków!";
        }
        setErrors((prevErrors) => ({
          ...prevErrors,
          name: error,
        }));
        break;
      case "email":
        if (registrationData.email.trim() === "") {
          error = "Pole jest wymagane!";
        }
        setErrors((prevErrors) => ({
          ...prevErrors,
          email: error,
        }));
        break;
      case "password":
        if (registrationData.password.trim() === "") {
          error = "Pole jest wymagane!";
        } else if (
          registrationData.password.length < 8 ||
          registrationData.password.length > 50
        ) {
          error = "Hasło musi mieć od 8 do 50 znaków!";
        }
        setErrors((prevErrors) => ({
          ...prevErrors,
          password: error,
        }));
        break;
      case "confirmPassword":
        if (registrationData.confirmPassword.trim() === "") {
          error = "Pole jest wymagane!";
        } else if (
          registrationData.password !== registrationData.confirmPassword
        ) {
          error = "Hasła nie są identyczne!";
        }
        setErrors((prevErrors) => ({
          ...prevErrors,
          confirmPassword: error,
        }));
        break;
      default:
        break;
    }
  };

  const handleSubmit = (event) => {
    event.preventDefault();

    if (
      errors.name ||
      errors.email ||
      errors.password ||
      errors.confirmPassword
    ) {
      return;
    }

    console.log(registrationData);
    setRegistrationData({
      name: "",
      email: "",
      password: "",
      confirmPassword: "",
    });
    nameRef.current.focus();
  };

  const checkFormValidity = () => {
    return Object.values(errors).every((error) => error === "");
  };

  const handleInputFocus = () => {
    setIsButtonDisabled(true);
  };

  const handleInputKeyUp = () => {
    setIsButtonDisabled(!checkFormValidity());
  };

  return (
    <div className={classes.total}>
      <form onSubmit={handleSubmit}>
        <h2>Rejestracja Użytkownika:</h2>
        <Input
          ref={nameRef}
          label="Nazwa*:"
          input={{
            id: "name",
            type: "text",
            name: "name",
            value: registrationData.name,
            onChange: handleInputChange,
            onBlur: () => handleInputBlur("name"),
            onFocus: handleInputFocus,
            onKeyUp: handleInputKeyUp,
          }}
        />
        {errors.name && <p className={classes.error}>{errors.name}</p>}
        <Input
          ref={emailRef}
          label="Email*:"
          input={{
            id: "email",
            type: "email",
            name: "email",
            value: registrationData.email,
            onChange: handleInputChange,
            onBlur: () => handleInputBlur("email"),
            onFocus: handleInputFocus,
            onKeyUp: handleInputKeyUp,
          }}
        />
        {errors.email && <p className={classes.error}>{errors.email}</p>}
        <Input
          ref={passwordRef}
          label="Hasło*:"
          input={{
            id: "password",
            type: "password",
            name: "password",
            value: registrationData.password,
            onChange: handleInputChange,
            onBlur: () => handleInputBlur("password"),
            onFocus: handleInputFocus,
            onKeyUp: handleInputKeyUp,
          }}
        />
        {errors.password && <p className={classes.error}>{errors.password}</p>}
        <Input
          ref={confirmPasswordRef}
          label="Powtórz*:"
          input={{
            id: "confirmPassword",
            type: "password",
            name: "confirmPassword",
            value: registrationData.confirmPassword,
            onChange: handleInputChange,
            onBlur: () => handleInputBlur("confirmPassword"),
            onFocus: handleInputFocus,
            onKeyUp: handleInputKeyUp,
          }}
        />
        {errors.confirmPassword && (
          <p className={classes.error}>{errors.confirmPassword}</p>
        )}
        <button
          type="submit"
          className={classes.actions}
          disabled={isButtonDisabled}
        >
          Register
        </button>
      </form>
    </div>
  );
};

export default Register;

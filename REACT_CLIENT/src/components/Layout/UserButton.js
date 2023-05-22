import React, { useState } from "react";
import classes from "./HeaderCart.module.css";
import user from "../../assets/user.svg";
import UserMenu from "../User/UserMenu";

const UserButton = (props) => {
  const [isMenuOpen, setMenuOpen] = useState(false);

  const toggleMenu = () => {
    if (props.isModalAvailable) {
      setMenuOpen(!isMenuOpen);
    }
  };

  return (
    <div className={classes.container}>
      <button className={classes.button} onClick={toggleMenu}>
        <span className={classes.icon}>
          <img src={user} alt="User" />
        </span>
        <span>{props.value}</span>
      </button>
      {props.isModalAvailable && isMenuOpen && (
        <UserMenu onClose={toggleMenu} />
      )}
    </div>
  );
};

export default UserButton;
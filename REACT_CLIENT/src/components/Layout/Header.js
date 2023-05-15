import { Fragment } from "react";
import classes from "./Header.module.css";
import searchIcon from "../../assets/search.svg";
import cart from "../../assets/cart.svg";
import user from "../../assets/user.svg";

const Header = (props) => {
  return (
    <header className={classes.header}>
      <h1 className={classes.logo}>Zaczarowana Cukiernia</h1>
      <div className={classes.buttons}>
        <button><img src={cart} className={classes.icon}/></button>
        <button><img src={user} className={classes.icon}/></button>
      </div>
    </header>
  );
};

export default Header;

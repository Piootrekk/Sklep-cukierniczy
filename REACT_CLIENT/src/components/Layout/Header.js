import { Fragment } from "react";
import HeaderCart from "./HeaderCart";

import classes from "./Header.module.css";
import PhotoHeader from "../../assets/PhotoHeader.png";

const Header = (props) => {
  return (
    <Fragment>
      <header className={classes.header}>
        <h1>ZaczarowanaCukiernia</h1>
        <HeaderCart onClick={props.onShowCart}/>
      </header>
      <div className={classes["main-image"]}>
        <img src={PhotoHeader} alt="A table full of delicious food!" />
      </div>
    </Fragment>
  );
};

export default Header;

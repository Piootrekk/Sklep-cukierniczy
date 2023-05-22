import { Fragment } from "react";
import HeaderCart from "./HeaderCart";

import classes from "./Header.module.css";
import PhotoHeader from "../../assets/PhotoHeader.png";
import logo from "../../assets/ciastko_usmiech_beznapis.png";
import UserButton from "./UserButton";

const Header = (props) => {
  return (
    <Fragment>
      <header className={classes.header}>
        <section className={classes.div}>
          <img src={logo} className={classes.imageLogo} alt="logo" />
          <h1>ZaczarowanaCukiernia</h1>
        </section>
        <section className={classes.div}>
          <HeaderCart onClick={props.onShowCart} />
          <UserButton value="LOGIN"/>
          <UserButton value="REGISTER"/>
          {/* <UserButton  isModalAvailable={true}/> */}
        </section>
      </header>
      <div className={classes["main-image"]}>
        <img src={PhotoHeader} alt="A table full of delicious food!" />
      </div>
    </Fragment>
  );
};

export default Header;

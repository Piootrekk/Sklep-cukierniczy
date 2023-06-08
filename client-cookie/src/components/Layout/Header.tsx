import { Fragment } from "react";
import HeaderCart from "./HeaderCart";

import classes from "./Header.module.css";
import PhotoHeader from "../../assets/PhotoHeader.png";
import logo from "../../assets/ciastko___/ciastko_napis.png";
import UserButton from "./UserButton";
import NavLink from "./NavLink";
import { useNavigate } from "react-router-dom";

const Header = (props: any) => {
  const navigate = useNavigate();
  return (
    <Fragment>
      <header className={classes.header}>
        <section className={classes.div}>
          <img src={logo} className={classes.imageLogo} alt="logo" />
          <h1 onClick={() => navigate('/')}>ZaczarowanaCukiernia</h1>
        </section>
        <section className={classes.div}>
          <HeaderCart onClick={props.onShowCart} />
          <UserButton />
          <NavLink onClick={() => navigate('/configurator')} />
        </section>
      </header>
      <div className={classes["main-image"]}>
        <img src={PhotoHeader} alt="A table full of delicious food!" />
      </div>
    </Fragment>
  );
};

export default Header;
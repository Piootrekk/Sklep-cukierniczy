import React from "react";
import classes from "./HeaderCart.module.css";
import user from "../../assets/user.svg";

const UserButton = (props) => {
return <button className={classes.button}>
    <span className={classes.icon} style={{ marginRight: 0 }} >
        <img src={user} alt="Cart" />
      </span>
</button>;
};

export default UserButton;
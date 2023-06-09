import classes from "./HeaderCart.module.css";
import user from "../../assets/user.svg";

const UserButton = () => {
return <button className={classes.button}>
    <span className={classes.icon} style={{ marginRight: 0 }} >
        <img src={user} alt="Cart" />
      </span>
</button>;
};

export default UserButton;
import { useContext } from "react";
import Cart from "../../assets/cart.svg";
import classes from "./HeaderCart.module.css";
import { CartContext } from "../../storage/CartProvider";

const HeaderCart = (props: any) => {
    const cartCtx = useContext(CartContext);
    const numberOfCartItems = cartCtx.items.reduce((curNumber, item) => {return curNumber + item.amountInStock}, 0);

    return (
    <button className={classes.button} onClick={props.onClick}>
      <span className={classes.icon}>
        <img src={Cart} alt="Cart" />
      </span>
      <span>Koszyk</span>
      <span className={classes.badge}>{numberOfCartItems}</span>
    </button>
  );
};

export default HeaderCart;

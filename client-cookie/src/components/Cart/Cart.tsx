import classes from "./Cart.module.css";
import Modal from "../UI/Model";
import { useContext } from "react";
import CartItem from "./CartItem";
import { CartContext, CartReturn } from "../../storage/CartProvider";
import { Ingredient } from "../Configurator/Configurator";

const Cart = ({ onClose }: { onClose: () => void}) => {
  const cartCtx = useContext(CartContext);
  const hasItems = cartCtx.items.length > 0;
  const cartItemAddHandler = (item: Ingredient) => {
    (cartCtx as CartReturn).addItem({...item, amountInStock: 1});
};
  const cartItems = (
    <ul className={classes["cart-items"]}>
      {cartCtx.items.map((item) => (
        <CartItem
          id={item.id}
          key={item.id}
          name={item.name}
          amount={item.amountInStock}
          price={item.priceBrutto}
          onRemove={() => (cartCtx as CartReturn).removeItem(item.id)}
          onAdd={() => cartItemAddHandler(item)}
        />
      ))}
    </ul>
  );

  return (
    <Modal onClose={onClose}>
      {cartItems}
      <div className={classes.total}>
        <span>Cena Całkowita</span>
        <span>{cartCtx.totalAmount.toFixed(2)} PLN</span>
      </div>
      <div className={classes.actions}>
        <button className={classes["button--alt"]} onClick={onClose}>
          Zamknij
        </button>
        {hasItems && <button className={classes.button}>Zamów</button>}
      </div>
    </Modal>
  );
};

export default Cart;

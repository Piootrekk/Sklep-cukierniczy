import classes from "./Cart.module.css";
import Modal from "../UI/Model";
import { useContext } from "react";
import CartContext from "../../storage/CartContext";
import CartItem from "./CartItem";

const Cart = (props) => {
  const cartCtx = useContext(CartContext);
  const hasItems = cartCtx.items.length > 0;

    const cartItemRemoveHandler = (id) => {
        cartCtx.removeItem(id);
    };
    const cartItemAddHandler = (item) => {
        cartCtx.addItem({...item, amount: 1});
    };

  const cartItems = (
    <ul className={classes["cart-items"]}>
      {cartCtx.items.map((item) => (
        // <CartItem key={item.id} name={item.name} amount={item.amount} price={item.price} onRemove={cartCtx.removeItem.bind(null, item.id)} onAdd={cartCtx.addItem.bind(null, item)} />
        <CartItem key={item.id} name={item.name} amount={item.amount} price={item.price} onRemove={cartItemRemoveHandler.bind(null, item.id)} onAdd={cartItemAddHandler.bind(null, item)} />
      ))}
    </ul>
  );

  return (
    <Modal onClose={props.onClose}>
      {cartItems}
      <div className={classes.total}>
        <span>Cena Całkowita</span>
        <span>{cartCtx.totalAmount.toFixed(2)} PLN</span>
      </div>
      <div className={classes.actions}>
        <button className={classes["button--alt"]} onClick={props.onClose}>
          Zamknij
        </button>
        {hasItems && <button className={classes.button}>Zamów</button>}
      </div>
    </Modal>
  );
};

export default Cart;

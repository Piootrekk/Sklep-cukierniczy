import classes from './CartItem.module.css';
import { PropsCartItem } from './interfaces/CartInterfaces';

const CartItem = ({priceBrutto, name, amount, onRemove, onAdd}: PropsCartItem ) => {
  const priceFixed = `${priceBrutto.toFixed(2)} PLN`; 
  return (
    <li className={classes['cart-item']}>
      <div>
        <h2>{name}</h2>
        <div className={classes.summary}>
          <span className={classes.priceBrutto}>{priceFixed}</span>
          <span className={classes.amount}>x {amount}</span>
        </div>
      </div>
      <div className={classes.actions}>
        <button onClick={onRemove}>−</button>
        <button onClick={onAdd}>+</button>
      </div>
    </li>
  );
};

export default CartItem;

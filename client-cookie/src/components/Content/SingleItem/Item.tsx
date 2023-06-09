import React, { useContext } from "react";
import classes from "./Item.module.css";
import FormItem from "./FormItem";
import { CartContext, CartReturn } from "../../../storage/CartProvider";
import { Ingredient } from "../../../storage/CustomCakeCont";

const Item: React.FC<Ingredient> = (props) => {
  const cartCtx = useContext(CartContext);

  const addItemHandler = (amount: number) => {

    return (cartCtx as CartReturn).addItem({
      uid: props.uid,
      id: props.id,
      name: props.name,
      amountInStock: amount,
      priceBrutto: props.priceBrutto,
      categoryId: props.categoryId,
      configurationPositionId: props.configurationPositionId,
      description: props.description,
      images: props.images,
      isActive: props.isActive,
      isIngredient: props.isIngredient
  });
  };

  return (
    <li className={classes.item}>
      <div>
        <h3>{props.name}</h3>
        <div className={classes.description}>{props.description}</div>
        <div className={classes.price}>{props.priceBrutto.toFixed(2)} PLN</div>
      </div>
      <div>
        <FormItem id={props.id} addItem={addItemHandler} />
      </div>
    </li>
  );
};

export default Item;
import React from "react";
import classes from "./AvailableCakes.module.css";
import Card from "../UI/Card";
import Item from "./SingleItem/Item";
import { Ingredient } from "../../storage/CustomCakeCont";
import classname from "../Cart/Cart.module.css";


const AvailableCakes: React.FC<{ products: Ingredient[], showCartHandler: () => void}> = ({products, showCartHandler}) => {
  return (
      <section className={classes.cakes}>
              <div style={{ marginTop: 10, marginBottom: 10}} className={classname.actions}>
          <button
            className={classname.button}
            onClick={showCartHandler}
            >Dodaj produkt</button>
        </div>
        <Card>
          <ul>{products.filter((i: Ingredient) => i.isIngredient === false).map((cake: Ingredient) => <Item
            uid={cake.uid}
            id={cake.id}
            key={cake.id}
            description={cake.description}
            name={cake.name}
            priceBrutto={cake.priceBrutto}
            images={cake.images}
            amountInStock={cake.amountInStock}
            categoryId={cake.categoryId}
            configurationPositionId={cake.configurationPositionId}
            isActive={cake.isActive}
            isIngredient={cake.isIngredient}
          />)}</ul>
        </Card>
      </section>
  );
};

export default AvailableCakes;
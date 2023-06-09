import React from "react";
import classes from "./AvailableCakes.module.css";
import Card from "../UI/Card";
import Item from "./SingleItem/Item";
import { Ingredient } from "../../storage/CustomCakeCont";


const AvailableCakes: React.FC<{ products: Ingredient[]}> = ({products}) => {
  return (
      <section className={classes.cakes}>
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
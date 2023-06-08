import React from "react";
import classes from "./AvailableCakes.module.css";
import Card from "../UI/Card";
import Item from "./SingleItem/Item";
import Async from "../Async/Async";
import { useCustomCookApi } from "../Configurator/Repositories/configuratorRepositories";
import { Ingredient } from "../Configurator/Configurator";

const AvailableCakes: React.FC = () => {
  const getCakes = useCustomCookApi();
  return (
    <Async action={() => getCakes()}>
      {data => 
        <section className={classes.cakes}>
          <Card>
            <ul>{data.value.map((cake: Ingredient) => <Item
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
      }
    </Async>
  );
};

export default AvailableCakes;
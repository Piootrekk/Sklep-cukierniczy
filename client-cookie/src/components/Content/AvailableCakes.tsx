import React, { useState } from "react";
import classes from "./AvailableCakes.module.css";
import Card from "../UI/Card";
import Item from "./SingleItem/Item";
import Async from "../Async/Async";
import { useGetAllProducts, useGetCategories } from "../Configurator/Repositories/configuratorRepositories";
import { Ingredient } from "../../storage/CustomCakeCont";
import Modal from "../UI/Model";
import CakesForm from "./CakesForm";
import classname from "../Cart/Cart.module.css";


const AvailableCakes: React.FC = () => {
  const getAllProducts = useGetAllProducts();
  const getCategories = useGetCategories();

  const [addProductModalIsShown, setCartIsShown] = useState(false);
  const showCartHandler = () => {
    setCartIsShown(true);
  };
  const hideCartHandler = () => {
    setCartIsShown(false);
  };
  return (
    <Async action={() => Promise.all([getAllProducts(), getCategories()])}>
      {data =>
        <section className={classes.cakes}>
          <div style={{ marginBottom: 10}} className={classname.actions}>
          <button
            className={classname.button}
            onClick={showCartHandler}
            >Dodaj produkt</button>

          </div>
          {addProductModalIsShown && <Modal onClose={hideCartHandler}>
            <CakesForm categories={data[1].value} />
          </Modal>}
          <Card>
            <ul>{data[0].value.filter((i: Ingredient) => i.isIngredient === false).map((cake: Ingredient) => <Item
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
      }
    </Async>
  );
};

export default AvailableCakes;
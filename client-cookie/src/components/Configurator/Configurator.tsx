import React, { useContext } from "react";
import Async from "../Async/Async";
import { useGetAllIngredients, useGetCategories } from "./Repositories/configuratorRepositories";
import { CakeContext } from "../../storage/CustomCakeCont";
import classes from "./Configurator.module.css";
import MyForm from "./Container/ConfiguratorForm";

export interface Image {
  added: Date;
  id: number;
  isDeleted: false;
  name: string;
  url: string;
}
export interface Ingredient {
  categoryId: number;
  configurationPositionId: number;
  amountInStock: number;
  description: string;
  id: number;
  isIngredient: boolean;
  images: Image[];
  isActive: boolean;
  name: string;
  priceBrutto: number
}

export const CakeVisualization: React.FC = () => {
  const getAllIngredients = useGetAllIngredients();
  const getCategories = useGetCategories();
  return (
    <Async action={() => Promise.all([getAllIngredients(), getCategories()])}>
      {data => <div className={classes.container}>
        <Cake />
        <IngredientList data={data[0]} />
        <MyForm categories={data[1].value}/>
      </div>}
    </Async>
  );
};

interface ICake {
  data: any
}

const Cake = () => {
  const cakeContext = useContext(CakeContext);
  return <div className={classes.cake}>
    {cakeContext?.cake.ingredients.map(({name, images, id}) => <div onClick={() => cakeContext.removeIngredient(id)}>
      {images[0] ? <img width={300} height={50} src={images[0]?.url} alt={images[0]?.name} /> : name}
      </div>)}
  </div>
}
export const IngredientList = (props: ICake) => {
  const cakeContext = useContext(CakeContext);
  if (!cakeContext) {
    return null;
  }

  const { addIngredient } = cakeContext;

  return (
    <div className={classes.ingredients}>
      <h3>Dostępne składniki:</h3>
      <ul>
        {props.data.value.map((ingredient: any) => (
          <li key={ingredient.id}>
            {ingredient.name} - ${ingredient.priceBrutto.toFixed(2)}{" "}
            <button onClick={() => addIngredient(ingredient)}>
              Add to Cake
            </button>
          </li>
        ))}
      </ul>
    </div>
  );
};

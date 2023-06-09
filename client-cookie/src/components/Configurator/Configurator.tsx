import React, { useContext } from "react";
import Async from "../Async/Async";
import { useGetAllIngredients, useGetCategories } from "./Repositories/configuratorRepositories";
import { CakeContext, Ingredient } from "../../storage/CustomCakeCont";
import classes from "./Configurator.module.css";
import MyForm from "./Container/ConfiguratorForm";
import { v4 as uuidv4 } from 'uuid';
import HorizontalLinearStepper from "./Container/Stepper";
import { useStepperContext } from "./Providers/StepperProvider";
import { Button, Container } from "@mui/material";
export interface Image {
  added: Date;
  id: number;
  isDeleted: false;
  name: string;
  url: string;
}

export const CakeVisualization: React.FC = () => {
  const getAllIngredients = useGetAllIngredients();
  const getCategories = useGetCategories();
  const {
    activeStep
  } = useStepperContext();
  return (
    <Async action={() => Promise.all([getAllIngredients(), getCategories()])}>
      {data =>
        <>
          <section className={classes.summary}>
            <h2>Witaj w konfiguratorze! <br /> Zróbmy razem własne ciasto!</h2>
            <p>
              Wybierz swoje ulubione składniki z naszej oferty!
            </p>
            <p>
              Wszystkie nasze składniki są najwyższej jakości!
              Zamów już dziś!
            </p>
          </section>
          <Container maxWidth="lg" sx={{ mt: 5 }}>
            <div className={classes.container}>
              <HorizontalLinearStepper />
              <div>
                {activeStep === 0 &&
                  <div className={classes.configuratorBox}>
                    <Cake />
                    <IngredientList data={data[0]} />
                  </div>
                }
                {activeStep === 1 && <MyForm categories={data[1].value} />}
              </div>

            </div>
          </Container>
        </>}
    </Async >
  );
};

interface ICake {
  data: any
}

const Cake = () => {
  const cakeContext = useContext(CakeContext);

  return <div className={classes.cake}>
    <div className={classes.biszkoptGorny} />
    {cakeContext?.cake.ingredients.map(({ name, images, uid }) => {
      return <div key={uid} onClick={() => cakeContext.removeIngredient(uid)}>
        {images[0] ? <img width={300} height={50} src={images[0]?.url} alt={images[0]?.name} /> : name}
      </div>
    })}
    <div className={classes.biszkoptDolny} />
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
      <ul style={{ listStyle: 'none', padding: 0 }}>
        {props.data.value.map((ingredient: Ingredient, idx: number) => (
          <li style={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between' }} key={uuidv4()}>
            {idx + 1}. {ingredient.name} - {ingredient.priceBrutto.toFixed(2)}zł{" "}
            <Button
              onClick={() => {
                addIngredient({ ...ingredient, uid: uuidv4() })
              }}
              type="submit"
              variant="contained"
              style={{ background: '#8a2b06' }}
              sx={{ mt: 1, mb: 1 }}
            >
              Dodaj do ciasta
            </Button>
          </li>
        ))}
      </ul>
    </div>
  );
};

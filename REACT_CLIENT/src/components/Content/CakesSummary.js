import React from "react";
import classes from "./CakesSummary.module.css";

const CakesSummary = () => {
  return (
    <section className={classes.summary}>
      <h2>Wspaniałe ciasta, wspaniałe smaki!</h2>
      <p>
        Wybierz swoje ulubione ciasto z naszej szerokiej oferty i ciesz się
        smakiem!
      </p>
      <p>
        Wszystkie nasze ciasta są przygotowywane z najwyższej jakości
        składników, z pasją i miłością. Zamów już dziś!
      </p>
    </section>
  );
};

export default CakesSummary;

import React from "react";
import classes from "./AvailableCakes.module.css";
import Card from "../UI/Card";
import Item from "./SingleItem/Item";

// KIEDYŚ TU BĘDZIE Z API POBIERAĆ
const DUMMY_CAKES = [
  {
    id: 0,
    name: "Ciasto czekoladowe",
    description:
      "Pyszne ciasto czekoladowe z kremem i polewą czekoladową na wierzchu i bokach. Dekorowane czekoladowymi wiórkami i truskawkami. Waga: 1,5 kg.",
    price: 21.37,
    pathImage: "",
  },
  {
    id: 1,
    name: "Ciasto truskawkowe",
    description:
      "Pyszne ciasto truskawkowe z kremem i polewą truskawkową na wierzchu i bokach. Dekorowane truskawkami. Waga: 1,5 kg.",
    price: 69.69,
  },
  {
    id: 2,
    name: "Ciasto malinowe",
    description:
      "Pyszne ciasto malinowe z kremem i polewą malinową na wierzchu i bokach. Dekorowane malinami. Waga: 1,5 kg.",
    price: 13.37,
    pathImage: "",
  },
  {
    id: 3,
    name: "Ciasto pomarańczowe",
    description:
      "Mój roommate umrze po zjedzeniu bo ma uczulenie na pomarańcze debil jebany XDD. Waga: 1 kg.",
    price: 2.0,
    pathImage: "",
  },
];

const AvailableCakes = () => {
  const cakesList = DUMMY_CAKES.map((cake) => <Item key={cake.id} {...cake} />);
  return (
    <section className={classes.cakes}>
      <Card>
        <ul>{cakesList}</ul>
      </Card>
    </section>
  );
};

export default AvailableCakes;

import { Fragment } from "react";
import CakesSummary from "./CakesSummary";
import AvailableCakes from "./AvailableCakes";

const Cakes = () => {
  return (
    <Fragment>
      <CakesSummary />
      <AvailableCakes />
    </Fragment>
  );
};

export default Cakes;

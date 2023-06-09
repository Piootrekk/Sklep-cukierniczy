import { Fragment, useState } from "react";
import CakesSummary from "./CakesSummary";
import AvailableCakes from "./AvailableCakes";
import Modal from "../UI/Model";
import CakesForm from "./CakesForm";
import Async from "../Async/Async";
import { useGetAllProducts, useGetCategories } from "../Configurator/Repositories/configuratorRepositories";

const Cakes = () => {
  const getAllProducts = useGetAllProducts();
  const getCategories = useGetCategories();
  const [addProductModalIsShown, setAddProductModalIsShown] = useState(false);
  const [refreshProducts, setRefreshProducts] = useState(false);
  const showCartHandler = () => {
    setAddProductModalIsShown(true);
  };
  const hideCartHandler = () => {
    setAddProductModalIsShown(false);
  };
  const refresh = () => {
    setRefreshProducts(!refreshProducts);
  }
  return (
    <Async action={() => Promise.all([getAllProducts(), getCategories()])} deps={[refreshProducts]}>
    {data => <Fragment>
      <CakesSummary />
          {addProductModalIsShown && <Modal onClose={hideCartHandler}>
            <CakesForm onClose={hideCartHandler} refresh={refresh} categories={data[1].value} productNumber={data[0].value.length} />
          </Modal>}
      <AvailableCakes showCartHandler={showCartHandler} products={data[0].value} />
      </Fragment>
    }
    </Async>
  );
};

export default Cakes;

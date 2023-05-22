import { useState } from "react";

import Header from "./components/Layout/Header";
import Cakes from "./components/Content/Cakes";
import Cart from "./components/Cart/Cart";
import CratProvider from "./storage/CartProvider";
import Register from "./components/User/Register";

function App() {
  const [cartIsShown, setCartIsShown] = useState(false);
  const showCartHandler = () => {
    setCartIsShown(true);
  };
  const hideCartHandler = () => {
    setCartIsShown(false);
  };

  return (
    <CratProvider>
      {cartIsShown && <Cart onClose={hideCartHandler} />}
      <Header onShowCart={showCartHandler} />
      <main>
        {/* <Cakes /> */}
        <Register />
      </main>
    </CratProvider>
  );
}

export default App;

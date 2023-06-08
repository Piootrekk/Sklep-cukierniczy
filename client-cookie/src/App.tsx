import { useState } from 'react';

import Header from './components/Layout/Header';
import Cakes from './components/Content/Cakes';
import Cart from './components/Cart/Cart';
import { Route, Routes } from 'react-router-dom';
import CartProvider from './storage/CartProvider';
import { CakeVisualization } from './components/Configurator/Configurator';
import { CakeProvider } from './storage/CustomCakeCont';

function App() {
  const [cartIsShown, setCartIsShown] = useState(false);
  const showCartHandler = () => {
    setCartIsShown(true);
  };
  const hideCartHandler = () => {
    setCartIsShown(false);
  };

  return (
    <CartProvider>
      <CakeProvider>
        {cartIsShown && <Cart onClose={hideCartHandler} />}
        <div id="overlays"></div>
        <Header onShowCart={showCartHandler} />
        <Routes>
          <Route path="/" element={<main>
            <Cakes />
          </main>} />
          <Route path="configurator" element={<main><CakeVisualization  /></main>} />
        </Routes>
      </CakeProvider>
    </CartProvider>
  );
}

export default App;
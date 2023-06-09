import { createContext, useReducer } from 'react';
import { Ingredient } from './CustomCakeCont';

export interface CartState {
    items: Ingredient[];
    totalAmount: number
}

export interface CartReturn {
    items: Ingredient[];
    totalAmount: number
    addItem: (item: Ingredient) => void
    removeItem: (id: string) => void
}
type CartAction =
  | { type: 'ADD'; item: Ingredient }
  | { type: 'REMOVE'; id: string };

const defaultCartState: CartState = {
  items: [],
  totalAmount: 0,
};

const cartReducer = (state: CartState, action: CartAction): CartReturn | CartState => {
  if (action.type === 'ADD') {
    const updatedTotalAmount =
      state.totalAmount + action.item.priceBrutto * action.item.amountInStock;

    const existingCartItemIndex = state.items.findIndex(
      (item) => item.id === action.item.id
    );
    const existingCartItem = state.items[existingCartItemIndex];
    let updatedItems;

    if (existingCartItem) {
      const updatedItem = {
        ...existingCartItem,
        amountInStock: existingCartItem.amountInStock + action.item.amountInStock,
      };
      updatedItems = [...state.items];
      updatedItems[existingCartItemIndex] = updatedItem;
    } else {
      updatedItems = state.items.concat(action.item);
    }
    return {
      items: updatedItems,
      totalAmount: updatedTotalAmount,
    };
  }

  if (action.type === 'REMOVE') {
    const existingCartItemIndex = state.items.findIndex(
      (item) => item.id === action.id
    );
    const existingItem = state.items[existingCartItemIndex];
    const updatedTotalAmount = state.totalAmount - existingItem.priceBrutto;
    let updatedItems;

    if (existingItem.amountInStock === 1) {
      updatedItems = state.items.filter((item) => item.id !== action.id);
    } else {
      const updatedItem = {
        ...existingItem,
        amountInStock: existingItem.amountInStock - 1,
      };
      updatedItems = [...state.items];
      updatedItems[existingCartItemIndex] = updatedItem;
    }

    return {
      items: updatedItems,
      totalAmount: updatedTotalAmount,
    };
  }

  return defaultCartState;
};

const CartProvider = (props: { children: React.ReactNode }) => {
  const [cartState, dispatchCartAction] = useReducer(
    cartReducer,
    defaultCartState
  );

  const addItemToCartHandler = (item: Ingredient) => {
    dispatchCartAction({ type: 'ADD', item: item });
  };

  const removeItemFromCartHandler = (id: string) => {
    dispatchCartAction({ type: 'REMOVE', id: id });
  };

  const cartContext = {
    items: cartState.items,
    totalAmount: cartState.totalAmount,
    addItem: addItemToCartHandler,
    removeItem: removeItemFromCartHandler,
  };
  return (
    <CartContext.Provider value={cartContext}>
      {props.children}
    </CartContext.Provider>
  );
};
export const CartContext = createContext<CartState | CartReturn>(defaultCartState);

export default CartProvider;
import React, { createContext, useState, useCallback, useMemo } from 'react';
import { Image } from '../components/Configurator/Configurator';

interface CakeProps {
  id: string;
  name: string;
  price: number;
  ingredients: Ingredient[];
}

export interface Ingredient {
  uid: string;
  categoryId: number;
  configurationPositionId: number;
  amountInStock: number;
  description: string;
  id: string | number;
  isIngredient: boolean;
  images: Image[];
  isActive: boolean;
  name: string;
  priceBrutto: number
}

interface CakeContextProps {
  cake: CakeProps;
  addIngredient: (ingredient: Ingredient) => void;
  removeIngredient: (ingredientId: string) => void;
}

export const CakeContext = createContext<CakeContextProps | undefined>(undefined);
const initialCake: CakeProps = {
    id: '123',
    name: 'Pierwsze Ciacho',
    price: 100,
    ingredients: []
   
  }
export const CakeProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
  const [cake, setCake] = useState<CakeProps>(initialCake);
  const addIngredient = useCallback((ingredient: Ingredient) => {
    setCake((prevCake) => {
      const { ingredients } = prevCake;
      const updatedIngredients = [...ingredients];
      let insertIndex = 1; // Domyślna pozycja wstawienia między pierwszym a drugim elementem
  
      if (ingredient.configurationPositionId !== undefined && ingredient.configurationPositionId < updatedIngredients.length) {
        insertIndex = ingredient.configurationPositionId; // Wstawienie na określonym indeksie
      } else if (ingredient.configurationPositionId !== undefined) {
        insertIndex = updatedIngredients.length; // Wstawienie na końcu, jeśli określony indeks przekracza długość tablicy
      }

      updatedIngredients.splice(insertIndex, 0, ingredient);
  
      return {
        ...prevCake,
        ingredients: [...updatedIngredients],
      };
    });
  }, []);

  const removeIngredient = useCallback((ingredientId: string) => {
    setCake((prevCake) => ({
      ...prevCake,
      ingredients: prevCake.ingredients.filter((ingredient) =>
        ingredient.uid !== ingredientId
      ),
    }));
  }, []);

  const totalBruttoPrice = useMemo(() => {
    return cake.ingredients.reduce((total, ingredient) => {
        return total + ingredient.priceBrutto;
    }, 0);
  }, [cake.ingredients]);

  return (
    <CakeContext.Provider value={{ cake, addIngredient, removeIngredient }}>
      <div>Total Brutto Price: {totalBruttoPrice}</div>
      {children}
    </CakeContext.Provider>
  );
};
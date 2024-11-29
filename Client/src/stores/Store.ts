import { createContext, useContext } from "react";
import ProductStore from "./ProductsStore";
import ViewProductsStore from "./ViewProductsStore";
import UserStore from "./UserStore";

interface Store {
  productStore: ProductStore;
  viewProductsStore: ViewProductsStore;
  UserStore: UserStore;
}

export const store: Store = {
  productStore: new ProductStore(),
  viewProductsStore: new ViewProductsStore(),
  UserStore: new UserStore(),
};

export const StoreContext = createContext(store);
export function useStore() {
  return useContext(StoreContext);
}

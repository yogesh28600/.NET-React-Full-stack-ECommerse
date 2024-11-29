import { makeAutoObservable } from "mobx";
import { Product } from "../Types/Product";
import { Products } from "../constants/Products";
import { ViewProduct } from "../Types/ViewProduct";

export default class ViewProductsStore {
  products: ViewProduct[] = Products.filter((product) => product.isNewArival);
  constructor() {
    makeAutoObservable(this);
  }
  setProducts(products: Product[]) {
    this.products = products;
  }
  ToggleWishlist(id: number, isTrue: boolean) {
    const idx = this.products.findIndex((prod) => prod.id === id);
    this.products[idx].isWishlisted = !isTrue;
  }
}

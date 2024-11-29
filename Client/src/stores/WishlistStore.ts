import { makeAutoObservable } from "mobx";
import { Product } from "../Types/Product";

export default class WishlistStore {
  products: Product[] = [];
  constructor() {
    makeAutoObservable(this);
  }
  AddToWishlist(product: Product) {
    const prod = this.products.find((element) => element.id === product.id);
    if (prod == undefined) {
      this.products = [...this.products, product];
    }
  }
  RemoveFromWishlist(id: number) {
    const idx = this.products.findIndex((prod) => prod.id === id);
    this.products.splice(idx, 1);
  }
}

import { makeAutoObservable } from "mobx";
import { CartProduct } from "../Types/CartProduct";

export default class CartStore {
  products: CartProduct[] = [];
  TotalPrice: number = 0;
  TotalItems: number = 0;

  constructor() {
    makeAutoObservable(this);
  }
  calculateTotalItems() {
    this.TotalItems = this.products.length;
  }
  calculateTotal(): number {
    let price: number = 0;
    this.products.forEach(
      (product) => (price += product.currentPrice * product.quantity),
    );
    return price;
  }
  AddToCart(product: CartProduct): void {
    const idx = this.products.findIndex((element) => element.id === product.id);
    if (idx >= 0) {
      this.products[idx].quantity += this.products[idx].quantity;
    } else {
      const newProd = { ...product, quantity: 1 };
      this.products = [...this.products, newProd];
    }
    this.TotalPrice = this.calculateTotal();
    this.calculateTotalItems();
  }
  removeProduct(id: number): void {
    const idx = this.products.findIndex((prod) => prod.id === id);
    this.products.splice(idx, 1);
    this.TotalItems = this.products.length;
    this.calculateTotalItems();
  }
  changeQuantity(id: number, qty: number) {
    const idx = this.products.findIndex((prod) => prod.id === id);
    this.products[idx].quantity = qty;
    this.TotalPrice = this.calculateTotal();
  }
}

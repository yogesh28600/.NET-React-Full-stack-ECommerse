import WishlistStore from "./WishlistStore";
import CartStore from "./CartStore";
import { makeAutoObservable } from "mobx";

export default class UserStore {
  userId: string | null = null;
  wishlist: WishlistStore = new WishlistStore();
  cart: CartStore = new CartStore();

  constructor() {
    makeAutoObservable(this);
  }
  setUser(user: string) {
    console.log(user);
    this.userId = user;
  }
  removeUser() {
    this.userId = null;
  }
}

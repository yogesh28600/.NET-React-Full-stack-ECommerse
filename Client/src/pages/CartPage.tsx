import { NavLink } from "react-router-dom";
import { useStore } from "../stores/Store";
import { observer } from "mobx-react-lite";
import CartProduct from "../components/CartProduct";

const CartPage = () => {
  const { UserStore } = useStore();
  if (UserStore.userId) {
    if (UserStore.cart.products.length > 0) {
      return (
        <div className="flex flex-col justify-center gap-5 md:flex-row">
          <div>
            {UserStore.cart.products.map((product) => (
              <CartProduct key={product.id} product={product} />
            ))}
          </div>
          <div className="border-[1px] border-gray-200 p-5 md:w-[536px]">
            <h1 className="font-bold">Order Summary</h1>
            <div className="my-5">
              <label htmlFor="PromoCode">Discount Code / Promo Code</label>
              <input
                className="mb-5 flex h-12 w-full rounded-md border bg-transparent px-3 py-1 text-sm shadow-sm transition-colors focus-visible:outline-none focus-visible:ring-1 disabled:cursor-not-allowed disabled:opacity-50"
                type="text"
                name="PromoCode"
                placeholder="Code"
              />
              <label htmlFor="bonousCard">Your bonous card number</label>
              <input
                className="flex h-12 w-full rounded-md border bg-transparent px-3 py-1 text-sm shadow-sm transition-colors focus-visible:outline-none focus-visible:ring-1 disabled:cursor-not-allowed disabled:opacity-50"
                type="text"
                name="bonousCard"
                placeholder="Enter card number"
              />
              <div className="mt-5 flex flex-col gap-y-4">
                <div className="flex justify-between">
                  <h1 className="font-bold">Sub Total</h1>
                  <h1 className="font-bold">$ {UserStore.cart.TotalPrice}</h1>
                </div>
                <div className="flex justify-between">
                  <h1 className="">Estimated Tax</h1>
                  <h1 className="font-bold">$ 0</h1>
                </div>
                <div className="flex justify-between">
                  <h1 className="">Estimated Shipping & Handling</h1>
                  <h1 className="font-bold">$ 0</h1>
                </div>
                <div className="flex justify-between">
                  <h1 className="font-bold">Total</h1>
                  <h1 className="font-bold">$ {UserStore.cart.TotalPrice}</h1>
                </div>
              </div>
              <button className="mt-5 w-full rounded-lg bg-black py-2 text-white">
                Checkout
              </button>
            </div>
          </div>
        </div>
      );
    }
    return (
      <div className="my-20 flex w-full flex-col items-center">
        <h1 className="text-2xl">No Items in Cart</h1>
        <NavLink
          to="/"
          className="mt-5 w-52 rounded-lg bg-black py-2 text-center text-white"
        >
          Go to home
        </NavLink>
      </div>
    );
  } else {
    return (
      <div className="my-20 flex w-full flex-col items-center">
        <h1 className="text-2xl">Sign in to Add Items to cart</h1>
        <NavLink
          to="/signin"
          className="mt-5 w-52 rounded-lg bg-black py-2 text-center text-white"
        >
          Sign in
        </NavLink>
      </div>
    );
  }
};

export default observer(CartPage);

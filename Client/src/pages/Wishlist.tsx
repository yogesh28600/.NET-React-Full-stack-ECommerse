import { observer } from "mobx-react-lite";
import ProductCard from "../components/ProductCard";
import { useStore } from "../stores/Store";
import { Link, NavLink } from "react-router-dom";

const Wishlist = () => {
  const { UserStore } = useStore();
  if (UserStore.userId) {
    if (UserStore.wishlist.products.length >= 1) {
      return (
        <div className="flex gap-4 px-5">
          {UserStore.wishlist.products.map((product) => (
            <ProductCard product={product} />
          ))}
        </div>
      );
    } else {
      return (
        <div className="flex w-full flex-col items-center gap-5 py-10">
          <h1 className="text-2xl">No Items in wishlist</h1>
          <Link to="/" className="rounded-lg bg-black px-10 py-2 text-white">
            Home
          </Link>
        </div>
      );
    }
  } else {
    return (
      <div className="my-20 flex w-full flex-col items-center">
        <h1 className="text-2xl">Sign in to Add Items to wishlist</h1>
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

export default observer(Wishlist);

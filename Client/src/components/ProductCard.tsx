import { CiHeart } from "react-icons/ci";
import { FaHeart } from "react-icons/fa";
import { ViewProduct } from "../Types/ViewProduct";
import { observer } from "mobx-react-lite";
import { useStore } from "../stores/Store";
import { CartProduct } from "../Types/CartProduct";
import { NavLink } from "react-router-dom";
import { auth } from "../Firebase/FirebaseConfig";
interface ProductCardProps {
  product: ViewProduct;
}
const ProductCard = ({ product }: ProductCardProps) => {
  const { viewProductsStore, UserStore } = useStore();

  //On click buy now button the product will be added to cart
  function buynowHandle(): void {
    if (auth.currentUser) {
      const cartProduct: CartProduct = { ...product, quantity: 1 };
      UserStore.cart.AddToCart(cartProduct);
    }
  }
  //------------------------end----------------------------//
  function AddToWishlistHandle() {
    if (auth.currentUser) {
      UserStore.wishlist.AddToWishlist(product);
      viewProductsStore.ToggleWishlist(
        product.id,
        product.isWishlisted ? product.isWishlisted : false,
      );
    }
  }
  return (
    <div className="relative flex h-[432px] max-w-[266px] flex-col items-center justify-center gap-y-4 rounded-lg bg-gray-200 px-5">
      <button className="absolute right-4 top-4">
        {!product.isWishlisted ? (
          <CiHeart size={30} onClick={() => AddToWishlistHandle()} />
        ) : (
          <FaHeart
            size={25}
            color="red"
            onClick={() => {
              UserStore.wishlist.RemoveFromWishlist(product.id);
              viewProductsStore.ToggleWishlist(
                product.id,
                product.isWishlisted ? product.isWishlisted : false,
              );
            }}
          />
        )}
      </button>
      <img src={product.image} alt="" />
      <h1 className="font-roboto text-lg">{product.title}</h1>
      <h1 className="font-roboto text-lg font-bold">
        $ {product.currentPrice}
      </h1>
      <NavLink
        to="/cart"
        className="rounded-lg bg-black px-10 py-2 text-white"
        onClick={() => buynowHandle()}
      >
        Buy Now
      </NavLink>
    </div>
  );
};

export default observer(ProductCard);

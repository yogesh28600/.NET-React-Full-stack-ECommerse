import { IoAddOutline } from "react-icons/io5";
import { RiSubtractFill } from "react-icons/ri";
import { IoMdClose } from "react-icons/io";
import { useStore } from "../stores/Store";
import { observer } from "mobx-react-lite";
import { useState } from "react";
import { CartProduct } from "../Types/CartProduct";
interface CartProductProps {
  product: CartProduct;
}
const CartItem = ({ product }: CartProductProps) => {
  const { UserStore } = useStore();
  const [quantity, setQuantity] = useState<number>(product.quantity);
  function ChangeQuantityHandler(e: React.ChangeEvent<HTMLInputElement>) {
    const qty = +e.target.value;
    setQuantity(qty);
    UserStore.cart.changeQuantity(product.id, qty);
  }
  return (
    <div
      key={product.id}
      className="flex items-center justify-around border-b-[1px] border-gray-200 md:w-[536px]"
    >
      <div>
        <img src={product.image} alt="" />
      </div>
      <div className="flex flex-col gap-5">
        <div>
          <h1 className="font-bold md:w-[193px]">{product.title}</h1>
        </div>
        <div className="flex items-center gap-3 font-bold">
          <div className="flex items-center gap-3">
            <button
              onClick={() => {
                if (quantity != 0) {
                  setQuantity(quantity - 1);
                  UserStore.cart.changeQuantity(product.id, quantity - 1);
                }
              }}
            >
              <RiSubtractFill />
            </button>
            <input
              className="flex h-9 w-10 rounded-md border bg-transparent px-3 py-1 text-sm shadow-sm transition-colors focus-visible:outline-none focus-visible:ring-1 disabled:cursor-not-allowed disabled:opacity-50"
              type="number"
              min={0}
              value={quantity}
              onChange={(e) => ChangeQuantityHandler(e)}
            />
            <button
              onClick={() => {
                setQuantity(quantity + 1);
                UserStore.cart.changeQuantity(product.id, quantity + 1);
              }}
            >
              <IoAddOutline />
            </button>
          </div>
          <div>
            <h1>$ {product.currentPrice}</h1>
          </div>
          <button
            className="ms-3"
            onClick={() => UserStore.cart.removeProduct(product.id)}
          >
            <IoMdClose size={20} />
          </button>
        </div>
      </div>
    </div>
  );
};

export default observer(CartItem);

import { observer } from "mobx-react-lite";
import ProductCard from "../components/ProductCard";
import { useStore } from "../stores/Store";
const Products = () => {
  const { viewProductsStore, productStore } = useStore();
  return (
    <div className="w-full px-5 md:px-20">
      <div>
        <ul className="flex gap-x-4 text-sm">
          <li>
            <button
              onClick={() => {
                viewProductsStore.setProducts(
                  productStore.products.filter(
                    (product) => product.isNewArival,
                  ),
                );
              }}
            >
              New Arrival
            </button>
          </li>
          <li>
            <button
              onClick={() => {
                viewProductsStore.setProducts(
                  productStore.products.filter(
                    (product) => product.isBestSeller,
                  ),
                );
              }}
            >
              Best Seller
            </button>
          </li>
          <li>
            <button
              onClick={() => {
                viewProductsStore.setProducts(
                  productStore.products.filter((product) => product.isFeatured),
                );
              }}
            >
              Featured Products
            </button>
          </li>
        </ul>
      </div>
      <div className="grid grid-cols-2 gap-5 py-4 md:grid-cols-4">
        {viewProductsStore.products.map((prod) => (
          <ProductCard key={prod.id} product={prod} />
        ))}
      </div>
    </div>
  );
};

export default observer(Products);

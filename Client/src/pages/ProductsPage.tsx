import Footer from "../components/Footer";
import ProductCard from "../components/ProductCard";
import SideFilter from "../components/SideFilter";
import { useStore } from "../stores/Store";

const ProductsPage = () => {
  const { viewProductsStore } = useStore();
  return (
    <section>
      <div className="flex w-full flex-col justify-center gap-x-10 md:flex-row">
        <div>
          <SideFilter />
        </div>
        <div>
          <div className="my-5 flex justify-between">
            <h1>
              Selected Products:{" "}
              <span className="font-bold">
                {viewProductsStore.products.length}
              </span>
            </h1>
            <select>
              <option>By Rating</option>
              <option>By Popularity</option>
            </select>
          </div>
          <div className="my-5 grid grid-cols-2 gap-5 md:grid-cols-3">
            {viewProductsStore.products.map((product) => (
              <ProductCard key={product.id} product={product} />
            ))}
          </div>
        </div>
      </div>
      <Footer />
    </section>
  );
};

export default ProductsPage;

import CategoryCard from "./CategoryCard";
import { CiMobile3 } from "react-icons/ci";
import { BsSmartwatch } from "react-icons/bs";
import { IoCameraOutline } from "react-icons/io5";
import { FiHeadphones } from "react-icons/fi";
import { HiOutlineComputerDesktop } from "react-icons/hi2";
import { TbDeviceGamepad } from "react-icons/tb";
import { Link } from "react-router-dom";
import { useStore } from "../stores/Store";
const Categories = () => {
  const { viewProductsStore, productStore } = useStore();
  return (
    <div className="font-roboto w-full px-5 py-10 md:px-20">
      <div className="flex items-center justify-between">
        <h1>Browse by category</h1>
      </div>

      <div className="md:scroll-hidden flex justify-center gap-x-5 overflow-x-scroll py-6">
        <Link
          to="Products"
          onClick={() =>
            viewProductsStore.setProducts(
              productStore.products.filter(
                (prod) => prod.category === "Mobiles",
              ),
            )
          }
        >
          <CategoryCard Title="Mobiles" icon={<CiMobile3 size={40} />} />
        </Link>

        <Link
          to="/Products"
          onClick={() =>
            viewProductsStore.setProducts(
              productStore.products.filter(
                (prod) => prod.category === "Smart Watches",
              ),
            )
          }
        >
          <CategoryCard
            Title="Smart Watches"
            icon={<BsSmartwatch size={40} />}
          />
        </Link>
        <Link
          to="/products"
          onClick={() =>
            viewProductsStore.setProducts(
              productStore.products.filter(
                (prod) => prod.category === "Cameras",
              ),
            )
          }
        >
          <CategoryCard Title="Cameras" icon={<IoCameraOutline size={40} />} />
        </Link>
        <Link
          to="/Products"
          onClick={() =>
            viewProductsStore.setProducts(
              productStore.products.filter(
                (prod) => prod.category === "Headphones",
              ),
            )
          }
        >
          <CategoryCard Title="Headphones" icon={<FiHeadphones size={40} />} />
        </Link>
        <Link
          to="/Products"
          onClick={() =>
            viewProductsStore.setProducts(
              productStore.products.filter(
                (prod) => prod.category === "Computers",
              ),
            )
          }
        >
          <CategoryCard
            Title="Computers"
            icon={<HiOutlineComputerDesktop size={40} />}
          />
        </Link>
        <Link
          to="/Products"
          onClick={() =>
            viewProductsStore.setProducts(
              productStore.products.filter((prod) => prod.category === "Games"),
            )
          }
        >
          <CategoryCard Title="Games" icon={<TbDeviceGamepad size={40} />} />
        </Link>
      </div>
    </div>
  );
};

export default Categories;

import CartPage from "../pages/CartPage";
import HomePage from "../pages/HomePage";
import ProductsPage from "../pages/ProductsPage";
import SignInPage from "../pages/SignInPage";
import SignUpPage from "../pages/SignUpPage";
import Wishlist from "../pages/Wishlist";

type Route = {
  path: string;
  element: JSX.Element;
  title: string;
};
export const PagesData: Route[] = [
  {
    path: "",
    element: <HomePage />,
    title: "Home",
  },
  {
    path: "/Products",
    element: <ProductsPage />,
    title: "Products",
  },
  {
    path: "/wishlist",
    element: <Wishlist />,
    title: "wishlist",
  },
  {
    path: "/cart",
    element: <CartPage />,
    title: "cart",
  },
  {
    path: "/signin",
    element: <SignInPage />,
    title: "signin",
  },
  {
    path: "/signup",
    element: <SignUpPage />,
    title: "signup",
  },
];

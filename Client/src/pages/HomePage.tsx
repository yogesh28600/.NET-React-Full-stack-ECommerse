import Categories from "../components/Categories";
import Footer from "../components/Footer";
import Banner from "../sections/Banner";
import Products from "../sections/Products";

const HomePage = () => {
  return (
    <div>
      <Banner />
      <Categories />
      <Products />
      <Footer />
    </div>
  );
};

export default HomePage;

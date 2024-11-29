import { Route, Routes } from "react-router-dom";
import { PagesData } from "./PagesData";

const Router = () => {
  const pageRoutes = PagesData.map(({ path, element, title }) => (
    <Route path={path} element={element} key={title} />
  ));
  return <Routes>{pageRoutes}</Routes>;
};

export default Router;

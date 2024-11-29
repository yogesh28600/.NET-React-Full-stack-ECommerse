import { BrowserRouter } from "react-router-dom";
import Router from "./Routes/Router";
import Navigation from "./components/Navigation";

const App = () => {
  return (
    <BrowserRouter>
      <Navigation />
      <Router />
    </BrowserRouter>
  );
};

export default App;

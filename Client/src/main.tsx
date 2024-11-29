import ReactDOM from "react-dom/client";
import App from "./App.tsx";
import "./index.css";
import { store, StoreContext } from "./stores/Store.ts";

ReactDOM.createRoot(document.getElementById("root")!).render(
  <StoreContext.Provider value={store}>
    <App />
  </StoreContext.Provider>,
);

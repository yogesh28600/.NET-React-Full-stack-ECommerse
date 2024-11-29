import { Product } from "./Product";

export interface ViewProduct extends Product {
  isWishlisted?: boolean;
}

export interface Product {
  id: number;
  image: string;
  title: string;
  orginalPrice: number;
  currentPrice: number;
  category:
    | "Mobiles"
    | "Smart Watches"
    | "Cameras"
    | "Headphones"
    | "Computers"
    | "Games";
  description?: string;
  isNewArival: boolean;
  isBestSeller: boolean;
  isFeatured: boolean;
  brand:
    | "Apple"
    | "Samsung"
    | "Sony"
    | "Oneplus"
    | "Iqoo"
    | "Oppo"
    | "Blackmagic";
}

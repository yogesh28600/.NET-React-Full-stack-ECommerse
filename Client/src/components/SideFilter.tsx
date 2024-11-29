import { GoChevronUp } from "react-icons/go";
import { GoChevronDown } from "react-icons/go";
import { Brands } from "../constants/Brands";
import { useState } from "react";

const SideFilter = () => {
  const [brandMenu, setBrandMenu] = useState(false);
  return (
    <div className="my-5 w-52">
      <div className="flex justify-between">
        <h1 className="font-bold">Brand</h1>
        <button onClick={() => setBrandMenu(!brandMenu)}>
          {brandMenu ? <GoChevronUp /> : <GoChevronDown />}
        </button>
      </div>
      <div
        className={`scroll-hidden max-h-[330px] overflow-y-scroll ${brandMenu ? "block" : "hidden"}`}
      >
        {Brands.map((brand, index) => (
          <div key={index} className="flex items-center gap-1">
            <input type="checkbox" name={brand} />
            <label htmlFor="Apple">{brand}</label>
          </div>
        ))}
      </div>
    </div>
  );
};

export default SideFilter;

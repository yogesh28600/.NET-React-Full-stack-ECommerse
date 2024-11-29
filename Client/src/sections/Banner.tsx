import iphone from "../assets/Images/Iphone Image.png";
const Banner = () => {
  return (
    <div className="flex w-full flex-col items-center justify-around bg-[#211C24] py-5 md:flex-row md:py-0">
      <div>
        <h2 className="text-gray-300">Pro.Beyond.</h2>
        <h1 className="my-4 text-7xl text-white">
          IPhone 14 <span className="font-bold">Pro</span>
        </h1>
        <p className="text-gray-300">
          Created to change everything for better. For everyone
        </p>
        <button className="mt-4 rounded-md border-[1px] border-white px-6 py-2 text-white">
          Shop Now
        </button>
      </div>
      <div className="h-[600px]">
        <img className="h-full" src={iphone} alt="" />
      </div>
    </div>
  );
};

export default Banner;

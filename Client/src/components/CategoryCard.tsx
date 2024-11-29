interface CategoryCardProps {
  icon: JSX.Element;
  Title: string;
}
const CategoryCard = ({ icon, Title }: CategoryCardProps) => {
  return (
    <div className="flex h-[128px] w-[160px] flex-col items-center justify-center gap-y-3 rounded-lg bg-gray-200">
      {icon}
      {Title}
    </div>
  );
};

export default CategoryCard;

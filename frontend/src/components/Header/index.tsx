import { FaRegCircleUser } from "react-icons/fa6";

export function Header() {
  return (
    <header className="w-full h-20 flex flex-row justify-between items-center p-4 bg-white shadow-[5px_2px_8px_0px_rgba(0,0,0,0.3)]">
      <div className="text-3xl font-bold text-[#086632]">
        <h2 className="ml-4">Estoque</h2>
      </div>
      <div className="flex flex-row gap-4 items-center">
        <div className="bold text-lg text-end">
            <h3>Patrik Malta</h3>
            <p>maltapatrik3@gmail.com</p>
        </div>
        <FaRegCircleUser className="w-15 h-15 bg-gray-400 rounded-full"/>
      </div>
    </header>
  );
}
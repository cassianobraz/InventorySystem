import { Link } from "react-router-dom";
import { LuInbox } from "react-icons/lu";
import { LuLayoutDashboard } from "react-icons/lu";
import { IoMdExit } from "react-icons/io";
import logo from "../../assets/logo.png";

export function SideBar() {
  return (
    <div className="w-72 h-screen bg-[#086632] flex flex-col items-center">
        <img src={logo} alt="Logo do sistema" className="h-50"/>

        <div className="w-full flex flex-col items-center mt-5">
            <Link to="/dash" 
                className="flex flex-row justify-center items-center gap-2 hover:w-full hover:border-l-[4px] hover:border-r-[4px] hover:border-white transition-all duration-75 w-50 text-white font-bold text-2xl p-2 text-start shadow-[4px_4px_6px_0px_rgba(0,0,0,0.3)] rounded-[10px_0px_10px_0px] "
                >
                Dashboard
                <LuLayoutDashboard />
            </Link>

            <Link to="/estoque" 
                className="flex flex-row justify-center items-center gap-2 hover:w-full hover:border-l-[4px] hover:border-r-[4px] hover:border-white transition-all duration-75 w-50 text-white font-bold text-2xl mt-10 p-2 text-start shadow-[4px_4px_6px_0px_rgba(0,0,0,0.3)] rounded-[10px_0px_10px_0px] "
                >
                Estoque
                <LuInbox />
            </Link>

        </div>

        <Link to={"/"} className="text-white font-bold text-2xl bottom-0 p-2 mb-4 absolute flex flex-row gap-2 item">Sair <IoMdExit /></Link>

    </div>
  );
}
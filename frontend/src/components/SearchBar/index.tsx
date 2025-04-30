
import { CiSearch } from "react-icons/ci";

export function SearchBar() {
    return (
        <div className=" h-16 flex flex-row items-center justify-center">
            <input type="text" placeholder="Search" className="w-80 rounded-full bg-white border-2 border-[#086632] px-4 py-2 focus:outline-none focus:border-blue-500" />
            <button className="hover:cursor-pointer">
                <CiSearch className="w-8 h-8 ml-1"/>
            </button>
        </div>
    )
}
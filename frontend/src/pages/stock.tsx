import { Header } from "../components/Header";
import { SideBar } from "../components/SideBar";
import { SearchBar } from "../components/SearchBar";
import { IoIosAdd } from "react-icons/io";
import { Table } from "../components/Table";
import { useEffect, useState } from "react";

export function Stock() {
  const [dataStock, setDataStock] = useState<any[]>([]);

  useEffect(() => {
    fetch("/products.json")
      .then((response) => response.json())
      .then((data) => setDataStock(data))
      .catch((error) => console.error("Erro ao carregar produtos:", error));
  }, []);

  return (
    <div className="flex min-h-screen bg-[#fafafa]">
      <SideBar />
      <div className="w-full flex flex-col items-center justify-center">
        <Header />
        <div className="w-full max-w-6xl bg-white mt-10 pt-4 rounded-4xl flex flex-col items-center">
          <div className="w-full h-16 flex flex-row items-center justify-between px-10">
            <SearchBar />
            <button className="h-10 bg-[#086632] hover:bg-[#0b7d4b] hover:cursor-pointer text-white font-bold px-4 rounded-[10px] flex items-center justify-center gap-2">
              Novo <IoIosAdd className="w-6 h-6" />
            </button>
          </div>

          <div className="max-h-[450px] overflow-y-auto w-full px-4">
            <Table dados={dataStock} />
          </div>
        </div>
      </div>
    </div>
  );
}

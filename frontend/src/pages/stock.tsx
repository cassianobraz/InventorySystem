import { Header } from "../components/Header";
import { SideBar } from "../components/SideBar";
import { SearchBar } from "../components/SearchBar";
import { IoIosAdd, IoIosClose } from "react-icons/io";
import { Table } from "../components/Table";
import { useEffect, useState } from "react";

export function Stock() {
  const [newProduct, setNewProduct] = useState<boolean>(false);
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
        <Header currentLocation="Estoque" />
        <div className="w-full max-w-6xl bg-white mt-10 pt-4 rounded-4xl flex flex-col items-center">
          <div className="w-full h-16 flex flex-row items-center justify-between px-10">
            <SearchBar />
            <button
              onClick={() => setNewProduct(true)}
              className="h-10 bg-[#086632] hover:bg-[#0b7d4b] hover:cursor-pointer text-white font-bold px-4 rounded-[10px] flex items-center justify-center gap-2"
            >
              Novo <IoIosAdd className="w-6 h-6" />
            </button>
          </div>

          <div className="max-h-[450px] overflow-y-auto w-full px-4">
            <Table dados={dataStock} />
          </div>

          {newProduct && (
            <div className="w-full h-screen bg-black/40 absolute top-0 left-0 flex items-center justify-center z-50">
              <div className="w-[400px] bg-white rounded-xl shadow-lg">
                <div className="w-full h-16 bg-[#086632] flex items-center justify-between px-6 rounded-t-xl">
                  <h2 className="text-white font-bold text-xl">Novo Produto</h2>
                  <button
                    onClick={() => setNewProduct(false)}
                    className="text-white hover:text-gray-300 hover:cursor-pointer"
                  >
                    <IoIosClose className="w-8 h-8" />
                  </button>
                </div>

                <form
                  onSubmit={(e) => {
                    e.preventDefault();

                    const formData = new FormData(e.currentTarget);
                    const nome = formData.get("nome") as string;
                    const saldo = Number(formData.get("saldo"));

                    const novoProduto = {
                      codigo: (dataStock.length + 1).toString(),
                      nome,
                      saldo,
                    };

                    setDataStock((prev) => [...prev, novoProduto]);
                    setNewProduct(false);
                  }}
                  className="flex flex-col gap-4 p-6"
                >
                  <input
                    type="text"
                    name="nome"
                    placeholder="Nome do produto"
                    className="border rounded px-3 py-2"
                    required
                  />
                  <input
                    type="number"
                    name="saldo"
                    placeholder="Saldo"
                    min={0}
                    className="border rounded px-3 py-2"
                    required
                  />

                  <div className="flex justify-end gap-2">
                    <button
                      type="button"
                      onClick={() => setNewProduct(false)}
                      className="px-4 py-2 bg-gray-300 rounded hover:bg-gray-400"
                    >
                      Cancelar
                    </button>
                    <button
                      type="submit"
                      className="px-4 py-2 bg-[#086632] text-white rounded hover:bg-[#0b7d4b]"
                    >
                      Salvar
                    </button>
                  </div>
                </form>
              </div>
            </div>
          )}
        </div>
      </div>
    </div>
  );
}

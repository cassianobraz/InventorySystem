import { Header } from "../components/Header";
import { SideBar } from "../components/SideBar";
import { useState, useEffect } from "react";

export function Dashboard() {
  const [totalProdutos, setTotalProdutos] = useState<number>(0);

  useEffect(() => {
    // Atualizando o caminho para buscar no diretório public
    fetch("/products.json")
      .then((response) => response.json())
      .then((data) => {
        setTotalProdutos(data.length);
      })
      .catch((error) => console.error("Erro ao carregar produtos:", error));
  }, []);

  return (
    <div className="flex flex-row bg-[#fafafa] min-h-screen">
      <SideBar />
      <div className="w-full flex flex-col items-center justify-start">
        <Header currentLocation="Dashboard" />
        <div className="w-4/5 mt-20">
          <h1 className="text-2xl font-semibold mb-1">Bem-Vindo, Patrik Malta</h1>
          <p className="text-gray-500 mb-8">Overview</p>

          <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-6">
            <Card title="Total de produtos" value={totalProdutos} />
          </div>
        </div>
      </div>
    </div>
  );
}

// Componente de Card
type CardProps = {
  title: string;
  value: number;
};

function Card({ title, value }: CardProps) {
  return (
    <div className="flex items-center gap-4 p-4 bg-[#eaf7ee] rounded-xl shadow-sm">
      <div>
        <p className="text-sm text-gray-700">{title}</p>
        <p className="text-lg font-semibold">{value}</p>
      </div>
    </div>
  );
}

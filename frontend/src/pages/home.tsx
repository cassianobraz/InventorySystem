import { Link } from "react-router-dom";

export function Home() {
  return (
    <div className="min-h-screen bg-[#fafafa] flex flex-col">
      {/* Header */}
      <header className="w-full py-6 px-10 bg-white shadow-sm flex justify-between items-center">
        <h1 className="text-2xl font-bold text-[#086632]">InventoryCloud</h1>
        <nav className="flex gap-6 text-gray-600 flex flex-row items-center">
          <a href="#sobre" className="hover:text-[#086632] transition">Sobre</a>
          <a href="#recursos" className="hover:text-[#086632] transition">Recursos</a>
          <Link to="/dash" className="bg-[#086632] text-white px-6 py-2 rounded-lg hover:bg-[#0b7d4b] transition">
            Acessar Painel
          </Link>
        </nav>
      </header>

      {/* Hero */}
      <section className="flex-1 flex flex-col items-center justify-center text-center px-4 mt-10">
        <h2 className="text-4xl md:text-5xl font-bold text-gray-800 mb-4">
          Controle seu estoque com facilidade
        </h2>
        <p className="text-gray-600 text-lg max-w-2xl mb-8">
          Um sistema simples, moderno e eficiente para gerenciar seus produtos e manter o controle do seu negócio.
        </p>
        <Link to="/estoque" className="bg-[#086632] text-white font-semibold px-8 py-3 rounded-xl hover:bg-[#0b7d4b] transition">
          Começar Agora
        </Link>
      </section>

      {/* Recursos */}
      <section id="recursos" className="py-20 bg-white mt-20">
        <div className="max-w-6xl mx-auto px-4">
          <h3 className="text-3xl font-bold text-center text-gray-800 mb-12">Recursos</h3>
          <div className="grid grid-cols-1 md:grid-cols-3 gap-10 text-center">
            <div className="bg-[#eaf7ee] p-6 rounded-xl shadow">
              <h4 className="text-xl font-semibold text-[#086632] mb-2">Gestão de Produtos</h4>
              <p className="text-gray-600">Adicione, edite e remova produtos com poucos cliques.</p>
            </div>
            <div className="bg-[#eaf7ee] p-6 rounded-xl shadow">
              <h4 className="text-xl font-semibold text-[#086632] mb-2">Visualização Clara</h4>
              <p className="text-gray-600">Veja rapidamente o saldo de cada item com uma interface amigável.</p>
            </div>
            <div className="bg-[#eaf7ee] p-6 rounded-xl shadow">
              <h4 className="text-xl font-semibold text-[#086632] mb-2">Interface Responsiva</h4>
              <p className="text-gray-600">Compatível com todos os dispositivos — desktop, tablet e celular.</p>
            </div>
          </div>
        </div>
      </section>

      {/* Footer */}
      <footer className="bg-[#086632] text-white py-6 text-center mt-auto">
        <p>© {new Date().getFullYear()} InventoryCloud. Todos os direitos reservados.</p>
      </footer>
    </div>
  );
}

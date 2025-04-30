interface Componente {
  codigo: string;
  nome: string;
  saldo: number;
}

interface TabelaComponentesProps {
  dados: Componente[];
}

export function Table({ dados }: TabelaComponentesProps) {
  return (
    <div className="flex justify-center items-center min-h-screen">
      <div className="overflow-x-auto rounded-lg mt-20 w-full max-w-6xl">
        <table className="text-sm text-left w-full">
          <thead className="text-gray-600 font-bold text-3xl border-b">
            <tr>
              <th className="px-8 py-4">ID</th>
              <th className="px-8 py-4">Produto</th>
              <th className="px-8 py-4">Saldo</th>
              <th className="px-8 py-4">Editar</th>
              <th className="px-8 py-4">Deletar</th>
            </tr>
          </thead>
          <tbody>
            {dados.map((item, index) => (
              <tr key={index} className="border-b text-gray-600 text-xl w-full">
                <td className="px-8 py-5 text-center">{item.codigo}</td>
                <td className="px-8 py-5 w-full">{item.nome}</td>
                <td className="px-8 py-5 w-full">{item.saldo}</td>
                <td className="px-8 py-5 w-full">
                  <button className="text-green-600 hover:text-green-800 hover:cursor-pointer w-full">
                    ✏️
                  </button>
                </td>
                <td className="px-6 py-4">
                  <button className="text-red-500 hover:text-red-700 hover:cursor-pointer w-full">
                    🗑️
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}

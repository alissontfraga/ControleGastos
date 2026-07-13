import { createBrowserRouter } from "react-router-dom";

import Layout from "../components/Layout";

import Dashboard from "../pages/Dashboard";

import Pessoas from "../pages/Pessoas";

import Transacoes from "../pages/Transacoes";

/*
 * Configuração principal das rotas da aplicação.
 *
 * O Layout funciona como estrutura base contendo:
 * - Navbar;
 * - Sidebar;
 * - Área onde as páginas são renderizadas através do Outlet.
 */
export const router = createBrowserRouter([
  {
    path: "/",

    element: <Layout />,

    children: [
      {
        // Página inicial com o resumo financeiro.
        path: "/",

        element: <Dashboard />,
      },

      {
        // Gerenciamento de pessoas cadastradas.
        path: "/pessoas",

        element: <Pessoas />,
      },

      {
        // Gerenciamento das receitas e despesas.
        path: "/transacoes",

        element: <Transacoes />,
      },
    ],
  },
]);

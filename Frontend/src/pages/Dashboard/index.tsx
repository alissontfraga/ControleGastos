import { useEffect, useState } from "react";

import { Button } from "@mui/material";

import {
  TrendingUp,
  TrendingDown,
  AccountBalanceWallet,
} from "@mui/icons-material";

import { api } from "../../api/api";

import type { ResumoGeral } from "../../types/Relatorio";

import PageHeader from "../../components/PageHeader";
import StatsCard from "../../components/StatsCard";

import { formatCurrency } from "../../utils/FormatCurrency";

import ResumoTabela from "./components/ResumoTabela";

export default function Dashboard() {
  // Armazena os dados financeiros gerais retornados pela API.
  const [resumo, setResumo] = useState<ResumoGeral | null>(null);

  // Controla a exibição de erro durante o carregamento dos dados.
  const [erro, setErro] = useState(false);

  async function buscarResumo() {
    try {
      setErro(false);

      /*
       * Busca os valores consolidados do sistema:
       * - Total de receitas;
       * - Total de despesas;
       * - Saldo geral;
       * - Valores agrupados por pessoa.
       */
      const response = await api.get<ResumoGeral>("/Relatorios/resumo");

      setResumo(response.data);
    } catch {
      setErro(true);
    }
  }

  // Carrega o resumo financeiro assim que a página é inicializada.
  useEffect(() => {
    buscarResumo();
  }, []);

  // Exibe uma mensagem de erro caso a API não responda.
  if (erro) {
    return (
      <div>
        <PageHeader
          title="Dashboard"
          subtitle="Resumo financeiro da residência"
        />

        <div className="mt-4 space-y-4">
          <p>Não foi possível carregar o resumo.</p>

          <Button variant="contained" onClick={buscarResumo}>
            Tentar novamente
          </Button>
        </div>
      </div>
    );
  }

  // Enquanto a requisição ainda não terminou.
  if (!resumo) {
    return <div>Carregando dashboard...</div>;
  }

  return (
    <div>
      <PageHeader
        title="Dashboard"
        subtitle="Resumo financeiro da residência"
      />

      {/* Cards com os principais indicadores financeiros */}
      <div className="mt-2 grid grid-cols-1 md:grid-cols-3 gap-6">
        <StatsCard
          title="Total Receitas"
          value={formatCurrency(resumo.totalReceitas)}
          color="#2e7d32"
          icon={<TrendingUp />}
        />

        <StatsCard
          title="Total Despesas"
          value={formatCurrency(resumo.totalDespesas)}
          color="#d32f2f"
          icon={<TrendingDown />}
        />

        <StatsCard
          title="Saldo Líquido"
          value={formatCurrency(resumo.saldo)}
          color="#1976d2"
          icon={<AccountBalanceWallet />}
        />
      </div>

      {/* Tabela detalhada com os valores agrupados por pessoa */}
      <div className="mt-6">
        <h2 className="text-xl font-semibold mb-2">Totais por pessoa</h2>

        {resumo.pessoas.length > 0 ? (
          <ResumoTabela pessoas={resumo.pessoas} />
        ) : (
          <p>Nenhuma transação cadastrada.</p>
        )}
      </div>
    </div>
  );
}

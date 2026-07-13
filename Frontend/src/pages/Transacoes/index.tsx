import { useEffect, useState } from "react";

import { Button } from "@mui/material";

import {
  Add,
  ReceiptLong,
  TrendingUp,
  TrendingDown,
} from "@mui/icons-material";

import { api } from "../../api/api";

import type { Pessoa } from "../../types/Pessoa";
import type { Transacao } from "../../types/Transacao";

import Notification from "../../components/Notification";
import PageHeader from "../../components/PageHeader";
import StatsCard from "../../components/StatsCard";

import TransacaoTable from "./components/TransacaoTable";
import TransacaoDialog from "./components/TransacaoDialog";

export default function Transacoes() {
  // Lista de transações cadastradas no sistema.
  const [transacoes, setTransacoes] = useState<Transacao[]>([]);

  // Lista usada para identificar a pessoa vinculada à transação.
  const [pessoas, setPessoas] = useState<Pessoa[]>([]);

  // Controla abertura do modal de cadastro.
  const [open, setOpen] = useState(false);

  // Estado responsável pelas mensagens de feedback ao usuário.
  const [notification, setNotification] = useState({
    open: false,

    message: "",

    severity: "success" as "success" | "error",
  });

  async function buscarTransacoes() {
    // Busca todas as movimentações financeiras cadastradas.
    const response = await api.get<Transacao[]>("/Transacoes");

    setTransacoes(response.data);
  }

  async function buscarPessoas() {
    // Carrega as pessoas disponíveis para relacionamento com transações.
    const response = await api.get<Pessoa[]>("/Pessoas");

    setPessoas(response.data);
  }

  async function removerTransacao(id: string) {
    try {
      // Remove a transação e atualiza a listagem após a exclusão.
      await api.delete(`/Transacoes/${id}`);

      await buscarTransacoes();

      showNotification("Transação removida com sucesso.", "success");
    } catch {
      showNotification("Erro ao remover transação.", "error");
    }
  }

  function showNotification(
    message: string,

    severity: "success" | "error",
  ) {
    setNotification({
      open: true,

      message,

      severity,
    });
  }

  function fecharNotification() {
    setNotification({
      ...notification,

      open: false,
    });
  }

  // Carrega os dados necessários ao abrir a página.
  useEffect(() => {
    buscarTransacoes();

    buscarPessoas();
  }, []);

  /*
   * Indicadores exibidos nos cards superiores.
   * São calculados com base nas transações carregadas.
   */
  const total = transacoes.length;

  const receitas = transacoes.filter((t) => t.tipo === "Receita").length;

  const despesas = transacoes.filter((t) => t.tipo === "Despesa").length;

  return (
    <div className="space-y-6">
      <PageHeader
        title="Transações"
        subtitle="Gerencie receitas e despesas"
        action={
          <Button
            variant="contained"
            startIcon={<Add />}
            onClick={() => setOpen(true)}
          >
            Nova Transação
          </Button>
        }
      />

      {/* Cards com os principais indicadores da página */}
      <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
        <StatsCard
          title="Transações"
          value={total}
          color="#1976d2"
          icon={<ReceiptLong />}
        />

        <StatsCard
          title="Receitas"
          value={receitas}
          color="#2e7d32"
          icon={<TrendingUp />}
        />

        <StatsCard
          title="Despesas"
          value={despesas}
          color="#d32f2f"
          icon={<TrendingDown />}
        />
      </div>

      <TransacaoTable
        transacoes={transacoes}
        pessoas={pessoas}
        onDelete={removerTransacao}
      />

      <TransacaoDialog
        open={open}
        onClose={() => setOpen(false)}
        onCreated={buscarTransacoes}
        onSuccess={(message) => showNotification(message, "success")}
        onError={(message) => showNotification(message, "error")}
      />

      <Notification
        open={notification.open}
        message={notification.message}
        severity={notification.severity}
        onClose={fecharNotification}
      />
    </div>
  );
}

import { useEffect, useState } from "react";

import { Button } from "@mui/material";
import { Add, People } from "@mui/icons-material";

import { api } from "../../api/api";

import type { Pessoa } from "../../types/Pessoa";

import PessoaDialog from "./components/PessoaDialog";
import PessoaTable from "./components/PessoaTable";

import Notification from "../../components/Notification";
import PageHeader from "../../components/PageHeader";
import StatsCard from "../../components/StatsCard";

export default function Pessoas() {
  // Lista de pessoas carregadas da API.
  const [pessoas, setPessoas] = useState<Pessoa[]>([]);

  // Controla a abertura do modal de cadastro.
  const [open, setOpen] = useState(false);

  // Estado responsável pelas mensagens exibidas ao usuário.
  const [notification, setNotification] = useState({
    open: false,

    message: "",

    severity: "success" as "success" | "error",
  });

  async function buscarPessoas() {
    try {
      // Busca todas as pessoas cadastradas no sistema.
      const response = await api.get<Pessoa[]>("/Pessoas");

      setPessoas(response.data);
    } catch {
      showNotification("Erro ao carregar pessoas.", "error");
    }
  }

  async function removerPessoa(id: string) {
    try {
      /*
       * Após remover uma pessoa, a lista é atualizada
       * novamente para refletir o estado atual do sistema.
       */
      await api.delete(`/Pessoas/${id}`);

      await buscarPessoas();

      showNotification("Pessoa removida com sucesso.", "success");
    } catch {
      showNotification("Erro ao remover pessoa.", "error");
    }
  }

  function showNotification(
    message: string,

    severity: "success" | "error",
  ) {
    // Exibe uma mensagem temporária de feedback para o usuário.
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

  // Carrega as pessoas ao abrir a página.
  useEffect(() => {
    buscarPessoas();
  }, []);

  return (
    <div className="space-y-6">
      <PageHeader
        title="Pessoas"
        subtitle="Gerencie as pessoas cadastradas"
        action={
          <Button
            variant="contained"
            startIcon={<Add />}
            onClick={() => setOpen(true)}
          >
            Nova Pessoa
          </Button>
        }
      />

      {/* Exibe a quantidade atual de pessoas cadastradas */}
      <StatsCard
        title="Pessoas cadastradas"
        value={pessoas.length}
        color="#1976d2"
        icon={<People />}
      />

      <PessoaTable pessoas={pessoas} onDelete={removerPessoa} />

      <PessoaDialog
        open={open}
        onClose={() => setOpen(false)}
        onCreated={buscarPessoas}
        onSuccess={() =>
          showNotification("Pessoa cadastrada com sucesso.", "success")
        }
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

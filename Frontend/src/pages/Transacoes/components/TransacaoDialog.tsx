import { useEffect, useState } from "react";

import {
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  TextField,
  Button,
  MenuItem,
} from "@mui/material";

import { api } from "../../../api/api";

import type { Pessoa } from "../../../types/Pessoa";

interface Props {
  open: boolean;

  onClose: () => void;

  onCreated: () => void;

  onSuccess: (message: string) => void;

  onError: (message: string) => void;
}

export default function TransacaoDialog({
  open,

  onClose,

  onCreated,

  onSuccess,

  onError,
}: Props) {
  const [descricao, setDescricao] = useState("");

  const [valor, setValor] = useState("");

  const [tipo, setTipo] = useState<"Despesa" | "Receita">("Despesa");

  const [pessoas, setPessoas] = useState<Pessoa[]>([]);

  const [pessoaId, setPessoaId] = useState("");

  async function buscarPessoas() {
    try {
      // Carrega as pessoas disponíveis para vincular à transação.
      const response = await api.get<Pessoa[]>("/Pessoas");

      setPessoas(response.data);
    } catch {
      onError("Erro ao carregar pessoas.");
    }
  }

  function pessoaSelecionada() {
    return pessoas.find((pessoa) => pessoa.id === pessoaId);
  }

  function validarFormulario() {
    if (!descricao.trim()) {
      onError("A descrição é obrigatória.");

      return false;
    }

    if (!valor || Number(valor) <= 0) {
      onError("O valor deve ser maior que zero.");

      return false;
    }

    if (!pessoaId) {
      onError("Selecione uma pessoa.");

      return false;
    }

    const pessoa = pessoaSelecionada();

    /*
     * Regra de negócio:
     * Pessoas menores de 18 anos podem cadastrar
     * apenas despesas.
     */
    if (pessoa && pessoa.idade < 18 && tipo === "Receita") {
      onError("Pessoas menores de idade podem cadastrar apenas despesas.");

      return false;
    }

    return true;
  }

  async function salvar() {
    // Impede o envio caso os dados não estejam válidos.
    if (!validarFormulario()) {
      return;
    }

    try {
      await api.post("/Transacoes", {
        descricao,

        valor: Number(valor),

        tipo,

        pessoaId,
      });

      limpar();

      // Atualiza a lista de transações após o cadastro.
      onCreated();

      onSuccess("Transação cadastrada com sucesso.");

      onClose();
    } catch (error: any) {
      console.error(
        "Erro ao cadastrar transação:",
        error.response?.data ?? error,
      );

      onError(error.response?.data?.detail ?? "Erro ao cadastrar transação.");
    }
  }

  function limpar() {
    // Restaura o formulário após salvar uma transação.
    setDescricao("");

    setValor("");

    setTipo("Despesa");

    setPessoaId("");
  }

  // Busca as pessoas somente quando o modal é aberto.
  useEffect(() => {
    if (open) {
      buscarPessoas();
    }
  }, [open]);

  return (
    <Dialog open={open} onClose={onClose}>
      <DialogTitle>Nova transação</DialogTitle>

      <DialogContent>
        <TextField
          fullWidth
          margin="dense"
          label="Descrição"
          value={descricao}
          onChange={(e) => setDescricao(e.target.value)}
        />

        <TextField
          fullWidth
          margin="dense"
          label="Valor"
          type="number"
          value={valor}
          onChange={(e) => setValor(e.target.value)}
        />

        <TextField
          select
          fullWidth
          margin="dense"
          label="Tipo"
          value={tipo}
          onChange={(e) => setTipo(e.target.value as "Despesa" | "Receita")}
        >
          <MenuItem value="Despesa">Despesa</MenuItem>

          <MenuItem value="Receita">Receita</MenuItem>
        </TextField>

        <TextField
          select
          fullWidth
          margin="dense"
          label="Pessoa"
          value={pessoaId}
          onChange={(e) => setPessoaId(e.target.value)}
        >
          {pessoas.map((pessoa) => (
            <MenuItem key={pessoa.id} value={pessoa.id}>
              {pessoa.nome}
              {" - "}
              {pessoa.idade} anos
            </MenuItem>
          ))}
        </TextField>
      </DialogContent>

      <DialogActions>
        <Button onClick={onClose}>Cancelar</Button>

        <Button variant="contained" onClick={salvar}>
          Salvar
        </Button>
      </DialogActions>
    </Dialog>
  );
}

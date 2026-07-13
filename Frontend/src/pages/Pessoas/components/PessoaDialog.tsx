import { useState } from "react";

import {
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  TextField,
  Button,
} from "@mui/material";

import { api } from "../../../api/api";

interface Props {
  open: boolean;

  onClose: () => void;

  // Atualiza a lista de pessoas após o cadastro.
  onCreated: () => void;

  // Exibe uma mensagem de sucesso para o usuário.
  onSuccess: () => void;
}

export default function PessoaDialog({
  open,

  onClose,

  onCreated,

  onSuccess,
}: Props) {
  // Estados utilizados para controlar os campos do formulário.
  const [nome, setNome] = useState("");

  const [idade, setIdade] = useState("");

  async function handleSubmit() {
    try {
      /*
       * Envia os dados para a API criar uma nova pessoa.
       * A idade é convertida para número antes do envio.
       */
      await api.post("/Pessoas", {
        nome,

        idade: Number(idade),
      });

      // Limpa o formulário após o cadastro.
      setNome("");

      setIdade("");

      // Atualiza a tabela e fecha o modal.
      onCreated();

      onSuccess();

      onClose();
    } catch (error) {
      console.error("Erro ao cadastrar pessoa:", error);
    }
  }

  return (
    /*
     * Modal responsável pelo cadastro de novas pessoas.
     */
    <Dialog open={open} onClose={onClose}>
      <DialogTitle>Nova pessoa</DialogTitle>

      <DialogContent className="space-y-4">
        <TextField
          fullWidth
          label="Nome"
          margin="dense"
          value={nome}
          onChange={(e) => setNome(e.target.value)}
        />

        <TextField
          fullWidth
          label="Idade"
          type="number"
          margin="dense"
          value={idade}
          onChange={(e) => setIdade(e.target.value)}
        />
      </DialogContent>

      <DialogActions>
        <Button onClick={onClose}>Cancelar</Button>

        <Button variant="contained" onClick={handleSubmit}>
          Salvar
        </Button>
      </DialogActions>
    </Dialog>
  );
}

import {
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Chip,
  IconButton,
  Tooltip,
} from "@mui/material";

import DeleteIcon from "@mui/icons-material/Delete";

import type { Pessoa } from "../../../types/Pessoa";
import type { Transacao } from "../../../types/Transacao";

import { formatCurrency } from "../../../utils/FormatCurrency";

/*
 * Tabela responsável por exibir as transações cadastradas.
 *
 * Apresenta:
 * - Descrição da transação;
 * - Valor;
 * - Tipo (receita ou despesa);
 * - Pessoa vinculada;
 * - Ação de exclusão.
 */
interface Props {
  transacoes: Transacao[];

  pessoas: Pessoa[];

  onDelete: (id: string) => void;
}

export default function TransacaoTable({
  transacoes,

  pessoas,

  onDelete,
}: Props) {
  function buscarNomePessoa(pessoaId: string) {
    // Localiza a pessoa responsável pela transação através do ID.
    return (
      pessoas.find((pessoa) => pessoa.id === pessoaId)?.nome ??
      "Pessoa não encontrada"
    );
  }

  return (
    <TableContainer
      component={Paper}
      elevation={2}
      sx={{
        borderRadius: 3,
      }}
    >
      <Table>
        <TableHead>
          <TableRow
            sx={{
              backgroundColor: "#f5f5f5",
            }}
          >
            <TableCell>
              <strong>Descrição</strong>
            </TableCell>

            <TableCell align="right">
              <strong>Valor</strong>
            </TableCell>

            <TableCell>
              <strong>Tipo</strong>
            </TableCell>

            <TableCell>
              <strong>Pessoa</strong>
            </TableCell>

            <TableCell align="center" width={100}>
              <strong>Ações</strong>
            </TableCell>
          </TableRow>
        </TableHead>

        <TableBody>
          {transacoes.length === 0 ? (
            <TableRow>
              <TableCell colSpan={5} align="center">
                Nenhuma transação cadastrada.
              </TableCell>
            </TableRow>
          ) : (
            transacoes.map((transacao) => (
              <TableRow key={transacao.id} hover>
                <TableCell>
                  <strong>{transacao.descricao}</strong>
                </TableCell>

                <TableCell align="right">
                  <strong>{formatCurrency(transacao.valor)}</strong>
                </TableCell>

                <TableCell>
                  {/*
                   * Receitas e despesas possuem
                   * cores diferentes para facilitar
                   * a identificação visual.
                   */}

                  {transacao.tipo === "Receita" ? (
                    <Chip label="Receita" color="success" size="small" />
                  ) : (
                    <Chip label="Despesa" color="error" size="small" />
                  )}
                </TableCell>

                <TableCell>{buscarNomePessoa(transacao.pessoaId)}</TableCell>

                <TableCell align="center">
                  <Tooltip title="Excluir">
                    <IconButton
                      color="error"
                      onClick={() => onDelete(transacao.id)}
                    >
                      <DeleteIcon />
                    </IconButton>
                  </Tooltip>
                </TableCell>
              </TableRow>
            ))
          )}
        </TableBody>
      </Table>
    </TableContainer>
  );
}

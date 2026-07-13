import {
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  IconButton,
  Tooltip,
  Chip,
  Stack,
} from "@mui/material";

import DeleteIcon from "@mui/icons-material/Delete";

import type { Pessoa } from "../../../types/Pessoa";

/*
 * Tabela responsável pela exibição das pessoas cadastradas.
 *
 * Permite:
 * - Visualizar nome e idade;
 * - Identificar situação de maioridade;
 * - Remover uma pessoa.
 */
interface Props {
  pessoas: Pessoa[];

  onDelete: (id: string) => void;
}

export default function PessoaTable({
  pessoas,

  onDelete,
}: Props) {
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
              <strong>Nome</strong>
            </TableCell>

            <TableCell>
              <strong>Idade</strong>
            </TableCell>

            <TableCell>
              <strong>Situação</strong>
            </TableCell>

            <TableCell align="center" width={100}>
              <strong>Ações</strong>
            </TableCell>
          </TableRow>
        </TableHead>

        <TableBody>
          {pessoas.length === 0 ? (
            <TableRow>
              <TableCell colSpan={4} align="center">
                Nenhuma pessoa cadastrada.
              </TableCell>
            </TableRow>
          ) : (
            pessoas.map((pessoa) => (
              <TableRow key={pessoa.id} hover>
                <TableCell>
                  <strong>{pessoa.nome}</strong>
                </TableCell>

                <TableCell>{pessoa.idade} anos</TableCell>

                <TableCell>
                  <Stack direction="row">
                    {/*
                     * A classificação de maioridade é baseada
                     * na idade da pessoa cadastrada.
                     */}
                    {pessoa.idade >= 18 ? (
                      <Chip
                        label="Maior de idade"
                        color="success"
                        size="small"
                      />
                    ) : (
                      <Chip
                        label="Menor de idade"
                        color="warning"
                        size="small"
                      />
                    )}
                  </Stack>
                </TableCell>

                <TableCell align="center">
                  <Tooltip title="Excluir">
                    <IconButton
                      color="error"
                      onClick={() => onDelete(pessoa.id)}
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

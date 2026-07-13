import {
  Box,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Typography,
} from "@mui/material";

import {
  TrendingUp,
  TrendingDown,
  AccountBalanceWallet,
} from "@mui/icons-material";

import type { ResumoPessoa } from "../../../types/Relatorio";

import { formatCurrency } from "../../../utils/FormatCurrency";

/*
 * Exibe o resumo financeiro agrupado por pessoa.
 *
 * Cada linha apresenta:
 * - Nome da pessoa;
 * - Total de receitas;
 * - Total de despesas;
 * - Saldo final calculado.
 */
interface Props {
  pessoas: ResumoPessoa[];
}

export default function ResumoTabela({ pessoas }: Props) {
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
              <strong>Pessoa</strong>
            </TableCell>

            <TableCell align="right">
              <strong>Receitas</strong>
            </TableCell>

            <TableCell align="right">
              <strong>Despesas</strong>
            </TableCell>

            <TableCell align="right">
              <strong>Saldo</strong>
            </TableCell>
          </TableRow>
        </TableHead>

        <TableBody>
          {pessoas.length === 0 ? (
            <TableRow>
              <TableCell colSpan={4} align="center">
                Nenhum dado encontrado.
              </TableCell>
            </TableRow>
          ) : (
            pessoas.map((pessoa) => (
              <TableRow key={pessoa.id} hover>
                <TableCell>
                  <strong>{pessoa.nome}</strong>
                </TableCell>

                {/* Exibe o total de entradas financeiras */}
                <TableCell align="right">
                  <Box
                    sx={{
                      display: "flex",
                      justifyContent: "flex-end",
                      alignItems: "center",
                      gap: 1,
                    }}
                  >
                    <TrendingUp fontSize="small" color="success" />

                    <Typography
                      sx={{
                        color: "success.main",
                        fontWeight: 600,
                      }}
                    >
                      {formatCurrency(pessoa.totalReceitas)}
                    </Typography>
                  </Box>
                </TableCell>

                {/* Exibe o total de saídas financeiras */}
                <TableCell align="right">
                  <Box
                    sx={{
                      display: "flex",
                      justifyContent: "flex-end",
                      alignItems: "center",
                      gap: 1,
                    }}
                  >
                    <TrendingDown fontSize="small" color="error" />

                    <Typography
                      sx={{
                        color: "error.main",
                        fontWeight: 600,
                      }}
                    >
                      {formatCurrency(pessoa.totalDespesas)}
                    </Typography>
                  </Box>
                </TableCell>

                {/*
                 * Saldo positivo é exibido em azul.
                 * Saldo negativo é exibido em vermelho.
                 */}
                <TableCell align="right">
                  <Box
                    sx={{
                      display: "flex",
                      justifyContent: "flex-end",
                      alignItems: "center",
                      gap: 1,
                    }}
                  >
                    <AccountBalanceWallet
                      fontSize="small"
                      color={pessoa.saldo >= 0 ? "primary" : "error"}
                    />

                    <Typography
                      sx={{
                        color:
                          pessoa.saldo >= 0 ? "primary.main" : "error.main",

                        fontWeight: 700,
                      }}
                    >
                      {formatCurrency(pessoa.saldo)}
                    </Typography>
                  </Box>
                </TableCell>
              </TableRow>
            ))
          )}
        </TableBody>
      </Table>
    </TableContainer>
  );
}

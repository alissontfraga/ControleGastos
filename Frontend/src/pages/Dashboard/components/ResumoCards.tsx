import { Card, CardContent, Typography } from "@mui/material";

import {
  TrendingUp,
  TrendingDown,
  AccountBalanceWallet,
} from "@mui/icons-material";

import { formatCurrency } from "../../../utils/FormatCurrency";

/*
 * Componente responsável por exibir os principais indicadores
 * financeiros do dashboard.
 *
 * Exibe:
 * - Total de receitas;
 * - Total de despesas;
 * - Saldo líquido.
 */
interface Props {
  // Valores calculados pelo relatório geral.
  totalReceitas: number;

  totalDespesas: number;

  saldo: number;
}

export default function ResumoCards({
  totalReceitas,

  totalDespesas,

  saldo,
}: Props) {
  return (
    <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
      {/* Card responsável pelo total de entradas financeiras */}
      <Card className="bg-green-50 border border-green-200">
        <CardContent>
          <div className="flex justify-between items-center">
            <div>
              <Typography color="text.secondary">Total Receitas</Typography>

              <Typography variant="h4" className="font-bold text-green-600">
                {formatCurrency(totalReceitas)}
              </Typography>
            </div>

            <TrendingUp className="text-green-600" fontSize="large" />
          </div>
        </CardContent>
      </Card>

      {/* Card responsável pelo total de saídas financeiras */}
      <Card className="bg-red-50 border border-red-200">
        <CardContent>
          <div className="flex justify-between items-center">
            <div>
              <Typography color="text.secondary">Total Despesas</Typography>

              <Typography variant="h4" className="font-bold text-red-600">
                {formatCurrency(totalDespesas)}
              </Typography>
            </div>

            <TrendingDown className="text-red-600" fontSize="large" />
          </div>
        </CardContent>
      </Card>

      {/* Card responsável pelo resultado financeiro final */}
      <Card className="bg-blue-50 border border-blue-200">
        <CardContent>
          <div className="flex justify-between items-center">
            <div>
              <Typography color="text.secondary">Saldo Líquido</Typography>

              <Typography variant="h4" className="font-bold text-blue-600">
                {formatCurrency(saldo)}
              </Typography>
            </div>

            <AccountBalanceWallet className="text-blue-600" fontSize="large" />
          </div>
        </CardContent>
      </Card>
    </div>
  );
}

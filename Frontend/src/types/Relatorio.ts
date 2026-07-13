export interface ResumoPessoa {
  id: string;

  nome: string;

  totalReceitas: number;

  totalDespesas: number;

  saldo: number;
}

export interface ResumoGeral {
  pessoas: ResumoPessoa[];

  totalReceitas: number;

  totalDespesas: number;

  saldo: number;
}

export type TipoTransacao = "Despesa" | "Receita";

export interface Transacao {
  id: string;
  descricao: string;
  valor: number;
  tipo: TipoTransacao;
  pessoaId: string;
}

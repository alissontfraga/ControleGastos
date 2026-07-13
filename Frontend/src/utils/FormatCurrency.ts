/*
* Formata valores numéricos para o padrão monetário brasileiro.
* Exemplo: 1500 -> R$ 1.500,00
*/
export function formatCurrency(value: number) {

return value.toLocaleString("pt-BR", {

  style: "currency",

  currency: "BRL",

});

}
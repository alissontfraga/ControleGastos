import axios from "axios";

/*
 * Instância centralizada do Axios utilizada para comunicação com a API.
 *
 * A URL base é carregada através de uma variável de ambiente,
 * permitindo alterar o endereço do backend sem modificar o código.
 */
export const api = axios.create({
  baseURL: import.meta.env.VITE_API_URL,
});

import { useEffect, useState } from "react";

import { api } from "../../api/api";

import type { Pessoa } from "../../types/Pessoa";

import PessoaForm from "./components/PessoaForm";
import PessoaTable from "./components/PessoaTable";


export default function Pessoas() {

    const [pessoas, setPessoas] = useState<Pessoa[]>([]);


    async function buscarPessoas() {

        const response = await api.get<Pessoa[]>("/Pessoas");

        setPessoas(response.data);

    }


    async function removerPessoa(id: string) {

        await api.delete(`/Pessoas/${id}`);

        buscarPessoas();

    }


    useEffect(() => {

        buscarPessoas();

    }, []);


    return (

        <div className="space-y-6">

            <h1 className="text-2xl font-bold">
                Pessoas
            </h1>


            <PessoaForm
                onCreated={buscarPessoas}
            />


            <PessoaTable
                pessoas={pessoas}
                onDelete={removerPessoa}
            />

        </div>

    );
}
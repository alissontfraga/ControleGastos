import { useState } from "react";

import {
    Button,
    TextField,
} from "@mui/material";

import { api } from "../../../api/api";


interface Props {
    onCreated: () => void;
}


export default function PessoaForm({ onCreated }: Props) {

    const [nome, setNome] = useState("");
    const [idade, setIdade] = useState("");


    async function handleSubmit() {

        await api.post("/Pessoas", {
            nome,
            idade: Number(idade),
        });


        setNome("");
        setIdade("");

        onCreated();
    }


    return (
        <div className="flex gap-4">

            <TextField
                label="Nome"
                value={nome}
                onChange={(e) => setNome(e.target.value)}
            />


            <TextField
                label="Idade"
                type="number"
                value={idade}
                onChange={(e) => setIdade(e.target.value)}
            />


            <Button
                variant="contained"
                onClick={handleSubmit}
            >
                Cadastrar
            </Button>

        </div>
    );
}
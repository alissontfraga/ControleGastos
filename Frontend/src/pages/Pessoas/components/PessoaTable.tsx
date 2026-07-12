import {
    Button,
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    Paper,
} from "@mui/material";


import type { Pessoa } from "../../../types/Pessoa";


interface Props {
    pessoas: Pessoa[];
    onDelete: (id: string) => void;
}


export default function PessoaTable({
    pessoas,
    onDelete
}: Props) {


    return (
        <TableContainer component={Paper}>

            <Table>

                <TableHead>

                    <TableRow>

                        <TableCell>
                            Nome
                        </TableCell>

                        <TableCell>
                            Idade
                        </TableCell>

                        <TableCell>
                            Ações
                        </TableCell>

                    </TableRow>

                </TableHead>


                <TableBody>

                    {pessoas.map((pessoa) => (

                        <TableRow key={pessoa.id}>

                            <TableCell>
                                {pessoa.nome}
                            </TableCell>


                            <TableCell>
                                {pessoa.idade}
                            </TableCell>


                            <TableCell>

                                <Button
                                    color="error"
                                    onClick={() => onDelete(pessoa.id)}
                                >
                                    Excluir
                                </Button>

                            </TableCell>

                        </TableRow>

                    ))}

                </TableBody>

            </Table>

        </TableContainer>
    );
}
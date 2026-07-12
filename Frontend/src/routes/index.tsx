import { BrowserRouter, Routes, Route } from "react-router-dom";

import Layout from "../components/Layout";

import Pessoas from "../pages/Pessoas"
import Transacoes from "../pages/Transacoes";
import Relatorios from "../pages/Relatorios";


export default function AppRoutes() {

    return (

        <BrowserRouter>

            <Routes>

                <Route element={<Layout />}>

                    <Route 
                        path="/" 
                        element={<Pessoas />} 
                    />

                    <Route
                        path="/transacoes"
                        element={<Transacoes />}
                    />

                    <Route
                        path="/relatorios"
                        element={<Relatorios />}
                    />

                </Route>

            </Routes>

        </BrowserRouter>

    );
}
import { Outlet, Link } from "react-router-dom";

import {
    AppBar,
    Toolbar,
    Typography,
    List,
    ListItem,
    ListItemButton,
    ListItemText,
} from "@mui/material";


const menuItems = [
    {
        label: "Pessoas",
        path: "/",
    },
    {
        label: "Transações",
        path: "/transacoes",
    },
    {
        label: "Relatórios",
        path: "/relatorios",
    },
];


export default function Layout() {
    return (
        <div className="flex flex-col min-h-screen w-full">

            {/* Navbar */}
            <AppBar 
                position="static"
                elevation={1}
            >
                <Toolbar>
                    <Typography variant="h6">
                        Controle de Gastos
                    </Typography>
                </Toolbar>
            </AppBar>


            {/* Corpo */}
            <div className="flex flex-1 w-full">

                {/* Sidebar */}
                <aside className="w-64 min-h-full border-r bg-gray-50">

                    <List>
                        {menuItems.map((item) => (
                            <ListItem 
                                key={item.path}
                                disablePadding
                            >
                                <ListItemButton
                                    component={Link}
                                    to={item.path}
                                >
                                    <ListItemText
                                        primary={item.label}
                                    />
                                </ListItemButton>
                            </ListItem>
                        ))}
                    </List>

                </aside>


                {/* Conteúdo */}
                <main className="flex-1 p-6">
                    <Outlet />
                </main>

            </div>

        </div>
    );
}
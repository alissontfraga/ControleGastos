// src/components/Layout/index.tsx

import { Outlet, NavLink } from "react-router-dom";

import {
  AppBar,
  Toolbar,
  Typography,
  List,
  ListItem,
  ListItemButton,
  ListItemIcon,
  ListItemText,
} from "@mui/material";

import {
  Dashboard,
  People,
  ReceiptLong,
  AccountBalanceWallet,
} from "@mui/icons-material";

const menuItems = [
  {
    label: "Dashboard",
    path: "/",
    icon: <Dashboard />,
  },

  {
    label: "Pessoas",
    path: "/pessoas",
    icon: <People />,
  },

  {
    label: "Transações",
    path: "/transacoes",
    icon: <ReceiptLong />,
  },
];

export default function Layout() {
  return (
    <div className="flex flex-col min-h-screen bg-slate-100">
      {/* Navbar */}

      <AppBar position="static" elevation={2}>
        <Toolbar className="gap-3">
          <AccountBalanceWallet />

          <Typography
            variant="h6"
            sx={{
              fontWeight: 600,
            }}
          >
            Controle de Gastos Residenciais
          </Typography>
        </Toolbar>
      </AppBar>

      {/* Corpo */}

      <div className="flex flex-1">
        {/* Sidebar */}

        <aside className="w-64 bg-white border-r shadow-sm">
          <List className="py-4">
            {menuItems.map((item) => (
              <ListItem key={item.path} disablePadding>
                <ListItemButton
                  component={NavLink}
                  to={item.path}
                  end={item.path === "/"}
                  sx={{
                    mx: 1,

                    my: 0.5,

                    borderRadius: 2,

                    "&.active": {
                      backgroundColor: "#1976d2",

                      color: "white",

                      "& .MuiListItemIcon-root": {
                        color: "white",
                      },
                    },
                  }}
                >
                  <ListItemIcon>{item.icon}</ListItemIcon>

                  <ListItemText primary={item.label} />
                </ListItemButton>
              </ListItem>
            ))}
          </List>
        </aside>

        {/* Conteúdo */}

        <main className="flex-1 p-8 overflow-auto">
          <Outlet />
        </main>
      </div>
    </div>
  );
}

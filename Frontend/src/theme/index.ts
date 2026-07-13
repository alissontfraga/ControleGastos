import { createTheme } from "@mui/material/styles";

const theme = createTheme({
  palette: {
    primary: {
      main: "#2563eb",
    },

    secondary: {
      main: "#7c3aed",
    },

    success: {
      main: "#16a34a",
    },

    error: {
      main: "#dc2626",
    },

    background: {
      default: "#f8fafc",
      paper: "#ffffff",
    },
  },

  shape: {
    borderRadius: 12,
  },

  typography: {
    fontFamily: ["Inter", "Roboto", "sans-serif"].join(","),

    h4: {
      fontWeight: 700,
    },

    h6: {
      fontWeight: 600,
    },
  },

  components: {
    MuiButton: {
      styleOverrides: {
        root: {
          borderRadius: 10,

          textTransform: "none",

          fontWeight: 600,
        },
      },
    },

    MuiAppBar: {
      styleOverrides: {
        root: {
          borderRadius: 0,
        },
      },
    },

    MuiPaper: {
      styleOverrides: {
        root: {
          borderRadius: 14,
        },
      },
    },

    MuiTableHead: {
      styleOverrides: {
        root: {
          backgroundColor: "#f8fafc",
        },
      },
    },
  },
});

export default theme;

import { Snackbar, Alert } from "@mui/material";

interface Props {
  open: boolean;
  message: string;
  severity: "success" | "error";
  onClose: () => void;
}

export default function Notification({
  open,
  message,
  severity,
  onClose,
}: Props) {
  return (
    <Snackbar open={open} autoHideDuration={3000} onClose={onClose}>
      <Alert severity={severity} onClose={onClose} variant="filled">
        {message}
      </Alert>
    </Snackbar>
  );
}

import { Card, CardContent, Typography, Box } from "@mui/material";

import type { ReactNode } from "react";

interface Props {
  title: string;

  value: string | number;

  icon: ReactNode;

  color: string;
}

export default function StatsCard({
  title,

  value,

  icon,

  color,
}: Props) {
  return (
    <Card
      elevation={2}
      sx={{
        borderRadius: 3,
      }}
    >
      <CardContent
        sx={{
          "&:last-child": {
            pb: 2,
          },
          py: 2,
        }}
      >
        <Box
          sx={{
            display: "flex",
            alignItems: "center",
            gap: 2,
          }}
        >
          <Box
            sx={{
              width: 48,
              height: 48,
              borderRadius: "50%",
              backgroundColor: color,
              color: "white",
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
            }}
          >
            {icon}
          </Box>

          <Box>
            <Typography variant="body2" color="text.secondary">
              {title}
            </Typography>

            <Typography
              variant="h5"
              sx={{
                fontWeight: 700,
              }}
            >
              {value}
            </Typography>
          </Box>
        </Box>
      </CardContent>
    </Card>
  );
}

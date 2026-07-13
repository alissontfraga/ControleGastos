import type { ReactNode } from "react";

import { Typography } from "@mui/material";

interface Props {
  title: string;

  subtitle?: string;

  action?: ReactNode;
}

export default function PageHeader({
  title,

  subtitle,

  action,
}: Props) {
  return (
    <div className="flex justify-between items-center mb-4">
      <div>
        <Typography
          variant="h4"
          sx={{
            fontWeight: 700,
          }}
        >
          {title}
        </Typography>

        {subtitle && (
          <Typography
            variant="body1"
            color="text.secondary"
            sx={{
              mt: 0.5,
            }}
          >
            {subtitle}
          </Typography>
        )}
      </div>

      {action}
    </div>
  );
}

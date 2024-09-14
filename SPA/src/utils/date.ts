import { format } from "date-fns";

export const toISODateStr = (value: Date | null | undefined) => {
  if (!value) return null;
  return format(value, "yyyy-MM-dd");
};

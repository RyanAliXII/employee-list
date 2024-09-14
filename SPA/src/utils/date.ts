import { format } from "date-fns";

export const toISODateStr = (value: Date | null | undefined) => {
  if (!value) return null;
  return format(value, "yyyy-MM-dd");
};

export const toReadableDate = (d: Date | null | undefined) => {
  if (!d) return "";
  return d.toLocaleDateString(undefined, {
    month: "long",
    day: "2-digit",
    year: "numeric",
  });
};

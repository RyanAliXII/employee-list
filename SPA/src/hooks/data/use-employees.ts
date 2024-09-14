import { useEffect, useState } from "react";
import { InferType } from "yup";
import { employeesSchema } from "../../schema/employee";
import { serverRequest } from "#utils/http";

export const useEmployees = () => {
  const [employees, setEmplooyes] = useState<InferType<typeof employeesSchema>>(
    []
  );
  useEffect(() => {
    load();
  }, []);
  const load = async () => {
    const response = await serverRequest("/api/employees");
    const data = await response.json();
    const employees = employeesSchema.cast(data?.employees) ?? [];
    setEmplooyes(employees);
  };

  return {
    employees,
    reload: () => {
      load();
    },
  };
};

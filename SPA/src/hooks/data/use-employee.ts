import { useEffect, useState } from "react";
import { employeeSchema } from "../../schema/employee";
import { InferType } from "yup";
import { StatusCodes } from "http-status-codes";

type UseEmployeeConfig = {
  id: string;
  onSuccess?: (
    employee: InferType<typeof employeeSchema>,
    response: Response
  ) => void;
  onError?: (response: Response) => void;
};
export const useEmployee = ({
  id = "",
  onSuccess,
  onError,
}: UseEmployeeConfig) => {
  const [employee, setEmployee] = useState<InferType<
    typeof employeeSchema
  > | null>();
  const load = async () => {
    const response = await fetch(`http://localhost:5171/api/employees/${id}`);
    const data = await response.json();

    if (
      response.status >= StatusCodes.OK &&
      response.status < StatusCodes.BAD_REQUEST
    ) {
      const employee = employeeSchema.cast(data?.employee);
      setEmployee(employee);
      onSuccess?.(employee, response);
    }
    if (response.status >= StatusCodes.BAD_REQUEST) {
      onError?.(response);
    }
  };
  useEffect(() => {
    load();
  }, []);

  return {
    employee,
    reload: () => {
      load();
    },
  };
};

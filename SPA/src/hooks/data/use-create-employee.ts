import { InferType } from "yup";
import { mutateEmployeeSchema } from "../../schema/employee";
import { toISODateStr } from "../../utils/date";

export const useCreateEmployee = () => {
  const mutate = async (form: InferType<typeof mutateEmployeeSchema>) => {
    const body = mutateEmployeeSchema.cast(form);
    const response = await fetch("http://localhost:5171/api/employees", {
      method: "POST",
      body: JSON.stringify({
        ...body,
        dateOfBirth: toISODateStr(body.dateOfBirth),
      }),
      headers: new Headers({ "content-type": "application/json" }),
    });
    return response;
  };
  return {
    mutate: mutate,
  };
};

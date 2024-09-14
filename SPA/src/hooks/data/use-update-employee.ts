import { InferType } from "yup";
import { mutateEmployeeSchema } from "../../schema/employee";
import { toISODateStr } from "../../utils/date";

export const useUpdateEmployee = () => {
  const mutate = async (
    form: InferType<typeof mutateEmployeeSchema>,
    id = ""
  ) => {
    const body = mutateEmployeeSchema.cast(form);
    const response = await fetch(`http://localhost:5171/api/employees/${id}`, {
      method: "PUT",
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

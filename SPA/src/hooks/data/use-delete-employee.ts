import { serverRequest } from "#utils/http";

export const useDeleteEmployee = () => {
  const mutate = async (id = "") => {
    const response = await serverRequest(`/api/employees/${id}`, {
      method: "DELETE",
    });
    return response;
  };
  return {
    mutate: mutate,
  };
};

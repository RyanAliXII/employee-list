export const useDeleteEmployee = () => {
  const mutate = async (id = "") => {
    const response = await fetch(`http://localhost:5171/api/employees/${id}`, {
      method: "DELETE",
    });
    return response;
  };
  return {
    mutate: mutate,
  };
};

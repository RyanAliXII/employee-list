import { ChangeEvent, useState } from "react";

type UseFormConfig<T> = {
  initialData: T;
};
const useForm = <T extends Record<string, unknown> | unknown[]>({
  initialData,
}: UseFormConfig<T>) => {
  const [form, setForm] = useState(initialData);
  const [errors, setErrors] = useState({});
  const handleInput = (
    event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    const name = event.target.name;
    const value = event.target.value;
    setForm((prev) => ({ ...prev, [name]: value }));
  };
  return {
    form,
    setForm,
    errors,
    setErrors,
    handleInput,
  };
};

export default useForm;

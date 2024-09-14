import { ChangeEvent, Dispatch, SetStateAction, useState } from "react";

type UseFormConfig<T> = {
  initialData: T;
};
export type FormErrors = Record<string | number, string[]> | undefined | null;
export type UseForm<T> = {
  data: T;
  setData: Dispatch<SetStateAction<T>>;
  errors: FormErrors;
  setErrors: Dispatch<SetStateAction<FormErrors>>;
  handleInput: (
    event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => void;
  resetForm: () => void;
  removeErrors: () => void;
};
const useForm = <T extends Record<string, unknown> | unknown[]>({
  initialData,
}: UseFormConfig<T>): UseForm<T> => {
  const [data, setData] = useState(initialData);
  const [errors, setErrors] = useState<FormErrors>({});
  const handleInput = (
    event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    const name = event.target.name;
    const value = event.target.value;
    setData((prev) => ({ ...prev, [name]: value }));
  };
  const resetForm = () => {
    setData({ ...initialData });
  };
  const removeErrors = () => [setErrors({})];
  return {
    data,
    setData,
    errors,
    setErrors,
    handleInput,
    resetForm,
    removeErrors,
  };
};

export default useForm;

import { Label, TextInput } from "flowbite-react";
import { InferType } from "yup";
import { mutateEmployeeSchema } from "../../schema/employee";
import { UseForm } from "../../hooks/use-form";

function GovernmentIndataationdataSection({
  data,
  errors,
  handleInput,
}: UseForm<InferType<typeof mutateEmployeeSchema>>) {
  return (
    <section className="grid md:grid-cols-2 gap-2 lg:grid-cols-3">
      <div>
        <Label>SS number</Label>
        <TextInput
          onChange={handleInput}
          name="ssNumber"
          value={data.ssNumber}
          color={errors?.ssNumber ? "failure" : "primary"}
        ></TextInput>
        <p className="text-sm text-red-600">{errors?.ssNumber?.[0]}</p>
      </div>
      <div>
        <Label>TIN</Label>
        <TextInput
          onChange={handleInput}
          name="tin"
          value={data.tin}
          color={errors?.tin ? "failure" : "primary"}
        ></TextInput>
        <p className="text-sm text-red-600">{errors?.tin?.[0]}</p>
      </div>
      <div>
        <Label>MID number(Pag-Ibig)</Label>
        <TextInput
          onChange={handleInput}
          name="midNumber"
          value={data.midNumber}
          color={errors?.midNumber ? "failure" : "primary"}
        ></TextInput>
        <p className="text-sm text-red-600">{errors?.midNumber?.[0]}</p>
      </div>

      <div>
        <Label>PhilHealth number</Label>
        <TextInput
          onChange={handleInput}
          name="philhealthNumber"
          value={data.philhealthNumber}
          color={errors?.philhealthNumber ? "failure" : "primary"}
        ></TextInput>
        <p className="text-sm text-red-600">{errors?.philhealthNumber?.[0]}</p>
      </div>
    </section>
  );
}
export default GovernmentIndataationdataSection;

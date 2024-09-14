import { Label, TextInput } from "flowbite-react";
import { UseForm } from "#hooks/use-form";
import { InferType } from "yup";
import { mutateEmployeeSchema } from "#schema/employee";

function ContactInformationFormSection({
  data,
  handleInput,
  errors,
}: UseForm<InferType<typeof mutateEmployeeSchema>>) {
  return (
    <section className="grid md:grid-cols-2 gap-2 lg:grid-cols-3">
      <div>
        <Label>Mobile number</Label>
        <TextInput
          onChange={handleInput}
          name="mobileNumber"
          value={data.mobileNumber}
          color={errors?.mobileNumber ? "failure" : "primary"}
        ></TextInput>
        <p className="text-sm text-red-600">{errors?.mobileNumber?.[0]}</p>
      </div>
      <div>
        <Label>Email</Label>
        <TextInput
          onChange={handleInput}
          name="email"
          type="email"
          value={data.email}
          color={errors?.email ? "failure" : "primary"}
        ></TextInput>
        <p className="text-sm text-red-600">{errors?.email?.[0]}</p>
      </div>
    </section>
  );
}
export default ContactInformationFormSection;

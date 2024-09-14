import { Datepicker, Label, Textarea, TextInput } from "flowbite-react";
import { UseForm } from "../../hooks/use-form";
import { InferType } from "yup";
import { mutateEmployeeSchema } from "../../schema/employee";
import { toReadableDate } from "../../utils/date";
function PersonalInformationFormSection({
  data,
  handleInput,
  errors,
  setData,
}: UseForm<InferType<typeof mutateEmployeeSchema>>) {
  const handleDateOfBirth = (date: Date) => {
    setData((prev) => ({ ...prev, dateOfBirth: date }));
  };
  return (
    <section className="grid md:grid-cols-2 gap-2 lg:grid-cols-3">
      <div>
        <Label>Given name</Label>
        <TextInput
          onChange={handleInput}
          name="givenName"
          value={data.givenName}
          color={errors?.givenName ? "failure" : "primary"}
        ></TextInput>
        <p className="text-sm text-red-600">{errors?.givenName?.[0]}</p>
      </div>
      <div>
        <Label>Middle name</Label>
        <TextInput
          onChange={handleInput}
          name="middleName"
          value={data.middleName}
          color={errors?.middleName ? "failure" : "primary"}
        ></TextInput>
        <p className="text-sm text-red-600">{errors?.middleName?.[0]}</p>
      </div>
      <div>
        <Label>Surname</Label>
        <TextInput
          onChange={handleInput}
          name="surname"
          value={data.surname}
          color={errors?.surname ? "failure" : "primary"}
        ></TextInput>
        <p className="text-sm text-red-600">{errors?.surname?.[0]}</p>
      </div>

      <div>
        <Label>Date of birth</Label>
        <Datepicker
          value={toReadableDate(data.dateOfBirth)}
          color={errors?.dateOfBirth ? "failure" : "primary"}
          onSelectedDateChanged={handleDateOfBirth}
        ></Datepicker>
        <p className="text-sm text-red-600">{errors?.dateOfBirth?.[0]}</p>
      </div>
      <div className="md:col-span-2 lg:col-span-3">
        <Label>Address</Label>
        <Textarea
          onChange={handleInput}
          name="address"
          value={data.address}
          color={errors?.address ? "failure" : "primary"}
        ></Textarea>
        <p className="text-sm text-red-600">{errors?.address?.[0]}</p>
      </div>
    </section>
  );
}

export default PersonalInformationFormSection;

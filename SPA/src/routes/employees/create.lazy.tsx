import { createLazyFileRoute } from "@tanstack/react-router";
import { HR, Card, Button } from "flowbite-react";
import useForm from "../../hooks/use-form";
import { FormEvent } from "react";
import { InferType } from "yup";
import { employeeSchema } from "../../schema/employee";
import { useCreateEmployee } from "../../hooks/data/useCreateEmployee";
import { StatusCodes } from "http-status-codes";
import PersonalInformationFormSection from "../../components/employee/personal-information-section";
import GovernmentInformationFormSection from "../../components/employee/goverment-information-section";
import ContactInformationFormSection from "../../components/employee/contact-information-section";
export const Route = createLazyFileRoute("/employees/create")({
  component: CreateEmployee,
});
export function CreateEmployee() {
  const form = useForm<InferType<typeof employeeSchema>>({
    initialData: {
      givenName: "",
      middleName: "",
      surname: "",
      dateOfBirth: null,
      address: "",
      ssNumber: "",
      tin: "",
      midNumber: "",
      philhealthNumber: "",
      mobileNumber: "",
      email: "",
    },
  });

  const { mutate } = useCreateEmployee();
  const onSubmit = async (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const response = await mutate(form.data);
    if (response.status === StatusCodes.OK) {
      alert("success!");
    }
    const responseBody = await response.json();
    if (response.status === StatusCodes.BAD_REQUEST) {
      form.setErrors(responseBody?.errors ?? {});
    }
  };

  return (
    <Card className="max-w-6xl mx-auto mt-10">
      <h1 className="font-bold text-2xl">New Employee</h1>
      <form onSubmit={onSubmit}>
        <div className="py-5">
          <h2 className="text-lg font-medium">Personal Information</h2>
          <HR className="my-0"></HR>
        </div>
        <PersonalInformationFormSection {...form} />
        <div className="py-5">
          <h2 className="text-lg font-medium">Government Details</h2>
          <HR className="my-0"></HR>
        </div>
        <GovernmentInformationFormSection {...form} />
        <div className="py-5">
          <h2 className="text-lg font-medium">Contact Information</h2>
          <HR className="my-0"></HR>
        </div>
        <ContactInformationFormSection {...form} />
        <Button type="submit" className="mt-5" color="blue">
          Save
        </Button>
      </form>
    </Card>
  );
}

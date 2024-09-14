import { createLazyFileRoute } from "@tanstack/react-router";
import { Button, Card, HR } from "flowbite-react";
import useForm from "#hooks/use-form";
import PersonalInformationFormSection from "#components/employee/personal-information-section";
import GovernmentInformationFormSection from "#components/employee/goverment-information-section";
import ContactInformationFormSection from "#components/employee/contact-information-section";
import { StatusCodes } from "http-status-codes";
import { FormEvent } from "react";
import { InferType } from "yup";
import { mutateEmployeeSchema } from "#schema/employee";
import { useEmployee } from "#hooks/data/use-employee";
import { useUpdateEmployee } from "#hooks/data/use-update-employee";
import { toast } from "react-toastify";
export const Route = createLazyFileRoute("/employees/$id/edit")({
  component: EditEmployee,
});

export function EditEmployee() {
  const { id } = Route.useParams();
  const form = useForm<InferType<typeof mutateEmployeeSchema>>({
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
  const { employee } = useEmployee({
    id,
    onSuccess: (employee) => {
      form.setData(() => ({ ...employee }));
    },
  });
  const { mutate } = useUpdateEmployee();
  const onSubmit = async (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    form.removeErrors();
    const response = await mutate(form.data, id);
    if (response.status === StatusCodes.OK) {
      toast.success("Employee has been updated.");
      form.removeErrors();
    }
    const responseBody = await response.json();
    if (response.status === StatusCodes.BAD_REQUEST) {
      form.setErrors(responseBody?.errors ?? {});
    }
    if (response.status >= StatusCodes.INTERNAL_SERVER_ERROR) {
      toast.error("Unknown error occured.");
    }
  };
  if ((employee?.id.length ?? 0) === 0) {
    return (
      <Card>
        <h1>Employee not found</h1>
      </Card>
    );
  }
  return (
    <Card className="max-w-6xl mx-auto mt-10">
      <h1 className="font-bold text-2xl">Edit Employee</h1>
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

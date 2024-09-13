import { createLazyFileRoute } from "@tanstack/react-router";
import {
  Button,
  Card,
  Datepicker,
  HR,
  Label,
  Textarea,
  TextInput,
} from "flowbite-react";
import useForm from "../../../hooks/useForm";

export const Route = createLazyFileRoute("/employees/$id/edit")({
  component: EditEmployee,
});

export function EditEmployee() {
  const { id } = Route.useParams();
  const { form, handleInput } = useForm({
    initialData: {
      givenName: "",
      middleName: "",
      surname: "",
      dateOfBirth: "",
      address: "",
      SSNumber: "",
      TIN: "",
      MIDNumber: "",
      philhealthNumber: "",
      email: "",
      mobileNumber: "",
    },
  });

  return (
    <Card className="max-w-6xl mx-auto mt-10">
      <h1 className="font-bold text-2xl">Edit Employee : {id}</h1>
      <form>
        <div className="py-5">
          <h2 className="text-lg font-medium">Personal Information</h2>
          <HR className="my-0"></HR>
        </div>
        <section className="grid md:grid-cols-2 gap-2 lg:grid-cols-3">
          <div>
            <Label>Given name</Label>
            <TextInput
              onChange={handleInput}
              name="givenName"
              value={form.givenName}
              color="primary"
            ></TextInput>
          </div>
          <div>
            <Label>Middle name</Label>
            <TextInput
              onChange={handleInput}
              name="middleName"
              value={form.middleName}
              color="primary"
            ></TextInput>
          </div>
          <div>
            <Label>Surname</Label>
            <TextInput
              onChange={handleInput}
              name="surname"
              value={form.surname}
              color="primary"
            ></TextInput>
          </div>

          <div>
            <Label>Date of birth</Label>
            <Datepicker color="primary"></Datepicker>
          </div>
          <div className="md:col-span-2 lg:col-span-3">
            <Label>Address</Label>
            <Textarea
              onChange={handleInput}
              name="address"
              value={form.address}
              color="primary"
            ></Textarea>
          </div>
        </section>
        <div className="py-5">
          <h2 className="text-lg font-medium">Government Details</h2>
          <HR className="my-0"></HR>
        </div>
        <section className="grid md:grid-cols-2 gap-2 lg:grid-cols-3">
          <div>
            <Label>SS number</Label>
            <TextInput
              onChange={handleInput}
              name="SSNumber"
              value={form.SSNumber}
              color="primary"
            ></TextInput>
          </div>
          <div>
            <Label>TIN</Label>
            <TextInput onChange={handleInput} color="primary"></TextInput>
          </div>
          <div>
            <Label>MID number(Pag-Ibig)</Label>
            <TextInput
              onChange={handleInput}
              name="MIDNumber"
              value={form.MIDNumber}
              color="primary"
            ></TextInput>
          </div>

          <div>
            <Label>PhilHealth number</Label>
            <TextInput
              onChange={handleInput}
              name="philhealthNumber"
              value={form.philhealthNumber}
              color="primary"
            ></TextInput>
          </div>
        </section>
        <div className="py-5">
          <h2 className="text-lg font-medium">Contact Information</h2>
          <HR className="my-0"></HR>
        </div>
        <section className="grid md:grid-cols-2 gap-2 lg:grid-cols-3">
          <div>
            <Label>Mobile number</Label>
            <TextInput
              onChange={handleInput}
              name="mobileNumber"
              value={form.mobileNumber}
              color="primary"
            ></TextInput>
          </div>
          <div>
            <Label>Email</Label>
            <TextInput
              onChange={handleInput}
              name="email"
              type="email"
              value={form.email}
              color="primary"
            ></TextInput>
          </div>
        </section>
        <Button type="submit" className="mt-5" color="blue">
          Save
        </Button>
      </form>
    </Card>
  );
}

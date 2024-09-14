import {
  HR,
  Label,
  Modal,
  ModalProps,
  Textarea,
  TextInput,
} from "flowbite-react";
import { InferType } from "yup";
import { employeeSchema } from "#schema/employee";
import { toReadableDate } from "#utils/date";

interface ViewModalProps extends ModalProps {
  employee: InferType<typeof employeeSchema>;
}
const ViewEmployeeModal = ({ show, onClose, employee }: ViewModalProps) => {
  return (
    <Modal dismissible show={show} size={"6xl"} onClose={onClose}>
      <Modal.Header>{employee.id}</Modal.Header>
      <Modal.Body>
        <div className="py-5">
          <h2 className="text-lg font-medium">Personal Information</h2>
          <HR className="my-0"></HR>
        </div>
        <section className="grid md:grid-cols-2 gap-2 lg:grid-cols-3">
          <div>
            <Label>Given name</Label>
            <TextInput
              readOnly
              name="givenName"
              value={employee.givenName}
            ></TextInput>
          </div>
          <div>
            <Label>Middle name</Label>
            <TextInput
              readOnly
              name="middleName"
              value={employee.middleName}
            ></TextInput>
          </div>
          <div>
            <Label>Surname</Label>
            <TextInput
              readOnly
              name="surname"
              value={employee.surname}
            ></TextInput>
          </div>

          <div>
            <Label>Date of birth</Label>
            <TextInput
              readOnly
              value={toReadableDate(employee.dateOfBirth)}
            ></TextInput>
          </div>
          <div className="md:col-span-2 lg:col-span-3">
            <Label>Address</Label>
            <Textarea
              readOnly
              name="address"
              value={employee.address}
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
              readOnly
              name="ssNumber"
              value={employee.ssNumber}
            ></TextInput>
          </div>
          <div>
            <Label>TIN</Label>
            <TextInput readOnly name="tin" value={employee.tin}></TextInput>
          </div>
          <div>
            <Label>MID number(Pag-Ibig)</Label>
            <TextInput
              readOnly
              name="midNumber"
              value={employee.midNumber}
            ></TextInput>
          </div>

          <div>
            <Label>PhilHealth number</Label>
            <TextInput
              readOnly
              name="philhealthNumber"
              value={employee.philhealthNumber}
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
              readOnly
              name="mobileNumber"
              value={employee.mobileNumber}
            ></TextInput>
          </div>
          <div>
            <Label>Email</Label>
            <TextInput
              readOnly
              name="email"
              type="email"
              value={employee.email}
            ></TextInput>
          </div>
        </section>
      </Modal.Body>
      <Modal.Footer></Modal.Footer>
    </Modal>
  );
};
export default ViewEmployeeModal;

import { createLazyFileRoute, Link } from "@tanstack/react-router";
import { Button, Card, Modal, Table } from "flowbite-react";
import { useEmployees } from "../../hooks/data/use-employees";
import { useToggle } from "../../hooks/use-toggle";
import { useState } from "react";
import { StatusCodes } from "http-status-codes";
import { useDeleteEmployee } from "../../hooks/data/use-delete-employee";
import ViewEmployeeModal from "../../components/employee/view-employee-modal";
import { InferType } from "yup";
import { employeeSchema } from "../../schema/employee";
import { toast } from "react-toastify";
export const Route = createLazyFileRoute("/employees/")({
  component: Employees,
});

function Employees() {
  const { employees, reload } = useEmployees();
  const confirmDeleteModalToggler = useToggle(false);
  const viewModalToggler = useToggle(false);
  const [selectedEmployee, setSelectedEmployee] = useState<
    InferType<typeof employeeSchema>
  >({
    id: "", // Empty string for UUID
    givenName: "",
    middleName: "",
    surname: "",
    dateOfBirth: new Date(), // Date can be null or a default date
    address: "",
    ssNumber: "",
    tin: "",
    midNumber: "",
    philhealthNumber: "",
    mobileNumber: "",
    email: "",
    createdAt: new Date(), // Date can be null or a default date
  });
  const { mutate } = useDeleteEmployee();
  const deleteEmployee = async () => {
    confirmDeleteModalToggler.toggle();
    const response = await mutate(selectedEmployee.id);
    if (response.status === StatusCodes.OK) {
      reload();
      toast.success("Employee deleted successfully");
    }
    if (response.status >= StatusCodes.BAD_REQUEST) {
      toast.error("Employee deleted successfully");
    }
  };
  return (
    <>
      <Card className="max-w-6xl mx-auto mt-10">
        <h1 className="font-bold text-2xl">Employees</h1>
        <div className="overflow-x-auto">
          <Table striped>
            <Table.Head>
              <Table.HeadCell>Name</Table.HeadCell>
              <Table.HeadCell>Contact</Table.HeadCell>
              <Table.HeadCell>Email</Table.HeadCell>
              <Table.HeadCell></Table.HeadCell>
            </Table.Head>
            <Table.Body>
              {employees?.map((employee) => {
                return (
                  <Table.Row key={employee.id}>
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                      {employee.givenName} {employee.surname}
                    </Table.Cell>
                    <Table.Cell>{employee.mobileNumber}</Table.Cell>
                    <Table.Cell>{employee.email}</Table.Cell>
                    <Table.Cell>
                      <div className="flex gap-1">
                        <Button
                          as={Link}
                          color="light"
                          outline
                          to={`/employees/${employee.id}/edit`}
                        >
                          Edit
                        </Button>
                        <Button
                          color="light"
                          onClick={() => {
                            setSelectedEmployee(employee);
                            viewModalToggler.toggle();
                          }}
                          outline
                        >
                          View
                        </Button>
                        <Button
                          onClick={() => {
                            setSelectedEmployee(employee);
                            confirmDeleteModalToggler.toggle();
                          }}
                          color="failure"
                        >
                          Delete
                        </Button>
                      </div>
                    </Table.Cell>
                  </Table.Row>
                );
              })}
            </Table.Body>
          </Table>
        </div>
      </Card>
      <Modal
        show={confirmDeleteModalToggler.state}
        size="md"
        onClose={() => {
          confirmDeleteModalToggler.toggle();
        }}
        popup
      >
        <Modal.Header />
        <Modal.Body>
          <div className="text-center">
            <h1 className="text-2xl">Delete Employee</h1>
            <h3 className="mb-5 text-lg font-normal text-gray-500 dark:text-gray-400">
              Are you sure you want to delete this employee?
            </h3>
            <div className="flex justify-center gap-4">
              <Button color="failure" onClick={() => deleteEmployee()}>
                {"Yes, I'm sure"}
              </Button>
              <Button
                color="gray"
                onClick={() => confirmDeleteModalToggler.toggle()}
              >
                No, cancel
              </Button>
            </div>
          </div>
        </Modal.Body>
      </Modal>
      <ViewEmployeeModal
        employee={selectedEmployee}
        show={viewModalToggler.state}
        onClose={viewModalToggler.toggle}
      ></ViewEmployeeModal>
    </>
  );
}

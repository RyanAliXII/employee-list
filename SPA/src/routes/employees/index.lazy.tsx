import { createLazyFileRoute, Link } from "@tanstack/react-router";
import { Button, Card, Table } from "flowbite-react";
import { useEmployees } from "../../hooks/data/use-employees";

export const Route = createLazyFileRoute("/employees/")({
  component: Employees,
});

function Employees() {
  const { employees } = useEmployees();
  return (
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
                      <Button color="light" outline>
                        View
                      </Button>
                      <Button color="failure">Delete</Button>
                    </div>
                  </Table.Cell>
                </Table.Row>
              );
            })}
          </Table.Body>
        </Table>
      </div>
    </Card>
  );
}

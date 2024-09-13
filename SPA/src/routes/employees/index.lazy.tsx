import { createLazyFileRoute } from "@tanstack/react-router";
import { Card, Table } from "flowbite-react";

export const Route = createLazyFileRoute("/employees/")({
  component: Employees,
});

function Employees() {
  return (
    <Card className="max-w-6xl mx-auto mt-10">
      <h1 className="font-bold text-2xl">Employees</h1>
      <Table>
        <Table.Head>
          <Table.HeadCell>Name</Table.HeadCell>
          <Table.HeadCell>Contact</Table.HeadCell>
          <Table.HeadCell>Email</Table.HeadCell>
        </Table.Head>
      </Table>
    </Card>
  );
}

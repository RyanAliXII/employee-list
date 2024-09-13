import { createRootRoute, Outlet } from "@tanstack/react-router";
import { TanStackRouterDevtools } from "@tanstack/router-devtools";
import { Navbar } from "flowbite-react";

export const Route = createRootRoute({
  component: () => (
    <>
      <Navbar fluid rounded>
        <Navbar.Brand>
          <span className="self-center whitespace-nowrap text-xl font-semibold dark:text-white">
            Employee List
          </span>
        </Navbar.Brand>
        <Navbar.Toggle />
        <Navbar.Collapse className="mr-10">
          <Navbar.Link href="#">Employees</Navbar.Link>
          <Navbar.Link href="#">Create</Navbar.Link>
        </Navbar.Collapse>
      </Navbar>
      <Outlet />
      <TanStackRouterDevtools />
    </>
  ),
});

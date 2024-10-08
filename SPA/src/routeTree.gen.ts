/* prettier-ignore-start */

/* eslint-disable */

// @ts-nocheck

// noinspection JSUnusedGlobalSymbols

// This file is auto-generated by TanStack Router

import { createFileRoute } from '@tanstack/react-router'

// Import Routes

import { Route as rootRoute } from './routes/__root'

// Create Virtual Routes

const IndexLazyImport = createFileRoute('/')()
const EmployeesIndexLazyImport = createFileRoute('/employees/')()
const EmployeesCreateLazyImport = createFileRoute('/employees/create')()
const EmployeesIdEditLazyImport = createFileRoute('/employees/$id/edit')()

// Create/Update Routes

const IndexLazyRoute = IndexLazyImport.update({
  path: '/',
  getParentRoute: () => rootRoute,
} as any).lazy(() => import('./routes/index.lazy').then((d) => d.Route))

const EmployeesIndexLazyRoute = EmployeesIndexLazyImport.update({
  path: '/employees/',
  getParentRoute: () => rootRoute,
} as any).lazy(() =>
  import('./routes/employees/index.lazy').then((d) => d.Route),
)

const EmployeesCreateLazyRoute = EmployeesCreateLazyImport.update({
  path: '/employees/create',
  getParentRoute: () => rootRoute,
} as any).lazy(() =>
  import('./routes/employees/create.lazy').then((d) => d.Route),
)

const EmployeesIdEditLazyRoute = EmployeesIdEditLazyImport.update({
  path: '/employees/$id/edit',
  getParentRoute: () => rootRoute,
} as any).lazy(() =>
  import('./routes/employees/$id/edit.lazy').then((d) => d.Route),
)

// Populate the FileRoutesByPath interface

declare module '@tanstack/react-router' {
  interface FileRoutesByPath {
    '/': {
      id: '/'
      path: '/'
      fullPath: '/'
      preLoaderRoute: typeof IndexLazyImport
      parentRoute: typeof rootRoute
    }
    '/employees/create': {
      id: '/employees/create'
      path: '/employees/create'
      fullPath: '/employees/create'
      preLoaderRoute: typeof EmployeesCreateLazyImport
      parentRoute: typeof rootRoute
    }
    '/employees/': {
      id: '/employees/'
      path: '/employees'
      fullPath: '/employees'
      preLoaderRoute: typeof EmployeesIndexLazyImport
      parentRoute: typeof rootRoute
    }
    '/employees/$id/edit': {
      id: '/employees/$id/edit'
      path: '/employees/$id/edit'
      fullPath: '/employees/$id/edit'
      preLoaderRoute: typeof EmployeesIdEditLazyImport
      parentRoute: typeof rootRoute
    }
  }
}

// Create and export the route tree

export interface FileRoutesByFullPath {
  '/': typeof IndexLazyRoute
  '/employees/create': typeof EmployeesCreateLazyRoute
  '/employees': typeof EmployeesIndexLazyRoute
  '/employees/$id/edit': typeof EmployeesIdEditLazyRoute
}

export interface FileRoutesByTo {
  '/': typeof IndexLazyRoute
  '/employees/create': typeof EmployeesCreateLazyRoute
  '/employees': typeof EmployeesIndexLazyRoute
  '/employees/$id/edit': typeof EmployeesIdEditLazyRoute
}

export interface FileRoutesById {
  __root__: typeof rootRoute
  '/': typeof IndexLazyRoute
  '/employees/create': typeof EmployeesCreateLazyRoute
  '/employees/': typeof EmployeesIndexLazyRoute
  '/employees/$id/edit': typeof EmployeesIdEditLazyRoute
}

export interface FileRouteTypes {
  fileRoutesByFullPath: FileRoutesByFullPath
  fullPaths: '/' | '/employees/create' | '/employees' | '/employees/$id/edit'
  fileRoutesByTo: FileRoutesByTo
  to: '/' | '/employees/create' | '/employees' | '/employees/$id/edit'
  id:
    | '__root__'
    | '/'
    | '/employees/create'
    | '/employees/'
    | '/employees/$id/edit'
  fileRoutesById: FileRoutesById
}

export interface RootRouteChildren {
  IndexLazyRoute: typeof IndexLazyRoute
  EmployeesCreateLazyRoute: typeof EmployeesCreateLazyRoute
  EmployeesIndexLazyRoute: typeof EmployeesIndexLazyRoute
  EmployeesIdEditLazyRoute: typeof EmployeesIdEditLazyRoute
}

const rootRouteChildren: RootRouteChildren = {
  IndexLazyRoute: IndexLazyRoute,
  EmployeesCreateLazyRoute: EmployeesCreateLazyRoute,
  EmployeesIndexLazyRoute: EmployeesIndexLazyRoute,
  EmployeesIdEditLazyRoute: EmployeesIdEditLazyRoute,
}

export const routeTree = rootRoute
  ._addFileChildren(rootRouteChildren)
  ._addFileTypes<FileRouteTypes>()

/* prettier-ignore-end */

/* ROUTE_MANIFEST_START
{
  "routes": {
    "__root__": {
      "filePath": "__root.tsx",
      "children": [
        "/",
        "/employees/create",
        "/employees/",
        "/employees/$id/edit"
      ]
    },
    "/": {
      "filePath": "index.lazy.tsx"
    },
    "/employees/create": {
      "filePath": "employees/create.lazy.tsx"
    },
    "/employees/": {
      "filePath": "employees/index.lazy.tsx"
    },
    "/employees/$id/edit": {
      "filePath": "employees/$id/edit.lazy.tsx"
    }
  }
}
ROUTE_MANIFEST_END */

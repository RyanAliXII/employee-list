import { object, string, date, array } from "yup";

export const createEmployeeSchema = object({
  givenName: string(),
  middleName: string(),
  surname: string(),
  dateOfBirth: date().nullable(),
  address: string(),
  ssNumber: string(),
  tin: string(),
  midNumber: string(),
  philhealthNumber: string(),
  mobileNumber: string(),
  email: string().email(),
}).strict(false);

export const employeesSchema = array(
  object({
    id: string().uuid().required(),
    givenName: string().required(),
    middleName: string().required(),
    surname: string().required(),
    dateOfBirth: date(),
    address: string().required(),
    ssNumber: string().required(),
    tin: string().required(),
    midNumber: string().required(),
    philhealthNumber: string().required(),
    mobileNumber: string().required(),
    email: string().email().required(),
    createdAt: date(),
  })
);

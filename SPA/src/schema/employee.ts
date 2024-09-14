import { object, string, date } from "yup";

export const employeeSchema = object({
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

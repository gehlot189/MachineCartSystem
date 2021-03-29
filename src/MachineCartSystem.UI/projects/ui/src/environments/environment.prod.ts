import { Environment } from "projects/lib/src/public-api";

export class EnvironmentImp implements Environment {
  production = false;
  apiUrl = "";
  identityServerUrl = "";
}
export const environment = EnvironmentImp;

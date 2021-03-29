import { StatusCodes } from "http-status-codes";

export abstract class ApiResponse {
  version: string;
  result: any;
  statusCode: StatusCodes;
  message: string;
  isError: boolean;
  responseException: any;
}

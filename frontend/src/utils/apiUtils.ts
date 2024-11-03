import axios, { AxiosResponse } from "axios";
import {
  APIError,
  BaseDeleteRequest,
  BaseDeleteResponse,
  BaseGetRequest,
  BaseGetResponse,
  BasePatchRequest,
  BasePatchResponse,
  BasePostRequest,
  BasePostResponse,
  BasePutRequest,
  BasePutResponse,
} from "../components/GlobalProviders/ErrorProvider/types";

export const handleError = (error: any): APIError => {
  if (axios.isAxiosError(error)) {
    const statusCode = error.response?.status;

    // Check for 500-class errors
    if (statusCode && statusCode >= 500) {
      return {
        message: "Unknown error",
        code: statusCode,
      };
    }

    // Check for 400-class errors
    if (statusCode && statusCode >= 400 && statusCode < 500) {
      return {
        message: error.response?.data?.message || error.message, // Use message from backend if available
        code: statusCode,
      };
    }

    // Default case for other errors
    return {
      message: error.message,
      code: statusCode || 520, // unknown error.
    };
  }

  return { message: "An unknown error occurred.", code: 520 };
};

export async function get<T extends BaseGetRequest>(
  request: T,
): Promise<AxiosResponse> {
  const { url, options } = request;
  return await axios.get(url, options);
}

export async function post<T extends BasePostRequest>(
  request: T,
): Promise<AxiosResponse> {
  const { url, data, options } = request;
  return await axios.post(url, data, options);
}

export async function put<T extends BasePutRequest>(
  request: T,
): Promise<AxiosResponse> {
  const { url, data, options } = request;
  return await axios.put(url, data, options);
}

export async function patch<T extends BasePatchRequest>(
  request: T,
): Promise<AxiosResponse> {
  const { url, data, options } = request;
  return await axios.patch(url, data, options);
}

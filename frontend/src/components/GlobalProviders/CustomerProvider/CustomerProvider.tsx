import React, { createContext, ReactNode, useContext, useState } from "react";
import {
  get,
  handleError,
  patch,
  post,
  put,
} from "@frontend-ui/utils/apiUtils";
import {
  Customer,
  SalesOpportunity,
  GetCustomersRequest,
  GetCustomersResponse,
  SalesOpportunityPostRequest,
  SalesOpportunityPostResponse,
  SalesOpportunityPutRequest,
  SalesOpportunityPutResponse,
  GetSalesOpportunitiesRequest,
  GetSalesOpportunitiesResponse,
  GetCustomerByIdResponse,
  CustomerPatchResponse,
  GetCustomerByIdRequest,
  CustomerPatchRequest,
} from "./types";
import { useError } from "../ErrorProvider";

interface CustomerContext {
  currentCustomer: Customer | null;
  setCurrentCustomer: React.Dispatch<React.SetStateAction<Customer | null>>;
  getCustomers: (
    pageNumber?: number,
    pageSize?: number,
    filter?: string,
    sort?: string,
    sortDirection?: string,
  ) => Promise<GetCustomersResponse>;
  getCustomerById: (customerId: string) => Promise<GetCustomerByIdResponse>;
  patchCustomer: (
    customerId: string,
    customerData: Customer,
  ) => Promise<CustomerPatchResponse>;
  getSalesOpportunities: (
    customerId: string,
  ) => Promise<GetSalesOpportunitiesResponse>;
  updateSalesOpportunity: (
    customerId: string,
    salesOpportunityId: string,
    salesOpportunityData: SalesOpportunity,
  ) => Promise<SalesOpportunityPutResponse>;
  createSalesOpportunity: (
    customerId: string,
    salesOpportunityData: SalesOpportunity,
  ) => Promise<SalesOpportunityPostResponse>;
}

const CustomerContext = createContext<CustomerContext>({
  currentCustomer: null,
  setCurrentCustomer: () => {
    throw new Error("setCurrentCustomer function not in context.");
  },
  getCustomers: async () => {
    throw new Error("getCustomers function not in context.");
  },
  getSalesOpportunities: async () => {
    throw new Error("getSalesOpportunities function not in context.");
  },
  updateSalesOpportunity: async () => {
    throw new Error("updateSalesOpportunity function not in context.");
  },
  createSalesOpportunity: async () => {
    throw new Error("createSalesOpportunity function not in context.");
  },
  getCustomerById: async () => {
    throw new Error("getCustomerById function not in context.");
  },
  patchCustomer: async () => {
    throw new Error("patchCustomer function not in context.");
  },
});

export const useCustomer = () => {
  const context = useContext(CustomerContext);
  if (!context) {
    throw new Error("useCustomer must be used within an CustomerProvider");
  }
  return context;
};

const CustomerProvider: React.FC<{ children: ReactNode }> = ({ children }) => {
  const { setError } = useError();
  const [currentCustomer, setCurrentCustomer] = useState<Customer | null>(null);
  const getCustomers = async (
    pageNumber: number = 1,
    pageSize: number = 5,
    filter: string = "",
    sort: string = "",
    sortDirection: string = "asc",
  ): Promise<GetCustomersResponse> => {
    try {
      const request: GetCustomersRequest = {
        url: `${import.meta.env.VITE_BACKEND_API_BASE_URL}/api/customers?pageNumber=${pageNumber}&pageSize=${pageSize}&filter=${filter}&sort=${sort}&sortDirection=${sortDirection}`,
      };
      const response = await get<GetCustomersRequest>(request);
      return response.data;
    } catch (error) {
      console.log(error);
      const apiError = handleError(error);
      setError(apiError);
      throw new Error("getCustomers failed.", { cause: error });
    }
  };

  const getCustomerById = async (
    customerId: string,
  ): Promise<GetCustomerByIdResponse> => {
    try {
      const request: GetCustomerByIdRequest = {
        url: `${import.meta.env.VITE_BACKEND_API_BASE_URL}/api/customers/${customerId}`,
      };
      const response = await get<GetCustomerByIdRequest>(request);
      return response;
    } catch (error) {
      console.log(error);
      const apiError = handleError(error);
      setError(apiError);
      throw new Error("getCustomerById failed.", { cause: error });
    }
  };

  const patchCustomer = async (
    customerId: string,
    customerData: Customer,
  ): Promise<CustomerPatchResponse> => {
    try {
      const request: CustomerPatchRequest = {
        url: `${import.meta.env.VITE_BACKEND_API_BASE_URL}/api/customers/${customerId}`,
        data: customerData,
      };
      const response = await patch<CustomerPatchRequest>(request);
      return response.data;
    } catch (error) {
      console.log(error);
      const apiError = handleError(error);
      setError(apiError);
      throw new Error("patchCustomer failed.", { cause: error });
    }
  };

  const getSalesOpportunities = async (
    customerId: string,
  ): Promise<GetSalesOpportunitiesResponse> => {
    try {
      const request: GetSalesOpportunitiesRequest = {
        url: `${import.meta.env.VITE_BACKEND_API_BASE_URL}/api/customers/${customerId}/salesopportunities`,
      };
      const response = await get<GetSalesOpportunitiesRequest>(request);
      return response.data;
    } catch (error) {
      console.log(error);
      const apiError = handleError(error);
      setError(apiError);

      throw new Error("getSalesOpportunities failed.", { cause: error });
    }
  };

  const updateSalesOpportunity = async (
    customerId: string,
    salesOpportunityId: string,
    salesOpportunityData: SalesOpportunity,
  ): Promise<SalesOpportunityPutResponse> => {
    try {
      const request: SalesOpportunityPutRequest = {
        url: `${import.meta.env.VITE_BACKEND_API_BASE_URL}/api/customers/${customerId}/salesopportunities/${salesOpportunityId}`,
        data: salesOpportunityData,
      };
      const response = await put<SalesOpportunityPutRequest>(request);
      return response.data;
    } catch (error) {
      console.log(error);
      const apiError = handleError(error);
      setError(apiError);
      throw new Error("updateSalesOpportunity failed.", { cause: error });
    }
  };

  const createSalesOpportunity = async (
    customerId: string,
    salesOpportunityData: SalesOpportunity,
  ): Promise<SalesOpportunityPostResponse> => {
    try {
      const request: SalesOpportunityPostRequest = {
        url: `${import.meta.env.VITE_BACKEND_API_BASE_URL}/api/customers/${customerId}/salesopportunities`,
        data: salesOpportunityData,
      };
      const response = await post<SalesOpportunityPostRequest>(request);
      return response.data;
    } catch (error) {
      console.log(error);
      const apiError = handleError(error);
      setError(apiError);
      throw new Error("createSalesOpportunity failed.", { cause: error });
    }
  };

  return (
    <CustomerContext.Provider
      value={{
        currentCustomer,
        setCurrentCustomer,
        getCustomers,
        getSalesOpportunities,
        updateSalesOpportunity,
        createSalesOpportunity,
        getCustomerById,
        patchCustomer,
      }}
    >
      {children}
    </CustomerContext.Provider>
  );
};

export default CustomerProvider;

import React, { createContext, ReactNode, useContext } from "react";
import { get, handleError, put } from "@frontend-ui/utils/apiUtils";
import {
  Customer,
  SalesOpportunity,
  PaginatedResponse,
  GetCustomersRequest,
  GetCustomersResponse,
  CustomerPutRequest,
  CustomerPutResponse,
  SalesOpportunityPutRequest,
  SalesOpportunityPutResponse,
  GetSalesOpportunitiesRequest,
  GetSalesOpportunitiesResponse,
} from "./types";
import { useError } from "../ErrorProvider";

// Define a type for the context value
interface CustomerContext {
  getCustomers: (
    pageNumber?: number,
    pageSize?: number,
    filter?: string,
    sort?: string,
  ) => Promise<PaginatedResponse<Customer>>;
  getSalesOpportunities: (
    customerId: string,
  ) => Promise<PaginatedResponse<SalesOpportunity>>;
  updateCustomer: (
    customerId: string,
    customerData: Customer,
  ) => Promise<CustomerPutResponse>;
  updateSalesOpportunity: (
    customerId: string,
    salesOpportunityId: string,
    salesOpportunityData: SalesOpportunity,
  ) => Promise<SalesOpportunityPutResponse>;
}

const CustomerContext = createContext<CustomerContext>({
  getCustomers: async () => {
    throw new Error("getCustomers function not in context.");
  },
  getSalesOpportunities: async () => {
    throw new Error("getSalesOpportunities function not in context.");
  },
  updateCustomer: async () => {
    throw new Error("updateCustomer function not in context.");
  },
  updateSalesOpportunity: async () => {
    throw new Error("updateSalesOpportunity function not in context.");
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

  const getCustomers = async (
    pageNumber: number = 1,
    pageSize: number = 5,
    filter: string = "",
    sort: string = "",
  ): Promise<PaginatedResponse<Customer>> => {
    try {
      const request: GetCustomersRequest = {
        url: `${import.meta.env.VITE_BACKEND_API_BASE_URL}/api/customers?pageNumber=${pageNumber}&pageSize=${pageSize}&filter=${filter}&sort=${sort}`,
      };
      const response = await get<GetCustomersRequest, GetCustomersResponse>(
        request,
      );
      return response.data;
    } catch (error) {
      console.log(error);
      const apiError = handleError(error);
      setError(apiError);
      return { data: [], totalCount: 0 }; 
    }
  };

  const getSalesOpportunities = async (
    customerId: string,
  ): Promise<PaginatedResponse<SalesOpportunity>> => {
    try {
      const request: GetSalesOpportunitiesRequest = {
        url: `${import.meta.env.VITE_BACKEND_API_BASE_URL}/api/customers/${customerId}/salesopportunities`,
      };
      const response = await get<
        GetSalesOpportunitiesRequest,
        GetSalesOpportunitiesResponse
      >(request);
      return response.data;
    } catch (error) {
      console.log(error);
      const apiError = handleError(error);
      setError(apiError);

      return { data: [], totalCount: 0 };
    }
  };

  const updateCustomer = async (
    customerId: string,
    customerData: Customer,
  ): Promise<CustomerPutResponse> => {
    try {
      const request: CustomerPutRequest = {
        url: `${import.meta.env.VITE_BACKEND_API_BASE_URL}/api/customers/${customerId}`,
        data: customerData,
      };
      const response = await put<CustomerPutRequest, CustomerPutResponse>(
        request,
      );
      return response; 
    } catch (error) {
      console.log(error);
      const apiError = handleError(error);
      setError(apiError);
      return { data: { success: false } };
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
      const response = await put<
        SalesOpportunityPutRequest,
        SalesOpportunityPutResponse
      >(request);
      return response; 
    } catch (error) {
      console.log(error);
      const apiError = handleError(error);
      setError(apiError);
      return { data: { success: false } };
    }
  };

  return (
    <CustomerContext.Provider
      value={{
        getCustomers,
        getSalesOpportunities,
        updateCustomer,
        updateSalesOpportunity,
      }}
    >
      {children}
    </CustomerContext.Provider>
  );
};

export default CustomerProvider;

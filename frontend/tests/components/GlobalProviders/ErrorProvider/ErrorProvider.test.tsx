import { render, screen, fireEvent, waitFor, renderHook } from "@testing-library/react";
import { describe, it, expect, vi } from "vitest";
import { ReactNode } from "react";
import {
  APIError,
  ErrorProvider,
  useError,
} from "@frontend-ui/components/GlobalProviders/ErrorProvider";
// Mock APIError type
const mockError: APIError = { message: "Test error message", code: 400 };

// Test component to use the useError hook
const TestComponent = () => {
  const { error, setError } = useError();

  return (
    <div>
      <button onClick={() => setError(mockError)}>Trigger Error</button>
      <button onClick={() => setError(null)}>Clear Error</button>
      {error && <p data-testid="error-message">{error.message}</p>}
    </div>
  );
};

// Render with ErrorProvider utility function
const renderWithProvider = (children: ReactNode) =>
  render(<ErrorProvider>{children}</ErrorProvider>);

describe("ErrorProvider", () => {
  it("provides error context with no initial error", () => {
    renderWithProvider(<TestComponent />);
    expect(screen.queryByTestId("error-message")).not.toBeInTheDocument();
  });

  it("displays an error when setError is called", async () => {
    renderWithProvider(<TestComponent />);

    // Click button to trigger error
    fireEvent.click(screen.getByText("Trigger Error"));

    // Check that error message is displayed
    await waitFor(() => {
      expect(screen.getByTestId("error-message")).toHaveTextContent(
        "Test error message",
      );
    });
  });

  it("clears the error when setError is called with null", async () => {
    renderWithProvider(<TestComponent />);

    // Trigger error
    fireEvent.click(screen.getByText("Trigger Error"));
    await waitFor(() => {
      expect(screen.getByTestId("error-message")).toBeInTheDocument();
    });

    // Clear error
    fireEvent.click(screen.getByText("Clear Error"));
    await waitFor(() => {
      expect(screen.queryByTestId("error-message")).not.toBeInTheDocument();
    });
  });

  it("displays a Snackbar when there is an error", async () => {
    renderWithProvider(<TestComponent />);

    // Trigger error
    fireEvent.click(screen.getByText("Trigger Error"));

    // Check that Snackbar is displayed
    await waitFor(() => {
      expect(screen.getByRole("alert")).toHaveTextContent("Test error message");
    });
  });

  it("closes Snackbar when close button is clicked", async () => {
    renderWithProvider(<TestComponent />);

    // Trigger error to show Snackbar
    fireEvent.click(screen.getByText("Trigger Error"));
    await waitFor(() => {
      expect(screen.getByRole("alert")).toBeInTheDocument();
    });

    // Close Snackbar using the close button
    fireEvent.click(screen.getByLabelText("Snackbar close icon"));
    await waitFor(() => {
      expect(screen.queryByRole("alert")).not.toBeInTheDocument();
    });
  });

});

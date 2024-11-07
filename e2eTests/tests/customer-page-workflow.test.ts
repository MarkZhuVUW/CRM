import { test, expect } from "@playwright/test";
import * as dotenv from "dotenv";

// Load environment variables
dotenv.config();

const expectedCustomersPage1 = [
  {
    id: "29bdb80b-1768-4eeb-83e7-5ed94c7755d4",
    name: "Sophia Hernandez",
    email: "sophia@example.com",
    phone: "5678901234",
    status: "Active",
    createdAt: "2024-11-03T08:17:40.073Z",
  },
  {
    id: "2b80ae8a-8a09-4f8f-b5c8-cb5280eb7a5e",
    name: "Jane Smith",
    email: "jane@example.com",
    phone: "0987654321",
    status: "Lead",
    createdAt: "2024-11-03T08:17:40.073Z",
  },
  {
    id: "31c8c8b8-d3fa-44a2-b4d2-7c85ed57453a",
    name: "Olivia Martinez",
    email: "olivia@example.com",
    phone: "4567890123",
    status: "Non-Active",
    createdAt: "2024-11-03T08:17:40.073Z",
  },
  {
    id: "3c1c68e1-847f-4059-b9f8-184f92300959",
    name: "Isabella Moore",
    email: "isabella@example.com",
    phone: "8908908901",
    status: "Active",
    createdAt: "2024-11-03T08:17:40.073Z",
  },
  {
    id: "3dfb1384-f037-41da-b84e-4d78fd67b13b",
    name: "Liam Anderson",
    email: "liam@example.com",
    phone: "9876543210",
    status: "Non-Active",
    createdAt: "2024-11-03T08:17:40.073Z",
  },
];

const expectedCustomerPage2 = {
  id: "3e8efcc8-07fa-4f53-9477-e3eaf34b98ed",
  name: "Frank Wilson",
  email: "frank@example.com",
  phone: "7897897890",
  status: "Active",
  createdAt: "2024-11-03T08:17:40.073Z",
  updatedAt: "2024-11-03T08:17:40.073Z",
};

const expectedCustomerPage4 = {
  id: "f748b8be-82f7-4ec0-86b7-8a5e35e94727",
  name: "Emma Davis",
  email: "emma@example.com",
  phone: "4564564567",
  status: "Non-Active",
  createdAt: "2024-11-03T08:17:40.073Z",
  updatedAt: "2024-11-03T08:17:40.073Z",
};
test.describe("Customer Page Tests", () => {
  test.beforeEach(async ({ page }) => {
    // Navigate to the customer page before each test
    await page.goto(`${process.env.REACT_APP_URL}`);
  });

  test("should display all customers on the first page", async ({ page }) => {
    // Expected customer details for page 1

    // Check customers on page 1
    for (const customer of expectedCustomersPage1) {
      await expect(page.locator(`text=${customer.name}`)).toBeVisible();
      await expect(page.locator(`text=${customer.email}`)).toBeVisible();
      await expect(page.locator(`text=${customer.phone}`)).toBeVisible();
    }
  });

  test("should display one customer on the second page", async ({ page }) => {
    // Navigate to the second page
    const page2Button = page
      .locator('button[aria-label="Go to page 2"]')
      .first();

    await expect(page2Button).toBeVisible();
    await page2Button.click();

    await expect(
      page.locator(`text=${expectedCustomerPage2.name}`)
    ).toBeVisible();
    await expect(
      page.locator(`text=${expectedCustomerPage2.email}`)
    ).toBeVisible();
    await expect(
      page.locator(`text=${expectedCustomerPage2.phone}`)
    ).toBeVisible();
  });

  test("should display last customer on the fourth page", async ({ page }) => {
    const page2Button = page
      .locator('button[aria-label="Go to page 4"]')
      .first();

    await expect(page2Button).toBeVisible();
    await page2Button.click();

    // Check customer on page 4
    await expect(
      page.locator(`text=${expectedCustomerPage4.name}`)
    ).toBeVisible();
    await expect(
      page.locator(`text=${expectedCustomerPage4.email}`)
    ).toBeVisible();
    await expect(
      page.locator(`text=${expectedCustomerPage4.phone}`)
    ).toBeVisible();
  });

  test("should filter customers by name", async ({ page }) => {
    const filterContainer = page.locator('[aria-label="Filter by name"]');
    await filterContainer.waitFor({ state: "visible" });
    const filterInput = filterContainer.locator("input");

    await filterInput.click();

    await filterInput.fill("Sophia");

    await expect(page.locator(`text=Sophia Hernandez`)).toBeVisible();
    await expect(page.locator(`text=Jane Smith`)).toBeHidden();

    await filterInput.fill("Jane");

    await expect(page.locator(`text=Sophia Hernandez`)).toBeHidden();
    await expect(page.locator(`text=Jane Smith`)).toBeVisible();
  });

  test("should filter customers by status", async ({ page }) => {
    const filterContainer = page.locator('[aria-label="Filter by Status"]');
    await filterContainer.waitFor({ state: "visible" });

    await filterContainer.click();
    const leadOption = page.locator('[aria-label="Filter by Status Lead"]');
    await leadOption.click();

    await expect(page.locator(`text=Jane Smith`)).toBeVisible();
    await expect(page.locator(`text=Sophia Hernandez`)).toBeHidden();
    await expect(page.locator(`text=Noah Garcia`)).toBeVisible();
  });

  test("should sort customers by name in both ascending order and descending order.", async ({
    page,
  }) => {
    const sortContainer = page.locator('[aria-label="Sort By"]');
    await sortContainer.waitFor({ state: "visible" });

    await sortContainer.click();
    const sortByNameOption = page.locator('[aria-label="Sort By Name"]');
    await sortByNameOption.click();



    await expect(page.locator(`text=Alice Williams`)).toBeVisible();
    await expect(page.locator(`text=Ava Hall`)).toBeVisible();
    await expect(page.locator(`text=Bob Johnson`)).toBeVisible();
    await expect(page.locator(`text=Charlie Brown`)).toBeVisible();
    await expect(page.locator(`text=David Miller`)).toBeVisible();
    await expect(page.locator(`text=Emma Davis`)).toBeHidden();

    const sortDirectionButton = page.locator(
      '[aria-label="Sort Direction Toggle Button"]'
    );
    await sortDirectionButton.click();

    await expect(page.locator(`text=Sophia Hernandez`)).toBeVisible();
    await expect(page.locator(`text=Olivia Martinez`)).toBeVisible();
    await expect(page.locator(`text=Noah Garcia`)).toBeVisible();
    await expect(page.locator(`text=Mia Thomas`)).toBeVisible();
    await expect(page.locator(`text=Lucas Lopez`)).toBeVisible();
    await expect(page.locator(`text=Emma Davis`)).toBeHidden();
    await expect(page.locator(`text=Alice Williams`)).toBeHidden();

  });

  test("should sort customers by name, filter by name", async ({
    page,
  }) => {
    // sort by name
    const sortContainer = page.locator('[aria-label="Sort By"]');
    await sortContainer.waitFor({ state: "visible" });

    await sortContainer.click();
    const sortByNameOption = page.locator('[aria-label="Sort By Name"]');
    await sortByNameOption.click();

    // filter by status Lead
    const filterStatusContainer = page.locator('[aria-label="Filter by Status"]');
    await filterStatusContainer.waitFor({ state: "visible" });

    await filterStatusContainer.click();
    const leadOption = page.locator('[aria-label="Filter by Status Lead"]');
    await leadOption.click();


    await expect(page.locator(`text=Charlie Brown`)).toBeVisible();
    await expect(page.locator(`text=Grace Lee`)).toBeVisible();
    await expect(page.locator(`text=Jack Taylor`)).toBeVisible();
    await expect(page.locator(`text=Jane Smith`)).toBeVisible();
    await expect(page.locator(`text=Alice Williams`)).toBeHidden();
  });

  test("should sort customers by name, filter by name and status", async ({
    page,
  }) => {
    // sort by name
    const sortContainer = page.locator('[aria-label="Sort By"]');
    await sortContainer.waitFor({ state: "visible" });

    await sortContainer.click();
    const sortByNameOption = page.locator('[aria-label="Sort By Name"]');
    await sortByNameOption.click();

    // filter by status Lead
    const filterStatusContainer = page.locator('[aria-label="Filter by Status"]');
    await filterStatusContainer.waitFor({ state: "visible" });

    await filterStatusContainer.click();
    const leadOption = page.locator('[aria-label="Filter by Status Lead"]');
    await leadOption.click();


    await expect(page.locator(`text=Charlie Brown`)).toBeVisible();
    await expect(page.locator(`text=Grace Lee`)).toBeVisible();
    await expect(page.locator(`text=Jack Taylor`)).toBeVisible();
    await expect(page.locator(`text=Jane Smith`)).toBeVisible();
    await expect(page.locator(`text=Alice Williams`)).toBeHidden();
  });
});

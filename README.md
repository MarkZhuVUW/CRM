# Assumptions
1. No APIs to createCustomer. Some customers and sales opportunities are preloaded into database to make testing easier
2. App intended to only work locally. No CICD, prod deployment will be in scope.
3. extensive logging, error handling are setup to make the codebase as production-ready as possible.
4. Responsive design is supported for mobile devices.
5. Originally I was planning on using MUI X Data Grid to display customers and sales opportunities. However the free version is very naive and after some spiking I have decided to just use plain MUI components. This does mean that the frontend is less extensible to business logic changes. For example. If customer / sales opportunity have more columns, will need to reinvent the data grid.
6. App throughput is not heavy. Otherwise might need event-driven architecture, caches etc.

# future improvements
1. I have only got a few e2e tests done. Would be good to increase playwright coverage.
2. performance tests
3. switch to a more mature "data grid" solution for displaying rows/columns of customers etc which allows for server-side pagination, filtering, sorting etc.
4. Implement full CICD pipeline that builds, tests, releases to prod in dockerized environment.

# API endpoints

# Code Structure

```bash
> backend - .Net 8 & unit tests
    | CRM.Api - .Net 8 backend
    | CRM.Api.Tests - backend unit tests with MSTest
> e2eTests - playwright e2e tests(chrome only)
    | .env - local playwright configs
    | tests - e2e test cases
> frontend - Vite, React, Mui 5
    | .env local frontend config/creds
    | package.json - frontend dependencies
    | tests - jest unit tests
> scripts
    | start.sh - script to spin up postgres as docker container locally
.env - Postgres local config/creds
docker-compose.yml - docker-compose for LOCAL environment
Dockerfile - postgres & pgadmin docker container
```

# Important: How to set up local development environment

## Install nvm

### Windows

Download the Zip (nvm-noinstall.zip)
[HERE](https://github.com/coreybutler/nvm-windows/releases)

### Mac

```bash
curl -o- https://raw.githubusercontent.com/nvm-sh/nvm/v0.39.1/install.sh | bash
```

## Provision nodejs

```bash
nvm install 20.11.1
nvm use 20.11.1
```

## Install dotnet

1. dotnet cli
2. dotnet ef

```bash
dotnet tool install --global dotnet-ef
```

## setup frontend react project

```bash
cd ./frontend
npm install
```

## setup backend project

```bash
cd ../backend
dotnet build CRM.Api
dotnet build CRM.Api.Tests
```

## Install Docker Desktop

### Windows

Follow the instruction [HERE](https://docs.docker.com/desktop/install/windows-install/#:~:text=Download%20the%20installer%20using%20the,Program%20Files%5CDocker%5CDocker%20)

### Mac

```bash
brew install docker
```

---

How to run frontend react, backend, database locally

## 1. Run postgres (docker-compose)

Run this from Git Bash if you use Windows

```bash
# you need to use a terminal that has sh command
cd ./scripts
sh start.sh
```

Open http://localhost:8888/ Login with user-name@domain-name.com/pgadminpassword
Register server:
Server name: test
Name: postgres
User name: postgres
Password: postgres

## 2. Run frontend react

```bash
cd ./frontend
npm run dev
```

## 3. Run backend

```bash
cd ./backend/CRM.Api
dotnet run
```

# How to test the code

## Frontend unit tests

1. `cd ./frontend`
2. `npm test`

## Frontend linting

1. `cd ./frontend`
2. `npm run lint`

## backend unit tests

1. `cd ./backend/CRM.Api.Tests`
2. `dotnet test`

You can also manually test APIs with swagger UI

1. spin up backend
2. access `http://localhost:5106/swagger/index.html`

## Browser end-to-end tests

### Note that we support only `Chrome` at this time

### Prerequisite

install playwright and chromium

```bash
npx playwright install --with-deps chromium
```

Ensure you have spinned up postgres, react and .Net backend locally. If you have not, follow the `Important: How to set up local development environment` guide above.

under project root folder:

1. `cd e2eTests`
2. `npm run test:e2e`

# Q & A

### 1. sh command not found running npm commands

##### A: Please make sure you use Git Bash to run the command if you are on Windows

### 2. docker or docker-compose command not found

##### A: Please review `Important: How to set up local development environment` section and install docker desktop.

##### A: Please make sure you use Git Bash to run the command if you are on Windows

# Fair Rent Advisor

An experiment in building an end-to-end SaaS using AI-first tooling and workflows.

## AI Tools Used

- **Claude Sonnet 4** (via Claude.ai) — Prompt generation and agent-based workflow management
- **Claude Sonnet 4** (via Cursor AI) — Code generation, editing, and implementation

## Vision

This project is an attempt to build a complete SaaS product using mostly AI tooling. It documents and demonstrates a practical, repeatable way to combine multiple specialized AI agents with a coding assistant to ship production-quality software quickly.

Creator: Jason Haffey — Software Engineer with 15+ years of experience in .NET/C#.

## AI-Agent Workflow

The development process is driven by a set of Claude projects acting as specialized agents. Each agent has a well-defined responsibility and its own instruction set:

- Product Manager Agent — requirements and scope
  - [Product Owner Agent Instructions](https://github.com/jnhaffey/AI-Agent-Project-Instruction-Generator/blob/main/Samples/Product%20Owner%20Agent%20Instructions.md)
- Architecture Agent — system design and boundaries
  - [Architecture Agent Instructions](https://github.com/jnhaffey/AI-Agent-Project-Instruction-Generator/blob/main/Samples/Architecture%20Agent%20Instructions.md)
- Software Engineer Agent — produces implementation prompts (not code)
  - [Software Engineer Agent Instructions](https://github.com/jnhaffey/AI-Agent-Project-Instruction-Generator/blob/main/Samples/Software%20Engineer%20Agent%20Instructions.md)
- Code Review Agent — review and quality gates
  - [Code Reviewer Agent Instructions](https://github.com/jnhaffey/AI-Agent-Project-Instruction-Generator/blob/main/Samples/Code%20Reviewer%20Agent%20Instructions.md)
- QA Engineer Agent — test planning and validation
  - [QA Engineer Agent Instructions](https://github.com/jnhaffey/AI-Agent-Project-Instruction-Generator/blob/main/Samples/QA%20Engineer%20Agent%20Instructions.md)

How these agents are generated and interact is documented in this repository:

- AI Agent Instruction Generator: [jnhaffey/AI-Agent-Project-Instruction-Generator](https://github.com/jnhaffey/AI-Agent-Project-Instruction-Generator)

Important: The Software Engineer Agent does not write the code directly. It generates high-quality prompts that are provided to Cursor AI, which is responsible for actually writing and editing the code in this repository.

---

## Project Overview

Top-level tech stack:

- Backend/API: .NET 8 (Azure Functions isolated model)
- Shared libraries: .NET 8 class libraries
- Frontend: React + TypeScript (Vite)
- Containers: Dockerfiles for API and Web; `docker-compose.yml`
- Tests: .NET unit and integration test projects

Repository structure:

```text
src/
  FairRentAdvisor.Api/            # Azure Functions isolated worker (Program.cs, host.json)
  FairRentAdvisor.Core/           # Domain and shared core logic (placeholder)
  FairRentAdvisor.Infrastructure/ # Infrastructure concerns (placeholder)
  FairRentAdvisor.Web/            # React + TypeScript (Vite)
tests/
  FairRentAdvisor.Tests.Unit/
  FairRentAdvisor.Tests.Integration/
containers/
  Dockerfile.api
  Dockerfile.web
docker-compose.yml
```

Notable details identified from the current codebase:

- `FairRentAdvisor.Api` includes `host.json` and isolated worker artifacts (e.g., `worker.config.json` under `obj`), indicating an Azure Functions isolated setup. You will typically run this with Azure Functions Core Tools.
- `FairRentAdvisor.Web` is a Vite React TypeScript app with ESLint configured and standard Vite project structure.
- `FairRentAdvisor.Core` and `FairRentAdvisor.Infrastructure` currently contain placeholder classes, ready for domain and persistence/service abstractions.
- Solution file: `FairRentAdvisor.sln` ties the projects together.

---

## Getting Started (Local)

Prerequisites:

- .NET SDK 8.x
- Node.js 18+ (Node 20 recommended)
- npm or pnpm (examples use npm)
- Azure Functions Core Tools v4 (for running the Functions API locally)

Clone and restore:

```bash
git clone <this-repo>
cd <this-repo>
dotnet restore FairRentAdvisor.sln
```

Run the API (Azure Functions, isolated):

```bash
cd src/FairRentAdvisor.Api
dotnet build
func start
```

Run the Web app (Vite React + TS):

```bash
cd src/FairRentAdvisor.Web
npm install
npm run dev
```

Run tests:

```bash
dotnet test FairRentAdvisor.sln
```

---

## Running with Docker

Build and run with Docker Compose:

```bash
docker compose up --build
```

Notes:

- See `containers/Dockerfile.api` and `containers/Dockerfile.web` for container build details.
- The compose file `docker-compose.yml` orchestrates both services. Ports are defined there; adjust if they conflict locally.

---

## Development Workflow

AI-first flow:

1. Define requirements and scope with the Product Manager Agent.
2. Validate architecture with the Architecture Agent.
3. Generate precise implementation prompts with the Software Engineer Agent.
4. Use Cursor AI to implement code changes from those prompts.
5. Run the Code Review Agent for feedback and gating.
6. Plan and execute tests with the QA Engineer Agent.

Conventional flow:

- Branch from `dev`, implement, run tests, and open PRs for review.

---

## Roadmap (Initial)

- Define domain model and core use-cases in `FairRentAdvisor.Core`.
- Implement key function endpoints in `FairRentAdvisor.Api`.
- Establish persistence strategies in `FairRentAdvisor.Infrastructure`.
- Build initial UI flows in `FairRentAdvisor.Web`.
- Integrate CI (build, test, lint) and container publishing.

---

## Contributing

This is an AI-driven project; contributions are welcome via issues and PRs. Please:

- Keep changes small and focused.
- Include tests when adding functionality.
- Align with the agent-driven workflow when feasible.

---

## License

TBD.

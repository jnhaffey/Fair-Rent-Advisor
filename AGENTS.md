# Fair Rent Advisor - Agent Instructions

## Project Overview
This is an AI-driven SaaS project using .NET 8 backend (Azure Functions) and React TypeScript frontend. The development follows an agent-based workflow where Claude agents generate implementation prompts for Cursor AI.

## Quick Guidelines
- Follow Clean Architecture patterns
- Use TypeScript for all frontend code
- Use C# 12 features appropriately
- Write unit tests for all business logic
- Follow conventional commit messages
- Update changelog for all commits
- Save AI prompts to `AI Prompts/` folder

## Code Style
- Use meaningful names for variables and methods
- Keep functions focused on single responsibilities
- Implement proper error handling
- Use async/await for I/O operations

## Security
- Never commit secrets or API keys
- Validate all user inputs
- Use HTTPS for all communications
- Implement proper authentication

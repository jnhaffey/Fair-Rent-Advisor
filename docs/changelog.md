# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Changed

- Migrated from legacy `.cursorrules` to new Project Rules format using `.cursor/rules/` directory
- Split large cursor rules into focused, composable `.mdc` files for better maintainability
- Implemented nested rules structure with testing-specific rules in `tests/.cursor/rules/`
- Corrected and improved all three AI Agent markdown files (Product Manager, Architecture, Software Engineer)
- Removed embedded HTML mockup code from Product Manager Agent file and replaced with concise overview
- Fixed malformed Mermaid diagram syntax in Architecture Agent file
- Corrected table formatting issues in Architecture Agent file
- Cleaned up duplicate content and inconsistent formatting in Software Engineer Agent file
- Removed build artifacts and test files from version control (bin folder cleanup)

### Removed

- Legacy `.cursorrules` file (replaced with new Project Rules structure)

### Added

- New Project Rules structure with focused `.mdc` files:
  - `project-context.mdc` - General project context and principles
  - `dotnet-backend.mdc` - .NET 8 backend development standards
  - `react-frontend.mdc` - React TypeScript frontend standards
  - `ai-agent-workflow.mdc` - AI agent integration and workflow automation
  - `security-guidelines.mdc` - Security best practices
  - `tests/.cursor/rules/testing-standards.mdc` - Testing-specific rules (nested)
- `AGENTS.md` - Simple alternative agent instructions file
- Initial changelog creation

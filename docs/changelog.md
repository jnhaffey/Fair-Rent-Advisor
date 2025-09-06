# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added

- **Core Domain Models Implementation (Phase 2A)**:
  - `Postcode` value object with UK postcode validation and formatting
  - `MonthlyRent` value object with business rules and multi-currency support
  - `PropertyType` value object with type-safe property classification
  - Comprehensive unit test suite with 100% coverage (35 tests)
  - Test infrastructure with FluentAssertions, xUnit, and TestDataBuilder utilities
  - JSON serialization support for Cosmos DB compatibility
  - Implicit type conversions for better developer experience

### Changed

- Enhanced test project structure with organized Models/ValueObjects hierarchy
- Removed default UnitTest1.cs files from test projects
- Updated `4-Software Engineer Agent.md` with Phase 2A implementation details
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
- Default UnitTest1.cs files from test projects
- Default Class1.cs files from new .NET projects (FairRentAdvisor.Core, FairRentAdvisor.Infrastructure)

### Technical Details

- **TDD Implementation**: Followed strict Red-Green-Refactor cycle for all value objects
- **Architecture Compliance**: .NET 8, System.Text.Json, manual object mapping
- **Business Rules**: Input validation, realistic constraints, proper error handling
- **Test Coverage**: 35 passing tests with comprehensive edge case coverage

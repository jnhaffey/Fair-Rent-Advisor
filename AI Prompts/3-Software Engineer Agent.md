# Fair Rent Advisor - Software Engineer Agent Prompts

## Context

- Product Manager Agent's Software Engineer Agent Hand-over Prompt provided
- Product Manager Agent's Mock-up UI provided
- Architecture Agent's Hand-over Prompt provided

Note had to provide some additional context during the Response Prompt creations:

```text
Update Phase 1: Infrastructure Setup - Cursor Prompts with the following:
* The root directory where the FairRentAdvisor folder is created is: C:\Coding\Repos\
* Make sure the folder is git ready by doing a git init command
* Make sure the gitignore is set for both Visual Studio and React with respect to the folder structure of the solution
* Make sure all projects that need to execute are containerised and run using a light weight Linux based container.
```

## Software Engineer Agent Response

### Summary

I've created a comprehensive implementation plan for the Fair Rent Advisor platform that translates the architectural specifications into actionable Cursor prompts. Here's what has been delivered:

#### Key Implementation Deliverables

##### Phase 1: Infrastructure Foundation
- **Complete project setup** with git initialization in `C:\Coding\Repos\FairRentAdvisor`
- **Containerized development environment** using lightweight Linux containers
- **Dual development approach**: local with emulators or fully containerized
- **Comprehensive .gitignore** covering both Visual Studio and React

##### Phase 2: Core Backend Implementation
- **Domain models** with value objects and proper validation
- **Repository layer** optimized for Cosmos DB free tier (1000 RU/s)
- **Business services** with sophisticated property assessment algorithm
- **Azure Functions** HTTP endpoints for RESTful API

##### Phase 3: Frontend Implementation
- **React TypeScript components** matching the provided UI mockups
- **Material-UI integration** for consistent design
- **Assessment results display** with dynamic rating badges and comparable properties
- **Mobile-first responsive design**

#### Technical Strengths

The implementation plan addresses several critical requirements:

1. **Cost Optimization**: Local emulators eliminate cloud costs during development
2. **Performance**: Algorithm designed for <10 second assessment responses
3. **Scalability**: Clean architecture supports future feature additions
4. **Quality**: Built-in testing requirements and comprehensive error handling

#### Implementation Readiness

Each prompt provides:
- Complete technical context and constraints
- Step-by-step implementation instructions
- File structures and code examples
- Testing requirements and success criteria

The prompts are structured by complexity (Complex/Moderate/Simple) to optimize Cursor's implementation approach, with detailed guidance for sophisticated features like the property assessment algorithm and high-level guidance for simpler components.

#### Next Steps

The immediate focus should be on executing the Phase 1 infrastructure setup, which provides the foundation for all subsequent development. The containerized approach ensures consistent development environments while the local emulator strategy eliminates cloud costs during the development phase.

This implementation plan successfully bridges the gap between architectural specifications and hands-on development, providing clear guidance for rapid MVP delivery while maintaining production-ready code quality.

### RESPONSE PROMPTS

## Development Environment Setup

The implementation includes comprehensive development scripts and containerization support for consistent development environments.

### Key Development Features

- **Local Development Scripts**: Automated setup for development environment with Docker emulators
- **Containerized Services**: Complete Docker containerization for both development and production
- **Dual Development Approach**: Support for both local development with emulators and fully containerized development
- **Package Management**: Comprehensive npm scripts for building, testing, and deployment

### Development Workflow Options

**Option 1: Local Development (Recommended)**
- Uses local emulators for Cosmos DB and Redis
- Native development experience with hot reload
- Faster iteration cycles

**Option 2: Fully Containerized**
- All services run in Docker containers
- Production-like environment
- Consistent across all development machines

## Integration Notes
- All projects use dependency injection following .NET 8 patterns
- Configuration uses the Options pattern with strongly-typed settings
- Repository pattern abstracts data access from business logic
- Local emulators eliminate cloud costs during development
- Containerized services provide consistent development environments
- Hot reload enabled for both frontend and backend development
- Git repository ready with comprehensive .gitignore
- Dual development approach: local with emulators or fully containerized

## Success Criteria
- Solution compiles without errors
- Docker containers start successfully for both emulators and applications
- All package dependencies resolve correctly
- Project references are properly configured
- Git repository is initialized with proper .gitignore
- Local development environment supports both containerized and native development
- Test projects are scaffolded and ready for TDD approach
- Emulator services provide cloud-free development experience

## Containerization Benefits
- **Consistent Environment**: All developers work in identical containers
- **Easy Scaling**: Containers can be easily scaled horizontally
- **Production Parity**: Development mirrors production deployment
- **Isolation**: Each service runs in its own container with controlled dependencies
- **Portability**: Application runs identically across different machines and environments

## Development Workflow Options

### Option 1: Local Development (Recommended for development)
```bash
# Terminal 1: Start emulators
npm run dev:emulators

# Terminal 2: Start API
cd src/FairRentAdvisor.Api
func start

# Terminal 3: Start Frontend
cd src/FairRentAdvisor.Web
npm start
```

### Option 2: Fully Containerized (Recommended for testing/demo)
```bash
# Start all services in containers
npm run dev:containers

# Or step by step
docker-compose up --build
```

## Next Steps
Once this structure is complete, proceed to:
1. Core domain models implementation
2. Cosmos DB repository setup with local emulator
3. Azure Functions dependency injection configuration
4. Container orchestration testing and optimization

## Summary

This comprehensive implementation plan provides clear guidance for building the Fair Rent Advisor platform with proper architecture, development workflows, and quality assurance processes. The focus on containerization and local development optimization ensures efficient development while maintaining production readiness.

---

*End of Software Engineer Agent Implementation Plan*

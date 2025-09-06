- Product Manager Agent's Architucture Agent Hand-over Prompt provided

# -- Architecture Agent Response --

# Fair Rent Advisor - Technical Architecture Plan

## Architecture Overview

After analyzing the product requirements, I recommend a **cloud-native serverless architecture** using Azure services to optimize for the £1000 development budget and £50/month operational constraints while ensuring scalability and performance.

## System Architecture Approach

### Overall Pattern: Serverless Microservices Hybrid
- **Frontend**: React SPA hosted on Azure Static Web Apps (free tier)
- **Backend**: .NET 8 Azure Functions for serverless compute
- **Database**: Azure Cosmos DB (free tier) for document storage
- **Caching**: Azure Redis Cache for market data
- **Authentication**: Auth0 for user management## Technology Stack Recommendations

graph TB
    subgraph "Frontend Layer"
        React[React SPA<br/>Azure Static Web Apps]
    end
    
    subgraph "API Gateway"
        APIM[Azure API Management<br/>Rate Limiting & Security]
    end
    
    subgraph "Authentication"
        Auth0[Auth0<br/>User Management]
    end
    
    subgraph "Backend Services"
        AssessmentAPI[Property Assessment API<br/>.NET Azure Functions]
        MarketAPI[Market Analysis API<br/>.NET Azure Functions]
        NegotiationAPI[Negotiation Tools API<br/>.NET Azure Functions]
        DataAPI[Data Collection API<br/>.NET Azure Functions]
    end
    
    subgraph "Data Layer"
        CosmosDB[(Azure Cosmos DB<br/>Property & Market Data)]
        Redis[(Azure Redis Cache<br/>Hot Market Data)]
        BlobStorage[(Azure Blob Storage<br/>Market Reports)]
    end
    
    subgraph "Data Sources"
        GovData[Government APIs<br/>Property Data]
        WebScraping[Ethical Web Scraping<br/>Rental Listings]
        TransportAPI[TfL API<br/>Transport Data]
    end
    
    subgraph "Background Processing"
        DataPipeline[Azure Functions<br/>Data Processing Pipeline]
        Timer[Timer Triggers<br/>Daily Data Updates]
    end
    
    React --> APIM
    APIM --> AssessmentAPI
    APIM --> MarketAPI
    APIM --> NegotiationAPI
    React --> Auth0
    
    AssessmentAPI --> CosmosDB
    AssessmentAPI --> Redis
    MarketAPI --> CosmosDB
    MarketAPI --> Redis
    NegotiationAPI --> BlobStorage
    
    DataAPI --> CosmosDB
    DataPipeline --> CosmosDB
    DataPipeline --> Redis
    Timer --> DataPipeline
    
    DataAPI --> GovData
    DataAPI --> WebScraping
    DataAPI --> TransportAPI

### Mandatory Stack Components
- **Backend**: .NET 8 with Azure Functions (serverless)
- **Frontend**: React 18 with TypeScript
- **Authentication**: Auth0 (free tier supports 7,000 active users)
- **Cloud Platform**: Microsoft Azure

### Database Strategy
- **Primary Database**: Azure Cosmos DB (free tier: 1000 RU/s, 25GB storage)
  - Document-based storage perfect for property data with varying attributes
  - Global distribution for performance
  - Automatic scaling
- **Caching Layer**: Azure Redis Cache (Basic C0: £11/month)
  - Cache market averages and frequently accessed data
  - Reduce Cosmos DB RU consumption

### Infrastructure Components
- **Hosting**: Azure Static Web Apps (free tier)
- **API Management**: Azure API Management (free tier: 1M calls/month)
- **Storage**: Azure Blob Storage (hot tier for reports)
- **Monitoring**: Azure Application Insights (free tier)

## Detailed Technical Specifications

### API Design Structure
# Fair Rent Advisor API Endpoints

## Property Assessment API

### POST /api/property/assess
**Purpose**: Assess if a rental price is fair
```json
{
  "postcode": "SW1A 1AA",
  "bedrooms": 2,
  "propertyType": "flat",
  "monthlyRent": 2500,
  "furnished": true,
  "hasGarden": false
}
```

**Response**:
```json
{
  "assessmentId": "uuid",
  "rating": "overpriced", // fair, overpriced, good_deal
  "confidence": 85,
  "marketAverage": 2200,
  "difference": 300,
  "reasoning": "£300 above area average for similar 2-bed flats",
  "comparableProperties": [
    {
      "address": "Similar Property 1",
      "rent": 2200,
      "bedrooms": 2,
      "distance": "0.3 miles",
      "url": "https://..."
    }
  ],
  "marketInsights": {
    "areaAverage": 2200,
    "priceRange": {
      "min": 1800,
      "max": 2800
    },
    "transportPremium": 200
  }
}
```

## Market Analysis API

### GET /api/market/area/{postcode}
**Purpose**: Get area market intelligence
```json
{
  "postcode": "SW1A 1AA",
  "averageRents": {
    "studio": 1400,
    "oneBed": 1800,
    "twoBed": 2200,
    "threeBed": 3200
  },
  "marketTrends": {
    "monthlyChange": 2.5,
    "yearlyChange": 8.2
  },
  "transportLinks": [
    {
      "station": "Victoria",
      "type": "tube",
      "walkingMinutes": 8,
      "pricePremium": 150
    }
  ],
  "businessDistrictTimes": {
    "city": 25,
    "canaryWharf": 35,
    "kingsCross": 15
  }
}
```

## Negotiation API

### POST /api/negotiation/suggest
**Purpose**: Generate negotiation recommendations
```json
{
  "assessmentId": "uuid",
  "currentRent": 2500,
  "suggestedRent": 2200,
  "negotiationStrength": "strong", // weak, moderate, strong
  "successProbability": 75,
  "negotiationPoints": [
    "Property is £300 above area average",
    "Similar properties available for £200 less",
    "No garden despite local premium for outdoor space"
  ]
}
```

### GET /api/negotiation/report/{assessmentId}
**Purpose**: Generate downloadable market evidence report
**Response**: PDF blob with market comparison data

## Data Collection API (Internal)

### POST /api/data/collect
**Purpose**: Trigger data collection from external sources
**Authentication**: Internal service-to-service

### GET /api/data/status
**Purpose**: Check data freshness and collection status
```json
{
  "lastUpdate": "2024-09-06T10:30:00Z",
  "recordsCount": 15420,
  "coverage": {
    "postcodes": 1250,
    "properties": 15420
  },
  "dataAge": {
    "averageHours": 18,
    "oldestHours": 72
  }
}
```

### Database Schema Design
# Fair Rent Advisor - Database Schema (Azure Cosmos DB)

## Container Structure

### Properties Container
**Partition Key**: `/postcode`
```json
{
  "id": "property_uuid",
  "postcode": "SW1A 1AA",
  "address": "123 Example Street, London",
  "propertyType": "flat", // flat, house, studio
  "bedrooms": 2,
  "bathrooms": 1,
  "monthlyRent": 2200,
  "furnished": true,
  "hasGarden": false,
  "hasParking": false,
  "floorArea": 65,
  "availableFrom": "2024-09-15",
  "coordinates": {
    "lat": 51.5074,
    "lng": -0.1278
  },
  "source": "rightmove", // source website
  "sourceUrl": "https://...",
  "dateAdded": "2024-09-06T10:30:00Z",
  "lastSeen": "2024-09-06T10:30:00Z",
  "isActive": true,
  "features": ["balcony", "dishwasher", "washing_machine"],
  "nearestStations": [
    {
      "name": "Victoria",
      "type": "tube",
      "walkingMinutes": 8
    }
  ]
}
```

### MarketData Container
**Partition Key**: `/postcode`
```json
{
  "id": "market_SW1A1AA_2024_09",
  "postcode": "SW1A 1AA",
  "period": "2024-09",
  "averageRents": {
    "studio": {
      "mean": 1400,
      "median": 1350,
      "min": 1100,
      "max": 1700,
      "count": 25
    },
    "oneBed": {
      "mean": 1800,
      "median": 1750,
      "min": 1400,
      "max": 2200,
      "count": 45
    },
    "twoBed": {
      "mean": 2200,
      "median": 2150,
      "min": 1800,
      "max": 2800,
      "count": 38
    }
  },
  "marketTrends": {
    "monthlyChange": 2.5,
    "quarterlyChange": 6.8,
    "yearlyChange": 8.2
  },
  "propertyCount": 108,
  "lastCalculated": "2024-09-06T06:00:00Z"
}
```

### Assessments Container
**Partition Key**: `/userId` (for user-specific assessments)
```json
{
  "id": "assessment_uuid",
  "userId": "user_uuid", // null for anonymous
  "sessionId": "session_uuid",
  "inputProperty": {
    "postcode": "SW1A 1AA",
    "bedrooms": 2,
    "propertyType": "flat",
    "monthlyRent": 2500,
    "furnished": true
  },
  "assessment": {
    "rating": "overpriced",
    "confidence": 85,
    "marketAverage": 2200,
    "difference": 300,
    "reasoning": "£300 above area average"
  },
  "comparableProperties": ["prop_uuid1", "prop_uuid2"],
  "timestamp": "2024-09-06T14:30:00Z",
  "ipAddress": "192.168.1.1" // for analytics, anonymized
}
```

### PostcodeData Container
**Partition Key**: `/postcode`
```json
{
  "id": "postcode_SW1A1AA",
  "postcode": "SW1A 1AA",
  "district": "Westminster",
  "zone": 1,
  "coordinates": {
    "lat": 51.5074,
    "lng": -0.1278
  },
  "transportLinks": [
    {
      "station": "Victoria",
      "type": "tube",
      "lines": ["Victoria", "District", "Circle"],
      "walkingMinutes": 8,
      "distance": 650
    }
  ],
  "businessDistrictTimes": {
    "city": 25,
    "canaryWharf": 35,
    "kingsCross": 15,
    "westEnd": 10
  },
  "amenities": {
    "supermarkets": 5,
    "restaurants": 25,
    "pubs": 8,
    "gyms": 3
  },
  "safetyScore": 8.2,
  "walkScore": 95
}
```

### Users Container (Auth0 Integration)
**Partition Key**: `/auth0Id`
```json
{
  "id": "user_uuid",
  "auth0Id": "auth0|user_id",
  "email": "user@example.com",
  "preferences": {
    "maxBudget": 2500,
    "preferredAreas": ["SW1A", "SW1B"],
    "propertyType": "flat",
    "bedrooms": 2
  },
  "savedProperties": ["prop_uuid1", "prop_uuid2"],
  "assessmentHistory": ["assess_uuid1", "assess_uuid2"],
  "createdAt": "2024-09-06T10:00:00Z",
  "lastLogin": "2024-09-06T14:30:00Z"
}
```

## Indexing Strategy

### Properties Container Indexes
- `/postcode` (partition key)
- `/bedrooms`
- `/monthlyRent`
- `/propertyType`
- `/coordinates` (geospatial)
- `/isActive`

### Composite Indexes
- `/postcode, /bedrooms, /propertyType`
- `/postcode, /monthlyRent`
- `/coordinates` (for distance queries)

## Data Retention Policy
- **Properties**: Keep for 6 months after `lastSeen`
- **MarketData**: Keep for 24 months
- **Assessments**: Keep for 12 months (anonymized after 3 months)
- **Users**: Keep until account deletion

### Security Architecture
graph TB
    subgraph "Client Security"
        Browser[Web Browser]
        HTTPS[HTTPS/TLS 1.3]
        CSP[Content Security Policy]
    end
    
    subgraph "Authentication Layer"
        Auth0[Auth0 Identity Provider]
        JWT[JWT Tokens]
        Refresh[Refresh Token Rotation]
    end
    
    subgraph "API Security"
        APIM[Azure API Management]
        RateLimit[Rate Limiting]
        CORS[CORS Policy]
        Auth[JWT Validation]
    end
    
    subgraph "Application Security"
        Functions[Azure Functions]
        InputVal[Input Validation]
        OutputSan[Output Sanitization]
        Secrets[Azure Key Vault]
    end
    
    subgraph "Data Security"
        CosmosDB[(Cosmos DB)]
        Encryption[Encryption at Rest]
        RBAC[Role-Based Access]
        Backup[Encrypted Backups]
    end
    
    subgraph "Network Security"
        VNet[Virtual Network]
        NSG[Network Security Groups]
        WAF[Web Application Firewall]
    end
    
    Browser --> HTTPS
    HTTPS --> Auth0
    Auth0 --> JWT
    JWT --> APIM
    APIM --> RateLimit
    APIM --> Auth
    Auth --> Functions
    Functions --> InputVal
    Functions --> Secrets
    Functions --> CosmosDB
    CosmosDB --> Encryption
    Functions --> VNet
    VNet --> NSG

## Cost Analysis & Optimization Strategy

### Monthly Cost Breakdown (Target: Under £50/month)

| Service | Tier | Monthly Cost (£) | Usage Assumptions |
|---------|------|------------------|-------------------|
| Azure Static Web Apps | Free | £0 | 100GB bandwidth |
| Azure Functions | Consumption | £5 | 1M executions, 400GB-s |
| Cosmos DB | Free | £0 | 1000 RU/s, 25GB |
| Redis Cache | Basic C0 | £11 | 250MB cache |
| API Management | Free | £0 | 1M calls |
| Blob Storage | Hot | £3 | 10GB reports |
| Application Insights | Free | £0 | 5GB telemetry |
| **Total** | | **£19/month** | |

### Scaling Cost Projections
- **High Usage (10K assessments/day)**: £35/month
- **Growth Phase (50K assessments/day)**: £85/month (requires tier upgrades)

## Development Roadmap

### Phase 1: Core MVP (Weeks 1-4)
**Week 1-2: Foundation**
- Azure resource provisioning and CI/CD setup
- Basic React application with Auth0 integration
- Core .NET Azure Functions structure
- Cosmos DB schema implementation

**Week 3-4: Core Features**
- Property assessment algorithm implementation
- Basic market data collection from government APIs
- Property comparison functionality
- Simple UI for property input and results

### Phase 2: Enhanced MVP (Weeks 5-8)
**Week 5-6: Data Pipeline**
- Automated data collection pipeline
- Web scraping implementation (ethical)
- Market trend calculation algorithms
- Caching layer optimization

**Week 7-8: User Experience**
- Enhanced UI with detailed results
- Negotiation tools implementation
- Market report generation
- Performance optimization

### Phase 3: Production Ready (Weeks 9-12)
**Week 9-10: Production Hardening**
- Security audit and implementation
- Comprehensive error handling
- Monitoring and alerting setup
- Load testing and optimization

**Week 11-12: Launch Preparation**
- User acceptance testing
- Documentation completion
- Production deployment
- Analytics implementation

## Risk Assessment & Mitigation

### Technical Risks
1. **Data Quality**: Inconsistent property data from web scraping
   - *Mitigation*: Multiple data sources, data validation algorithms
2. **Rate Limiting**: External APIs limiting data collection
   - *Mitigation*: Multiple API keys, respectful scraping, caching
3. **Cosmos DB RU Limits**: Exceeding free tier limits
   - *Mitigation*: Efficient queries, caching layer, query optimization

### Business Risks
1. **Legal Issues**: Web scraping violations
   - *Mitigation*: Legal review, robots.txt compliance, rate limiting
2. **Competition**: Large portals blocking access
   - *Mitigation*: Diversified data sources, government data priority

## Compliance & Legal Considerations

### GDPR Compliance
- Minimal data collection (only assessment data)
- Clear privacy policy and cookie consent
- Right to deletion implementation
- Data anonymization after 3 months

### Web Scraping Ethics
- Robots.txt compliance
- Rate limiting (1 request per 5 seconds)
- User-Agent identification
- Terms of service review

---

## Software Engineer Agent Handoff

Based on this architecture, I recommend proceeding with the implementation in the following priority order:

1. **Infrastructure Setup**: Azure resources and CI/CD pipeline
2. **Core Assessment Engine**: Property analysis algorithms
3. **Data Collection Pipeline**: Government API integration first, then ethical web scraping
4. **Frontend Implementation**: React application with responsive design
5. **Authentication Integration**: Auth0 setup for user management

The architecture is designed to:
- Stay within budget constraints using Azure free tiers
- Scale efficiently with usage growth
- Maintain security and compliance standards
- Support rapid MVP development

Would you like me to generate the detailed Software Engineer Agent prompt with specific implementation instructions for Phase 1?

# -- User Response Prompt --
Yes

# -- Architecture Agent Response --
# Technical Architecture Plan for Software Engineer Agent

## Project Overview
**Fair Rent Advisor** is an AI-powered platform that helps London renters instantly assess if rental prices are fair by providing market analysis and negotiation guidance through a web platform. The MVP targets young professional renters (22-35) seeking 1-2 bed properties in London with a development budget under £1000 and operational costs under £50/month.

## Architecture Specifications

### System Architecture
**Pattern**: Serverless microservices hybrid using Azure cloud services
- **Frontend**: React 18 SPA hosted on Azure Static Web Apps
- **Backend**: .NET 8 Azure Functions for serverless compute
- **Database**: Azure Cosmos DB with document-based storage
- **Caching**: Azure Redis Cache for frequently accessed market data
- **Authentication**: Auth0 for user management and JWT tokens

### Technology Stack
- **Frontend**: React 18 with TypeScript, hosted on Azure Static Web Apps (free tier)
- **Backend**: .NET 8 with Azure Functions (consumption plan), C# 12
- **Database**: Azure Cosmos DB (free tier: 1000 RU/s, 25GB storage)
- **Caching**: Azure Redis Cache Basic C0 (£11/month, 250MB)
- **Authentication**: Auth0 (free tier: 7,000 active users)
- **Infrastructure**: Azure API Management (free tier), Azure Blob Storage for reports
- **Monitoring**: Azure Application Insights (free tier)

### Implementation Guidelines

#### API Design
**RESTful API Structure** with the following core endpoints:

**Property Assessment API**:
```
POST /api/property/assess
- Input: postcode, bedrooms, propertyType, monthlyRent, furnished, hasGarden
- Output: rating (fair/overpriced/good_deal), confidence %, market average, comparable properties
- Response time requirement: <10 seconds
```

**Market Analysis API**:
```
GET /api/market/area/{postcode}
- Output: area averages by property type, transport links, business district journey times
- Cached data with daily refresh
```

**Negotiation Support API**:
```
POST /api/negotiation/suggest
GET /api/negotiation/report/{assessmentId}
- Generate negotiation recommendations and downloadable market evidence reports
```

#### Database Design
**Azure Cosmos DB Containers** with the following structure:

1. **Properties Container** (Partition Key: `/postcode`)
   - Store rental listings with property details, coordinates, transport links
   - Include source tracking, active status, and feature arrays
   - Geospatial indexing for distance-based queries

2. **MarketData Container** (Partition Key: `/postcode`)
   - Monthly aggregated statistics by postcode and property type
   - Mean/median/min/max rent calculations with trend analysis
   - Automatic calculation triggers via Azure Functions

3. **Assessments Container** (Partition Key: `/userId`)
   - Store user assessment requests and results
   - Support anonymous assessments with session tracking
   - Include comparable property references

4. **PostcodeData Container** (Partition Key: `/postcode`)
   - Static postcode information with transport links
   - Business district journey times and amenity scores
   - One-time data load from government sources

#### Security Implementation
**Multi-layered security approach**:
- Auth0 JWT token validation in Azure Functions
- Azure API Management for rate limiting (1000 requests/hour per IP)
- HTTPS/TLS 1.3 enforcement with CORS policies
- Input validation and output sanitization in all APIs
- Azure Key Vault for connection strings and API keys
- Role-based access control for Cosmos DB operations

#### Performance Requirements
- **Response Time**: Property assessments must complete within 10 seconds
- **Caching Strategy**: Redis cache for market averages (24-hour TTL), Cosmos DB query results (1-hour TTL)
- **Database Optimization**: Composite indexes on postcode+bedrooms+propertyType combinations
- **Auto-scaling**: Azure Functions consumption plan with automatic scaling based on demand

### Development Standards
- **Code Organization**: Clean Architecture pattern with separate layers for Domain, Application, Infrastructure, and Presentation
- **Naming Conventions**: PascalCase for C# classes/methods, camelCase for TypeScript, kebab-case for CSS classes
- **Testing Requirements**: 
  - Backend: xUnit for unit tests, 80% code coverage minimum
  - Frontend: Jest and React Testing Library for component tests
  - Integration: Azure Functions testing with TestServer
- **Documentation**: XML documentation for all public APIs, README files for setup instructions, OpenAPI/Swagger specifications

### Software Engineer Agent Instructions

Please implement this architecture following these specific guidelines:

1. **Phase 1 Implementation Priorities (Weeks 1-4)**:
   - Set up Azure resource group with Cosmos DB, Redis, and Static Web Apps
   - Create .NET 8 Azure Functions project with dependency injection and configuration
   - Implement core property assessment algorithm using manual object mapping (no AutoMapper)
   - Build React frontend with TypeScript, Material-UI components, and responsive design
   - Integrate Auth0 authentication with JWT token handling
   - Create basic property input form and results display components

2. **Key Architectural Patterns to Follow**:
   - Use Azure Functions with HTTP triggers for all API endpoints
   - Implement repository pattern for Cosmos DB data access with manual mapping
   - Create separate services for PropertyAssessment, MarketAnalysis, and DataCollection
   - Use Azure Functions dependency injection container for service registration
   - Implement async/await patterns throughout for optimal performance

3. **Integration Requirements and External Dependencies**:
   - Government property data APIs (start with Land Registry and ONS)
   - Transport for London (TfL) API for station data and journey times
   - Ethical web scraping framework for property portals (with rate limiting)
   - Azure Service Bus for background data processing tasks
   - Application Insights for logging and performance monitoring

4. **Testing and Quality Requirements**:
   - Unit tests for all business logic with xUnit and FluentAssertions
   - Integration tests for Azure Functions using TestServer
   - React component tests with Jest and React Testing Library
   - End-to-end testing with Playwright for critical user journeys
   - Performance testing to ensure <10 second response times
   - Security testing for input validation and authentication flows

**Critical Implementation Notes**:
- **Never use AutoMapper** - implement manual object mapping using static methods or extension methods
- **Cost Optimization**: Use Azure free tiers exclusively in Phase 1, implement efficient Cosmos DB queries to stay within 1000 RU/s limit
- **Error Handling**: Comprehensive try-catch blocks with structured logging to Application Insights
- **Data Validation**: Server-side validation for all inputs with detailed error responses
- **Responsive Design**: Mobile-first approach with breakpoints for tablet and desktop
- **Performance**: Implement caching at multiple layers (browser, Redis, Cosmos DB query cache)

**Phase 1 Specific Deliverables**:
1. Complete Azure infrastructure setup with ARM templates or Bicep
2. .NET 8 Azure Functions project with core assessment functionality
3. React frontend with property input form and basic results display
4. Auth0 integration with user registration and login flows
5. Core database schema implementation in Cosmos DB
6. Basic data collection from government APIs
7. Unit and integration test suites with CI/CD pipeline in Azure DevOps

**Technology Constraints**:
- Use .NET 8 minimal APIs pattern in Azure Functions
- Implement React functional components with hooks (no class components)
- Use Azure SDK v12 for all Azure service interactions
- Follow Microsoft security best practices for Azure Functions
- Implement proper CORS configuration for cross-origin requests

Please provide implementation plans and code that I can review for architectural compliance, focusing on the Phase 1 deliverables first. Include detailed setup instructions for the development environment and deployment procedures for Azure resources.
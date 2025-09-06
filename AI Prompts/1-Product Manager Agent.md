# -- Initial User Prompt --

# Fair Rent Advisor - Detailed Idea Brief

## Problem Statement
Renters in the UK, particularly first-time renters and those new to areas, struggle to determine if rental prices are fair. Property portals show listings but don't provide context about whether prices are reasonable compared to local market rates, property conditions, or tenant rights. This information asymmetry allows some landlords to overcharge, particularly in high-demand areas or when targeting vulnerable renters.

## Solution Overview
An AI-powered platform that analyzes rental listings in real-time and provides renters with:
- Fair market value assessment for specific properties
- Price comparison with similar properties in the area
- Red flag detection for potentially exploitative practices
- Negotiation guidance and scripts
- Alternative property suggestions

## How It Works

### Core AI Functionality
1. **Data Collection**: Web scraping of major UK property sites (Rightmove, Zoopla, SpareRoom, etc.)
2. **Property Analysis**: AI processes listing details, photos, descriptions to extract key features
3. **Market Comparison**: Machine learning models compare properties against local market data
4. **Price Assessment**: Algorithm determines if asking rent is below, at, or above fair market value
5. **Red Flag Detection**: AI identifies suspicious patterns (poor photos, vague descriptions, unusually high prices for area)

### User Experience
- **Browser Extension**: Overlay on property sites showing instant price assessment
- **Mobile App**: Upload property links or photos for analysis
- **Email Reports**: Weekly digest of new fairly-priced properties in user's search area
- **Negotiation Assistant**: AI-generated talking points for rent negotiations

## Technical Implementation

### MVP Development (Under £1000)
- **Data Sources**: Free APIs where available, ethical web scraping for others
- **AI/ML**: Combination of existing APIs (OpenAI for analysis) and simple regression models
- **Infrastructure**: Cloud hosting (AWS/GCP free tiers initially)
- **Frontend**: Simple web app and browser extension

### Key Features for MVP
1. Postcode-based rent analysis
2. Basic property comparison (bed count, area, transport links)
3. Simple "Fair/Overpriced/Underpriced" assessment
4. Link to similar properties at better prices

## Market Opportunity

### Target Users
- **Primary**: Renters aged 22-35 in major UK cities
- **Secondary**: International students and new UK residents
- **Tertiary**: Parents helping children find rental properties

### Market Size
- UK rental market: ~4.5 million households
- Average rent negotiation could save £50-200/month
- Potential to help 10,000+ renters in first year

### Competition Analysis
- **Current Solutions**: Limited to basic price comparison on property sites
- **Advantages**: Real-time AI analysis, negotiation support, red flag detection
- **Differentiation**: Focus on fairness and tenant advocacy rather than just listings

## Business Model

### Revenue Streams
1. **Freemium Model**: Basic analysis free, premium features £5-10/month
2. **Success Fees**: Small fee (£20-50) when users successfully negotiate rent reductions
3. **B2B Partnerships**: 
   - Tenant advocacy organizations
   - Student accommodation services
   - Relocation companies
4. **Data Insights**: Anonymized market reports to housing charities and policy organizations

### Cost Structure
- **Development**: Mostly time investment (evenings/weekends)
- **Infrastructure**: £30-100/month initially
- **Data**: Potential costs for premium property data APIs
- **Legal**: Basic terms of service and privacy policy setup

## Social Impact

### Primary Benefits
- **Economic**: Help renters save money on housing costs
- **Educational**: Increase awareness of tenant rights and fair market rates
- **Advocacy**: Provide data to support housing policy improvements
- **Accessibility**: Make rental market information more transparent and accessible

### Success Metrics
- Number of users helped with rent assessments
- Total money saved by users through negotiations
- Reduction in reported rental exploitation cases
- Policy impact through data sharing with housing organizations

## Technical Challenges & Solutions

### Data Acquisition
- **Challenge**: Property sites may block scraping
- **Solution**: Respectful scraping practices, API partnerships where possible, user-contributed data

### Accuracy
- **Challenge**: Ensuring price assessments are reliable
- **Solution**: Continuous model training, user feedback loops, conservative recommendations

### Scalability
- **Challenge**: Handling multiple cities and regions
- **Solution**: Start with London, expand gradually with local data validation

## Go-to-Market Strategy

### Phase 1: MVP Launch (Months 1-3)
- Focus on London rental market
- Browser extension for major property sites
- Social media and community outreach to renters

### Phase 2: Expansion (Months 4-6)
- Add mobile app
- Expand to Manchester, Birmingham, Bristol
- Partner with student unions and housing charities

### Phase 3: Scale (Months 7-12)
- National coverage
- Advanced AI features (photo analysis, amenity scoring)
- B2B partnerships and potential funding rounds

## Regulatory Considerations
- **Data Protection**: GDPR compliance for user data
- **Web Scraping**: Ensure compliance with property site terms of service
- **Consumer Rights**: Align with UK tenant protection laws
- **Advertising Standards**: Clear disclaimers about assessment limitations

## Risk Assessment

### Low Risk
- Technical implementation within skillset
- Clear user need and market demand
- Minimal upfront investment required

### Medium Risk
- Property sites blocking data access
- Competition from established players
- User adoption in conservative rental market

### Mitigation Strategies
- Multiple data sources and user-contributed content
- Focus on unique value proposition (fairness vs. listings)
- Strong community engagement and word-of-mouth marketing

This detailed brief provides a comprehensive foundation for product management evaluation while staying true to your core parameters of low startup cost, social impact, and AI integration.

# -- Product Manager Response --

I'll evaluate your Fair Rent Advisor idea and transform it into a structured MVP plan. Let me start by gathering some additional context to ensure I create the most effective product requirements.

## Context Gathering Questions

Based on your detailed brief, I have a few clarifying questions to better scope the MVP:

1. **Technical Constraints**: You mention under £1000 budget - are you planning to handle development yourself, or do you need to account for developer costs in this budget?

2. **Timeline**: What's your target timeline for MVP launch? This will help prioritize features appropriately.

3. **Geographic Focus**: You mention starting with London - are you familiar with London rental market dynamics, or would you prefer to start with an area you know better?

4. **User Validation**: Have you spoken with potential users (renters) about this problem? Any specific feedback on which pain points are most acute?

5. **Data Access**: Do you have any existing relationships with property sites or data providers, or will you be starting from scratch with web scraping?

## Initial Idea Evaluation

**Problem-Solution Fit**: ✅ Strong - Rental price opacity is a real, documented problem affecting millions of UK renters.

**Market Viability**: ✅ Good - Large addressable market with clear willingness to pay for housing-related tools.

**MVP Feasibility**: ⚠️ Moderate - The core concept is solid, but we'll need to carefully scope the AI components to fit budget constraints.

**Competitive Differentiation**: ✅ Strong - Current solutions focus on listings aggregation, not fairness assessment.

**Risk Assessment**: The main risks are data access limitations and AI accuracy, but these are manageable with the right MVP approach.

Once you provide the additional context above, I'll create a comprehensive MVP breakdown with epics, user stories, and clear acceptance criteria that can be built within your constraints.

Would you please answer these questions so I can create the most targeted product requirements for your Fair Rent Advisor platform?

# -- User Reply Prompt --

1. We will be using AI Agents (Architecture, Software Engineer, QA Engineer) + myself to develop this product.
2. No Timeline
3. Lets focus on London only for the MVP
4. No
5. We do not have any existing data so will be starting from scratch. We should try to use publicly available free data first but if this data is not efficient then we may need to consider web scraping.

# -- Product Manager Agent Response --

Perfect! Now I have the context I need. Let me evaluate and structure your Fair Rent Advisor idea into a comprehensive MVP plan.

## Product Vision Statement
Fair Rent Advisor helps London renters instantly assess if rental prices are fair by providing AI-powered market analysis and negotiation guidance through a simple web platform.

## Target User Personas

**Primary: Young Professional Renter (Sarah, 26)**
- Working in London, looking for 1-2 bed flat
- Limited knowledge of different areas and fair pricing
- Time-constrained, wants quick assessments
- Budget-conscious, willing to negotiate

**Secondary: International Newcomer (Marco, 29)**
- New to UK/London rental market
- Unfamiliar with local pricing norms and tenant rights
- Vulnerable to exploitation due to knowledge gap
- Needs comprehensive guidance and education

## Epic Breakdown

### Epic 1: Property Price Assessment Engine
**Theme**: Core value proposition - determining rental fairness
**Features**:
- **Property Data Collection**: Aggregate rental listings from public sources
- **Market Analysis**: Compare property against similar rentals in area
- **Price Assessment**: Generate fair/overpriced/underpriced rating
- **Comparison Display**: Show similar properties with better value

**User Stories**:
- **Story**: "As a renter, I want to input a property postcode and basic details so that I can get an instant assessment of whether the rent is fair"
  - **Acceptance Criteria**: 
    - User can enter postcode, property type, bedrooms, rent amount
    - System returns assessment within 10 seconds
    - Assessment shows "Fair", "Overpriced", or "Good Deal" with confidence level
    - Basic reasoning provided (e.g., "£200 above area average")
  - **Priority**: High
  - **Effort Estimate**: Large

- **Story**: "As a renter, I want to see comparable properties in my area so that I can understand the local market"
  - **Acceptance Criteria**:
    - Shows 3-5 similar properties within 1 mile radius
    - Displays key details: rent, bedrooms, transport links
    - Highlights properties with better value
    - Links to original listings where possible
  - **Priority**: High
  - **Effort Estimate**: Medium

### Epic 2: Area Market Intelligence
**Theme**: Providing local market context and insights
**Features**:
- **Postcode Analysis**: Area-specific rental trends and averages
- **Transport Premium**: How proximity to transport affects pricing
- **Market Alerts**: Notify when good deals appear in target areas

**User Stories**:
- **Story**: "As a renter, I want to understand the rental market in a specific area so that I can set realistic expectations"
  - **Acceptance Criteria**:
    - Shows average rent by property type for entered postcode
    - Displays price range (min, max, median) for last 30 days
    - Includes area highlights (transport, amenities)
    - Shows price trends (increasing/decreasing/stable)
  - **Priority**: Medium
  - **Effort Estimate**: Medium

- **Story**: "As a renter, I want to understand how transport links affect rental prices so that I can make informed location decisions"
  - **Acceptance Criteria**:
    - Shows distance to nearest tube/rail stations
    - Indicates transport premium/discount vs area average
    - Lists journey times to major business districts
    - Highlights areas with best value-for-money transport access
  - **Priority**: Medium
  - **Effort Estimate**: Small

### Epic 3: User Property Portfolio
**Theme**: Personal rental search management and tracking
**Features**:
- **Property Watchlist**: Save and track interesting properties
- **Search Alerts**: Notifications for new fair-priced properties
- **Assessment History**: Track all previous property assessments

**User Stories**:
- **Story**: "As a renter, I want to save properties I'm interested in so that I can compare them later"
  - **Acceptance Criteria**:
    - Users can create account and save properties
    - Saved properties include assessment, date saved, and notes
    - Can compare saved properties side-by-side
    - Shows if saved property price has changed
  - **Priority**: Low
  - **Effort Estimate**: Medium

- **Story**: "As a renter, I want to be notified when new fairly-priced properties appear in my target areas so that I don't miss opportunities"
  - **Acceptance Criteria**:
    - Users can set search criteria (area, price range, bedrooms)
    - Email notifications sent for new properties meeting criteria
    - Only properties assessed as "Fair" or "Good Deal" trigger alerts
    - Maximum one email per day with digest format
  - **Priority**: Low
  - **Effort Estimate**: Small

### Epic 4: Negotiation Support Tools
**Theme**: Empowering renters with negotiation guidance
**Features**:
- **Negotiation Calculator**: Suggest reasonable counter-offers
- **Market Evidence**: Generate talking points with local data
- **Success Tracking**: Track negotiation outcomes

**User Stories**:
- **Story**: "As a renter, I want guidance on how much to negotiate down the rent so that I can make a reasonable counter-offer"
  - **Acceptance Criteria**:
    - Suggests negotiation amount based on market analysis
    - Provides reasoning and comparable properties as evidence
    - Includes template negotiation email/script
    - Shows probability of success based on over-pricing level
  - **Priority**: Medium
  - **Effort Estimate**: Small

- **Story**: "As a renter, I want access to local market data to support my negotiation so that I have credible evidence"
  - **Acceptance Criteria**:
    - Generates 1-page market summary for specific property
    - Includes recent comparable rentals with prices
    - Shows area average and property's position vs average
    - Downloadable/printable format for landlord discussions
  - **Priority**: Medium
  - **Effort Estimate**: Small

## Success Metrics
- **User Engagement**: 1,000+ property assessments in first 3 months
- **User Value**: Average £75/month rent savings for users who negotiate
- **Platform Growth**: 500+ registered users by month 6
- **Data Quality**: 85%+ accuracy on price assessments vs user feedback

## Out of Scope (Future Iterations)
- Mobile app (web-responsive initially)
- Photo analysis of property condition
- Landlord/agent reputation scoring
- Integration with property viewing scheduling
- Advanced ML models (start with rule-based algorithms)
- Multiple cities beyond London
- Browser extension (standalone web app first)
- Tenant rights legal advice
- Property condition/quality scoring

---

## Validation Questions

Before I proceed to generate the agent handoff prompts, I need your confirmation:

1. **Does this breakdown capture your vision accurately?** Particularly the focus on price assessment as the core value proposition?

2. **Are there any epics, features, or stories you'd like to modify?** For example, should we prioritize negotiation tools higher, or focus more on the data collection aspects?

3. **Is there anything missing or anything that should be removed?** The scope feels appropriate for an MVP, but I want to ensure we haven't missed critical user needs.

4. **Do the priorities align with your expectations?** I've prioritized the core assessment engine highest, with supporting features as medium/low priority.

Please review and let me know if you'd like any adjustments before I create the comprehensive handoff prompts for the Architecture, Software Engineer, and QA Engineer agents.

# -- User Response Prompt --

Yes that all looks good

# -- Product Manager Agent Response --

Excellent! I'll now create comprehensive handoff prompts for each agent and develop UI mockups to visualize the user experience. Let me start with the UI mockups to demonstrate the key user workflows.

```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Fair Rent Advisor - UI Mockups</title>
    <style>
        * { margin: 0; padding: 0; box-sizing: border-box; }
        body { font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; background-color: #f5f7fa; color: #333; }
        
        .mockup-container { max-width: 1200px; margin: 0 auto; padding: 20px; }
        .mockup-section { background: white; margin: 40px 0; border-radius: 12px; box-shadow: 0 4px 12px rgba(0,0,0,0.1); overflow: hidden; }
        .mockup-header { background: #2563eb; color: white; padding: 20px; text-align: center; }
        .mockup-content { padding: 30px; }
        
        .screen { background: #fff; border: 2px solid #e5e7eb; border-radius: 8px; padding: 20px; margin: 20px 0; }
        .screen-title { font-size: 18px; font-weight: 600; margin-bottom: 15px; color: #1f2937; }
        
        /* Header styles */
        .app-header { background: #2563eb; color: white; padding: 15px 0; text-align: center; }
        .app-header h1 { font-size: 24px; font-weight: 700; }
        .app-header p { opacity: 0.9; margin-top: 5px; }
        
        /* Form styles */
        .property-form { background: #f8fafc; padding: 25px; border-radius: 8px; margin: 20px 0; }
        .form-group { margin-bottom: 20px; }
        .form-group label { display: block; font-weight: 600; margin-bottom: 8px; color: #374151; }
        .form-group input, .form-group select { width: 100%; padding: 12px; border: 2px solid #d1d5db; border-radius: 6px; font-size: 16px; }
        .form-group input:focus, .form-group select:focus { outline: none; border-color: #2563eb; }
        
        .btn-primary { background: #2563eb; color: white; padding: 15px 30px; border: none; border-radius: 6px; font-size: 16px; font-weight: 600; cursor: pointer; width: 100%; }
        .btn-primary:hover { background: #1d4ed8; }
        
        /* Assessment result styles */
        .assessment-result { margin: 25px 0; }
        .assessment-card { border-left: 5px solid #10b981; background: #f0fdf4; padding: 20px; border-radius: 8px; margin: 15px 0; }
        .assessment-card.overpriced { border-left-color: #ef4444; background: #fef2f2; }
        .assessment-card.good-deal { border-left-color: #10b981; background: #f0fdf4; }
        
        .assessment-badge { display: inline-block; padding: 8px 16px; border-radius: 20px; font-weight: 600; font-size: 14px; }
        .assessment-badge.fair { background: #dbeafe; color: #1d4ed8; }
        .assessment-badge.overpriced { background: #fee2e2; color: #dc2626; }
        .assessment-badge.good-deal { background: #dcfce7; color: #166534; }
        
        .price-comparison { display: flex; justify-content: space-between; margin: 15px 0; }
        .price-item { text-align: center; }
        .price-value { font-size: 24px; font-weight: 700; }
        .price-label { font-size: 12px; color: #6b7280; text-transform: uppercase; }
        
        /* Property list styles */
        .property-list { margin: 25px 0; }
        .property-item { border: 1px solid #e5e7eb; border-radius: 8px; padding: 20px; margin: 15px 0; }
        .property-item:hover { border-color: #2563eb; }
        .property-header { display: flex; justify-content: between; align-items: center; margin-bottom: 10px; }
        .property-title { font-weight: 600; font-size: 16px; }
        .property-price { font-size: 18px; font-weight: 700; color: #2563eb; }
        .property-details { color: #6b7280; font-size: 14px; }
        .property-tags { margin-top: 10px; }
        .tag { display: inline-block; background: #f3f4f6; padding: 4px 8px; border-radius: 4px; font-size: 12px; margin-right: 8px; }
        
        /* Navigation styles */
        .nav-tabs { display: flex; border-bottom: 2px solid #e5e7eb; margin-bottom: 20px; }
        .nav-tab { padding: 12px 24px; cursor: pointer; border-bottom: 2px solid transparent; font-weight: 500; }
        .nav-tab.active { border-bottom-color: #2563eb; color: #2563eb; }
        
        /* Area analysis styles */
        .area-stats { display: grid; grid-template-columns: repeat(auto-fit, minmax(200px, 1fr)); gap: 20px; margin: 20px 0; }
        .stat-card { background: #f8fafc; padding: 20px; border-radius: 8px; text-align: center; }
        .stat-value { font-size: 28px; font-weight: 700; color: #2563eb; }
        .stat-label { font-size: 14px; color: #6b7280; margin-top: 5px; }
        
        /* Negotiation tools */
        .negotiation-section { background: #fef3c7; border: 1px solid #f59e0b; border-radius: 8px; padding: 20px; margin: 20px 0; }
        .negotiation-suggestion { font-size: 18px; font-weight: 600; color: #92400e; margin-bottom: 10px; }
        
        .workflow-indicator { display: flex; align-items: center; margin: 20px 0; }
        .step { background: #e5e7eb; width: 30px; height: 30px; border-radius: 50%; display: flex; align-items: center; justify-content: center; font-weight: 600; }
        .step.active { background: #2563eb; color: white; }
        .step-connector { height: 2px; background: #e5e7eb; flex-grow: 1; margin: 0 10px; }
        
        @media (max-width: 768px) {
            .price-comparison { flex-direction: column; gap: 15px; }
            .area-stats { grid-template-columns: 1fr; }
        }
    </style>
</head>
<body>
    <div class="mockup-container">
        
        <!-- Main Landing Page -->
        <div class="mockup-section">
            <div class="mockup-header">
                <h2>Screen 1: Main Landing Page & Property Assessment</h2>
                <p>Primary user entry point - property assessment tool</p>
            </div>
            <div class="mockup-content">
                <div class="screen">
                    <div class="app-header">
                        <h1>Fair Rent Advisor</h1>
                        <p>Get instant assessment of London rental prices</p>
                    </div>
                    
                    <div class="property-form">
                        <h3 style="margin-bottom: 20px; text-align: center;">Check if your rent is fair</h3>
                        
                        <div class="form-group">
                            <label for="postcode">Property Postcode</label>
                            <input type="text" id="postcode" placeholder="e.g. SW1A 1AA" value="">
                        </div>
                        
                        <div style="display: grid; grid-template-columns: 1fr 1fr; gap: 15px;">
                            <div class="form-group">
                                <label for="bedrooms">Bedrooms</label>
                                <select id="bedrooms">
                                    <option>Studio</option>
                                    <option>1 bedroom</option>
                                    <option selected>2 bedrooms</option>
                                    <option>3 bedrooms</option>
                                    <option>4+ bedrooms</option>
                                </select>
                            </div>
                            
                            <div class="form-group">
                                <label for="rent">Monthly Rent (£)</label>
                                <input type="number" id="rent" placeholder="2500" value="">
                            </div>
                        </div>
                        
                        <div class="form-group">
                            <label for="property-type">Property Type</label>
                            <select id="property-type">
                                <option>Flat/Apartment</option>
                                <option>House</option>
                                <option>Studio</option>
                                <option>Room in shared house</option>
                            </select>
                        </div>
                        
                        <button class="btn-primary">Check Fair Rent Price</button>
                    </div>
                </div>
            </div>
        </div>
        
        <!-- Assessment Results -->
        <div class="mockup-section">
            <div class="mockup-header">
                <h2>Screen 2: Property Assessment Results</h2>
                <p>Core value proposition - showing rent fairness assessment</p>
            </div>
            <div class="mockup-content">
                <div class="screen">
                    <div class="screen-title">Assessment Results for SW1A 1AA</div>
                    
                    <div class="assessment-result">
                        <div class="assessment-card overpriced">
                            <div style="display: flex; justify-content: space-between; align-items: center; margin-bottom: 15px;">
                                <span class="assessment-badge overpriced">OVERPRICED</span>
                                <span style="font-size: 14px; color: #6b7280;">Confidence: 87%</span>
                            </div>
                            
                            <div class="price-comparison">
                                <div class="price-item">
                                    <div class="price-value" style="color: #dc2626;">£2,500</div>
                                    <div class="price-label">Your Property</div>
                                </div>
                                <div class="price-item">
                                    <div class="price-value">£2,150</div>
                                    <div class="price-label">Area Average</div>
                                </div>
                                <div class="price-item">
                                    <div class="price-value" style="color: #10b981;">£2,200</div>
                                    <div class="price-label">Fair Price</div>
                                </div>
                            </div>
                            
                            <p style="margin-top: 15px;"><strong>Analysis:</strong> This 2-bedroom flat is £350 above the area average and £300 above our fair price estimate. Similar properties in SW1A typically rent for £2,100-£2,250.</p>
                        </div>
                    </div>
                    
                    <div class="negotiation-section">
                        <div class="negotiation-suggestion">💡 Negotiation Opportunity</div>
                        <p>Based on local market data, you could reasonably negotiate down to <strong>£2,200-£2,250</strong>. We estimate a <strong>65% chance of success</strong> with proper market evidence.</p>
                        <button style="background: #f59e0b; color: white; border: none; padding: 10px 20px; border-radius: 6px; margin-top: 10px; cursor: pointer;">Get Negotiation Kit</button>
                    </div>
                    
                    <div class="nav-tabs">
                        <div class="nav-tab active">Similar Properties</div>
                        <div class="nav-tab">Area Analysis</div>
                        <div class="nav-tab">Negotiation Tools</div>
                    </div>
                    
                    <div class="property-list">
                        <div class="property-item">
                            <div class="property-header">
                                <div class="property-title">2 bed flat, Victoria Street</div>
                                <div class="property-price">£2,100/month</div>
                            </div>
                            <div class="property-details">0.3 miles away • Victoria tube 2min walk • Available now</div>
                            <div class="property-tags">
                                <span class="tag">Better Value</span>
                                <span class="tag">Similar Size</span>
                            </div>
                        </div>
                        
                        <div class="property-item">
                            <div class="property-header">
                                <div class="property-title">2 bed apartment, Buckingham Gate</div>
                                <div class="property-price">£2,200/month</div>
                            </div>
                            <div class="property-details">0.5 miles away • St James Park 5min walk • Available next week</div>
                            <div class="property-tags">
                                <span class="tag">Better Value</span>
                                <span class="tag">Modern</span>
                            </div>
                        </div>
                        
                        <div class="property-item">
                            <div class="property-header">
                                <div class="property-title">2 bed flat, Petty France</div>
                                <div class="property-price">£2,250/month</div>
                            </div>
                            <div class="property-details">0.4 miles away • Multiple tube lines • Recently renovated</div>
                            <div class="property-tags">
                                <span class="tag">Fair Price</span>
                                <span class="tag">Renovated</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
        <!-- Area Analysis -->
        <div class="mockup-section">
            <div class="mockup-header">
                <h2>Screen 3: Area Market Analysis</h2>
                <p>Detailed market intelligence for the selected area</p>
            </div>
            <div class="mockup-content">
                <div class="screen">
                    <div class="screen-title">Market Analysis: Westminster (SW1A)</div>
                    
                    <div class="area-stats">
                        <div class="stat-card">
                            <div class="stat-value">£2,150</div>
                            <div class="stat-label">Average 2-bed rent</div>
                        </div>
                        <div class="stat-card">
                            <div class="stat-value">£1,900 - £2,400</div>
                            <div class="stat-label">Price range</div>
                        </div>
                        <div class="stat-card">
                            <div class="stat-value">+5%</div>
                            <div class="stat-label">Price trend (3 months)</div>
                        </div>
                        <div class="stat-card">
                            <div class="stat-value">15</div>
                            <div class="stat-label">Properties available</div>
                        </div>
                    </div>
                    
                    <div style="background: #f8fafc; padding: 20px; border-radius: 8px; margin: 20px 0;">
                        <h4 style="margin-bottom: 15px;">Transport Premium Analysis</h4>
                        <div style="display: grid; grid-template-columns: repeat(auto-fit, minmax(250px, 1fr)); gap: 15px;">
                            <div>
                                <strong>Nearest Stations:</strong><br>
                                • Victoria (2 min walk): +£150/month<br>
                                • St James Park (4 min walk): +£100/month<br>
                                • Green Park (8 min walk): +£75/month
                            </div>
                            <div>
                                <strong>Journey Times:</strong><br>
                                • Canary Wharf: 25 minutes<br>
                                • City: 15 minutes<br>
                                • King's Cross: 20 minutes
                            </div>
                        </div>
                    </div>
                    
                    <div style="background: #eff6ff; border: 1px solid #2563eb; border-radius: 8px; padding: 20px;">
                        <h4 style="color: #1d4ed8; margin-bottom: 10px;">🎯 Key Insights for SW1A</h4>
                        <ul style="margin-left: 20px; line-height: 1.6;">
                            <li>Premium location with excellent transport links</li>
                            <li>Prices 15-20% above London average due to central location</li>
                            <li>Market showing steady growth but high competition</li>
                            <li>Properties near Victoria station command highest premiums</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        
        <!-- Negotiation Tools -->
        <div class="mockup-section">
            <div class="mockup-header">
                <h2>Screen 4: Negotiation Support Tools</h2>
                <p>Practical tools to help users negotiate better rent</p>
            </div>
            <div class="mockup-content">
                <div class="screen">
                    <div class="screen-title">Negotiation Kit for SW1A Property</div>
                    
                    <div class="workflow-indicator">
                        <div class="step active">1</div>
                        <div class="step-connector"></div>
                        <div class="step">2</div>
                        <div class="step-connector"></div>
                        <div class="step">3</div>
                        <div class="step-connector"></div>
                        <div class="step">4</div>
                    </div>
                    
                    <div style="display: grid; grid-template-columns: repeat(auto-fit, minmax(300px, 1fr)); gap: 20px; margin: 25px 0;">
                        <div style="background: #f0f9ff; border: 1px solid #0ea5e9; border-radius: 8px; padding: 20px;">
                            <h4 style="color: #0369a1; margin-bottom: 15px;">📊 Your Evidence Package</h4>
                            <ul style="margin-left: 20px; line-height: 1.6;">
                                <li>Market average: £2,150/month</li>
                                <li>3 comparable properties at £2,100-£2,200</li>
                                <li>Property is 16% above fair value</li>
                                <li>Similar properties available now</li>
                            </ul>
                            <button style="background: #0ea5e9; color: white; border: none; padding: 8px 16px; border-radius: 4px; margin-top: 10px; cursor: pointer;">Download Evidence Report</button>
                        </div>
                        
                        <div style="background: #f0fdf4; border: 1px solid #10b981; border-radius: 8px; padding: 20px;">
                            <h4 style="color: #059669; margin-bottom: 15px;">💬 Negotiation Script</h4>
                            <p style="font-style: italic; margin-bottom: 10px;">"Based on my research of similar 2-bedroom properties in SW1A, the market rate appears to be £2,100-£2,200. Would you consider £2,200/month?"</p>
                            <button style="background: #10b981; color: white; border: none; padding: 8px 16px; border-radius: 4px; cursor: pointer;">View Full Script</button>
                        </div>
                    </div>
                    
                    <div style="background: #fefce8; border: 1px solid #eab308; border-radius: 8px; padding: 20px;">
                        <h4 style="color: #a16207; margin-bottom: 15px;">🎯 Negotiation Strategy</h4>
                        <div style="display: grid; grid-template-columns: repeat(auto-fit, minmax(200px, 1fr)); gap: 15px;">
                            <div>
                                <strong>Target Price:</strong> £2,200/month<br>
                                <strong>Fallback:</strong> £2,250/month<br>
                                <strong>Success Probability:</strong> 65%
                            </div>
                            <div>
                                <strong>Best Timing:</strong> Before lease signing<br>
                                <strong>Approach:</strong> Professional with evidence<br>
                                <strong>Backup Plan:</strong> Alternative properties ready
                            </div>
                        </div>
                    </div>
                    
                    <div style="margin-top: 25px;">
                        <h4 style="margin-bottom: 15px;">📋 Negotiation Checklist</h4>
                        <div style="background: white; border: 1px solid #e5e7eb; border-radius: 8px; padding: 20px;">
                            <label style="display: block; margin: 10px 0; cursor: pointer;">
                                <input type="checkbox"> Research completed - market evidence gathered
                            </label>
                            <label style="display: block; margin: 10px 0; cursor: pointer;">
                                <input type="checkbox"> Alternative properties identified as backup
                            </label>
                            <label style="display: block; margin: 10px 0; cursor: pointer;">
                                <input type="checkbox"> Professional script prepared
                            </label>
                            <label style="display: block; margin: 10px 0; cursor: pointer;">
                                <input type="checkbox"> Timing planned (before signing)
                            </label>
                            <label style="display: block; margin: 10px 0; cursor: pointer;">
                                <input type="checkbox"> Follow-up strategy ready
                            </label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
        <!-- User Dashboard -->
        <div class="mockup-section">
            <div class="mockup-header">
                <h2>Screen 5: User Dashboard (Future Enhancement)</h2>
                <p>Personal property tracking and search management</p>
            </div>
            <div class="mockup-content">
                <div class="screen">
                    <div class="screen-title">My Property Search Dashboard</div>
                    
                    <div class="nav-tabs">
                        <div class="nav-tab active">Saved Properties</div>
                        <div class="nav-tab">Search Alerts</div>
                        <div class="nav-tab">Assessment History</div>
                    </div>
                    
                    <div style="margin: 20px 0;">
                        <button style="background: #2563eb; color: white; border: none; padding: 12px 24px; border-radius: 6px; cursor: pointer;">+ New Search Alert</button>
                    </div>
                    
                    <div class="property-list">
                        <div class="property-item" style="border-left: 4px solid #10b981;">
                            <div class="property-header">
                                <div class="property-title">2 bed flat, Victoria Street</div>
                                <div class="property-price">£2,100/month</div>
                            </div>
                            <div class="property-details">Saved 2 days ago • Last checked: Today • Status: Still available</div>
                            <div class="property-tags">
                                <span class="tag" style="background: #dcfce7; color: #166534;">Good Deal</span>
                                <span class="tag">Viewing Scheduled</span>
                            </div>
                        </div>
                        
                        <div class="property-item" style="border-left: 4px solid #f59e0b;">
                            <div class="property-header">
                                <div class="property-title">2 bed apartment, Westminster</div>
                                <div class="property-price">£2,400/month</div>
                            </div>
                            <div class="property-details">Saved 1 week ago • Price changed: £2,500 → £2,400</div>
                            <div class="property-tags">
                                <span class="tag" style="background: #fef3c7; color: #92400e;">Price Improved</span>
                                <span class="tag">Watching</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
    </div>
</body>
</html>
```

Now I'll create the comprehensive handoff prompts for each agent:


# Product Requirements for Architecture Agent

## Product Overview

**Product Name**: Fair Rent Advisor  
**Product Vision**: AI-powered platform that helps London renters instantly assess if rental prices are fair by providing market analysis and negotiation guidance through a simple web platform.

**Target Users**: 
- Primary: Young Professional Renters (22-35) seeking 1-2 bed properties in London
- Secondary: International newcomers unfamiliar with UK rental market

**Business Context**: 
- MVP budget under £1000 for development
- Focus on London market only for initial release
- Social impact focus - helping renters avoid exploitation
- Starting from scratch with no existing data partnerships

## MVP Scope & Requirements

### Epic 1: Property Price Assessment Engine (HIGH PRIORITY)
**Core Value Proposition**: Determine rental fairness through AI-powered market analysis

**Key Features**:
1. **Property Data Collection**: Aggregate rental listings from public sources and web scraping
2. **Market Analysis**: Compare input property against similar rentals in area
3. **Price Assessment**: Generate fair/overpriced/underpriced rating with confidence level
4. **Comparison Display**: Show 3-5 similar properties with better value

**Critical User Stories**:
- Input property details (postcode, bedrooms, rent, property type) → Get instant assessment within 10 seconds
- Display assessment as "Fair", "Overpriced", or "Good Deal" with confidence percentage
- Show reasoning (e.g., "£200 above area average") with supporting data
- Present comparable properties within 1-mile radius with pricing and basic details

### Epic 2: Area Market Intelligence (MEDIUM PRIORITY)
**Purpose**: Provide local market context and insights

**Key Features**:
1. **Postcode Analysis**: Area-specific rental trends and averages for last 30 days
2. **Transport Premium Analysis**: How proximity to tube/rail affects pricing
3. **Market Insights**: Price trends, availability, and area highlights

**Critical User Stories**:
- Show average rent by property type for entered postcode with price ranges (min/max/median)
- Display distance to nearest stations with associated price premiums
- Include journey times to major business districts (City, Canary Wharf, King's Cross)

### Epic 3: Negotiation Support Tools (MEDIUM PRIORITY)
**Purpose**: Empower renters with data-driven negotiation guidance

**Key Features**:
1. **Negotiation Calculator**: Suggest reasonable counter-offers based on market analysis
2. **Market Evidence**: Generate downloadable 1-page market summary with comparables
3. **Negotiation Scripts**: Template emails and talking points

**Critical User Stories**:
- Suggest negotiation amount with probability of success estimate
- Generate market evidence report with recent comparable rentals
- Provide professional negotiation script templates

### Epic 4: User Property Portfolio (LOW PRIORITY - Future Enhancement)
**Purpose**: Personal rental search management

**Key Features**:
1. **Property Watchlist**: Save and track interesting properties
2. **Search Alerts**: Email notifications for new fairly-priced properties
3. **Assessment History**: Track all previous property assessments

## Key Constraints & Considerations

### Budget Constraints
- Development budget under £1000
- Must prioritize free/low-cost data sources initially
- Cloud infrastructure costs should start under £50/month
- No premium API subscriptions in MVP phase

### Data Acquisition Challenges
- No existing data partnerships or relationships
- Must rely on publicly available data sources first (gov.uk property data, open APIs)
- Web scraping as secondary option (must be ethical and legal)
- Property sites may implement anti-scraping measures

### Technical Constraints
- Team consists of AI agents + one human product manager
- Development expertise available through AI agents
- No existing infrastructure or codebase
- Must be production-ready within reasonable timeframe

### Geographic Scope
- London postcodes only for MVP (approximately 2000+ postcodes)
- Focus on central London areas initially (Zones 1-3)
- Can expand to outer London areas once core functionality proven

### Regulatory Considerations
- GDPR compliance for any user data collection
- Respectful web scraping practices (robots.txt compliance, rate limiting)
- Property site terms of service compliance
- Consumer protection law alignment

## Success Criteria

### Technical Performance Requirements
- Property assessment response time: < 10 seconds
- System availability: 95%+ uptime
- Data accuracy: 85%+ on price assessments (measured against user feedback)
- Scalability: Support 1000+ assessments per day

### Business Success Metrics
- 1,000+ property assessments in first 3 months
- 500+ registered users by month 6
- Average £75/month rent savings for users who negotiate
- 85%+ user satisfaction with assessment accuracy

### Data Quality Standards
- Property data refresh: Daily for new listings
- Market analysis: Updated weekly for area averages
- Comparable properties: Minimum 3 matches within 1-mile radius
- Price confidence: Clear confidence percentages for all assessments

## Architecture Agent Instructions

Please evaluate these requirements and recommend:

### 1. Overall System Architecture Approach
- **Web Architecture**: Recommend suitable architecture pattern (microservices, monolith, serverless)
- **Database Strategy**: Data storage approach for property listings, user data, and market analysis
- **API Design**: RESTful API structure for frontend-backend communication
- **Caching Strategy**: How to handle repeated property assessments and market data queries

### 2. Technology Stack Recommendations
- **Backend Framework**: Consider Python (Django/FastAPI), Node.js, or other suitable frameworks
- **Database**: PostgreSQL, MongoDB, or other appropriate database solutions
- **Frontend**: React, Vue.js, or vanilla JavaScript for responsive web application
- **Cloud Platform**: AWS, Google Cloud, Azure, or alternative cost-effective hosting
- **AI/ML Components**: Integration approach for property analysis and price assessment algorithms
- **Data Processing**: ETL pipeline for property data collection and processing

### 3. Integration Patterns and Data Flow
- **Data Ingestion**: Strategy for collecting property data from multiple sources
- **Real-time Processing**: How to handle immediate property assessment requests
- **Data Synchronization**: Keeping market data current across the system
- **External API Integration**: Connecting with mapping services, transport APIs, government data sources

### 4. Scalability and Performance Considerations
- **Database Optimization**: Indexing strategy for fast property lookups by postcode/area
- **Caching Layers**: Redis or similar for frequently accessed market data
- **Load Balancing**: Handling concurrent user requests efficiently
- **Data Pipeline Scaling**: Processing large volumes of property listings daily

### 5. Security and Compliance Requirements
- **Data Protection**: GDPR-compliant user data handling and storage
- **API Security**: Authentication, rate limiting, and secure data transmission
- **Web Scraping Ethics**: Legal and respectful data collection practices
- **User Privacy**: Minimal data collection with clear privacy policies

### 6. Development and Deployment Approach
- **Environment Strategy**: Development, staging, and production environment setup
- **CI/CD Pipeline**: Automated testing and deployment processes
- **Monitoring and Logging**: Application performance and error tracking
- **Database Migration**: Strategy for schema changes and data updates

### 7. Cost Optimization Strategy
- **Infrastructure Costs**: Recommendations for staying within £50/month initially
- **Auto-scaling**: Cost-effective scaling based on usage patterns
- **Data Storage**: Efficient storage solutions for large property datasets
- **Third-party Services**: Free tier utilization and cost-effective service selection

### 8. MVP Implementation Phases
**Phase 1 (Core MVP - Weeks 1-4)**:
- Basic property assessment functionality
- Simple web interface
- Postcode-based market analysis
- Static data sources

**Phase 2 (Enhanced MVP - Weeks 5-8)**:
- Dynamic data collection pipeline
- Improved UI with mockup implementation
- Negotiation tools
- Basic user analytics

**Phase 3 (Production Ready - Weeks 9-12)**:
- Performance optimization
- Security hardening
- Monitoring implementation
- User feedback integration

## Reference Materials
- **UI Mockups**: Detailed interface designs showing user workflows for property assessment, results display, market analysis, and negotiation tools
- **User Stories**: Complete acceptance criteria for each feature requirement
- **Business Context**: Social impact focus with emphasis on helping renters avoid exploitation

## Specific Technical Questions to Address
1. **Data Architecture**: How should we structure property data for efficient querying by location, property type, and price ranges?
2. **AI Integration**: What's the best approach for implementing price assessment algorithms within budget constraints?
3. **Web Scraping**: Technical architecture for ethical, scalable web scraping with proper rate limiting and error handling?
4. **Real-time Updates**: How to keep market data current without excessive infrastructure costs?
5. **Mobile Responsiveness**: Ensuring the web application works well across devices without native app development?

## Expected Deliverables
Please provide your architectural plan in a format suitable for handoff to the Software Engineer Agent, including:
- Detailed system architecture diagrams
- Technology stack justification with cost analysis
- Database schema recommendations
- API endpoint specifications
- Development roadmap with technical milestones
- Infrastructure setup guide
- Security and compliance checklist

Your architectural decisions should prioritize rapid MVP development while maintaining scalability for future growth, all within the specified budget constraints.


# Product Requirements for Software Engineer Agent

## Product Overview

**Product Name**: Fair Rent Advisor  
**Mission**: Build an AI-powered web platform that helps London renters instantly assess rental price fairness and provides negotiation guidance.

**Development Context**:
- MVP budget under £1000
- Team: AI agents + human product manager
- Timeline: Rapid MVP development prioritized
- Starting from scratch with no existing codebase

## Implementation Requirements

### Core Application Features

#### 1. Property Assessment Engine (HIGHEST PRIORITY)
**User Workflow**: User inputs property details → System provides instant fairness assessment

**Frontend Requirements**:
- Clean, responsive web interface following provided UI mockups
- Property input form with fields: postcode, bedrooms, monthly rent, property type
- Real-time validation and user feedback
- Assessment results page showing fairness rating with confidence percentage
- Comparable properties display with key details and pricing

**Backend Requirements**:
- RESTful API endpoints for property assessment
- Property data storage and retrieval system
- Market analysis algorithms comparing property against local data
- Response time optimization (< 10 seconds for assessments)

**Specific Implementation**:
```
POST /api/assess-property
{
  "postcode": "SW1A 1AA",
  "bedrooms": 2,
  "monthlyRent": 2500,
  "propertyType": "flat"
}

Response:
{
  "assessment": "overpriced",
  "confidence": 87,
  "marketAverage": 2150,
  "fairPrice": 2200,
  "reasoning": "£350 above area average",
  "comparableProperties": [...],
  "negotiationOpportunity": true
}
```

#### 2. Area Market Analysis (HIGH PRIORITY)
**Purpose**: Provide comprehensive market intelligence for specific postcodes

**Frontend Requirements**:
- Interactive area analysis dashboard
- Market statistics display (average rent, price ranges, trends)
- Transport premium visualization
- Area insights and highlights

**Backend Requirements**:
- Postcode-based market data aggregation
- Transport API integration for station proximity and journey times
- Price trend calculations and historical data analysis
- Area-specific insights generation

#### 3. Negotiation Support Tools (MEDIUM PRIORITY)
**Purpose**: Practical tools to help users negotiate better rental prices

**Frontend Requirements**:
- Negotiation strategy display with recommended prices
- Evidence package generation (downloadable market report)
- Negotiation script templates and guidance
- Success probability indicators

**Backend Requirements**:
- Negotiation recommendation algorithms
- Market evidence report generation (PDF)
- Template script management system
- Success probability calculations based on market over-pricing levels

#### 4. Data Collection Pipeline (CRITICAL INFRASTRUCTURE)
**Purpose**: Automated system for gathering and processing rental market data

**Implementation Requirements**:
- Web scraping system for major UK property sites (Rightmove, Zoopla, SpareRoom)
- Government data integration (Land Registry, local authority data)
- Data cleaning and normalization pipelines
- Automated daily data refresh processes

**Technical Specifications**:
- Respectful scraping with rate limiting (1 request per 2-3 seconds)
- Robot.txt compliance and proper headers
- Error handling and retry mechanisms
- Data validation and duplicate detection

### Technical Architecture Implementation

#### Database Schema Design
**Properties Table**:
```sql
CREATE TABLE properties (
    id UUID PRIMARY KEY,
    postcode VARCHAR(10) NOT NULL,
    bedrooms INTEGER,
    property_type VARCHAR(50),
    monthly_rent INTEGER,
    listing_url TEXT,
    description TEXT,
    available_date DATE,
    created_at TIMESTAMP,
    updated_at TIMESTAMP,
    INDEX idx_postcode_bedrooms (postcode, bedrooms),
    INDEX idx_rent_range (monthly_rent)
);
```

**Market_Analysis Table**:
```sql
CREATE TABLE market_analysis (
    id UUID PRIMARY KEY,
    postcode VARCHAR(10),
    property_type VARCHAR(50),
    bedrooms INTEGER,
    average_rent INTEGER,
    median_rent INTEGER,
    min_rent INTEGER,
    max_rent INTEGER,
    sample_size INTEGER,
    analysis_date DATE,
    INDEX idx_postcode_analysis (postcode, analysis_date)
);
```

#### API Endpoint Specifications

**Core Endpoints**:
- `POST /api/assess-property` - Property fairness assessment
- `GET /api/market-analysis/{postcode}` - Area market intelligence
- `GET /api/comparable-properties` - Similar property search
- `POST /api/negotiation-kit` - Generate negotiation materials
- `GET /api/transport-analysis/{postcode}` - Transport premium analysis

#### Frontend Framework Implementation
- Responsive web application using React.js or Vue.js
- Mobile-first design following provided UI mockups
- Component-based architecture for reusability
- State management for user inputs and assessment results
- Progressive Web App (PWA) capabilities for mobile experience

### Data Processing & AI Integration

#### Property Analysis Algorithm
```python
def assess_property_fairness(property_data, market_data):
    # Compare against local market averages
    market_avg = calculate_market_average(
        postcode=property_data.postcode,
        bedrooms=property_data.bedrooms,
        property_type=property_data.property_type
    )
    
    # Factor in transport premiums
    transport_premium = calculate_transport_premium(property_data.postcode)
    
    # Generate assessment
    fair_price = market_avg + transport_premium
    variance = (property_data.rent - fair_price) / fair_price
    
    if variance > 0.15:
        return "overpriced"
    elif variance < -0.10:
        return "good_deal"
    else:
        return "fair"
```

#### Market Data Processing
- Daily ETL pipeline for new property listings
- Automated market average calculations by postcode
- Transport data integration (TfL API for London)
- Price trend analysis and historical data management

### Development Implementation Plan

#### Week 1-2: Foundation Setup
- Project structure and development environment
- Database schema implementation
- Basic API framework setup
- Core data models and relationships

#### Week 3-4: Core Assessment Engine
- Property assessment algorithm implementation
- Market data processing pipeline
- Basic frontend interface with property input form
- API integration for property assessment

#### Week 5-6: Data Collection Pipeline
- Web scraping implementation for property sites
- Data cleaning and validation processes
- Automated data refresh scheduling
- Market analysis calculation engine

#### Week 7-8: Frontend Development
- Complete UI implementation following mockups
- Assessment results visualization
- Market analysis dashboard
- Responsive design and mobile optimization

#### Week 9-10: Negotiation Tools
- Negotiation recommendation algorithms
- Market evidence report generation
- Template management system
- User guidance and script generation

#### Week 11-12: Testing & Deployment
- Comprehensive testing suite
- Performance optimization
- Production deployment setup
- Monitoring and error tracking implementation

### Technical Constraints & Considerations

#### Budget Optimization
- Utilize free tier cloud services (AWS, GCP, Heroku)
- Open source libraries and frameworks
- Efficient database queries to minimize compute costs
- Caching strategies for frequently accessed data

#### Legal & Ethical Compliance
- Respectful web scraping practices
- GDPR-compliant data handling
- Clear terms of service and privacy policy
- Proper attribution for data sources

#### Performance Requirements
- Property assessment response time < 10 seconds
- Database query optimization for postcode-based searches
- Efficient caching for market data and comparable properties
- Graceful error handling and user feedback

#### Scalability Considerations
- Database indexing strategy for performance
- API rate limiting and request handling
- Modular architecture for future feature additions
- Efficient data storage and retrieval patterns

### Quality Assurance Integration Points

The implementation should include:
- Unit tests for all core algorithms
- Integration tests for API endpoints
- End-to-end testing for user workflows
- Performance testing for data processing pipelines
- Security testing for data handling and API security

### Expected Deliverables

1. **Complete Application Codebase**:
   - Frontend application with responsive design
   - Backend API with all specified endpoints
   - Database schema and migrations
   - Data processing and analysis pipelines

2. **Documentation**:
   - API documentation with endpoint specifications
   - Database schema documentation
   - Deployment and setup instructions
   - Code structure and architecture overview

3. **Testing Suite**:
   - Comprehensive test coverage for core functionality
   - Performance benchmarks and optimization reports
   - Security assessment and compliance verification

4. **Deployment Package**:
   - Production-ready deployment configuration
   - Environment setup and configuration files
   - Monitoring and logging implementation
   - Backup and recovery procedures

## Reference Materials
- **UI Mockups**: Complete interface designs showing all user workflows
- **Architecture Specifications**: System architecture from Architecture Agent
- **User Stories**: Detailed acceptance criteria for all features

Please implement this system with focus on rapid MVP delivery while maintaining code quality and scalability for future enhancements. Prioritize core property assessment functionality first, then build supporting features incrementally.



# Product Requirements for QA Engineer Agent

## Product Overview

**Product Name**: Fair Rent Advisor  
**Quality Mission**: Ensure a reliable, accurate, and user-friendly AI-powered platform that London renters can trust for rental price assessments and negotiation guidance.

**Quality Context**:
- MVP launch with limited budget requires efficient testing strategies
- Social impact focus means accuracy and user trust are critical
- AI-powered assessments must be reliable and explainable
- Web scraping and data accuracy are fundamental to product value

## Testing Scope & Priorities

### Critical Quality Areas (HIGHEST PRIORITY)

#### 1. Property Assessment Accuracy
**Why Critical**: Core value proposition - users must trust our price assessments

**Testing Requirements**:
- **Algorithm Validation**: Verify assessment accuracy against known market data
- **Edge Case Testing**: Test with extreme price points, unusual postcodes, rare property types
- **Confidence Level Verification**: Ensure confidence percentages align with actual accuracy
- **Market Comparison Logic**: Validate comparable property selection algorithms

**Specific Test Scenarios**:
```
Test Case: Overpriced Property Assessment
- Input: SW1A 1AA, 2-bed flat, £3000/month
- Expected: "Overpriced" rating with 80%+ confidence
- Validation: Compare against real market data for verification

Test Case: Edge Postcode Handling
- Input: Unusual postcodes (e.g., EC4Y, WC2H)
- Expected: Graceful handling with appropriate confidence adjustment
- Validation: System doesn't crash, provides reasonable assessment
```

#### 2. Data Quality & Integrity
**Why Critical**: Unreliable data leads to inaccurate assessments and user distrust

**Testing Requirements**:
- **Data Collection Validation**: Verify web scraping accuracy and completeness
- **Data Freshness Testing**: Ensure market data updates properly and timely
- **Duplicate Detection**: Confirm system handles duplicate property listings
- **Data Sanitization**: Test data cleaning processes for consistency

**Quality Metrics to Monitor**:
- Data collection success rate (target: 95%+)
- Data accuracy against source sites (spot-check validation)
- Market average calculation precision
- Property matching algorithm effectiveness

#### 3. User Experience & Interface
**Why Critical**: Complex rental decisions require clear, trustworthy interface

**Testing Requirements**:
- **Cross-browser Compatibility**: Test on Chrome, Firefox, Safari, Edge
- **Mobile Responsiveness**: Ensure UI mockups translate to functional mobile experience
- **Form Validation**: Test all input scenarios and error handling
- **Performance Testing**: Verify 10-second assessment response time

### Comprehensive Testing Strategy

#### Functional Testing Plan

**1. Property Assessment Workflow**
```
Test Suite: Core Assessment Flow
├── Valid Input Processing
│   ├── Standard postcodes (SW1A, E1, N1, etc.)
│   ├── All property types (flat, house, studio, shared)
│   ├── All bedroom counts (studio through 4+)
│   └── Rent ranges (£500-£5000+)
├── Invalid Input Handling
│   ├── Invalid postcodes
│   ├── Negative rent amounts
│   ├── Missing required fields
│   └── Special characters in inputs
└── Assessment Result Validation
    ├── Assessment category accuracy
    ├── Confidence level reasonableness
    ├── Market comparison data quality
    └── Comparable properties relevance
```

**2. Market Analysis Features**
```
Test Suite: Area Market Intelligence
├── Postcode Analysis
│   ├── Market average calculations
│   ├── Price range accuracy
│   ├── Trend analysis (3-month data)
│   └── Sample size sufficiency
├── Transport Premium Analysis
│   ├── Station proximity accuracy
│   ├── Journey time calculations
│   ├── Premium calculation logic
│   └── Multi-station handling
└── Area Insights Generation
    ├── Insight relevance and accuracy
    ├── Data source attribution
    └── Update frequency validation
```

**3. Negotiation Support Tools**
```
Test Suite: Negotiation Guidance
├── Negotiation Recommendations
│   ├── Counter-offer calculation accuracy
│   ├── Success probability modeling
│   ├── Strategy appropriateness
│   └── Market evidence compilation
├── Evidence Package Generation
│   ├── PDF generation functionality
│   ├── Data accuracy in reports
│   ├── Comparable property inclusion
│   └── Professional presentation quality
└── Script Template System
    ├── Template relevance to situation
    ├── Customization accuracy
    └── Professional tone maintenance
```

#### Performance Testing Requirements

**Response Time Targets**:
- Property assessment: < 10 seconds (95th percentile)
- Market analysis: < 5 seconds
- Comparable property search: < 8 seconds
- Evidence report generation: < 15 seconds

**Load Testing Scenarios**:
- Concurrent user testing (100+ simultaneous assessments)
- Database query performance under load
- Data processing pipeline stress testing
- Web scraping rate limit compliance

**Performance Test Cases**:
```
Load Test: Peak Usage Simulation
- Scenario: 200 concurrent property assessments
- Duration: 30 minutes sustained load
- Success Criteria: 
  * 95% of requests complete within SLA
  * No system errors or crashes
  * Database performance remains stable
  * Response times meet targets
```

#### Data Quality Assurance

**Web Scraping Validation**:
```
Data Quality Test Suite
├── Source Site Monitoring
│   ├── Scraping success rates by site
│   ├── Data format consistency checks
│   ├── Anti-bot detection monitoring
│   └── Rate limit compliance verification
├── Data Accuracy Validation
│   ├── Manual spot-checking (sample size: 50 properties/week)
│   ├── Cross-reference with multiple sources
│   ├── Historical data consistency checks
│   └── Market average calculation verification
└── Data Freshness Testing
    ├── Daily data refresh validation
    ├── Stale data detection and handling
    ├── Market trend accuracy over time
    └── Property availability status updates
```

**Market Analysis Accuracy**:
- Validate market averages against government data sources
- Cross-check transport data with TfL APIs
- Verify area boundary definitions and postal code mappings
- Test edge cases (new developments, unusual property types)

#### Security & Compliance Testing

**Data Protection (GDPR) Compliance**:
- User data handling and storage validation
- Data retention policy enforcement
- User consent and privacy controls
- Data export and deletion capabilities

**Web Scraping Ethics & Legal Compliance**:
- Robots.txt compliance verification
- Rate limiting enforcement testing
- Terms of service adherence validation
- Proper attribution and data source credits

**API Security Testing**:
- Input validation and sanitization
- Rate limiting effectiveness
- Error message information leakage
- Authentication and authorization (future features)

#### Browser & Device Compatibility

**Cross-Platform Testing Matrix**:
```
Device/Browser Test Coverage
├── Desktop Browsers
│   ├── Chrome (latest 3 versions)
│   ├── Firefox (latest 3 versions)
│   ├── Safari (latest 2 versions)
│   └── Edge (latest 2 versions)
├── Mobile Devices
│   ├── iOS Safari (iPhone 12+, iPad)
│   ├── Android Chrome (Samsung, Google Pixel)
│   └── Responsive design breakpoints
└── Accessibility Testing
    ├── Screen reader compatibility
    ├── Keyboard navigation
    ├── Color contrast validation
    └── WCAG 2.1 compliance
```

#### User Acceptance Testing (UAT)

**Real User Scenario Testing**:
```
UAT Test Scenarios
├── First-Time User Journey
│   ├── Landing page comprehension
│   ├── Property input ease and clarity
│   ├── Assessment result understanding
│   └── Negotiation guidance usability
├── Expert User Validation
│   ├── Real estate professional feedback
│   ├── Market data accuracy verification
│   ├── Negotiation strategy validation
│   └── Industry best practice compliance
└── Target Demographic Testing
    ├── Young professionals (25-35)
    ├── International newcomers
    ├── First-time renters
    └── Mobile-first users
```

### Test Automation Strategy

#### Automated Test Coverage
- **Unit Tests**: 90%+ coverage for core algorithms and business logic
- **Integration Tests**: All API endpoints and database interactions
- **End-to-End Tests**: Critical user workflows and assessment processes
- **Performance Tests**: Automated response time and load monitoring

#### Continuous Quality Monitoring
```python
# Example: Automated Assessment Accuracy Monitoring
def daily_accuracy_check():
    """
    Daily automated test using known market data
    """
    test_properties = get_validation_dataset()
    accuracy_scores = []
    
    for property_data in test_properties:
        assessment = assess_property(property_data)
        expected = property_data.known_assessment
        accuracy_scores.append(calculate_accuracy(assessment, expected))
    
    overall_accuracy = mean(accuracy_scores)
    if overall_accuracy < 0.85:
        alert_team("Assessment accuracy below threshold")
    
    log_quality_metrics(overall_accuracy, accuracy_scores)
```

### Quality Metrics & Reporting

#### Key Performance Indicators (KPIs)
- **Assessment Accuracy**: 85%+ against validation dataset
- **User Satisfaction**: 4.0+ rating on assessment helpfulness
- **System Reliability**: 99%+ uptime during business hours
- **Data Freshness**: 95%+ of market data updated within 24 hours

#### Quality Dashboard Requirements
- Real-time system health monitoring
- Assessment accuracy trends over time
- User feedback and satisfaction scores
- Data quality metrics and alerts
- Performance benchmarks and SLA compliance

### Risk Assessment & Mitigation

#### High-Risk Areas for Testing Focus
1. **Data Source Dependencies**: Property sites changing structure/blocking access
2. **Algorithm Accuracy**: Market conditions changing, affecting assessment reliability
3. **User Trust**: Inaccurate assessments damaging platform credibility
4. **Legal Compliance**: Web scraping practices violating terms of service

#### Quality Assurance Escalation Procedures
- Critical bugs: Immediate escalation to development team
- Data accuracy issues: Daily monitoring with weekly review cycles
- Performance degradation: Automated alerts with 4-hour response SLA
- User complaints: Weekly analysis with monthly trend reporting

### Testing Deliverables

#### Test Documentation
1. **Comprehensive Test Plan**: Detailed testing strategy and approach
2. **Test Case Repository**: Organized test cases with expected results
3. **Test Automation Suite**: Automated testing framework and scripts
4. **Quality Metrics Dashboard**: Real-time quality monitoring and reporting

#### Quality Reports
1. **Daily Quality Summary**: Automated system health and accuracy reports
2. **Weekly Test Execution Report**: Test coverage, pass/fail rates, identified issues
3. **Monthly Quality Assessment**: Trend analysis, improvement recommendations
4. **Release Quality Gate**: Go/no-go recommendations for feature releases

## Integration with Development Process

### Quality Gates for MVP Release
- [ ] Core assessment algorithm accuracy > 85%
- [ ] All critical user workflows tested and validated
- [ ] Cross-browser compatibility verified
- [ ] Performance benchmarks met
- [ ] Data quality processes validated
- [ ] Security and compliance requirements satisfied

### Ongoing Quality Assurance
- Daily automated test execution and reporting
- Weekly manual testing of new features and edge cases
- Monthly user experience and accuracy validation
- Quarterly comprehensive system quality review

## Success Criteria

The QA process is successful when:
- Users can trust and rely on property assessments
- System performance meets user expectations consistently
- Data quality maintains high standards over time
- Platform scales reliably as user base grows
- Compliance and legal requirements are continuously met

Your testing approach should balance comprehensive coverage with efficient resource utilization, focusing on the areas most critical to user trust and platform success.


## Summary

I've successfully transformed your Fair Rent Advisor idea into a comprehensive MVP plan with the following deliverables:

### ✅ **Complete MVP Breakdown**
- **4 Epics** with detailed user stories and acceptance criteria
- **Clear prioritization** focusing on core property assessment first
- **Success metrics** and out-of-scope items for future iterations

### ✅ **UI Mockups Created**
Functional mockups demonstrating:
- Property assessment workflow with real-time feedback
- Results display with fairness ratings and comparable properties
- Area market analysis with transport premiums
- Negotiation support tools with evidence packages
- User dashboard for future enhancements

### ✅ **Three Comprehensive Agent Handoff Prompts**

1. **Architecture Agent Prompt**: System design, technology stack, scalability, and infrastructure recommendations
2. **Software Engineer Prompt**: Detailed implementation requirements, code specifications, database schemas, and development roadmap
3. **QA Engineer Prompt**: Comprehensive testing strategy, quality assurance processes, and performance validation

### **Key Strengths of This MVP Plan:**
- **Budget-Conscious**: Designed specifically for under £1000 development cost
- **User-Focused**: Addresses real pain points with clear value proposition
- **Technically Feasible**: Realistic scope using AI agents and available data sources
- **Scalable Foundation**: Architecture supports future growth beyond London

### **Next Steps:**
1. Review and approve this MVP breakdown
2. Share the Architecture Agent prompt to get system design recommendations
3. Use the Architecture output to inform the Software Engineer implementation
4. Implement QA processes throughout development

The plan balances ambitious social impact goals with practical technical constraints, providing a clear roadmap for building a platform that can genuinely help London renters avoid rental exploitation while staying within budget.

Would you like me to modify any aspects of this plan before proceeding to the Architecture Agent?
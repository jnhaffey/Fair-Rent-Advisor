#!/bin/bash
# Fair Rent Advisor - Local Development Environment Startup Script

echo "🚀 Starting Fair Rent Advisor local development environment..."

# Start emulators
echo "📦 Starting Docker emulators (Cosmos DB, Redis, Azurite)..."
docker-compose up -d

# Wait for emulators to be ready
echo "⏳ Waiting for emulators to initialize..."
sleep 10

# Check if emulators are running
echo "🔍 Checking emulator status..."
docker ps --format "table {{.Names}}\t{{.Status}}\t{{.Ports}}" | grep -E "(cosmos|redis|azurite)"

echo ""
echo "🌐 Emulator URLs:"
echo "  - Cosmos DB Explorer: http://localhost:8081/_explorer/index.html"
echo "  - Redis: localhost:6379"
echo "  - Azurite Blob: http://localhost:10000"
echo ""

echo "🔧 To start the API (in another terminal):"
echo "  cd src/FairRentAdvisor.Api && func start"
echo ""
echo "🎨 To start the Web app (in another terminal):"
echo "  cd src/FairRentAdvisor.Web && npm run dev"
echo ""
echo "✅ Local development environment is ready!"
echo "   Use 'docker-compose down' to stop emulators when done."

#!/bin/bash
# Fair Rent Advisor - Complete Build Script

echo "🔨 Building Fair Rent Advisor solution..."

# Build .NET solution
echo "🏗️ Building .NET solution..."
dotnet build

if [ $? -ne 0 ]; then
    echo "❌ .NET build failed!"
    exit 1
fi

# Build React frontend
echo "🎨 Building React frontend..."
cd src/FairRentAdvisor.Web

# Install dependencies if node_modules doesn't exist
if [ ! -d "node_modules" ]; then
    echo "📦 Installing npm dependencies..."
    npm install
fi

# Build frontend
npm run build

if [ $? -ne 0 ]; then
    echo "❌ Frontend build failed!"
    exit 1
fi

# Return to root
cd ../..

echo ""
echo "✅ Build complete!"
echo ""
echo "📁 Build outputs:"
echo "   - .NET: src/*/bin/Debug/net8.0/"
echo "   - React: src/FairRentAdvisor.Web/dist/"
echo ""
echo "🚀 Ready to run:"
echo "   - API: cd src/FairRentAdvisor.Api && func start"
echo "   - Web: cd src/FairRentAdvisor.Web && npm run preview"

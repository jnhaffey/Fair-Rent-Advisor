@echo off
REM Fair Rent Advisor - Complete Build Script (Windows)

echo 🔨 Building Fair Rent Advisor solution...

REM Build .NET solution
echo 🏗️ Building .NET solution...
dotnet build

if %ERRORLEVEL% NEQ 0 (
    echo ❌ .NET build failed!
    exit /b 1
)

REM Build React frontend
echo 🎨 Building React frontend...
cd src\FairRentAdvisor.Web

REM Install dependencies if node_modules doesn't exist
if not exist "node_modules" (
    echo 📦 Installing npm dependencies...
    npm install
)

REM Build frontend
npm run build

if %ERRORLEVEL% NEQ 0 (
    echo ❌ Frontend build failed!
    exit /b 1
)

REM Return to root
cd ..\..

echo.
echo ✅ Build complete!
echo.
echo 📁 Build outputs:
echo    - .NET: src/*/bin/Debug/net8.0/
echo    - React: src/FairRentAdvisor.Web/dist/
echo.
echo 🚀 Ready to run:
echo    - API: cd src/FairRentAdvisor.Api ^&^& func start
echo    - Web: cd src/FairRentAdvisor.Web ^&^& npm run preview
pause

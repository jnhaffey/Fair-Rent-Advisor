@echo off
REM Fair Rent Advisor - Test Execution with Coverage Script (Windows)

echo 🧪 Running Fair Rent Advisor tests with coverage...

REM Clean previous test results
echo 🧹 Cleaning previous test results...
for /d /r . %%d in (TestResults) do @if exist "%%d" rd /s /q "%%d" 2>nul

REM Run tests with coverage
echo 🔍 Executing tests with coverage collection...
dotnet test --verbosity normal --collect:"XPlat Code Coverage" --logger "console;verbosity=detailed"

if %ERRORLEVEL% EQU 0 (
    echo.
    echo ✅ All tests passed!
    
    REM Find and display coverage files
    echo.
    echo 📊 Coverage reports generated:
    for /r . %%f in (coverage.cobertura.xml) do echo   - %%f
    
    echo.
    echo 💡 To view detailed coverage:
    echo    Install: dotnet tool install -g dotnet-reportgenerator-globaltool
    echo    Generate: reportgenerator -reports:**/coverage.cobertura.xml -targetdir:coverage-report
    echo    Open: coverage-report/index.html
) else (
    echo.
    echo ❌ Tests failed! Check output above for details.
    exit /b 1
)

echo.
echo 🎯 Coverage targets:
echo    - Value Objects: 95%+ (current target achieved)
echo    - Overall: 90%+ line coverage
pause

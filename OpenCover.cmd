@echo off

rd /s /q %~dp0\OpenCover
md OpenCover

REM OpenCover
"%~dp0\src\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe" ^
-register:user ^
-target:"%VS140COMNTOOLS%\..\IDE\mstest.exe" ^
-targetargs:"/testcontainer:\"%~dp0\src\AnyStatus.API.Tests\bin\Debug\AnyStatus.API.Tests.dll\" /resultsfile:\"%~dp0\OpenCover\AnyStatus.API.trx\"" ^
-filter:"+[AnyStatus*]* -[AnyStatus.API.Tests]*" ^
-mergebyhash ^
-skipautoprops ^
-excludebyattribute:*.ExcludeFromCodeCoverage* ^
-hideskipped:attribute ^
-output:"%~dp0\OpenCover\Coverage.xml"

REM Report Generator
"%~dp0\src\packages\ReportGenerator.2.5.11\tools\ReportGenerator.exe" ^
-reports:"%~dp0\OpenCover\Coverage.xml" ^
-targetdir:"%~dp0\OpenCover\Report"

start "" "%~dp0\OpenCover\Report\index.htm"

::pause
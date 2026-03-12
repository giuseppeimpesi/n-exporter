@echo off

IF EXIST "%~dp0NExporter.Core\bin" @RD /S /Q "%~dp0NExporter.Core\bin"
IF EXIST "%~dp0NExporter.Core\obj" @RD /S /Q "%~dp0NExporter.Core\obj"

IF EXIST "%~dp0NExporter.Models\bin" @RD /S /Q "%~dp0NExporter.Models\bin"
IF EXIST "%~dp0NExporter.Models\obj" @RD /S /Q "%~dp0NExporter.Models\obj"

IF EXIST "%~dp0NExporter.TemplateReader\bin" @RD /S /Q "%~dp0NExporter.TemplateReader\bin"
IF EXIST "%~dp0NExporter.TemplateReader\obj" @RD /S /Q "%~dp0NExporter.TemplateReader\obj"

exit
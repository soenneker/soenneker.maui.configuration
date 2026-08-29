[![](https://img.shields.io/nuget/v/soenneker.maui.configuration.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.maui.configuration/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.maui.configuration/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.maui.configuration/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.maui.configuration.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.maui.configuration/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.maui.configuration/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.maui.configuration/actions/workflows/codeql.yml)

# Soenneker.Maui.Configuration

A utility library for MAUI configuration related operations.

## Install

```bash
dotnet add package Soenneker.Maui.Configuration
```

## Quick start

```csharp
using Soenneker.Maui.Configuration;

var result = MauiConfigurationUtil.Load(true);
```

Loads the application configuration from JSON files (appsettings.json, appsettings.debug.json, appsettings.release.json).

## What you get

- `MauiConfigurationUtil` — A utility library for MAUI configuration related operations.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `MauiConfigurationUtil.Load(isDebug)` | Loads the application configuration from JSON files (appsettings.json, appsettings.debug.json, appsettings.release.json). | An `IConfiguration` instance. |

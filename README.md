# Soenneker.Maui.Configuration
[![](https://img.shields.io/nuget/v/soenneker.maui.configuration.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.maui.configuration/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.maui.configuration/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.maui.configuration/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.maui.configuration.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.maui.configuration/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.maui.configuration/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.maui.configuration/actions/workflows/codeql.yml)

Builds .NET configuration from JSON files packaged with a .NET MAUI application.

## Installation

```bash
dotnet add package Soenneker.Maui.Configuration
```

## Package the settings files

Add the files to the MAUI app project with the logical names the loader expects:

```xml
<ItemGroup>
  <MauiAsset Include="appsettings.json" LogicalName="appsettings.json" />
  <MauiAsset Include="appsettings.debug.json" LogicalName="appsettings.debug.json" />
  <MauiAsset Include="appsettings.release.json" LogicalName="appsettings.release.json" />
</ItemGroup>
```

Files under `Resources/Raw` are already treated as MAUI assets; keep their logical names at the package root if you use that convention.

## Load configuration

Call the loader while constructing the MAUI app, then add the result to the builder configuration:

```csharp
using Soenneker.Maui.Configuration;

#if DEBUG
bool useDebugSettings = true;
#else
bool useDebugSettings = false;
#endif

IConfiguration packagedConfiguration = MauiConfigurationUtil.Load(useDebugSettings);
builder.Configuration.AddConfiguration(packagedConfiguration);
```

The loader reads `appsettings.json` first. It then reads either `appsettings.debug.json` or `appsettings.release.json`, whose values override matching base values. Missing files are skipped; malformed JSON and other read failures are surfaced to the caller.

The returned configuration is an in-memory snapshot. It does not watch for changes and does not read from the app's writable data directory.

Packaged JSON is extractable from the application bundle. Do not store API keys, passwords, or other secrets in these files.

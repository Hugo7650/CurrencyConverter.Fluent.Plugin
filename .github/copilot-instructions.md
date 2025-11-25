# Copilot Instructions for CurrencyConverter.Fluent.Plugin

## Project Overview
This is a **Fluent Search plugin** that provides real-time currency conversion using the [currency-api](https://latest.currency-api.pages.dev/). Built on the Blast.API framework for Fluent Search integration.

## Architecture

### Core Components
| File | Purpose |
|------|---------|
| `CurrencyConversionSearchApp.cs` | Main plugin entry point, implements `ISearchApplication` interface |
| `CurrencyConversionSearchResult.cs` | Search result model extending `SearchResultBase` |
| `CurrencyConversionSearchOperation.cs` | Defines operations (Copy, OpenWebsite, ConvertToOther) |
| `CurrencyConverterSearchAppSettings.cs` | Settings UI using Blast.API `[Setting]` attributes |
| `LanguageManager.cs` | Singleton for i18n, loads translations from embedded resources |
| `CurrencyApiResponse.cs` | API response deserialization with `[JsonExtensionData]` |

### Data Flow
```
User Query → Regex Parse → API Call → Exchange Rate Lookup → Result Generation
"100 USD to EUR" → (100, USD, EUR) → currency-api → rate → CurrencyConversionSearchResult
```

## Key Patterns

### Blast.API Integration
- Implement `ISearchApplication` for the main search app
- Use `SearchResultBase` for results, `SearchOperationBase` for operations
- Settings use `[Setting]` attribute with custom `SettingManagerType` classes
- Operations are defined as static singletons: `CurrencyConversionSearchOperation.OpenExchangeRateOperation`

### Search Query Pattern
The regex pattern `^(\d+(?:\.\d+)?)\s*([a-z]{3})\s*(?:to|in)\s*([a-z]{3})$` accepts:
- `100 USD to EUR`
- `50.5 gbp in jpy`

### Localization System
- Language files: `langs/{language_code}.json` as embedded resources
- Currency codes map to localized names (e.g., `"USD": "US Dollar"`)
- `LanguageManager.Instance.GetCurrencyName(code)` for translations
- Auto-detects system language, falls back to English

### Adding New Languages
1. Create `langs/{code}.json` with currency code → name mappings
2. Add language to `_supportedLanguages` dictionary in `LanguageManager.cs`
3. Files are automatically embedded via `<EmbeddedResource Include="langs\*.json" />`

## Build & Development

### Commands
```powershell
# Build
dotnet build

# Publish for deployment
dotnet publish -c Release -r win10-x64

# Run tests (if added)
dotnet test
```

### Target Framework
- .NET 9.0 with nullable enabled
- Main dependency: `Blast.API 1.0.1.4-beta`

### Plugin Installation
Copy published output to Fluent Search plugins directory. Configure via `pluginsInfo.json`.

## Code Conventions
- Use `HashSet<string>` with `StringComparer.OrdinalIgnoreCase` for currency code lookups
- API calls use 5-second timeout: `httpClient.Timeout = TimeSpan.FromSeconds(5)`
- Always use `CancellationToken` for async search operations
- Currency codes stored as uppercase internally, lowercase for API calls
- Prefer `IAsyncEnumerable<ISearchResult>` for streaming results

## External API
- Endpoint: `https://latest.currency-api.pages.dev/v1/currencies/{currency}.json`
- No authentication required
- Response contains exchange rates keyed by currency code (lowercase)

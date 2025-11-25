# Currency Converter - Fluent Search Plugin

[![.NET 9.0](https://img.shields.io/badge/.NET-9.0-512BD4)](https://dotnet.microsoft.com/)
[![Fluent Search](https://img.shields.io/badge/Fluent%20Search-Plugin-blue)](https://fluentsearch.net/)
[![License](https://img.shields.io/badge/license-MIT-green.svg)](LICENSE)

A **Fluent Search plugin** that provides real-time currency conversion using live exchange rates. Convert between 300+ currencies and cryptocurrencies directly from your search bar.

![Currency Converter Demo](https://img.shields.io/badge/demo-currency%20conversion-orange)

## ✨ Features

- 🌍 **300+ Currencies** - Support for fiat currencies and cryptocurrencies (BTC, ETH, etc.)
- 💱 **Real-time Exchange Rates** - Powered by [currency-api](https://latest.currency-api.pages.dev/)
- 🌐 **20 Languages** - Localized currency names in multiple languages
- ⚡ **Fast & Lightweight** - Quick search with minimal resource usage
- ⚙️ **Customizable** - Configure popular currencies for quick conversion
- 📋 **Copy Results** - One-click copy to clipboard
- 🔗 **External Links** - Open detailed exchange rates on xe.com

## 📦 Installation

### Prerequisites

- [Fluent Search](https://fluentsearch.net/) installed on Windows
- Windows 10/11

### Steps

1. Download the latest release from the [Releases](https://github.com/yourusername/CurrencyConverter.Fluent.Plugin/releases) page
2. Extract the files to your Fluent Search plugins directory:
   ```
   %APPDATA%\Blast\FluentSearch\Plugins\CurrencyConverter
   ```
3. Restart Fluent Search
4. The plugin will be automatically detected and enabled

## 🚀 Usage

Simply type your conversion query in Fluent Search using one of these formats:

```
100 USD to EUR
50.5 GBP in JPY
1 BTC to USD
250 EUR to CNY
```

### Supported Query Patterns

| Pattern | Example | Description |
|---------|---------|-------------|
| `{amount} {from} to {to}` | `100 USD to EUR` | Convert amount from one currency to another |
| `{amount} {from} in {to}` | `50 GBP in JPY` | Alternative syntax using "in" |

### Search Tags

You can also use these tags to filter results:
- `currency:`
- `convert:`
- `exchange:`

Example: `currency: 100 USD to EUR`

## 🌐 Supported Languages

The plugin supports localized currency names in the following languages:

| Language | Code | Language | Code |
|----------|------|----------|------|
| English | en | Japanese | ja |
| German | de | Korean | ko |
| Spanish | es | Chinese | zh |
| French | fr | Polish | pl |
| Italian | it | Portuguese | pt |
| Danish | da | Romanian | ro |
| Greek | el | Swedish | sv |
| Finnish | fi | Turkish | tr |
| Lithuanian | lt | Ukrainian | ua |
| Norwegian | nb | Urdu | ur |

## ⚙️ Settings

Access plugin settings through Fluent Search's settings panel:

### Language
Select your preferred language for currency names. The plugin auto-detects your system language on first launch.

### Popular Currencies
Configure a list of frequently used currencies. When you perform a conversion, these currencies will appear as additional quick-convert options.

Default popular currencies:
- USD (US Dollar)
- EUR (Euro)
- GBP (Pound Sterling)
- JPY (Japanese Yen)
- CNY (Chinese Yuan)
- CAD (Canadian Dollar)
- AUD (Australian Dollar)
- CHF (Swiss Franc)

## 🛠️ Building from Source

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Visual Studio 2022 or VS Code

### Build

```powershell
# Clone the repository
git clone https://github.com/hugo7650/CurrencyConverter.Fluent.Plugin.git
cd CurrencyConverter.Fluent.Plugin

# Build the project
dotnet build

# Publish for deployment
dotnet publish -c Release -r win10-x64
```

### Output

The published files will be located in:
```
CurrencyConverter.Fluent.Plugin/bin/Release/net9.0/win10-x64/publish/
```

## 📁 Project Structure

```
CurrencyConverter.Fluent.Plugin/
├── CurrencyConversionSearchApp.cs      # Main plugin entry point
├── CurrencyConversionSearchResult.cs   # Search result model
├── CurrencyConversionSearchOperation.cs # Operations (Copy, OpenWebsite, Convert)
├── CurrencyConverterSearchAppSettings.cs # Settings UI
├── CurrencyApiResponse.cs              # API response model
├── CurrencyItem.cs                     # Currency item model
├── LanguageManager.cs                  # Localization manager
├── pluginsInfo.json                    # Plugin metadata
└── langs/                              # Localization files
    ├── en.json
    ├── zh.json
    └── ... (18 more languages)
```

## 🔌 API

This plugin uses the free [currency-api](https://latest.currency-api.pages.dev/) for exchange rates:

- **Endpoint**: `https://latest.currency-api.pages.dev/v1/currencies/{currency}.json`
- **No authentication required**
- **Rate limits**: None (fair use)
- **Update frequency**: Daily

## 🤝 Contributing

Contributions are welcome! Here's how you can help:

### Adding a New Language

1. Create a new file `langs/{language_code}.json`
2. Add currency code to localized name mappings:
   ```json
   {
       "USD": "美元",
       "EUR": "欧元",
       ...
   }
   ```
3. Add the language to `_supportedLanguages` dictionary in `LanguageManager.cs`
4. Submit a pull request

### Reporting Issues

Please use the [GitHub Issues](https://github.com/hugo7650/CurrencyConverter.Fluent.Plugin/issues) page to report bugs or request features.

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments

- [Fluent Search](https://fluentsearch.net/) - The amazing launcher this plugin is built for
- [currency-api](https://github.com/fawazahmed0/currency-api) - Free currency exchange rate API
- [Blast.API](https://www.nuget.org/packages/Blast.API) - Fluent Search plugin framework

---

Made with ❤️ for the Fluent Search community

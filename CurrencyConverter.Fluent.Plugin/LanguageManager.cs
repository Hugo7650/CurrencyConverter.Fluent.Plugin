using System.Globalization;
using System.Text.Json;

namespace CurrencyConverter.Fluent.Plugin
{
    public class LanguageManager
    {
        private static readonly Lazy<LanguageManager> _instance = new(() => new LanguageManager());
        public static LanguageManager Instance => _instance.Value;

        private readonly Dictionary<string, Dictionary<string, string>> _translations = new();
        private string _currentLanguage = "en";

        private readonly Dictionary<string, string> _supportedLanguages = new()
        {
            { "en", "English" },
            { "zh", "中文" },
            { "ua", "Українська" },
            { "tr", "Türkçe" },
            { "sv", "Svenska" },
            { "ro", "Română" },
            { "pt", "Português" },
            { "pl", "Polski" },
            { "nb", "Norsk" },
            { "lt", "Lietuvių" },
            { "ko", "한국어" },
            { "ja", "日本語" },
            { "it", "Italiano" },
            { "fi", "Suomi" },
            { "el", "Ελληνικά" },
            { "de", "Deutsch" }
        };

        public IReadOnlyDictionary<string, string> SupportedLanguages => _supportedLanguages;
        public string CurrentLanguage => _currentLanguage;

        private LanguageManager()
        {
            LoadTranslations();
            SetLanguageFromSystem();
        }

        private void LoadTranslations()
        {
            var assembly = typeof(LanguageManager).Assembly;
            
            foreach (var language in _supportedLanguages.Keys)
            {
                try
                {
                    var resourceName = $"CurrencyConverter.Fluent.Plugin.langs.{language}.json";
                    using var stream = assembly.GetManifestResourceStream(resourceName);
                    
                    if (stream != null)
                    {
                        using var reader = new StreamReader(stream);
                        var json = reader.ReadToEnd();
                        var translations = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                        
                        if (translations != null)
                        {
                            _translations[language] = translations;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log error and continue with other languages
                    System.Diagnostics.Debug.WriteLine($"Failed to load language {language}: {ex.Message}");
                }
            }

            // Ensure English is always available as fallback
            if (!_translations.ContainsKey("en"))
            {
                _translations["en"] = new Dictionary<string, string>();
            }
        }

        private void SetLanguageFromSystem()
        {
            try
            {
                var systemLanguage = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToLowerInvariant();
                
                // Special handling for Chinese variants
                if (systemLanguage == "zh" || CultureInfo.CurrentUICulture.Name.StartsWith("zh"))
                {
                    systemLanguage = "zh";
                }
                // Special handling for Norwegian
                else if (systemLanguage == "no" || CultureInfo.CurrentUICulture.Name.StartsWith("nb"))
                {
                    systemLanguage = "nb";
                }

                if (_supportedLanguages.ContainsKey(systemLanguage))
                {
                    _currentLanguage = systemLanguage;
                }
            }
            catch
            {
                // Fall back to English if detection fails
                _currentLanguage = "en";
            }
        }

        public void SetLanguage(string languageCode)
        {
            if (_supportedLanguages.ContainsKey(languageCode))
            {
                _currentLanguage = languageCode;
            }
        }

        public string GetCurrencyName(string currencyCode)
        {
            var upperCode = currencyCode.ToUpperInvariant();
            
            // Try current language first
            if (_translations.TryGetValue(_currentLanguage, out var currentTranslations) &&
                currentTranslations.TryGetValue(upperCode, out var translation))
            {
                return translation;
            }

            // Fall back to English
            if (_currentLanguage != "en" && 
                _translations.TryGetValue("en", out var englishTranslations) &&
                englishTranslations.TryGetValue(upperCode, out var englishTranslation))
            {
                return englishTranslation;
            }

            // Return the currency code if no translation found
            return upperCode;
        }

        public string GetLocalizedText(string key, string fallback = null)
        {
            // This method can be extended for other UI text translations
            return fallback ?? key;
        }
    }
}

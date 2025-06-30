using Microsoft.Extensions.Localization;
using System.Reflection;

namespace StokCore.WebUI.Resources
{
    public class LanguageService
    {
        private readonly IStringLocalizer _stringLocalizer;

        public LanguageService(IStringLocalizerFactory factory)

        {
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _stringLocalizer = factory.Create("SharedResource", assemblyName.Name);
        }

        public LocalizedString GetLocalizeHTML(string key)
        {
            return _stringLocalizer[key];
        }
    }
}

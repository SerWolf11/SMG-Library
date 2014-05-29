using System.Configuration;
using System.Linq;

;
namespace LibKo.SystemConfiguration
{
    public class SystemConfiguration
    {
        private void Configuration()
        {
            var config =
                    System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(
                        new System.Configuration.ExeConfigurationFileMap()
            { ExeConfigFilename = webconfigFile
            },
            System.Configuration.ConfigurationUserLevel.None);
            var oldValue = config.AppSettings.Settings["SomeKey"].Value;
            config.AppSettings.Settings["SomeKey"].Value = "NewValue";
            config.Save(ConfigurationSaveMode.Modified);
        }

        public string webconfigFile { get; set; }
    }
}

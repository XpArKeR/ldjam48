using System;
using System.IO;
using System.Windows.Input;

using Balancer.Commands;
using Balancer.Model.Core;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Balancer.Views.Tabs
{
    public class ConsumptionRatesContext : TabContext<ConsumptionRates>
    {
        private ICommand writeToFileCommand;
        public ICommand WriteToFileCommand
        {
            get
            {
                if (this.writeToFileCommand == default)
                {
                    this.writeToFileCommand = new SimpleCommand(ExecuteWriteToFileCommand);
                }

                return this.writeToFileCommand;
            }
        }

        private String assetSubPath;
        public String AssetSubPath
        {
            get
            {
                if (String.IsNullOrEmpty(this.assetSubPath))
                {
                    this.assetSubPath = Path.Combine("Assets", "StreamingAssets", "Core", "ConsumptionRates.json");
                }

                return this.assetSubPath;
            }
        }

        public override void SetContext(ConsumptionRates context)
        {
            base.SetContext(context);

            if (this.Value != default)
            {
                IsEnabled = true;
            }
        }

        public override System.Boolean Load(System.String baseDirectoryPath)
        {
            base.Load(baseDirectoryPath);

            var isSuccessful = false;

            var consumptionRatesFilenName = Path.Combine(baseDirectoryPath, AssetSubPath);

            if (File.Exists(consumptionRatesFilenName))
            {
                var consumptionRates = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsumptionRates>(File.ReadAllText(consumptionRatesFilenName));

                this.SetContext(consumptionRates);

                isSuccessful = true;
            }

            return isSuccessful;
        }

        private void ExecuteWriteToFileCommand()
        {
            var consumptionRatesFilename = Path.Combine(BasePath, AssetSubPath);

            var consumptionRatesString = JsonConvert.SerializeObject(this.Value, new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                Formatting = Formatting.Indented
            });

            if (!String.IsNullOrEmpty(consumptionRatesString))
            {
                if (File.Exists(consumptionRatesFilename))
                {
                    File.Delete(consumptionRatesFilename);
                }

                File.WriteAllText(consumptionRatesFilename, consumptionRatesString);
            }
        }
    }
}

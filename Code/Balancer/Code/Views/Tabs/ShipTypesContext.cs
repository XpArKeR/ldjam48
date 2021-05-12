using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;

using Balancer.Commands;
using Balancer.Model.Ships;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Balancer.Views.Tabs
{
    public class ShipTypesContext : TabContext<List<ShipType>>
    {
        public Boolean HasSelectedShipType
        {
            get
            {
                return (this.SelectedShipType != default);
            }
        }

        private ShipType selectedShipType;
        public ShipType SelectedShipType
        {
            get
            {
                return this.selectedShipType;
            }
            set
            {
                if (SetProperty(ref this.selectedShipType, value))
                {
                    OnPropertyChanged(nameof(HasSelectedShipType));
                }
            }
        }

        private String assetSubPath;
        public String AssetSubPath
        {
            get
            {
                if (String.IsNullOrEmpty(this.assetSubPath))
                {
                    this.assetSubPath = Path.Combine("Assets", "StreamingAssets", "Ships", "ShipTypes.json");
                }

                return this.assetSubPath;
            }
        }

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

        public override void SetContext(List<ShipType> context)
        {
            base.SetContext(context);

            if (this.Value?.Count > 0)
            {
                IsEnabled = true;
            }
        }

        public override Boolean Load(String baseDirectoryPath)
        {
            base.Load(baseDirectoryPath);
            var isSuccessful = false;

            var shipTypesFileName = Path.Combine(baseDirectoryPath, AssetSubPath);

            if (File.Exists(shipTypesFileName))
            {
                var shipTypes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ShipType>>(File.ReadAllText(shipTypesFileName));

                this.SetContext(shipTypes);

                isSuccessful = true;
            }

            return isSuccessful;
        }

        private void ExecuteWriteToFileCommand()
        {
            var shipTypesFileName = Path.Combine(BasePath, AssetSubPath);

            var shipTypesString = JsonConvert.SerializeObject(this.Value, new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                Formatting = Formatting.Indented
            });

            if (!String.IsNullOrEmpty(shipTypesString))
            {
                if (File.Exists(shipTypesFileName))
                {
                    File.Delete(shipTypesFileName);
                }

                File.WriteAllText(shipTypesFileName, shipTypesString);
            }
        }
    }
}

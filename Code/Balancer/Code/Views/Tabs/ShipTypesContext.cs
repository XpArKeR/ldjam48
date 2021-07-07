using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;

using Balancer.Commands;
using Balancer.Model.Ships;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Balancer.Views.Tabs
{
    public class ShipTypesContext : TabContext<ObservableCollection<ShipType>>
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

        private ICommand removeSelectedShipTypeCommand;
        public ICommand RemoveSelectedShipTypeCommand
        {
            get
            {
                if (this.removeSelectedShipTypeCommand == default)
                {
                    this.removeSelectedShipTypeCommand = new SimpleCommand<ShipType>(CanExecuteRemoveSelectedShipTypeCommand, ExecuteRemoveSelectedShipTypeCommand);
                }

                return this.removeSelectedShipTypeCommand;
            }
        }

        private ICommand duplicateSelectedShipTypeCommand;
        public ICommand DuplicateSelectedShipTypeCommand
        {
            get
            {
                if (this.duplicateSelectedShipTypeCommand == default)
                {
                    this.duplicateSelectedShipTypeCommand = new SimpleCommand<ShipType>(CanDuplicateSelectedShipTypeCommand, ExecuteDuplicateSelectedShipTypeCommand);
                }

                return this.duplicateSelectedShipTypeCommand;
            }
        }

        private ICommand addNewShipTypeCommand;
        public ICommand AddNewShipTypeCommand
        {
            get
            {
                if (this.addNewShipTypeCommand == default)
                {
                    this.addNewShipTypeCommand = new SimpleCommand(ExecuteAddNewShipTypeCommand);
                }

                return this.addNewShipTypeCommand;
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

        public override void SetContext(ObservableCollection<ShipType> context)
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
                var shipTypes = JsonConvert.DeserializeObject<ObservableCollection<ShipType>>(File.ReadAllText(shipTypesFileName));

                this.SetContext(shipTypes);

                isSuccessful = true;
            }

            return isSuccessful;
        }

        private Boolean CanExecuteRemoveSelectedShipTypeCommand(ShipType shipType)
        {
            return (shipType != default);
        }

        private void ExecuteRemoveSelectedShipTypeCommand(ShipType shipType)
        {
            this.Value.Remove(shipType);
        }

        private Boolean CanDuplicateSelectedShipTypeCommand(ShipType shipType)
        {
            return (shipType != default);
        }

        private void ExecuteDuplicateSelectedShipTypeCommand(ShipType shipType)
        {
            var clone = new ShipType()
            {
                Name = String.Format("{0} - Clone", shipType.Name),
                MaxOxygenLevel = shipType.MaxOxygenLevel,
                OxygenLevel = shipType.OxygenLevel,
                OxygenConsumption = shipType.OxygenConsumption,
                MaxFoodLevel = shipType.MaxFoodLevel,
                FoodLevel = shipType.FoodLevel,
                FoodConsumption = shipType.FoodConsumption,
                MaxFuelLevel = shipType.MaxFuelLevel,
                FuelLevel = shipType.FuelLevel,
                FuelConsumption = shipType.FuelConsumption,
            };

            this.Value.Add(clone);
        }

        private void ExecuteAddNewShipTypeCommand()
        {
            this.Value.Add(new ShipType()
            {
                Name = "New Shiptype"
            });
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

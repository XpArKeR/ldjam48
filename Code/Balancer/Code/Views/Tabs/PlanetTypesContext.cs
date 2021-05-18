using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;

using Balancer.Commands;
using Balancer.Extensions;
using Balancer.Model;
using Balancer.Model.Planets;
using Balancer.Views.ResourceSelection;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Balancer.Views.Tabs
{
    public class PlanetTypesContext : TabContext<ObservableCollection<PlanetType>>
    {
        private String planetTypesDefinitionPath;
        public String PlanetTypesDefinitionPath
        {
            get
            {
                if (String.IsNullOrEmpty(this.planetTypesDefinitionPath))
                {
                    this.planetTypesDefinitionPath = Path.Combine("Assets", "StreamingAssets", "Planets", "PlanetTypes.json");
                }

                return this.planetTypesDefinitionPath;
            }
        }

        public Boolean HasSelectedPlanetType
        {
            get
            {
                return (this.SelectedPlanetType != default);
            }
        }

        private PlanetType selectedPlanetType;
        public PlanetType SelectedPlanetType
        {
            get
            {
                return this.selectedPlanetType;
            }
            set
            {
                if (SetProperty(ref this.selectedPlanetType, value))
                {
                    OnPropertyChanged(nameof(HasSelectedPlanetType));
                }
            }
        }

        private Int32 selectedLandResourceIndex = -1;
        public Int32 SelectedLandResourceIndex
        {
            get
            {
                return this.selectedLandResourceIndex;
            }
            set
            {
                SetProperty(ref this.selectedLandResourceIndex, value);
            }
        }

        private Int32 selectedCloudResourceIndex = -1;
        public Int32 SelectedCloudResourceIndex
        {
            get
            {
                return this.selectedCloudResourceIndex;
            }
            set
            {
                SetProperty(ref this.selectedCloudResourceIndex, value);
            }
        }

        private CustomColor selectedPlanetBaseColor;
        public CustomColor SelectedPlanetBaseColor
        {
            get
            {
                return this.selectedPlanetBaseColor;
            }
            set
            {
                SetProperty(ref this.selectedPlanetBaseColor, value);
            }
        }

        private ICommand removeSelectedPlanetTypeCommand;
        public ICommand RemoveSelectedPlanetTypeCommand
        {
            get
            {
                if (this.removeSelectedPlanetTypeCommand == default)
                {
                    this.removeSelectedPlanetTypeCommand = new SimpleCommand<PlanetType>(CanExecuteRemoveSelectedPlanetTypeCommand, ExecuteRemoveSelectedPlanetTypeCommand);
                }

                return this.removeSelectedPlanetTypeCommand;
            }
        }

        private ICommand duplicateSelectedPlanetTypeCommand;
        public ICommand DuplicateSelectedPlanetTypeCommand
        {
            get
            {
                if (this.duplicateSelectedPlanetTypeCommand == default)
                {
                    this.duplicateSelectedPlanetTypeCommand = new SimpleCommand<PlanetType>(CanExecuteDuplicateSelectedPlanetTypeCommand, ExecuteDuplicateSelectedPlanetTypeCommand);
                }

                return this.duplicateSelectedPlanetTypeCommand;
            }
        }

        private ICommand addNewPlanetTypeCommand;
        public ICommand AddNewPlanetTypeCommand
        {
            get
            {
                if (this.addNewPlanetTypeCommand == default)
                {
                    this.addNewPlanetTypeCommand = new SimpleCommand(ExecuteAddNewPlanetTypeCommand);
                }

                return this.addNewPlanetTypeCommand;
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

        private ICommand removeSelectedLandSpriteCommand;
        public ICommand RemoveSelectedLandSpriteCommand
        {
            get
            {
                if (this.removeSelectedLandSpriteCommand == default)
                {
                    this.removeSelectedLandSpriteCommand = new SimpleCommand<Int32>(CanRemoveSelectedIndex, ExecuteRemoveSelectedLandResourceCommand);
                }

                return this.removeSelectedLandSpriteCommand;
            }
        }

        private ICommand removeSelectedCloudSpriteCommand;
        public ICommand RemoveSelectedCloudSpriteCommand
        {
            get
            {
                if (this.removeSelectedCloudSpriteCommand == default)
                {
                    this.removeSelectedCloudSpriteCommand = new SimpleCommand<Int32>(CanRemoveSelectedIndex, ExecuteRemoveSelectedCloudResourceCommand);
                }

                return this.removeSelectedCloudSpriteCommand;
            }
        }

        private ICommand addColorCommand;
        public ICommand AddColorCommand
        {
            get
            {
                if (this.addColorCommand == default)
                {
                    this.addColorCommand = new SimpleCommand<ObservableCollection<CustomColor>>(ExecuteAddColorCommand);
                }

                return this.addColorCommand;
            }
        }

        private ICommand removeBaseColorCommand;
        public ICommand RemoveBaseColorCommand
        {
            get
            {
                if (this.removeBaseColorCommand == default)
                {
                    this.removeBaseColorCommand = new SimpleCommand<CustomColor>(ExecuteRemoveBaseColorCommand);
                }

                return this.removeBaseColorCommand;
            }
        }

        private ICommand removeLandColorCommand;
        public ICommand RemoveLandColorCommand
        {
            get
            {
                if (this.removeLandColorCommand == default)
                {
                    this.removeLandColorCommand = new SimpleCommand<CustomColor>(ExecuteRemoveLandColorCommand);
                }

                return this.removeLandColorCommand;
            }
        }

        private ICommand removeCloudColorCommand;
        public ICommand RemoveCloudColorCommand
        {
            get
            {
                if (this.removeCloudColorCommand == default)
                {
                    this.removeCloudColorCommand = new SimpleCommand<CustomColor>(ExecuteRemoveCloudColorCommand);
                }

                return this.removeCloudColorCommand;
            }
        }

        private ICommand addSpriteCommand;
        public ICommand AddSpriteCommand
        {
            get
            {
                if (this.addSpriteCommand == default)
                {
                    this.addSpriteCommand = new SimpleCommand<ObservableCollection<String>>(ExecuteAddSpriteCommand);
                }

                return this.addSpriteCommand;
            }
        }

        public override void SetContext(ObservableCollection<PlanetType> context)
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
            var planetTypesFileName = Path.Combine(BasePath, PlanetTypesDefinitionPath);

            if (File.Exists(planetTypesFileName))
            {
                var planetTypes = JsonConvert.DeserializeObject<ObservableCollection<PlanetType>>(File.ReadAllText(planetTypesFileName));

                this.SetContext(planetTypes);

                isSuccessful = true;
            }

            return isSuccessful;
        }

        private Boolean CanExecuteRemoveSelectedPlanetTypeCommand(PlanetType planetType)
        {
            return (planetType != default);
        }

        private void ExecuteRemoveSelectedPlanetTypeCommand(PlanetType planetType)
        {
            Value.Remove(planetType);
        }

        private Boolean CanExecuteDuplicateSelectedPlanetTypeCommand(PlanetType planetType)
        {
            return (planetType != default);
        }

        private void ExecuteDuplicateSelectedPlanetTypeCommand(PlanetType planetType)
        {
            var clone = new PlanetType()
            {
                Name = String.Format("{0} - Clone", planetType.Name),
                BaseColors = planetType.BaseColors.Clone(),
                LandColors = planetType.LandColors.Clone(),
                CloudColors = planetType.CloudColors.Clone(),
                LandSprites = planetType.LandSprites.Clone(),
                CloudSprites = planetType.CloudSprites.Clone(),
                Resources = new PlanetResources()
                {
                    Oxygen = new PlanetResource()
                    {
                        RangeMin = planetType.Resources.Oxygen.RangeMin,
                        RangeMax = planetType.Resources.Oxygen.RangeMax,
                        Dispersion = planetType.Resources.Oxygen.Dispersion,
                    },
                    Food = new PlanetResource()
                    {
                        RangeMin = planetType.Resources.Food.RangeMin,
                        RangeMax = planetType.Resources.Food.RangeMax,
                        Dispersion = planetType.Resources.Food.Dispersion,
                    },
                    Fuel = new PlanetResource()
                    {
                        RangeMin = planetType.Resources.Fuel.RangeMin,
                        RangeMax = planetType.Resources.Fuel.RangeMax,
                        Dispersion = planetType.Resources.Fuel.Dispersion,
                    }
                }
            };

            Value.Add(clone);
        }

        private void ExecuteAddNewPlanetTypeCommand()
        {
            Value.Add(new PlanetType()
            {
                Name = "New Planet",
                BaseColors = new ObservableCollection<CustomColor>(),
                LandColors = new ObservableCollection<CustomColor>(),
                CloudColors = new ObservableCollection<CustomColor>(),
                LandSprites = new ObservableCollection<String>(),
                CloudSprites = new ObservableCollection<String>(),
                Resources = new PlanetResources()
                {
                    Oxygen = new PlanetResource(),
                    Food = new PlanetResource(),
                    Fuel = new PlanetResource()
                }
            });
        }

        private void ExecuteWriteToFileCommand()
        {
            var planetTypesFileName = Path.Combine(BasePath, PlanetTypesDefinitionPath);

            var planetTypesString = JsonConvert.SerializeObject(this.Value, new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                Formatting = Formatting.Indented
            });

            if (!String.IsNullOrEmpty(planetTypesString))
            {
                if (File.Exists(planetTypesFileName))
                {
                    File.Delete(planetTypesFileName);
                }

                File.WriteAllText(planetTypesFileName, planetTypesString);
            }
        }

        private void ExecuteRemoveSelectedLandResourceCommand(Int32 selectedIndex)
        {
            this.SelectedPlanetType.LandSprites.RemoveAt(selectedIndex);
        }

        private Boolean CanRemoveSelectedIndex(Int32 selectedIndex)
        {
            return (selectedIndex >= 0);
        }

        private void ExecuteRemoveSelectedCloudResourceCommand(Int32 selectedIndex)
        {
            this.SelectedPlanetType.CloudSprites.RemoveAt(selectedIndex);
        }

        private void ExecuteAddColorCommand(ObservableCollection<CustomColor> target)
        {
            target?.Add(new CustomColor());
        }

        private void ExecuteRemoveBaseColorCommand(CustomColor customColor)
        {
            this.SelectedPlanetType.BaseColors.Remove(customColor);
        }

        private void ExecuteRemoveLandColorCommand(CustomColor customColor)
        {
            this.SelectedPlanetType.LandColors.Remove(customColor);
        }

        private void ExecuteRemoveCloudColorCommand(CustomColor customColor)
        {
            this.SelectedPlanetType.CloudColors.Remove(customColor);
        }

        private void ExecuteAddSpriteCommand(ObservableCollection<String> targetCollection)
        {
            var selectSpriteWindow = new ResourceSelectionWindow()
            {
                FilterPath = Path.Combine("Planets", "Sprites")
            };

            if (selectSpriteWindow.ShowDialog() == true)
            {
                foreach (var resource in selectSpriteWindow.SelectedResources)
                {
                    targetCollection.Add(resource.Name);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;

using Balancer.Commands;
using Balancer.Model;
using Balancer.Model.Planets;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Balancer.Views.Tabs
{
    public class PlanetTypesContext : TabContext<List<PlanetType>>
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

        private String selectedLandResource;
        public String SelectedLandResource
        {
            get
            {
                return this.selectedLandResource;
            }
            set
            {
                if (SetProperty(ref this.selectedLandResource, value))
                {
                    this.RemoveSelectedCloudSpriteCommand.OnCanExecuteChanged();
                }
            }
        }

        private String selectedCloudResource;
        public String SelectedCloudResource
        {
            get
            {
                return this.selectedCloudResource;
            }
            set
            {
                if (SetProperty(ref this.selectedCloudResource, value))
                {
                    CommandManager.InvalidateRequerySuggested();
                }
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
        public SimpleCommand<String> RemoveSelectedLandSpriteCommand
        {
            get
            {
                if (this.removeSelectedLandSpriteCommand == default)
                {
                    this.removeSelectedLandSpriteCommand = new SimpleCommand<String>(CanExecuteRemoveSelectedLandResourceCommand, ExecuteRemoveSelectedLandResourceCommand);
                }

                return this.removeSelectedLandSpriteCommand;
            }
        }

        private ICommand removeSelectedCloudSpriteCommand;
        public SimpleCommand<String> RemoveSelectedCloudSpriteCommand
        {
            get
            {
                if (this.removeSelectedCloudSpriteCommand == default)
                {
                    this.removeSelectedCloudSpriteCommand = new SimpleCommand<String>(CanExecuteRemoveSelectedCloudResourceCommand, ExecuteRemoveSelectedCloudResourceCommand);
                }

                return this.removeSelectedCloudSpriteCommand;
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

        public override void SetContext(List<PlanetType> context)
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
                var planetTypes = JsonConvert.DeserializeObject<List<PlanetType>>(File.ReadAllText(planetTypesFileName));

                this.SetContext(planetTypes);

                isSuccessful = true;
            }

            return isSuccessful;
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

        private Boolean CanExecuteRemoveSelectedLandResourceCommand(String resourceName)
        {
            return (this.SelectedLandResource != default);
        }

        private void ExecuteRemoveSelectedLandResourceCommand(String resourceName)
        {
            if (!String.IsNullOrEmpty(resourceName))
            {
                this.SelectedPlanetType.LandSprites.Remove(resourceName);
            }
        }

        private Boolean CanExecuteRemoveSelectedCloudResourceCommand(String resourceName)
        {
            return (this.SelectedCloudResource != default);
        }

        private void ExecuteRemoveSelectedCloudResourceCommand(String resourceName)
        {
            if (!String.IsNullOrEmpty(resourceName))
            {
                this.SelectedPlanetType.CloudSprites.Remove(resourceName);
            }
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
    }
}

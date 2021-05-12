﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;

using Balancer.Commands;
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
    }
}

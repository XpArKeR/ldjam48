using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;

using Balancer.Commands;
using Balancer.Model.Core;
using Balancer.Model.Planets;
using Balancer.Model.Ships;
using Balancer.Views;
using Balancer.Views.Tabs;

using Microsoft.Win32;

namespace Balancer
{
    public class MainWindowContext : BaseContext
    {
        private Boolean isLoading;
        public Boolean IsLoading
        {
            get
            {
                return this.isLoading;
            }
            set
            {
                SetProperty(ref this.isLoading, value);
            }
        }

        private Boolean areItemsLoaded;
        public Boolean AreItemsLoaded
        {
            get
            {
                return this.areItemsLoaded;
            }
            set
            {
                SetProperty(ref this.areItemsLoaded, value);
            }
        }

        private String resourceDirectoryName;
        public String ResourceDirectoryName
        {
            get
            {
                return resourceDirectoryName;
            }
            set
            {
                SetProperty(ref resourceDirectoryName, value);
            }
        }

        private PlanetTypesContext planetTypesContext = new PlanetTypesContext();
        public PlanetTypesContext PlanetTypesContext
        {
            get
            {
                return this.planetTypesContext;
            }
            set
            {
                SetProperty(ref this.planetTypesContext, value);
            }
        }

        private ShipTypesContext shipTypesContext = new ShipTypesContext();
        public ShipTypesContext ShipTypesContext
        {
            get
            {
                return this.shipTypesContext;
            }
            set
            {
                SetProperty(ref this.shipTypesContext, value);
            }
        }

        private ConsumptionRatesContext consumptionRatesContext = new ConsumptionRatesContext();
        public ConsumptionRatesContext ConsumptionRatesContext
        {
            get
            {
                return this.consumptionRatesContext;
            }
            set
            {
                SetProperty(ref this.consumptionRatesContext, value);
            }
        }

        private ICommand browseResourceFolderCommand;
        public ICommand BrowseResourceFolderCommand
        {
            get
            {
                if (this.browseResourceFolderCommand == default)
                {
                    this.browseResourceFolderCommand = new SimpleCommand(ExecuteBrowseResourceFolderCommand);
                }

                return this.browseResourceFolderCommand;
            }
        }

        private void ExecuteBrowseResourceFolderCommand()
        {
            var folderBrowser = new OpenFileDialog()
            {
                RestoreDirectory = true,
                AddExtension = false,
                CheckPathExists = true,
                Multiselect = false,
                CheckFileExists = true,
                Filter = "Visual Studio Solution file (*.sln) | *.sln"
            };

            if (folderBrowser.ShowDialog() == true)
            {
                this.ResourceDirectoryName = Path.GetDirectoryName(folderBrowser.FileName);

                this.LoadResources();
            }
        }

        private async Task LoadResources()
        {
            this.IsLoading = true;

            var loadResourcesTask = Base.Resources.LoadAsync(this.ResourceDirectoryName);

            var loadPlanetsTask = this.LoadPlanetTypesAsync();
            var loadShipTypesTask = this.LoadShipTypesAsync();
            var loadConsumptionRatesTask = this.LoadConsumptionRatesAsymc();

            Debug.WriteLine("Started Tasks");

            await Task.WhenAll(loadResourcesTask, loadPlanetsTask, loadShipTypesTask, loadConsumptionRatesTask);

            Debug.WriteLine("Completed Tasks");

            this.AreItemsLoaded = true;
            this.IsLoading = false;
        }

        private async Task<Boolean> LoadPlanetTypesAsync()
        {
            return await Task.Run(() =>
            {
                Debug.WriteLine("Started loading Planets");
                                
                var isSuccessful = this.PlanetTypesContext.Load(this.ResourceDirectoryName);
                
                Debug.WriteLine("Finished loading Planets");

                return isSuccessful;
            });
        }

        private async Task<Boolean> LoadShipTypesAsync()
        {
            return await Task.Run(() =>
            {
                Debug.WriteLine("Started loading ShipTypes");

                var isSuccessful = this.ShipTypesContext.Load(this.ResourceDirectoryName);
                
                Debug.WriteLine("Finished loading ShipTypes");

                return isSuccessful;
            });
        }

        private async Task<Boolean> LoadConsumptionRatesAsymc()
        {
            return await Task.Run(() =>
            {
                Debug.WriteLine("Started loading ConsumptionRates");

                var isSuccessful = this.ConsumptionRatesContext.Load(this.ResourceDirectoryName);
                
                Debug.WriteLine("Finished loading ConsumptionRates");

                return isSuccessful;
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using Balancer.Base;
using Balancer.Commands;
using Balancer.Model.Resources;

namespace Balancer.Views.ResourceSelection
{
    public class ResourceSelectionContext : BaseContext
    {
        public ResourceSelectionContext()
        {
        }

        private Boolean? dialogResult;
        public Boolean? DialogResult
        {
            get
            {
                return this.dialogResult;
            }
            set
            {
                SetProperty(ref dialogResult, value);
            }
        }

        private String filterPath;
        public String FilterPath
        {
            get
            {
                return this.filterPath;
            }
            set
            {
                SetProperty(ref this.filterPath, value);
            }
        }

        private ObservableCollection<ResourceSurrogate> availableResourceItems = new ObservableCollection<ResourceSurrogate>();
        public ObservableCollection<ResourceSurrogate> AvailableResourceItems
        {
            get
            {
                return this.availableResourceItems;
            }
        }

        public IEnumerable<Resource> SelectedResources
        {
            get
            {
                foreach (var selectedResource in this.AvailableResourceItems.Where(r => r.IsSelected))
                {
                    yield return selectedResource.Resource;
                }

                yield break;
            }
        }

        private ICommand cancelCommand;
        public ICommand CancerCommand
        {
            get
            {
                if (this.cancelCommand == default)
                {
                    this.cancelCommand = new SimpleCommand(ExecuteCancelCommand);
                }

                return this.cancelCommand;
            }
        }

        private ICommand selectCommand;
        public ICommand SelectCommand
        {
            get
            {
                if (this.selectCommand == default)
                {
                    this.selectCommand = new SimpleCommand(CanExecuteSelectCommand, ExecuteSelectCommand);
                }

                return this.selectCommand;
            }
        }

        private void ExecuteCancelCommand()
        {
            this.DialogResult = false;
        }

        private Boolean CanExecuteSelectCommand()
        {
            return this.AvailableResourceItems.Any(r => r.IsSelected);
        }

        private void ExecuteSelectCommand()
        {
            this.DialogResult = true;
        }

        public void Load()
        {
            this.LoadResourcesFromCacheAsync();
        }

        private async Task LoadResourcesFromCacheAsync()
        {
            await Task.Run(() =>
            {
                foreach (var resource in Resources.GetResources(this.FilterPath))
                {
                    System.Windows.Application.Current.Dispatcher.Invoke(() =>
                    {
                        this.AvailableResourceItems.Add(new ResourceSurrogate(resource));
                    });
                }
            });
        }
    }
}

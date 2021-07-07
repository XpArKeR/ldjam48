using System;
using System.Collections.Generic;
using System.Windows;

using Balancer.Model.Resources;

namespace Balancer.Views.ResourceSelection
{
    /// <summary>
    /// Interaction logic for ResourceSelectionWindow.xaml
    /// </summary>
    public partial class ResourceSelectionWindow : Window
    {
        public ResourceSelectionWindow()
        {
            InitializeComponent();
        }

        public String FilterPath
        {
            get
            {
                return this.ViewContext.FilterPath;
            }
            set
            {
                this.ViewContext.FilterPath = value;
            }
        }

        public IEnumerable<Resource> SelectedResources
        {
            get
            {
                return this.ViewContext.SelectedResources;
            }
        }

        private void Window_Loaded(Object sender, RoutedEventArgs e)
        {
            this.ViewContext.Load();
        }
    }
}

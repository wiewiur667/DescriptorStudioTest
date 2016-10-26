using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Caliburn.Micro;
using System.Diagnostics;
using DescriptorStudioTest.Models;

namespace DescriptorStudioTest.ViewModels
{
    class CustomTreeViewModel : PropertyChangedBase
    {
        private DescriptorItemViewModel _rootItem;
        public DescriptorItemViewModel RootItem
        {
            get { return _rootItem; }
            set
            {
                _rootItem = value;
                NotifyOfPropertyChange(() => RootItem);
            }
        }

        private BindableCollection<DescriptorItemViewModel> _firstGeneration;
        public BindableCollection<DescriptorItemViewModel> FirstGeneration
        {
            get { return _firstGeneration; }
            set
            {
                _firstGeneration = value;
                NotifyOfPropertyChange(() => _firstGeneration);
            }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }

        public CustomTreeViewModel()
        {
            Title = "Test";
            DescriptorItem item = new DescriptorItem()
            {
                Type = "Test"
            };

            RootItem = new DescriptorItemViewModel(item);
            FirstGeneration = new BindableCollection<DescriptorItemViewModel>();
            FirstGeneration.Add(RootItem);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using DescriptorStudioTest.Models;
using System.Windows.Controls;
using System.Diagnostics;

namespace DescriptorStudioTest.ViewModels
{
    class DescriptorItemViewModel : PropertyChangedBase
    {
        private DescriptorItem _item;

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                NotifyOfPropertyChange(() => IsSelected);
                Selected(value);
            }
        }

        private DescriptorItemViewModel _parent;
        public DescriptorItemViewModel Parent
        {
            get { return _parent; }
            private set
            {
                _parent = value;
                NotifyOfPropertyChange("Parent");
            }
        }

        private BindableCollection<DescriptorItemViewModel> _children;
        public BindableCollection<DescriptorItemViewModel> Children
        {
            get { return _children; }
            set
            {
                _children = value;
                NotifyOfPropertyChange("Children");
            }
        }

        private bool _isLast;
        public bool IsLast
        {
            get { return _isLast; }
            set
            {
                _isLast = value;
                NotifyOfPropertyChange("IsLast");
            }
        }

        private bool _name;
        public bool Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange("Name");
            }
        }

        public BindableCollection<DescriptorItem.DescriptorProperty> Values
        {
            get { return _item.Values; }
            set
            {
                _item.Values = value;
                NotifyOfPropertyChange("Values");
                Console.WriteLine("Changed");
            }
        }

        public string Type
        {
            get { return _item.Type; }
            set
            {
                _item.Type = value;
                NotifyOfPropertyChange("Type");
            }
        }

        
  

        #region Constructors
        public DescriptorItemViewModel(DescriptorItem item): this(item, null)
        { 
        }

        public DescriptorItemViewModel(DescriptorItem item, DescriptorItemViewModel parent)
        {
            _item = item;
            Parent = parent;

            Children = new BindableCollection<DescriptorItemViewModel>(
                from child in _item.Children select new DescriptorItemViewModel(child, this));
        }

        #endregion

        #region Methods

        public void Selected(bool value)
        {
            if (value)
            {
                Console.WriteLine($"Selected item {Type}: {value}");
            }
            
        }

        public void ABC(object sender, TextChangedEventArgs e)
        {
            try
            {
                Console.WriteLine( e.Changes.ToString());
            }
            catch (DescriptorItem.DescriptorValue.ValueRange.OutOfRangeException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void AddChild()
        {
            DescriptorItem item = new DescriptorItem("Test3");
            item.Values.Add(new DescriptorItem.DescriptorProperty("a", new DescriptorItem.DescriptorValue(121, "ubyte")));
            item.Values.Add(new DescriptorItem.DescriptorProperty("a", new DescriptorItem.DescriptorValue(10, "ushort")));
            DescriptorItemViewModel desc = new DescriptorItemViewModel(item, this);
            Children.Add(desc);
        }

        #endregion
    }
}

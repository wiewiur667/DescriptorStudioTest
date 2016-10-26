using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using DescriptorStudioTest.ViewModels;

namespace DescriptorStudioTest.ViewModels
{
    class MainWindowViewModel : PropertyChangedBase
    {
        string _windowName;

        public string WindowName
        {
            get { return _windowName; }
            set
            {
                _windowName = value;
                NotifyOfPropertyChange(() => WindowName);
            }
        }


        private CustomTreeViewModel _tree;

        public CustomTreeViewModel MyTree
        {
            get { return _tree; }
            set
            {
                _tree = value;
                NotifyOfPropertyChange(() => MyTree);
            }
        }

        public MainWindowViewModel()
        {
            WindowName = "Hello Window";
            MyTree = new CustomTreeViewModel();
            if (Execute.InDesignMode)
            {
                Console.WriteLine("InDesign");
            }
            
        }

        
    }
}

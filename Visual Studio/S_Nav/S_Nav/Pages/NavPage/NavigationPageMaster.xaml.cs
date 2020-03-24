using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace S_Nav
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationPageMaster : ContentPage
    {
        public ListView ListView;

        public NavigationPageMaster()
        {
            InitializeComponent();

            BindingContext = new NavigationPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class NavigationPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<NavigationPageMasterMenuItem> MenuItems { get; set; }

            public NavigationPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<NavigationPageMasterMenuItem>(new[]
                {
                    new NavigationPageMasterMenuItem { Id = 0, Title = "Page 1" },
                    new NavigationPageMasterMenuItem { Id = 1, Title = "Page 2" },
                    new NavigationPageMasterMenuItem { Id = 2, Title = "Page 3" },
                    new NavigationPageMasterMenuItem { Id = 3, Title = "Page 4" },
                    new NavigationPageMasterMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}
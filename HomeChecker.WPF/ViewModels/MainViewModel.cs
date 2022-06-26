using HomeChecker.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeChecker.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public HomeCreatorViewModel HomeCreatorViewModel { get; }
        public AddRoomFormViewModel AddRoomFormViewModel { get; }

        public MainViewModel(NavigationStore modalNavigationStore)
        {
            _navigationStore = modalNavigationStore;

            _navigationStore.CurrentViewModelChanged += NavigationStore_CurrentViewModelChanged;
           
        }

        protected override void Dispose()
        {
            _navigationStore.CurrentViewModelChanged -= NavigationStore_CurrentViewModelChanged;
            base.Dispose();
        }

        private void NavigationStore_CurrentViewModelChanged()
        {
            OnPropertychanged(nameof(CurrentViewModel));
        }


    }
}

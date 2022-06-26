using HomeChecker.WPF.Models;
using HomeChecker.WPF.Stores;
using HomeChecker.WPF.Stores.Actions;
using HomeChecker.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HomeChecker.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private readonly RoomListItemMade _roomListStore;
        private readonly SelectedRoomStore _selectedRoomStore;
        private readonly HomeCreatorViewModel _homeCreatorViewModel;
        private readonly AddRoomFormViewModel _addRoomFormViewModel;
        private readonly RoomListViewStore _roomListViewStore;
        private readonly RoomsListViewModel _roomListViewModel;
        private readonly RoomDetailsViewModel _roomDetailsViewModel;
        private readonly RoomListViewUpdateRoom _roomListViewUpdateRoom;

        public App()
        {
            
            _navigationStore = new NavigationStore();
            _selectedRoomStore = new SelectedRoomStore();
            _roomListStore = new RoomListItemMade();
            _roomListViewUpdateRoom = new RoomListViewUpdateRoom();  
            _roomListViewStore = new RoomListViewStore(_roomListStore, _roomListViewUpdateRoom);

            _roomListViewModel = new RoomsListViewModel(_roomListViewStore, _selectedRoomStore);
            _roomDetailsViewModel = new RoomDetailsViewModel(_navigationStore, _roomListStore, _roomListViewStore, _selectedRoomStore, _roomListViewModel, _roomListViewUpdateRoom);
            _addRoomFormViewModel = new AddRoomFormViewModel(_roomListStore, _navigationStore, _roomListViewStore, _selectedRoomStore, _roomListViewModel, _roomDetailsViewModel, _roomListViewUpdateRoom);
            _homeCreatorViewModel = new HomeCreatorViewModel(_navigationStore, _roomListStore, _roomListViewStore, _selectedRoomStore, _roomListViewModel, _roomDetailsViewModel, _roomListViewUpdateRoom);

        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = new HomeCreatorViewModel(_navigationStore, _roomListStore, _roomListViewStore, _selectedRoomStore, _roomListViewModel, _roomDetailsViewModel, _roomListViewUpdateRoom);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}

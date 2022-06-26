using HomeChecker.WPF.Stores;
using HomeChecker.WPF.Stores.Actions;
using HomeChecker.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeChecker.WPF.Commands
{
    public class NavigateHomeCreatorCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly RoomListItemMade _roomListStore;
        private readonly RoomListViewStore _roomListViewStore;
        private readonly SelectedRoomStore _selectedRoomStore;
        private readonly RoomsListViewModel _roomListViewModel;
        private readonly RoomDetailsViewModel _roomDetailsViewModel;
        private readonly RoomListViewUpdateRoom _roomListViewUpdateRoom;

        public NavigateHomeCreatorCommand(NavigationStore navigationStore, RoomListItemMade roomListStore, 
            RoomListViewStore roomListViewStore, SelectedRoomStore selectedRoomStore, RoomsListViewModel roomListViewModel,
            RoomDetailsViewModel roomDetailsViewModel, RoomListViewUpdateRoom roomListViewUpdateRoom)
        {
            _navigationStore = navigationStore;
            _roomListStore = roomListStore;
            _roomListViewStore = roomListViewStore;
            _selectedRoomStore = selectedRoomStore;
            _roomListViewModel = roomListViewModel;
            _roomDetailsViewModel = roomDetailsViewModel;
            _roomListViewUpdateRoom = roomListViewUpdateRoom;
        }


        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new HomeCreatorViewModel(_navigationStore, _roomListStore, _roomListViewStore, 
                _selectedRoomStore, _roomListViewModel, _roomDetailsViewModel, _roomListViewUpdateRoom);
        }
    }
}

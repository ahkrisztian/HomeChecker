using HomeChecker.WPF.Commands;
using HomeChecker.WPF.Stores;
using HomeChecker.WPF.Stores.Actions;
using System.Windows.Input;

namespace HomeChecker.WPF.ViewModels
{
    public class HomeCreatorViewModel : ViewModelBase
    {
        public  RoomsListViewModel RoomsListViewModel { get; }
        public  RoomDetailsViewModel RoomDetailsViewModel { get; }


        public ICommand OpenAddViewCommand { get; }

        public HomeCreatorViewModel(NavigationStore navigationStore, 
            RoomListItemMade roomListStore, RoomListViewStore roomListViewStore, 
            SelectedRoomStore selectedRoomStore, RoomsListViewModel roomsListViewModel,
            RoomDetailsViewModel roomDetailsViewModel, RoomListViewUpdateRoom roomListViewUpdateRoom)
        {

            RoomsListViewModel = new RoomsListViewModel(roomListViewStore, selectedRoomStore);
            RoomDetailsViewModel = new RoomDetailsViewModel(navigationStore, roomListStore, roomListViewStore, selectedRoomStore,
            roomsListViewModel, roomListViewUpdateRoom);

            OpenAddViewCommand = new OpenAddRoomViewCommand(navigationStore, roomListStore, roomListViewStore, selectedRoomStore, roomsListViewModel, roomDetailsViewModel, roomListViewUpdateRoom);
        }
    }
}

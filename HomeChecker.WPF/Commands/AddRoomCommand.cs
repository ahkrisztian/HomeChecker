using HomeChecker.WPF.Models;
using HomeChecker.WPF.Stores;
using HomeChecker.WPF.Stores.Actions;
using HomeChecker.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HomeChecker.WPF.Commands
{
    public class AddRoomCommand : CommandBase
    {
        private readonly AddRoomFormViewModel _addRoomFormViewModel;
        private readonly RoomListItemMade _roomListStore;
        private readonly RoomsListViewModel _roomListViewModel;

        public AddRoomCommand(AddRoomFormViewModel addRoomFormViewModel, RoomListItemMade roomListStore, RoomsListViewModel roomListViewModel)
        {
            _addRoomFormViewModel = addRoomFormViewModel;
            _roomListStore = roomListStore;
            _roomListViewModel = roomListViewModel;
        }


        public override void Execute(object? parameter)
        {
            RoomListingItemViewModel room = new RoomListingItemViewModel(new RoomModel(_addRoomFormViewModel.RoomName, false, false, false, false, _roomListViewModel.RoomListingItemViewModels.Count+1, false));

            _roomListStore.OnRoomMade(room);
        }
    }
}

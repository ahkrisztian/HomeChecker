using HomeChecker.WPF.Models;
using HomeChecker.WPF.Stores.Actions;
using HomeChecker.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeChecker.WPF.Commands
{
    public class ReadyCommand : CommandBase
    {
        private readonly RoomsListViewModel _roomsListViewModel;
        private readonly RoomDetailsViewModel _roomDetailsViewModel;
        private readonly RoomListViewUpdateRoom _roomListViewUpdateRoom;

        public ReadyCommand(RoomsListViewModel roomsListViewModel, RoomDetailsViewModel roomDetailsViewModel, RoomListViewUpdateRoom roomListViewUpdateRoom)
        {
            _roomsListViewModel = roomsListViewModel;
            _roomDetailsViewModel = roomDetailsViewModel;
            _roomListViewUpdateRoom = roomListViewUpdateRoom;
        }

        public override void Execute(object? parameter)
        {

            RoomModel model = new RoomModel(
                _roomDetailsViewModel.RoomName,
                _roomDetailsViewModel.Lights,
                _roomDetailsViewModel.Water,
                _roomDetailsViewModel.Windows,
                _roomDetailsViewModel.Doors,
                _roomsListViewModel.RoomListingItemViewModels.Where(x => x.RoomModel.Id == _roomDetailsViewModel.Id).FirstOrDefault().RoomModel.Id,
                _roomDetailsViewModel.IsReady);

            _roomListViewUpdateRoom.OnRoomUpdate(new RoomListingItemViewModel(model));

        }
    }
}

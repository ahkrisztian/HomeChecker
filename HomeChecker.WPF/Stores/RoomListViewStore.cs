using HomeChecker.WPF.Stores.Actions;
using HomeChecker.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeChecker.WPF.Stores
{
    public  class RoomListViewStore : ViewModelBase
    {
        private readonly RoomListItemMade _roomListStore;
        private readonly RoomListViewUpdateRoom _roomListViewUpdateRoom;

        private readonly ObservableCollection<RoomListingItemViewModel> _roomListingItemViewModel = new ObservableCollection<RoomListingItemViewModel>();
        public List<RoomListingItemViewModel> RoomListingItemViewModels => _roomListingItemViewModel.ToList();


        public int RoomListViewSelectedRoomId { get; set; }
        public RoomListViewStore(RoomListItemMade roomListStore, RoomListViewUpdateRoom roomListViewUpdateRoom)
        {
            _roomListStore = roomListStore;
            _roomListViewUpdateRoom = roomListViewUpdateRoom;


            _roomListingItemViewModel = new ObservableCollection<RoomListingItemViewModel>();

            _roomListStore.RoomAdded += AddRoom;
            _roomListViewUpdateRoom.RoomUpdated += UpdateRoom;
            
        }

        protected override void Dispose()
        {
            _roomListStore.RoomAdded -= AddRoom;
            _roomListViewUpdateRoom.RoomUpdated -= UpdateRoom;
        }

        private void AddRoom(RoomListingItemViewModel room)
        {
            _roomListingItemViewModel.Add(room);
        }

        private void UpdateRoom(RoomListingItemViewModel room)
        {
            var model = _roomListingItemViewModel.Where(x => x.RoomModel.Id == room.RoomModel.Id).Select(x => { x.RoomModel = room.RoomModel; return x; }).FirstOrDefault() ;
        }


    }
}

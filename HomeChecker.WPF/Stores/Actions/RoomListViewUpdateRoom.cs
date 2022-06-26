using HomeChecker.WPF.ViewModels;
using System;

namespace HomeChecker.WPF.Stores.Actions
{
    public class RoomListViewUpdateRoom
    {
        public event Action<RoomListingItemViewModel> RoomUpdated;


        public void OnRoomUpdate(RoomListingItemViewModel room)
        {
            RoomUpdated?.Invoke(room);
        }
    }
}

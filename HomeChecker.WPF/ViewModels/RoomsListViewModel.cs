using HomeChecker.WPF.Models;
using HomeChecker.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HomeChecker.WPF.ViewModels
{
    public class RoomsListViewModel : ViewModelBase
    {
        private readonly SelectedRoomStore _selectedRoomStore;

        private readonly RoomListViewStore _roomListViewStore;
        public List<RoomListingItemViewModel> RoomListingItemViewModels => _roomListViewStore.RoomListingItemViewModels;


        public bool HasRooms => RoomListingItemViewModels.Count > 0;

        private RoomListingItemViewModel _selectedRoomListingItemViewModel;

        public RoomListingItemViewModel SelectedRoomListingItemViewModel
        {
            get 
            { 
                return _selectedRoomListingItemViewModel; 
            }
            set 
            {
                _selectedRoomListingItemViewModel = value; 
                OnPropertychanged(nameof(SelectedRoomListingItemViewModel));

                _selectedRoomStore.SelectedRoomModel = _selectedRoomListingItemViewModel?.RoomModel;

                Checked = _selectedRoomListingItemViewModel.RoomModel.IsReady;

                AllRoomsAreReady = IsAllRoomsAreReady();
            }
        }

        private int _selectedRoomId;

        public int SelectedRoomId
        {
            get { return _selectedRoomId; }
            set 
            { 
                _selectedRoomId = value; 
                OnPropertychanged(nameof(SelectedRoomId));
            }
        }


        private bool _allRoomsAreReady;

        public bool AllRoomsAreReady
        {
            get { return _allRoomsAreReady; }
            set
            {
                _allRoomsAreReady = value;
                OnPropertychanged(nameof(AllRoomsAreReady));
                
            }
        }

        private bool _checked;

        public bool Checked
        {
            get { return _checked; }
            set
            {
                _checked = value;
                OnPropertychanged(nameof(Checked));
            }
        }

        public RoomsListViewModel(RoomListViewStore roomListViewStore, SelectedRoomStore selectedRoomStore)
        {
            _roomListViewStore = roomListViewStore;
            _selectedRoomStore = selectedRoomStore;
        }

        public bool IsAllRoomsAreReady()
        {
            bool output = true;

            foreach(RoomListingItemViewModel room in RoomListingItemViewModels)
            {
                if (!room.RoomModel.IsReady)
                {
                    output = false;
                    return output;
                }
            }

            return output;
        }
    }
}

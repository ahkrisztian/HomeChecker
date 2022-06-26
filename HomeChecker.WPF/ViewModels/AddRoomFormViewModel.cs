using HomeChecker.WPF.Commands;
using HomeChecker.WPF.Models;
using HomeChecker.WPF.Stores;
using HomeChecker.WPF.Stores.Actions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HomeChecker.WPF.ViewModels
{
    public class AddRoomFormViewModel : ViewModelBase
    {
        private readonly RoomsListViewModel _roomListViewModel;

        private readonly ObservableCollection<RoomListingItemViewModel> _roomListingItemViewModel;
        public IEnumerable<RoomListingItemViewModel> RoomListingItemViewModels => _roomListingItemViewModel;


        private string _roomName;
        public string RoomName
        {
            get { return _roomName; }
            set 
            { 
                _roomName = value; 
                OnPropertychanged(nameof(RoomName));
                //OnPropertychanged(nameof(CanSubmit));
            }
        }

        private RoomListingItemViewModel _room;
        public RoomListingItemViewModel Room
        {
            get { return _room; }
            set
            {
                _room = value;
                RoomName = value.RoomName;
                OnPropertychanged(nameof(Room));
                //OnPropertychanged(nameof(CanSubmit));
            }
        }

        //public bool CanSubmit => !string.IsNullOrEmpty(RoomName);

       
        public ICommand SubmitCommand { get; set; }

        public ICommand CancelCommand { get; set; }


        public AddRoomFormViewModel(RoomListItemMade roomListStore, NavigationStore navigationStore, RoomListViewStore roomListViewStore, 
            SelectedRoomStore selectedRoomStore, RoomsListViewModel roomListViewModel, RoomDetailsViewModel roomDetailsViewModel, RoomListViewUpdateRoom roomListViewUpdateRoom)
        {
            _roomListViewModel = roomListViewModel;
            _roomListingItemViewModel = new ObservableCollection<RoomListingItemViewModel>();

            _roomListingItemViewModel.Add(new RoomListingItemViewModel(new RoomModel("Kitchen", false, false, false, false, _roomListViewModel.RoomListingItemViewModels.Count + 1, false)));
            _roomListingItemViewModel.Add(new RoomListingItemViewModel(new RoomModel("Bedroom", false, false, false, false, _roomListViewModel.RoomListingItemViewModels.Count + 1, false)));
            _roomListingItemViewModel.Add(new RoomListingItemViewModel(new RoomModel("Bathroom", false, false, false, false, _roomListViewModel.RoomListingItemViewModels.Count + 1, false)));


            SubmitCommand = new AddRoomCommand(this, roomListStore, roomListViewModel);

            CancelCommand = new NavigateHomeCreatorCommand(navigationStore, roomListStore, roomListViewStore, selectedRoomStore, roomListViewModel, roomDetailsViewModel, roomListViewUpdateRoom);
            
        }

    }
}

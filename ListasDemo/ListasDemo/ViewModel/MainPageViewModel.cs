using ListasDemo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ListasDemo.Annotations;
using ListasDemo.Helpers;
using ListasDemo.View;
using Xamarin.Forms;

namespace ListasDemo.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection
            <Grouping<string, Friend>> Friends
        { get; set; }
        public Command AddFriendCommand { get; set; }
        private INavigation Navigation;
        private Friend _currentFriend;
        public Command ItemTappedCommand { get; set; }

        public Friend CurrentFriend
        {
            get { return _currentFriend; }
            set
            {
                _currentFriend = value; 
                OnPropertyChanged();
            }
        }

        public MainPageViewModel(INavigation navigation)
        {
            FriendRepository repository
                = new FriendRepository();
            Friends = repository.GetAllGrouped();
            Navigation = navigation;
            AddFriendCommand = new Command(async () =>
                await NavigateToFriendView());
            ItemTappedCommand = new Command(async () => await NavigateToEditFriendView());
        }

        public async Task NavigateToEditFriendView()
        {
            await Navigation.PushAsync(new FriendView(CurrentFriend));
        }

        public async Task NavigateToFriendView()
        {
            await Navigation.PushAsync(new FriendView());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

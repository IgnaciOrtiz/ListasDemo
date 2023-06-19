using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListasDemo.Model;
using Xamarin.Forms;

namespace ListasDemo.ViewModel
{
    public class FriendViewViewModel
    {
        public Command SaveFriendCommand { get; set; }
        public Friend NewFriend { get; set; }
        private INavigation Navigation;

        public FriendViewViewModel(INavigation navigation)
        {
            NewFriend = new Friend();
            SaveFriendCommand = new Command(async ()=> await SaveFriend());
            Navigation = navigation;
        }

        public FriendViewViewModel(INavigation navigation, Friend friend)
        {
            NewFriend = friend;
            SaveFriendCommand = new Command(async () => await SaveFriend());
            Navigation = navigation;
        }

        public async Task SaveFriend()
        {
            await App.Database.SaveItemAsync(NewFriend);
            await Navigation.PopToRootAsync();
        }
    }
}
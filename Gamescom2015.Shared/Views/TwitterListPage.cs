using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.LocalStorage;
using AppStudio.DataProviders.Menu;
using Gamescom2015;
using Gamescom2015.Sections;
using Gamescom2015.ViewModels;

namespace Gamescom2015.Views
{
    public sealed partial class TwitterListPage : PageBase
    {
        public ListViewModel<LocalStorageDataConfig, MenuSchema> ViewModel { get; set; }

        public TwitterListPage()
        {
            this.ViewModel = new ListViewModel<LocalStorageDataConfig, MenuSchema>(new TwitterConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}

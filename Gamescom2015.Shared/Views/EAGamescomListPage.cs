using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.Twitter;
using Gamescom2015;
using Gamescom2015.Sections;
using Gamescom2015.ViewModels;

namespace Gamescom2015.Views
{
    public sealed partial class EAGamescomListPage : PageBase
    {
        public ListViewModel<TwitterDataConfig, TwitterSchema> ViewModel { get; set; }

        public EAGamescomListPage()
        {
            this.ViewModel = new ListViewModel<TwitterDataConfig, TwitterSchema>(new EAGamescomConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}

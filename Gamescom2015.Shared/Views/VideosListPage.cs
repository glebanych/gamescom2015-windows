using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.YouTube;
using Gamescom2015;
using Gamescom2015.Sections;
using Gamescom2015.ViewModels;

namespace Gamescom2015.Views
{
    public sealed partial class VideosListPage : PageBase
    {
        public ListViewModel<YouTubeDataConfig, YouTubeSchema> ViewModel { get; set; }

        public VideosListPage()
        {
            this.ViewModel = new ListViewModel<YouTubeDataConfig, YouTubeSchema>(new VideosConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}

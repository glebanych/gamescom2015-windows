using System;
using System.Collections.Generic;
using AppStudio.Common.Actions;
using AppStudio.Common.Commands;
using AppStudio.Common.Navigation;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.YouTube;
using Gamescom2015.Config;
using Gamescom2015.ViewModels;

namespace Gamescom2015.Sections
{
    public class VideosConfig : SectionConfigBase<YouTubeDataConfig, YouTubeSchema>
    {
        public override DataProviderBase<YouTubeDataConfig, YouTubeSchema> DataProvider
        {
            get
            {
                return new YouTubeDataProvider(new YouTubeOAuthTokens
                {
                    ApiKey = "AIzaSyC9-_XLRkFj84_iToM1kaByXI0qG0YxW5Q"

                });
            }
        }

        public override YouTubeDataConfig Config
        {
            get
            {
                return new YouTubeDataConfig
                {
                    QueryType = YouTubeQueryType.Playlist,
                    Query = @"PL4Zyf5DkJuLbbjAHUqSOeZ0z-j-4t94hq",
                };
            }
        }

        public override NavigationInfo ListNavigationInfo
        {
            get 
            {
                return NavigationInfo.FromPage("VideosListPage");
            }
        }

        public override ListPageConfig<YouTubeSchema> ListPage
        {
            get 
            {
                return new ListPageConfig<YouTubeSchema>
                {
                    Title = "Videos",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Title.ToSafeString();
                        viewModel.SubTitle = "";
                        viewModel.Description = "";
                        viewModel.Image = item.ImageUrl.ToSafeString();

                    },
                    NavigationInfo = (item) =>
                    {
                        return NavigationInfo.FromPage("VideosDetailPage", true);
                    }
                };
            }
        }

        public override DetailPageConfig<YouTubeSchema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, YouTubeSchema>>();

                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = item.Title.ToSafeString();
                    viewModel.Title = null;
                    viewModel.Description = item.Summary.ToSafeString();
                    viewModel.Image = null;
                    viewModel.Content = item.EmbedHtmlFragment;
                });

				var actions = new List<ActionConfig<YouTubeSchema>>
				{
                    ActionConfig<YouTubeSchema>.Link("Go To Source", (item) => item.ExternalUrl.ToSafeString()),
				};

                return new DetailPageConfig<YouTubeSchema>
                {
                    Title = "Videos",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

        public override string PageTitle
        {
            get { return "Videos"; }
        }

    }
}

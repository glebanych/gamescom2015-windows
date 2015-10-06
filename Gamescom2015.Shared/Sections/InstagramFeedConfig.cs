using System;
using System.Collections.Generic;
using AppStudio.Common.Actions;
using AppStudio.Common.Commands;
using AppStudio.Common.Navigation;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.Instagram;
using Gamescom2015.Config;
using Gamescom2015.ViewModels;

namespace Gamescom2015.Sections
{
    public class InstagramFeedConfig : SectionConfigBase<InstagramDataConfig, InstagramSchema>
    {
        public override DataProviderBase<InstagramDataConfig, InstagramSchema> DataProvider
        {
            get
            {
                return new InstagramDataProvider(new InstagramOAuthTokens
                {
                    ClientId = "14c67f30661f48e895e52a1b6e8efe0d"

                });
            }
        }

        public override InstagramDataConfig Config
        {
            get
            {
                return new InstagramDataConfig
                {
                    QueryType = InstagramQueryType.Tag,
                    Query = @"gamescom"
                };
            }
        }

        public override NavigationInfo ListNavigationInfo
        {
            get 
            {
                return NavigationInfo.FromPage("InstagramFeedListPage");
            }
        }

        public override ListPageConfig<InstagramSchema> ListPage
        {
            get 
            {
                return new ListPageConfig<InstagramSchema>
                {
                    Title = "Instagram feed",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Title.ToSafeString();
                        viewModel.SubTitle = "";
                        viewModel.Description = null;
                        viewModel.Image = item.ThumbnailUrl.ToSafeString();

                    },
                    NavigationInfo = (item) =>
                    {
                        return NavigationInfo.FromPage("InstagramFeedDetailPage", true);
                    }
                };
            }
        }

        public override DetailPageConfig<InstagramSchema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, InstagramSchema>>();

                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = item.Title.ToSafeString();
                    viewModel.Title = item.Title.ToSafeString();
                    viewModel.Description = item.Author.ToSafeString();
                    viewModel.Image = item.ImageUrl.ToSafeString();
                    viewModel.Content = null;
                });

				var actions = new List<ActionConfig<InstagramSchema>>
				{
                    ActionConfig<InstagramSchema>.Link("Go To Source", (item) => item.SourceUrl.ToSafeString()),
				};

                return new DetailPageConfig<InstagramSchema>
                {
                    Title = "Instagram feed",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

        public override string PageTitle
        {
            get { return "Instagram feed"; }
        }

    }
}

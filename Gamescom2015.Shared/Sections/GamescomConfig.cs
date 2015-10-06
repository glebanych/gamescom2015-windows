using System;
using System.Collections.Generic;
using AppStudio.Common.Actions;
using AppStudio.Common.Commands;
using AppStudio.Common.Navigation;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.Twitter;
using Gamescom2015.Config;
using Gamescom2015.ViewModels;

namespace Gamescom2015.Sections
{
    public class GamescomConfig : SectionConfigBase<TwitterDataConfig, TwitterSchema>
    {
        public override DataProviderBase<TwitterDataConfig, TwitterSchema> DataProvider
        {
            get
            {
                return new TwitterDataProvider(new TwitterOAuthTokens
                {
                    ConsumerKey = "iSSTzHfuCQJcjdcbBBu5sR8G7",
                        ConsumerSecret = "e19UTSeaWImBVXU9uKbCLalssuyPkwcsCMwKXBzD1K9JKpsz8N",
                        AccessToken = "2169550185-5awfL4HOwu8oRkPXpA5YjecEtWIBJk1k8frYfVF",
                        AccessTokenSecret = "oI6z8Cu6fUeEQhui2Fn9qYSRNWt8Kly73imDzP91RKat8"

                });
            }
        }

        public override TwitterDataConfig Config
        {
            get
            {
                return new TwitterDataConfig
                {
                    QueryType = TwitterQueryType.Search,
                    Query = @"#gamescom"
                };
            }
        }

        public override NavigationInfo ListNavigationInfo
        {
            get 
            {
                return NavigationInfo.FromPage("GamescomListPage");
            }
        }


        public override ListPageConfig<TwitterSchema> ListPage
        {
            get 
            {
                return new ListPageConfig<TwitterSchema>
                {
                    Title = "Gamescom",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.UserName.ToSafeString();
                        viewModel.SubTitle = item.Text.ToSafeString();
                        viewModel.Description = "";
                        viewModel.Image = item.UserProfileImageUrl.ToSafeString();

                    },
                    NavigationInfo = (item) =>
                    {
                        return new NavigationInfo
                        {
                            NavigationType = NavigationType.DeepLink,
                            TargetUri = new Uri(item.Url)
                        };
                    }
                };
            }
        }

        public override DetailPageConfig<TwitterSchema> DetailPage
        {
            get { return null; }
        }

        public override string PageTitle
        {
            get { return "Gamescom"; }
        }

    }
}

using Microsoft.Toolkit.Uwp.Notifications;
using System;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Windows.UI.StartScreen;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Quickstart_Sending_Local_Tile
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ButtonNotifyPrimaryTile_Click(object sender, RoutedEventArgs e)
        {
            // In a real app, these would be initialized with actual data
            string from = "Jennifer Parker";
            string subject = "Photos from our trip";
            string body = "Check out these awesome photos I took while in New Zealand!";


            // Construct the tile content
            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    TileMedium = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new AdaptiveText()
                                {
                                    Text = from
                                },

                                new AdaptiveText()
                                {
                                    Text = subject,
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                },

                                new AdaptiveText()
                                {
                                    Text = body,
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                }
                            }
                        }
                    },

                    TileWide = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new AdaptiveText()
                                {
                                    Text = from,
                                    HintStyle = AdaptiveTextStyle.Subtitle
                                },

                                new AdaptiveText()
                                {
                                    Text = subject,
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                },

                                new AdaptiveText()
                                {
                                    Text = body,
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                }
                            }
                        }
                    }
                }
            };


            // Then create the tile notification
            var notification = new TileNotification(content.GetXml());


            // And send the notification
            TileUpdateManager.CreateTileUpdaterForApplication().Update(notification);
        }

        private async void ButtonPinSecondaryTile_Click(object sender, RoutedEventArgs e)
        {
            SecondaryTile tile = new SecondaryTile("MySecondaryTile", "Secondary", "args", new Uri("ms-appx:///Assets/Square150x150Logo.png"), TileSize.Default);

            tile.VisualElements.ShowNameOnSquare150x150Logo = true;

            await tile.RequestCreateAsync();
        }

        private async void ButtonNotifySecondary_Click(object sender, RoutedEventArgs e)
        {
            // In a real app, these would be initialized with actual data
            string from = "Steve Bosniak";
            string subject = "Build 2015 Dinner";
            string body = "Want to go out for dinner after Build tonight?";


            // Construct the tile content
            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    TileMedium = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new AdaptiveText()
                                {
                                    Text = from
                                },

                                new AdaptiveText()
                                {
                                    Text = subject,
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                },

                                new AdaptiveText()
                                {
                                    Text = body,
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                }
                            }
                        }
                    }
                }
            };


            // Then create the tile notification
            var notification = new TileNotification(content.GetXml());


            // If the secondary tile is pinned
            if (SecondaryTile.Exists("MySecondaryTile"))
            {
                // Get its updater
                var updater = TileUpdateManager.CreateTileUpdaterForSecondaryTile("MySecondaryTile");

                // And send the notification
                updater.Update(notification);
            }

            else
                await new MessageDialog("You must first pin the secondary tile.").ShowAsync();
        }
    }
}

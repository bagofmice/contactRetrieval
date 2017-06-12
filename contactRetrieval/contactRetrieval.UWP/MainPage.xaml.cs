using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.Chat;
using System.Text;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace contactRetrieval.UWP
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

        private async void Button_Click_1(System.Object sender, RoutedEventArgs e)
        {
            ChatMessageStore store = await ChatMessageManager.RequestStoreAsync();
            var reader = store.GetMessageReader();
            IReadOnlyList<ChatMessage> messages = await reader.ReadBatchAsync();
            List<string> lines = new List<string>();
            foreach (var m in messages)
            {
                lines.Add(m.From);
                foreach (var r in m.Recipients)
                {
                    lines.Add(r);
                }
                lines.Add(m.Subject);
                lines.Add(m.Body);
            }

            StringBuilder sb = new StringBuilder();
            foreach (string s in lines)
            {
                sb.AppendLine(s);
            }
            this.targetText.Text = sb.ToString();

        }


    }
}
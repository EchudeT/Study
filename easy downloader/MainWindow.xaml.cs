//using System.Text;
using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;
using System.Windows.Threading;
using System.Net;
using System.Security.Policy;
using System.Net.Http;
using System.IO;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private DispatcherTimer download_timer;
        private bool isBegin;
        private int clickCount;
        private double percentageDownloaded;
        private static readonly HttpClient client = new HttpClient();
        public MainWindow()
        {
            InitializeComponent();
            
            isBegin = false;
            clickCount = 0;
            percentageDownloaded = 0;
            download_timer = new DispatcherTimer();
            download_timer.Interval = TimeSpan.FromMilliseconds(20);

            download_timer.Tick += (sender, e) => {

                progressBar.Value = percentageDownloaded ;

                if(progressBar.Value >= 100) 
                {
                    DPShow.Text = "Download Finished!";
                }
                //progressBar.Value = progressBar.Minimum + (progressBar.Maximum - progressBar.Minimum) * percentageDownloaded;

            };

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CheckTick.IsChecked == false) return;
            if (!isBegin)
            {
                download_timer.Start();
                Confirm_Button.Content = "已确定";
                Cancel_Button.Content = "无法取消";
                CheckTick.IsEnabled = false;
                Cancel_Button.IsEnabled = false;
                URLbox.IsReadOnly = true;
                Homebox.IsReadOnly = true;

                string url = URLbox.Text;
                string path = Homebox.Text;

                Task t = Task.Run(async () =>
                {
                    await DownloadWeb(url, path);
                });

            }
            isBegin = true;
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            clickCount++;
            if (clickCount == 1)
            {
                Cancel_Button.Content = "真的要拒绝吗";
            }
            if(clickCount > 1)
            {
                this.Close();
            }
        }

        public async Task DownloadWeb(string url,string path)
        {
            using (WebClient webClient = new WebClient())
            {
                
                webClient.DownloadProgressChanged += (sender, e) =>
                {
                    int bytesReceived = (int)e.BytesReceived;
                    int totalBytesToReceive = (int)e.TotalBytesToReceive;

                    percentageDownloaded = (double)bytesReceived / totalBytesToReceive * 100;
                    percentageDownloaded = Math.Round(percentageDownloaded, 2);
                    Dispatcher.Invoke(() => DPShow.Text = $"{percentageDownloaded}%");
                };

                try
                {
                    await webClient.DownloadFileTaskAsync(new Uri(url), path);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }



        public async Task DownloadFileWithProgress(string url, string outputPath)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new HttpRequestException($"Error while downloading file. Status code: {response.StatusCode}");
                    }

                    var totalBytes = response.Content.Headers.ContentLength ?? -1L;
                    var canReportProgress = totalBytes != -1;

                    using (var streamToReadFrom = await response.Content.ReadAsStreamAsync())
                    {
                        using (var streamToWriteTo = File.Open(outputPath, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            var buffer = new byte[8192];
                            var totalRead = 0L;
                            var bytesRead = 0;

                            while ((bytesRead = await streamToReadFrom.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await streamToWriteTo.WriteAsync(buffer, 0, bytesRead);
                                totalRead += bytesRead;

                                if (canReportProgress)
                                {
                                    ReportProgress((totalRead * 1d) / totalBytes * 100);
                                }
                            }
                        }
                    }
                }
            }
        }
        private void ReportProgress(double percentageComplete)
        {
            DPShow.Text = percentageComplete.ToString();
        }
    }
}
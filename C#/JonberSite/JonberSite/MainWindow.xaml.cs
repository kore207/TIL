using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Tulpep.NotificationWindow;

namespace JonberSite
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

      
        static int ReFreshCnt = 0;
        public static IWebDriver driver;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            button.Content = "JBING";
            driver = new ChromeDriver(@"C:\Users\CEO\source\repos\JonberSite\JonberSite\bin\Debug");
            driver.Navigate().GoToUrl("https://www.sangsocamping.kr:453/reservation.asp?location=002");
            

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(30000); //30초 마다
            timer.Tick += new EventHandler(timer_Tick);            
            timer.Start();                      
        }      

        private void timer_Tick(object sender, EventArgs e)
        {
            JBCnt.Content = ReFreshCnt;

            IWebElement baseTable = driver.FindElement(By.TagName("table"));


            //sat 1th            
            IWebElement tableRow1 = baseTable.FindElement(By.XPath("//*[@id='contents']/div[2]/div[2]/table/tbody/tr[2]/td[7]"));
            //sat 2th
            IWebElement tableRow2 = baseTable.FindElement(By.XPath("//*[@id='contents']/div[2]/div[2]/table/tbody/tr[3]/td[7]"));            
            //sat 3th
            IWebElement tableRow3 = baseTable.FindElement(By.XPath("//*[@id='contents']/div[2]/div[2]/table/tbody/tr[4]/td[7]"));
            //sat 4th
            IWebElement tableRow4 = baseTable.FindElement(By.XPath("//*[@id='contents']/div[2]/div[2]/table/tbody/tr[5]/td[7]"));
            //sat 5th
            IWebElement tableRow5 = baseTable.FindElement(By.XPath("//*[@id='contents']/div[2]/div[2]/table/tbody/tr[6]/td[7]"));

            string rowtext1 = tableRow1.Text;
            string rowtext2 = tableRow2.Text;
            string rowtext3 = tableRow3.Text;
            string rowtext4 = tableRow4.Text;
            string rowtext5 = tableRow4.Text;

            bool open = rowtext1.Contains("*");
            bool open2 = rowtext2.Contains("*");
            bool open3 = rowtext3.Contains("*");
            bool open4 = rowtext4.Contains("*");
            bool open5 = rowtext5.Contains("*");
            Console.WriteLine("{0} {1} {2} {3} {4} ", open, open2, open3, open4, open5);

            if (open || open2 || open3 || open4 || open5)
            {
                MessageBox.Show("Hello there", "Prompt", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

                PopupNotifier popup = new PopupNotifier();
                popup.TitleText = " OPEN";
                popup.ContentText = "https://www.sangsocamping.kr:453/reservation.asp?location=002";
                popup.Popup();
                return;
            }

            driver.Navigate().Refresh();
            ReFreshCnt++;
        }
    }
}

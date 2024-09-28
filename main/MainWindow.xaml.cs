using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using System.Diagnostics;
using System.Net.Mail;
using OpenQA.Selenium.Edge;
using System.Windows.Media.Animation;
using OtpNet;
using System.Drawing.Imaging;
//using OpenQA.Selenium.DevTools.V120.WebAudio;
using System.Net;
using System.Net.Sockets;
using System.Windows.Markup;
//using OpenQA.Selenium.DevTools.V113.Debugger;

namespace main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string baseDir;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var options = new ChromeOptions();
            string baseDir = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ref");
            baseDir += "\\";
            string outputPath = baseDir + "output_web3.txt";
            string reCaptchaPATH = baseDir + "recaptcha.crx";
            options.AddArgument(@"user-data-dir=C:\Users\Surface\Desktop\fuel_chrome\profile\");
            options.AddArgument("no-sandbox");
            options.AddArguments("start-maximized");



            init();
            string[] dataa = System.IO.File.ReadAllLines(baseDir + "input_web3.txt");
            string password = dataa[0].Split(' ')[0];
            int index_startup = dataa.Length - 1;
            int count = 0;
            string Ipv4 = getIpV4();
            List<string> list = new List<string>() { };

            //for (int index_profile = 1; index_profile < 98; index_profile++)//86+1
            for (int index_profile = 1; index_profile < 98; index_profile++)//86+1
            {

                try
                {

                    options.AddArgument("profile-directory=Profile " + index_profile.ToString());
                    ChromeDriver driver = new ChromeDriver(options);
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
                    string currentWindow = driver.CurrentWindowHandle;




                    /*driver.Navigate().GoToUrl("chrome-extension://cpmkedoipcpimgecpmgpldfpohjplkpp/popup.html");
                    try
                    {
                        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[3]/div/input"))).SendKeys("Lop09876@");
                        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[3]/button/div"))).Click();

                    }
                    catch (Exception)
                    {}

                    try
                    {
                        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[4]/div/div[2]/span"))).Click();

                    }
                    catch (Exception)
                    {}
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[1]/div/div[1]/div[2]/div/div[1]"))).Click();

                    // xoas


                    driver.Quit();
                    continue; //

                   wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[text()='Add an account']"))).Click();

                    wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[4]/div/div[2]/div[1]/div/input"))).SendKeys("Lop09876@");
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[text()='Account02']"))).Click();
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("svg.iconpark-icon.icon-size-12.cursor.icon-1"))).Click();
                    //string evmAddr = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[3]/div/div[2]/div[1]/div/div[2]/div[2]/div[1]/p"))).Text;

                    driver.Quit();
                    continue;//*/


                    int voted = 0;

                    try
                    {
                        
                        driver.SwitchTo().Window(currentWindow);
                        bool loop1 = true;
                        string val = "";
                        while (loop1)
                        {
                            try
                            {
                                try
                                {

                                    for (int temp = 1; temp <= index_startup; temp++)
                                    {
                                        try
                                        {
                                            Thread.Sleep(100);
                                            driver.Navigate().GoToUrl(dataa[temp]);
                                            /*bool connected = false;
                                            while (!connected)
                                            {
                                                try
                                                {
                                                    wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[1]/div/div[1]/section/div[1]/div[1]/div/div")));
                                                    connected = true;
                                                }
                                                catch (Exception)
                                                { }
                                            }*/
                                            waitForWallet(wait);
                                            voteAfterClick(wait, ref voted, ref val);
                                            /*wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div[1]/div[2]/div/div[3]/div/div[2]/div/button"))).Click();
                                            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[15]/div/div/div[2]/div/div[2]/div[1]/div[2]/div/div/div"))).Click();
                                            //val = driver.FindElement(By.XPath("/html/body/div[15]/div/div/div[2]/div/div[2]/div[1]/div[1]/div[1]/div[3]/div[2]")).Text;
                                            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[15]/div/div/div[2]/div/div[2]/div[2]/button"))).Click();
                                            wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[9]/div/div/div[2]/div/div[2]/div[1]/div/div[2]/div")));
                                            voted++;*/
                                        }
                                        catch (Exception)
                                        { }
                                        Thread.Sleep(100);
                                    }
                                    File.AppendAllText(outputPath, index_profile.ToString() + "|" + ++count + "|" + voted + "|" + val+ "|" + Ipv4);
                                    //dataa = System.IO.File.ReadAllLines(baseDir + "input_web3.txt");

                                    do
                                    {
                                        fakeIP();
                                        Ipv4 = getIpV4();
                                    }while (list.Contains(Ipv4));
                                    list.Add(Ipv4);

                                }
                                catch (Exception)//92
                                { }
                                loop1 = false;
                            }
                            catch (Exception)
                            {
                                try
                                {
                                    driver.Navigate().Refresh();
                                }
                                catch (Exception)
                                { } 
                            }
                        }
                    }
                    catch (Exception)
                    { }
                    /*if (index_profile == 29)
                        index_profile = 32;
                    if (index_profile == 23)
                        index_profile = 27;*/
                    
                    if (index_profile == 69)
                    {
                        index_profile = 80;
                    }
                    Thread.Sleep(1000);
                    driver.Quit();
                }
                
                catch (Exception)
                {
                    Thread.Sleep(500);
                }
            }

            
        }

        private void import(object sender, RoutedEventArgs e)
        {
            var options = new ChromeOptions();
            string baseDir = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ref");
            baseDir += "\\";
            options.AddArgument(@"user-data-dir=A:\profile\");
            options.AddArgument("no-sandbox");
            options.AddArguments("start-maximized");
            options.AddArgument("profile-directory=Profile_temp");
            options.AddExtension(@"C:\Users\Surface\Desktop\temp\gateWallet.crx");
            // Xóa thư mục dữ liệu người dùng của Chrome


            string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string chromeUserDataPath = System.IO.Path.Combine(userProfile, @"A:\profile\Profile_temp");

            // Nếu thư mục tồn tại, xóa toàn bộ nội dung
            
            

            string[] seeds = System.IO.File.ReadAllLines(@"C:\Users\Surface\Desktop\fuel_chrome\gate3vote\main\seedss.txt");
            for (int i = 0 ; i < seeds.Length ; i++)
            {
                try
                {
                    do
                    {
                        try
                        {
                            Directory.Delete(chromeUserDataPath, true);
                        }
                        catch (Exception)
                        {}
                        
                    } while (Directory.Exists(chromeUserDataPath));
                    ChromeDriver driver = new ChromeDriver(options);
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    string currentWindow = driver.CurrentWindowHandle;

                    driver.Navigate().GoToUrl("chrome-extension://cpmkedoipcpimgecpmgpldfpohjplkpp/popup.html");
                    int voted = 0;
                    string val = "";
                    try
                    {
                        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[2]/button"))).Click();
                        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[2]/div/div/div[3]/div[1]"))).Click();


                        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[2]/div/div[1]/div/div[1]/div/input"))).SendKeys("Lop09876@");
                        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[2]/div/div[1]/div/div[2]/div/input"))).SendKeys("Lop09876@");
                        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[2]/div/div[2]/button/div"))).Click();
                        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[2]/div/div[1]/div[2]/div/div/div/textarea"))).SendKeys(seeds[i]);
                        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[2]/div/div[2]/button"))).Click();
                        bool waitt = true;
                        while (waitt)
                        {
                            try
                            {
                                wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[1]/div[2]/main/div/div[1]/div/div[1]/div[2]")));
                                waitt = false;
                                Thread.Sleep(4000);
                            }
                            catch (Exception)
                            {}
                        }
                       
                        driver.Navigate().GoToUrl("https://www.gate.io/web3/startup/1867");
                        conncetWallet(wait, driver, currentWindow);
                        voteAfterClick(wait, ref voted, ref val);
                        File.AppendAllText(baseDir + "output_web3.txt", i + "|" + voted + "|" + val + "|" + seeds[i] + "\n");

                        //fakeIP();
                        Thread.Sleep(40);



                    }
                    catch (Exception)
                    { }





                   
                    driver.Quit();

                }
                catch (Exception)
                { }
            }
            
        }


    
        private void conncetWallet(WebDriverWait wait, ChromeDriver driver, string currentWindow)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div/div[1]/section/div[1]/div[1]/button"))).Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[17]/div/div/div[2]/div/div[2]/div/div[2]/div[1]/div[2]/button"))).Click();
                bool loop = true;
                while (loop)
                {
                    Thread.Sleep(2000);
                    List<string> tabs = new List<string>(driver.WindowHandles);

                    foreach (var tab in tabs)
                    {
                        if (tab != currentWindow)
                        {
                            driver.SwitchTo().Window(tab);
                        }

                        try
                        {
                            // Tìm phần tử button với text "Connect" 
                            IWebElement connectButton = driver.FindElement(By.XPath("//span[text()='Connect']/.."));

                            // Nếu tìm thấy, thực hiện click và thoát vòng lặp 
                            connectButton.Click();
                            loop = false;
                            break;
                        }
                        catch (NoSuchElementException)
                        { }
                    }

                }
                driver.SwitchTo().Window(currentWindow);

            }
            catch (Exception)
            { }

        }
        private void create(object sender, RoutedEventArgs e)
        {
            string squidServerIp = "178.18.248.10"; // Thay thế bằng địa chỉ IP thực tế của bạn

            // Danh sách các proxy từ Squid với các cổng khác nhau
            List<string> proxyList = new List<string>();
            for (int i = 3128; i <= 3627; i++)
            {
                proxyList.Add($"http://{squidServerIp}:{i}");
            }
            var options = new ChromeOptions();
            string baseDir = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ref");
            baseDir += "\\";
            options.AddArgument(@"user-data-dir=C:\Users\Surface\Desktop\fuel_chrome\profile\");
            options.AddArgument("no-sandbox");
            options.AddArguments("start-maximized");
            options.AddArgument("profile-directory=Profile_temp");
            options.AddExtension(@"C:\Users\Surface\Desktop\temp\gateWallet.crx");
            // Xóa thư mục dữ liệu người dùng của Chrome


            string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string chromeUserDataPath = System.IO.Path.Combine(userProfile, @"C:\Users\Surface\Desktop\fuel_chrome\profile\Profile_temp");

            // Nếu thư mục tồn tại, xóa toàn bộ nội dung

            for (int i = 0; i <= 90; i++)
            {
                try
                {
                    string seed = "";
                    string proxyAddress = proxyList[i % proxyList.Count];  // Lặp lại danh sách proxy nếu cần

                    // Cấu hình proxy
                    Proxy proxy = new Proxy();
                    proxy.HttpProxy = proxyAddress;
                    proxy.SslProxy = proxyAddress;
                    options.Proxy = proxy;

                    /*do
                    {
                        try
                        {
                            Directory.Delete(chromeUserDataPath, true);
                        }
                        catch (Exception)
                        { }
                    } while (Directory.Exists(chromeUserDataPath));*/
                    ChromeDriver driver = new ChromeDriver(options);
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    string currentWindow = driver.CurrentWindowHandle;

                    driver.Navigate().GoToUrl("chrome-extension://cpmkedoipcpimgecpmgpldfpohjplkpp/popup.html");
                    try
                    {
                        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[2]/button/div"))).Click();
                        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[2]/div/div/div[1]"))).Click();
                        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[2]/div/div[1]/div/div[1]/div/input"))).SendKeys("Lop09876@");
                        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[2]/div/div[1]/div/div[2]/div/input"))).SendKeys("Lop09876@");
                        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[2]/div/div[2]/button/div"))).Click();
                        //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[2]/div/div[1]/div[2]/div/div/div/textarea"))).SendKeys(seeds[i]);
                        //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[2]/div/div[2]/button"))).Click();
                        bool waitt = true;
                        while (waitt)
                        {
                            try
                            {
                                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[3]/div[2]/div[3]/button[1]/div"))).Click();
                                waitt = false;
                                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[3]/div/div[2]/div[1]/div/input"))).SendKeys("Lop09876@");
                                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[3]/div/div[2]/div[2]/button[2]"))).Click();
                                Thread.Sleep(1000);

                            }
                            catch (Exception)
                            { }
                        }
                        try
                        {
                            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[2]/div/div/div[2]/div[1]"))).Click();
                            Thread.Sleep(1000);

                            for (int j = 0; j < 12; j++)
                            {
                                seed += wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[2]/div/div/div[2]/div[1]/span[" + (j+1).ToString() + "]/span[2]"))).Text + " ";

                            }
                            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[2]/div/div/div[3]/button"))).Click();

                            Thread.Sleep(1000);
                            for (int j = 1; j < 4; j++)
                            {
                                int slot = int.Parse(wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[2]/div/div/div[2]/div[1]/div[" + j + "]/p"))).Text.Split(' ')[1]);
                                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='" + seed.Split(' ')[slot - 1] + "']"))).Click();
                            }

                            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='Confirm']"))).Click();

                            Thread.Sleep(1500);
                            
                        }
                        catch (Exception)
                        { }
                       

                    }
                    catch (Exception)
                    { }
                    File.AppendAllText(baseDir + "output_web3.txt", i + "|" + seed + "\n");

                    driver.Quit();
                }
                catch (Exception)
                { }
            }

        }
        private void init()
        {
            var options = new ChromeOptions();
            string baseDir = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ref");
            baseDir += "\\";
            options.AddArgument(@"user-data-dir=C:\Users\Surface\Desktop\fuel_chrome\profile\");
            options.AddArgument("no-sandbox");
            options.AddArguments("start-maximized");
            options.AddArgument("profile-directory=Profile 0");
            int voted = 0;

            try
            {
                ChromeDriver driver = new ChromeDriver(options);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                string currentWindow = driver.CurrentWindowHandle;
                driver.Navigate().GoToUrl("https://www.gate.io/web3/startup");
                waitForWallet(wait);
                var claimNowButtons = driver.FindElements(By.XPath("//span[text()='Claim Now']/.."));
                var count = claimNowButtons.Count;

                for (int i = 0; i < count; i++)
                { 
                    try
                    {
                        waitForWallet(wait);
                        IWebElement claimNowButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='Claim Now']/..")));
                        claimNowButton.Click();
                        try
                        {
                            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[15]/div/div/div[2]/div/div[1]")));
                        }
                        catch (Exception)
                        {}
                        string destinationUrl = driver.Url.Split('?')[0];
                        File.AppendAllText(@"C:\Users\Surface\Desktop\fuel_chrome\gate3vote\main\bin\Debug\ref\input_web3.txt", destinationUrl + "\n");
                        driver.Navigate().GoToUrl(destinationUrl);
                        string temp = "";
                        voteAfterClick(wait,ref voted, ref temp);
                        driver.Navigate().GoToUrl("https://www.gate.io/web3/startup");

                    }
                    catch (Exception)
                    {}
                        
                }
                
                driver.Quit();

            }
            catch (Exception)
            { }            
        }
        private void ProcessClaimAndVote(IWebDriver driver, WebDriverWait wait, ref int voted)
        {
            driver.Navigate().GoToUrl("https://www.gate.io/web3/startup");
            waitForWallet(wait);
            var claimNowButtons = driver.FindElements(By.XPath("//span[text()='Claim Now']/.."));
            var count = claimNowButtons.Count;

            for (int i = 0; i < count; i++)
            {
                try
                {
                    IWebElement claimNowButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='Claim Now']/..")));
                    claimNowButton.Click();
                    try
                    {
                        wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[15]/div/div/div[2]/div/div[2]/div[2]/button")));
                    }
                    catch (Exception)
                    {}
                    string destinationUrl = driver.Url.Split('?')[0];
                    File.AppendAllText(@"C:\Users\Surface\Desktop\fuel_chrome\gate3vote\main\bin\Debug\ref\input_web3.txt", destinationUrl + "\n");
                    driver.Navigate().GoToUrl(destinationUrl);
                    string temp = "";
                    voteAfterClick(wait, ref voted, ref temp);
                    driver.Navigate().GoToUrl("https://www.gate.io/web3/startup");
                    waitForWallet(wait);

                }
                catch (Exception)
                {
                    // Xử lý lỗi (nếu cần)
                }
            }
        }
        private void waitForWallet(WebDriverWait wait)
        {
            bool connected = false;
            while (!connected)
            {
                try
                {
                    wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[1]/div/div[1]/section/div[1]/div[1]/div/div")));
                    connected = true;
                }
                catch (Exception)
                { }
            }
            Thread.Sleep(1500);
        }
        private void voteAfterClick(WebDriverWait wait, ref int voted, ref string val)
        {
            waitForWallet(wait);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[.//span[text()='Claim Now']]"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[15]/div/div/div[2]/div/div[2]/div[1]/div[2]/div/div/div"))).Click();
            //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/div[1]/div[2]/div/div[3]/div/div[2]/div/button"))).Click();
            //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[15]/div/div/div[2]/div/div[2]/div[1]/div[2]/div/div/div"))).Click();

            try
            {
                if (voted == 0)
                {
                    val = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[15]/div/div/div[2]/div/div[2]/div[1]/div[1]/div[1]/div[3]/div[2]"))).Text;
                }
            }
            catch (Exception)
            {}
            
            //val = driver.FindElement(By.XPath("/html/body/div[15]/div/div/div[2]/div/div[2]/div[1]/div[1]/div[1]/div[3]/div[2]")).Text;
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[15]/div/div/div[2]/div/div[2]/div[2]/button"))).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[9]/div/div/div[2]/div/div[2]/div[1]/div/div[2]/div")));
            voted++;
        }
        private string getIpV4()
        {
            try
            {
                Thread.Sleep(1500);
                WebClient client = new WebClient();
                string publicIP = client.DownloadString("https://ipv4.icanhazip.com/");
                return publicIP;    
            }
            catch (Exception)
            {
                return getIpV4();
                //return "NaN\n";    
            }
        }
        private void doubleCheck(object sender, RoutedEventArgs e)
        {
            var options = new ChromeOptions();
            string baseDir = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ref");
            baseDir += "\\";
            options.AddArgument(@"user-data-dir=C:\Users\Surface\Desktop\fuel_chrome\profile\");
            options.AddArgument("no-sandbox");
            options.AddArguments("start-maximized");
            string[] dataa = System.IO.File.ReadAllLines(baseDir + "output_web3.txt");
            for (int i = 0; i < dataa.Length; i++)
            {
                if (dataa[i].Split('|')[2]!="10")
                {
                    try
                    {

                        options.AddArgument("profile-directory=Profile " + dataa[i].Split('|')[0]);
                        ChromeDriver driver = new ChromeDriver(options);
                        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                        string currentWindow = driver.CurrentWindowHandle;
                        int voted = 0;

                        try
                        {

                            driver.SwitchTo().Window(currentWindow);
                           
                            try
                            {
                                ProcessClaimAndVote(driver, wait, ref voted);
                                fakeIP();
                            }
                            catch (Exception)
                            {}

                        }
                        catch (Exception)
                        { }
                        driver.Quit();
                    }
                    catch (Exception)
                    {
                        Thread.Sleep(500);
                    }
                }
             
            }

        }

        private void fakeIP()
        {
                ExecuteAdbCommand("adb shell cmd connectivity airplane-mode enable");
                Thread.Sleep(500);
                ExecuteAdbCommand("adb shell cmd connectivity airplane-mode disable");
                ExecuteAdbCommand("adb shell svc data disable");
                Thread.Sleep(500);
                ExecuteAdbCommand("adb shell svc data enable");
                Thread.Sleep(1000);

        }
        private void openChrome(object sender, RoutedEventArgs e)
        {
            var options = new ChromeOptions();
            string baseDir = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ref");
            baseDir += "\\";
            options.AddArgument(@"user-data-dir=C:\Users\Surface\Desktop\fuel_chrome\profile\");
            options.AddArgument("no-sandbox");
            options.AddArguments("start-maximized");
            for (int index_profile = 0; index_profile < 97; index_profile++)//97
            { 
                try
                {

                    options.AddArgument("profile-directory=Profile " + index_profile.ToString());
                    ChromeDriver driver = new ChromeDriver(options);
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    string currentWindow = driver.CurrentWindowHandle;
                    driver.Quit();

                }
                catch (Exception)
                { }
            }
        }
        private void fakeIP_(object sender, RoutedEventArgs e)
        {
            ExecuteAdbCommand("adb shell cmd connectivity airplane-mode enable");
            Thread.Sleep(500);
            ExecuteAdbCommand("adb shell cmd connectivity airplane-mode disable");
            ExecuteAdbCommand("adb shell svc data disable");
            Thread.Sleep(500);
            ExecuteAdbCommand("adb shell svc data enable");
            Thread.Sleep(1000);

        }
        private void ExecuteAdbCommand(string command)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                RedirectStandardInput = true,
                UseShellExecute = false
            };

            Process process = new Process { StartInfo = startInfo };
            process.Start();

            process.StandardInput.WriteLine(command);
            process.StandardInput.Flush();
            process.StandardInput.Close();
            process.WaitForExit();
        }

        private async void ImportAsync(object sender, RoutedEventArgs e)
        {
            string[] seeds = System.IO.File.ReadAllLines(@"C:\Users\Surface\Desktop\fuel_chrome\gate3vote\main\seedss.txt");

            int n = 3; // Số luồng cần chạy song song
            List<Task> tasks = new List<Task>();

            for (int i = 0; i < n; i++)
            {
                // Khởi tạo mỗi luồng với một profile tương ứng
                int index = i; // Lưu lại giá trị của i
                tasks.Add(Task.Run(() => RunSeleniumForSeeds(seeds, index, n)));
            }

            // Chờ tất cả các luồng hoàn thành
            await Task.WhenAll(tasks);

            Console.WriteLine("Tất cả các luồng đã hoàn thành!");
        }

        private void RunSeleniumForSeeds(string[] seeds, int index, int n)
        {
            // Tạo một danh sách các thư mục profile cho các luồng
            string[] profiles = new string[n];
            for (int i = 0; i < n; i++)
            {
                profiles[i] = $@"A:\profile{i + 1}";
            }

            // Xử lý các seeds được chỉ định cho luồng này
            for (int i = index; i < seeds.Length; i += n)
            {
                string seed = seeds[i];

                // Thiết lập các tùy chọn của Chrome cho mỗi luồng
                var options = new ChromeOptions();
                string baseDir = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ref");
                baseDir += "\\";

                // Sử dụng profile tương ứng cho luồng này
                string profileDir = profiles[index % n];
                options.AddArgument($"user-data-dir={profileDir}");
                options.AddArgument("no-sandbox");
                options.AddArguments("start-maximized");
                options.AddArgument($"profile-directory=Profile_temp");  // Profile riêng cho mỗi luồng
                options.AddExtension(@"C:\Users\Surface\Desktop\temp\gateWallet.crx");

                // Vòng lặp để chạy Selenium với mỗi seed
                try
                {
                 

                    do
                    {
                        try
                        {
                            Directory.Delete(profileDir + @"\Profile_temp", true);
                        }
                        catch (Exception)
                        { }

                    } while (Directory.Exists(profileDir + @"\Profile_temp"));
                    // Khởi tạo ChromeDriver
                    using (ChromeDriver driver = new ChromeDriver(options))
                    {
                        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                        string currentWindow = driver.CurrentWindowHandle;

                        driver.Navigate().GoToUrl("chrome-extension://cpmkedoipcpimgecpmgpldfpohjplkpp/popup.html");
                        int voted = 0;
                        string val = "";

                        // Tiến hành các thao tác WebDriver (như trong hàm import ban đầu)
                        try
                        {
                            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[2]/button"))).Click();
                            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[2]/div/div/div[3]/div[1]"))).Click();
                            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[2]/div/div[1]/div/div[1]/div/input"))).SendKeys("Lop09876@");
                            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[2]/div/div[1]/div/div[2]/div/input"))).SendKeys("Lop09876@");
                            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[2]/div/div[2]/button/div"))).Click();
                            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[2]/div/div[1]/div[2]/div/div/div/textarea"))).SendKeys(seed);
                            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[2]/main/div/div[2]/div/div[2]/button"))).Click();

                            // Chờ một số điều kiện nhất định
                            bool waitt = true;
                            while (waitt)
                            {
                                try
                                {
                                    wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[1]/div[2]/main/div/div[1]/div/div[1]/div[2]")));
                                    waitt = false;
                                    Thread.Sleep(4000);
                                }
                                catch (Exception)
                                {
                                }
                            }

                            // Truy cập trang đích để thực hiện vote
                            driver.Navigate().GoToUrl("https://www.gate.io/web3/startup/1835");
                            conncetWallet(wait, driver, currentWindow);
                            voteAfterClick(wait, ref voted, ref val);

                            // Ghi kết quả vào file (cần đồng bộ hóa khi truy cập tài nguyên dùng chung)
                            lock (baseDir)
                            {
                                File.AppendAllText(baseDir + "output_web3.txt", i + "|" + seed + "|" + val + "|" + voted + "\n");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Task {index} gặp lỗi: {ex.Message}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Task {index} không thể chạy: {ex.Message}");
                }
            }
        }

    }

}



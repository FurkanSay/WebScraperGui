using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraperGui.Configuration
{
    public class WebDriverConfiguration
    {
        public static List<ChromeDriver> driverlist = new List<ChromeDriver> { };
        public WebDriverConfiguration(int count,string path = "") {
            if (string.IsNullOrEmpty(path)) path = "C:\\Users\\admin\\AppData\\Local\\Google\\Chrome\\User Data\\Default";
            ChromeOptions options = new ChromeOptions();
            string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/123.0.4567.89 Safari/537.36";
            options.AddArgument($"--user-agent={userAgent}");
           // options.AddArgument($"user-data-dir={path}");
            options.AddArgument("--silent");
            options.AddArgument("--log-level=3");
             //options.AddArgument("--incognito");// gizlilik
            var chromeDriverPath = Path.Combine(Directory.GetCurrentDirectory(), "chromedriver.exe");
            for (int i = 0; i < count; i++)
            {
                ChromeDriver driver = new ChromeDriver(chromeDriverPath, options);
                driverlist.Add(driver);
            }
        }
        public List<ChromeDriver> GetDriver() {
            return driverlist;
        }
    }
}

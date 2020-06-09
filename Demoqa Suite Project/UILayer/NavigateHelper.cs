using Demoqa_Suite_Project.Utils;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Demoqa_Suite_Project.PageHelper
{
    class NavigateHelper
    {
       
        public static RemoteWebDriver NavigateDemoqa(string type)
        {
            DriverUtils driverUtils = new DriverUtils();
            RemoteWebDriver driver = driverUtils.GetDriver(type);
            driver.Navigate().GoToUrl("http://demoqa.com/");
            return driver;

        }

        public static RemoteWebDriver NavigateDemoqa()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            RemoteWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
            driver.Navigate().GoToUrl("http://demoqa.com/");
            return driver;
        }
    }
}

using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demoqa_Suite_Project.PageHelper
{
    class Common
    {
        public WebDriverWait Wait(RemoteWebDriver driver)
        { 
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            return wait;
        }
    }
}

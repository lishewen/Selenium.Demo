using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Demo
{
    public static class LoginEx
    {
        public static bool Login(this EdgeDriver browser)
        {
            // 发起请求前先移除Chrome的window.navigator.webdriver参数，并随机等待，减少被检测的风险
            IJavaScriptExecutor js = browser;
            string returnjs = (string)js.ExecuteScript("Object.defineProperties(navigator, {webdriver:{get:()=>undefined}});");

            browser.Navigate().GoToUrl("https://pc.xuexi.cn/points/my-points.html");
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement qglogin = browser.FindElement(By.Id("qglogin"));
            browser.ExecuteScript("arguments[0].scrollIntoView();", qglogin);

            for (int i = 0; i < 60; i++)
            {
                if (browser.Url == "https://pc.xuexi.cn/points/my-points.html")
                {
                    Console.WriteLine("--> 登录成功");
                    return true;
                }
                Thread.Sleep(5 * 1000);
            }
            return false;
        }
    }
}

// See https://aka.ms/new-console-template for more information
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using Selenium.Demo;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

Console.WriteLine("Hello, World!");

new DriverManager().SetUpDriver(new EdgeConfig());

var options = new EdgeOptions();
// 防止检测
options.AddExcludedArgument("enable-automation");
options.AddAdditionalOption("useAutomationExtension", false);

options.AddArgument("--mute-audio"); // 静音
//options.AddAdditionalOption("excludeSwitches", new string[] { "enable-logging" }); // 禁止打印日志
options.AddArgument("--ignore-certificate-errors"); // 忽略证书错误
options.AddArgument("--ignore-ssl-errors"); // 忽略ssl错误
options.AddArgument("–log-level=3");

var driver = new EdgeDriver(options);

// 窗口最大化
driver.Manage().Window.Maximize();

// 登录
driver.Login();

// Todo:操作

// 关闭浏览器
// driver.Quit();
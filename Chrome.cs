using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using Keys = OpenQA.Selenium.Keys;

class Chrome
{
    public IJavaScriptExecutor Js;
    public IWebDriver Driver;
    private ChromeOptions Options;
    private ChromeDriverService Services;
    private WebDriverWait wait;
    private bool isClean;
    private Actions actions;

    public Chrome(bool clear = false)
    {
        string chromeDir = Environment.CurrentDirectory + @"\Chrome";
        if (clear) ClearChrome(chromeDir);
        SetServices();
        SetOptions(chromeDir);
        Driver = new ChromeDriver(Services, Options);
        Js = (IJavaScriptExecutor)Driver;
        actions = new Actions(Driver);
    }

    public Chrome(string directory, bool clear = false)
    {
        if (clear) ClearChrome(directory);
        SetServices();
        SetOptions(directory);
        Driver = new ChromeDriver(Services, Options);
        Js = (IJavaScriptExecutor)Driver;
        actions = new Actions(Driver);
    }

    public Chrome(string directory, string useragent, bool clear = false)
    {
        if(clear) ClearChrome(directory);
        SetServices();
        SetOptions(directory, useragent);
        Driver = new ChromeDriver(Services, Options);
        Js = (IJavaScriptExecutor)Driver;
        actions = new Actions(Driver);
    }

    public Chrome(string directory, string useragent, string proxy, bool clear = false)
    {
        ClearChrome(directory);
        SetServices();
        SetOptions(directory, useragent, proxy);
        Driver = new ChromeDriver(Services, Options);
        Js = (IJavaScriptExecutor)Driver;
        actions = new Actions(Driver);
    }

    public void GoToURL(string url, int sleep = 3000)
    {
        if (Driver == null)
        {
            return;
        }
        try
        {
            Driver.Navigate().GoToUrl(url);
            Thread.Sleep(3000);
        }
        catch { }
    }

    public void GoToURL(string url, string contain, int sleep = 3000)
    {
        if (Driver == null)
        {
            return;
        }
        GoToURL(url, sleep);
        while (Driver.Url.IndexOf(contain) == -1)
        {
            GoToURL(url, sleep);
        }
        if(Driver.FindElements(By.Id("main-frame-error")).Count > 0)
        {
            Driver.Navigate().Refresh();
        }
    }

    public void SwitchToFrame(string selector, int pos = 0)
    {
        var element = Driver.FindElements(By.CssSelector(selector))[pos];
        Driver.SwitchTo().Frame(element);
    }

    public void SwitchToParentFrame()
    {
        Driver.SwitchTo().ParentFrame();
    }

    public void SwitchToDefaultContent()
    {
        Driver.SwitchTo().DefaultContent();
    }

    public string UserAgent()
    {
        var path = Environment.CurrentDirectory + @"\useragent.txt";
        if (!File.Exists(path))
        {
            return null;
        }
        var lines = File.ReadAllLines(path);
        var r = new Random();
        var randomLineNumber = r.Next(0, lines.Length - 1);
        var line = lines[randomLineNumber];
        return line;
    }

    void ClearChrome(string directory = null)
    {
        if (isClean) return;
        if (Driver != null)
        {
            try
            {
                Driver.Close();
                Driver.Quit();
                Driver.Dispose();
            }
            catch { }
            Driver = null;
        }

        Process[] bProcess2 = Process.GetProcessesByName("chromedriver");
        if (bProcess2.Length > 0)
        {
            foreach (var proc in bProcess2)
            {
                try
                {
                    proc.Kill();
                }
                catch { }
            }
            Thread.Sleep(1000);
        }

        Process[] bProcess = Process.GetProcessesByName("chrome");
        if (bProcess.Length > 0)
        {
            foreach (var proc in bProcess)
            {
                try
                {
                    proc.Kill();
                }
                catch { }
            }
            Thread.Sleep(1000);
        }

        while (Directory.Exists(directory))
        {
            try
            {
                Directory.Delete(directory, true);
            }
            catch { }
        }
        isClean = true;
    }

    void SetServices()
    {
        Services = ChromeDriverService.CreateDefaultService(Environment.CurrentDirectory);
        Services.HideCommandPromptWindow = true;
    }

    void SetOptions(string chromeDir = null, string useragent = null, string proxy = null)
    {
        if (string.IsNullOrEmpty(useragent))
        {
            useragent = UserAgent();
        }
        if (string.IsNullOrEmpty(chromeDir))
        {
            chromeDir = Environment.CurrentDirectory+@"\Chrome";
        }
        Options = new ChromeOptions();
        Options.AddArgument("--no-sandbox");
        Options.AddArgument("--disable-gpu");
        Options.AddArgument("--disable-popup-blocking");
        Options.AddArgument("--disable-default-apps");
        //Options.AddArgument("--blink-settings=imagesEnabled=false");
        Options.AddExcludedArgument("enable-automation");
        Options.AddAdditionalCapability("useAutomationExtension", false);
        Options.AddArgument("--disable-infobars");
        if (!string.IsNullOrEmpty(useragent))
        {
            Options.AddArgument("--user-agent=" + useragent);
        }
        if (!string.IsNullOrEmpty(proxy))
        {
            Options.AddArgument("--proxy-server="+ proxy);
            Options.AddArgument("ignore-certificate-errors");
        }
        Options.AddArgument("user-data-dir=" + chromeDir);
    }

    public void OpenNewTab(bool switchTo = true)
    {
        Js.ExecuteScript("window.open();");
        if (switchTo)
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
    }

    public bool Wait(string selector, int seconds, int time = 1)
    {
        By by = By.CssSelector(selector);
        return Wait(by, seconds, time);
    }


    public bool Wait(string selector, int pos, string action, int seconds, int time = 1)
    {
        By by = By.CssSelector(selector);
        return Wait(by, pos, action, seconds, time);
    }

    public bool Wait(By by, int seconds, int time = 1)
    {
        if (Driver == null)
        {
            return false;
        }
        try
        {
            if (seconds < 0) seconds = 30;
            int i = 1;
            if (time < 0) time = 10;
            while (i <= time)
            {
                i++;
                wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
                try
                {
                    return wait.Until<bool>(drv => drv.FindElement(by).Displayed == true);
                }
                catch { }
            }
            return false;
        }
        catch (Exception e)
        {
        }
        return false;
    }

    public bool Wait(By by , string action, int seconds, int time = 1)
    {
        if (Driver == null)
        {
            return false;
        }
        try
        {
            if (seconds < 0) seconds = 30;
            int i = 1;
            if (time < 0) time = 10;
            while (i <= time)
            {
                i++;
                wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
                try
                {
                    switch (action)
                    {
                        case "Enabled":
                            return wait.Until<bool>(drv => drv.FindElement(by).Enabled);
                        case "Displayed":
                            return wait.Until<bool>(drv => drv.FindElement(by).Displayed);
                        case "Selected":
                            return wait.Until<bool>(drv => drv.FindElement(by).Selected);
                        default:
                            return wait.Until<bool>(drv => drv.FindElements(by).Count > 0);
                    }                        
                }
                catch { }
            }
            return false;
        }
        catch (Exception e)
        {    }
        return false;
    }

    public bool Wait(By by, int pos, string action, int seconds, int time = 1)
    {
        if (Driver == null)
        {
            return false;
        }
        try
        {
            if (seconds < 0) seconds = 30;
            int i = 1;
            if (time < 0) time = 10;
            while (i <= time)
            {
                i++;
                if (Driver.FindElements(by).Count < pos) {
                    Thread.Sleep(seconds*1000);
                    continue;
                };
                wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
                try
                {
                    switch (action)
                    {
                        case "Enabled":
                            return wait.Until<bool>(drv => drv.FindElements(by)[pos].Enabled);
                        case "Displayed":
                            return wait.Until<bool>(drv => drv.FindElements(by)[pos].Displayed);
                        case "Selected":
                            return wait.Until<bool>(drv => drv.FindElements(by)[pos].Selected);
                        default:
                            return wait.Until<bool>(drv => drv.FindElements(by).Count > 0);
                    }
                }
                catch { }
            }
            return false;
        }
        catch (Exception e)
        {
        }
        return false;
    }
    public bool Click(string selector, int pos = 0)
    {
        By by = By.CssSelector(selector);
        return Click(by, pos);
    }
    public bool Click(By by, int pos = 0)
    {
        if (Driver == null)
        {
            return false;
        }
        if (Wait(by, pos, "Enabled", 5))
        {
            try
            {
                var elms = Driver.FindElements(by);
                if(elms.Count > pos)
                    elms[pos].Click();
                return true;
            }
            catch { }
        }
        return false;
    }
    public bool TryClick(string selector, int pos = 0)
    {
        return TryClick(By.CssSelector(selector),pos);

    }

    public bool TryClick(By by, int pos = 0)
    {
        if (Driver == null)
        {
            return false;
        }
        if (Wait(by, pos, 5))
        {
            try
            {
                var elm = Driver.FindElements(by)[pos];

                actions.MoveToElement(elm, 0, 0, MoveToElementOffsetOrigin.Center).Click().Perform();
                return true;
            }
            catch
            {
                return false;
            }
        }
        return false;
    }

    public bool SendKeys(string selector, string text, int pos = 0, bool isClear = true, bool isSubmit = true, int speed = 0)
    {
        By by = By.CssSelector(selector);
        return SendKeys(by,text,pos,isClear,isSubmit, speed);
    }

    public bool SendKeys(By by, string text, int pos = 0, bool isClear = true, bool isSubmit = true, int speed = 0)
    {
        if (Driver == null)
        {
            return false;
        }
        if (Wait(by, pos, "Displayed", 10))
        {
            try
            {
                var elm = Driver.FindElements(by)[pos];
                if(isClear) elm.Clear();
                if (speed > 0)
                {
                    foreach (var character in text)
                    {
                        elm.SendKeys(character.ToString());
                        Thread.Sleep(speed);
                    }
                }
                else
                {
                    elm.SendKeys(text);
                }
                Thread.Sleep(1500);
                if (isSubmit) elm.SendKeys(Keys.Enter);
                return true;
            }
            catch { }
        }
        return false;
    }

    public bool TrySendKeys(string text, By by, int pos = 0, bool isClear = true, bool isSubmit = true)
    {
        if (Driver == null)
        {
            return false;
        }
        if (Wait(by, pos, "Displayed", 5))
        {
            try
            {

                var elm = Driver.FindElements(by)[pos];
                actions.MoveToElement(elm, 0, 0, MoveToElementOffsetOrigin.Center).Perform();
                if (isClear)
                {
                    actions.SendKeys(Keys.Control + "a");
                    Thread.Sleep(1000);
                    actions.SendKeys(Keys.Backspace);
                    Thread.Sleep(1000);
                }
                actions.SendKeys(elm, text);
                if (isSubmit)
                {
                    Thread.Sleep(1000);
                    actions.SendKeys(Keys.Enter);
                }
                actions.Perform();
                return true;
            }
            catch
            {
                return false;
            }
        }
        return false;
    }
    public bool TrySendKeys(string text, bool isClear = true, bool isSubmit = true)
    {
        if (Driver == null)
        {
            return false;
        }
        try
        {
            if (isClear)
            {
                actions.SendKeys(Keys.Control + "a");
                Thread.Sleep(1000);
                actions.SendKeys(Keys.Backspace);
                Thread.Sleep(1000);
            }
            actions.SendKeys(text);
            if (isSubmit)
            {
                Thread.Sleep(1000);
                actions.SendKeys(Keys.Enter);
            }
            actions.Perform();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public int CountElements(string selector)
    {
        By by = By.CssSelector(selector);
        return CountElements(by);
    }

    public int CountElements(By by)
    {
        if (Driver == null)
        {
            return 0;
        }
        return Driver.FindElements(by).Count();
    }

    public void Close()
    {
        if(Driver == null)
        {
            return;
        }
        Driver.Close();
    }

    public void Quit()
    {
        if (Driver == null)
        {
            return;
        }
        Driver.Quit();
        Driver.Dispose();
    }

    public string Url { get=>Driver.Url;}

    public INavigation Navigate()
    {
        return Driver.Navigate();
    }

    public System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> FindElements(string selector)
    {
        return Driver.FindElements(By.CssSelector(selector));
    }

    public System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> FindElements(By by)
    {
        return Driver.FindElements(by);
    }

    public IWebElement FindElement(string selector)
    {
        return Driver.FindElement(By.CssSelector(selector));
    }

    public IWebElement FindElement(By by)
    {
        return Driver.FindElement(by);
    }

    public string getText(string selector, int pos = 0)
    {
        var element = Driver.FindElements(By.CssSelector(selector))[pos];
        return element.Text;
    }

    public void Scroll(int pixel = 500)
    {
        Js.ExecuteScript("window.scrollBy(0,"+ pixel + ")");
    }

    public void DragAndDrop(string source, string target, int pos = 0)
    {
        actions = new Actions(Driver);
        var elmSource = Driver.FindElement(By.CssSelector(source));
        var elmTarget = Driver.FindElements(By.CssSelector(target))[pos];
        actions.ClickAndHold(elmSource).MoveToElement(elmTarget,0,0, MoveToElementOffsetOrigin.Center).Release().Build().Perform();
        actions = new Actions(Driver);
    }
}


using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GittigidiyorBDD.Base
{
    public class BaseTest
    {
        IWebDriver webDriver;

        public void SetUp()
        {
            string driverPath = Path.Combine(@"c:\users\cihatd\source\repos\IntertechDemo\IntertechDemo\Driver\");

            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("start-maximized");
            chromeOptions.AddArguments("test-type");
            chromeOptions.AddArguments("disable-popup-blocking");
            chromeOptions.AddArguments("ignore-certificate-errors");
            chromeOptions.AddArguments("disable-translate");
            chromeOptions.AddArguments("disable-automatic-password-saving");
            chromeOptions.AddArguments("allow-silent-push");
            chromeOptions.AddArguments("disable-infobars");
            chromeOptions.AddArguments("disable-notification");

            webDriver= new ChromeDriver(driverPath, chromeOptions);

        }

        public IWebElement FindElement(By by)
        {
            UntilElementAppear(by);
            return webDriver.FindElement(by);
        }

        /*SendKey*/
        public void SendKeys(By by, string text)
        {
            FindElement(by).Clear();
            FindElement(by).SendKeys(text);
        }


        public IJavaScriptExecutor GetScriptExecutor()
        {
            return (IJavaScriptExecutor)webDriver;
        }
        public Boolean IsElementDisplayed(By by)
        {
            try
            {
                return FindElement(by).Displayed;
            }
            catch (Exception ex)
            {
                return false;

            }

        }
        public void Navigate(string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }


        public void ScrollTo(int x, int y)
        {
            var js = String.Format("window.scrollTo({0}, {1})", x, y);
            GetScriptExecutor().ExecuteScript(js, true);
        }

        /*Click*/
        public void ClickElement(By by)
        {

            IWebElement element = FindElement(by);
            if (!IsElementDisplayed(by))
            {
                ScrollTo(element.Location.X, element.Location.Y);
            }


            UntilElementAppear(by);
            UntilElementClickable(by);
            GetScriptExecutor().ExecuteScript("arguments[0].setAttribute('style','background: yellow; border: 2px solid red;');", element); /*Tıklanılan elementleri boyar*/
            element.Click();
        }

        /*Elementin üzerine gelme*/
        public void HoverElement(By by)
        {
            Actions hoverAction = new Actions(webDriver);
            hoverAction.MoveToElement(FindElement(by)).Build().Perform();
        }

        public string GetText(By by)
        {
            return FindElement(by).Text;
        }

        /*Listboxdaki değeri yazdırma*/
        public void SelectOptionByText(By by, string text)
        {
            SelectElement selectElement = new SelectElement(FindElement(by));
            selectElement.SelectByText(text);
        }

        /*var olana kadar bekle*/
        public void UntilElementAppear(By by)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));

        }

        /*kaybolana kadar bekle*/
        public void UntilElementDisappear(By by)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(by));

        }

        /*tıklanabilir olana kadar bekle*/
        public void UntilElementClickable(By by)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));

        }

        /*görünür olana kadar bekle*/
        public void UntilElementDisplayed(By by)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));

        }

        /*elementin görünür olup olmadığını kontrol eder*/

    }
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GittigidiyorBDD.Base;

namespace GittigidiyorBDD.Page
{
    public class LoginPage : BaseTest
    {
       
        public void SetChrome()
        {
            SetUp();
        }

        public void SetUrl(string url)
        {
            Navigate(url);
        }

        public void clickLoginButton()
        {
            ClickElement(By.ClassName("afterLoginURL"));
        }

        internal void clickFindButton()
        {
            ClickElement(By.Id("header-search-find-link"));
        }

        internal void clickFirstProduct()
        {
            ClickElement(By.Id("product_id_450045462"));
        }

        internal void SearchText(string p1)
        {
            SendKeys(By.Id("search_word"), p1);
        }

        internal void clickFirstProductBuyNow()
        {
            ClickElement(By.Id("buy-now"));
        }

        internal void clickLogin()
        {
            ClickElement(By.Id("gg-login-enter"));
        }

        internal void closeSubscribePopup()
        {
            ClickElement(By.Id("gg-subscribe-close-button"));
        }

        public void setUserInfo()
        {
            SendKeys(By.Id("L-UserNameField"), "walter_bishop@hotmail.com");
            SendKeys(By.Id("L-PasswordField"), "Chat153795");
         
        }
    }
}

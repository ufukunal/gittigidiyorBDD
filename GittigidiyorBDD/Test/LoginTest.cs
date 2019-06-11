using GittigidiyorBDD.Page;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace GittigidiyorBDD.Test
{
    [Binding]
    public class LoginTest
    {
        LoginPage loginPage = new LoginPage();

        [StepDefinition(@"Chrome ayarları yapılır")]
        public void ChromeAyarlarıYapılır()
        {
            loginPage.SetChrome();
        }
     
        [StepDefinition(@"Bul butonuna tıklanır")]
        public void ClickFindButton()
        {
            loginPage.clickFindButton();
        }

        [StepDefinition(@"İlk ürüne tıklanır")]
        public void ClickFirstProduct()
        {
            loginPage.clickFirstProduct();
        }

        [StepDefinition(@"İlk ürünü hemen al butonuna tıklanır")]
        public void ClickFirstProductBuyNow()
        {
            loginPage.clickFirstProductBuyNow();
        }

        [StepDefinition(@"Arama alanına '(.*)' yazılır")]
        public void SetText(string p1)
        {
            loginPage.SearchText(p1);
        }

        [StepDefinition(@"Login butonuna tıklanır")]
        public void LoginButonunaTıklanır()
        {
            loginPage.clickLogin();
        }

        [StepDefinition(@"Firsatlar popupı kapatılır")]
        public void FirsatlarPopupıKapatlır()
        {
            loginPage.closeSubscribePopup();
        }
        
        [StepDefinition(@"Gittigidiyor açılır")]
        public void GittigidiyorAcılır()
        {
            loginPage.SetUrl("https://www.gittigidiyor.com/");
        }

        [StepDefinition(@"Giriş yap butonuna  tıklanır")]
        public void GirisYapButonunaTıklanır()
        {
            loginPage.clickLoginButton();
        }
        
        [StepDefinition(@"Kullanıcı bilgileri girilir")]
        public void KullanıcıBilgileriGirilir()
        {
            loginPage.setUserInfo();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using GeoApteka_Daily.WebPageElements;
using System.Drawing;
using System.Drawing.Imaging;
using OpenQA.Selenium.Support.Extensions;



namespace GeoApteka_Daily
{
    [TestFixture]
    public class GeoAptekaDataPresence
    {
        [Test]
        public void IsDataPresent()
        {
            var firefox = new FirefoxDriver();
            firefox.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
            var pageElements = new PageElements(firefox);

            firefox.Navigate().GoToUrl("http://pharmxplorer.com.ua/572");

            var loginElement = pageElements.LoginElement;
            var passwordElement = pageElements.PasswordElement;
            var loginButton = pageElements.LoginButton;
            loginElement.SendKeys("");                      //ENTER LOGIN
            passwordElement.SendKeys("");                   //ENTER PASSWORD
            loginButton.Click();

            firefox.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(10));

            var dateDropDownButton = pageElements.DateDropDownButton;
            dateDropDownButton.Click();
            System.Threading.Thread.Sleep(7000);

            var lastDate = pageElements.LastDate;
            lastDate.Click();
            System.Threading.Thread.Sleep(5000);
            var choosenDate = pageElements.ChoosenDate;
            //System.Threading.Thread.Sleep(7000);
            //Assert.AreEqual("27.04.2016", choosenDate.Text);

            System.Threading.Thread.Sleep(5000);

            ITakesScreenshot screenshotDriver = firefox as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            String fp = "D:\\" + "snapshot" + ".png";
            screenshot.SaveAsFile(fp, ImageFormat.Png);
            

            pageElements.email_send();


            firefox.Quit();

        }
    }
}

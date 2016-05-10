using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Net;
using System.Net.Mail;


namespace GeoApteka_Daily.WebPageElements
{
    public class PageElements
    {
        private readonly FirefoxDriver _firefox;

        public PageElements(FirefoxDriver firefox)
        {
            _firefox = firefox;

        }

        public IWebElement LoginElement
        {
            get { return _firefox.FindElement(By.Id("username")); }
        }
        public IWebElement PasswordElement
        {
            get { return _firefox.FindElement(By.Id("password")); }
        }

        public IWebElement LoginButton
        {
            get { return _firefox.FindElement(By.Id("submit")); }
        }

        public IWebElement DateDropDownButton
        {
            get { return _firefox.FindElement(By.CssSelector("img.Qv_CellIcon_right")); }
        }
        public IWebElement LastDate
        {
            get { return _firefox.FindElement(By.XPath(".//*[@id='DS']/div/div/div[1]/div[1]/div[1]")); }
        }

        public IWebElement ChoosenDate
        {
            get { return _firefox.FindElement(By.CssSelector(".QvSliderObject>table>tbody>tr>td")); }
        }

        public void email_send()
        {
            var mail = new MailMessage();
            var smtpServer = new SmtpClient("post.morion.ua");
            mail.From = new MailAddress("snizhana.nomirovska@proximaresearch.com");
            mail.To.Add("snizhana.nomirovska@proximaresearch.com");
           // mail.To.Add("nataly.tenkova@proximaresearch.com");
            mail.Subject = "Test Mail - 1";
            mail.Body = "mail with attachment";

            var attachment = new Attachment("d:/snapshot.png");
            mail.Attachments.Add(attachment);


            //smtpServer.Port = 110;
            //smtpServer.Credentials = new NetworkCredential("snizhana.nomirovska@proximaresearch.com", "s.nomirovska2016");
            //smtpServer.EnableSsl = true;

            smtpServer.Send(mail);

        }

    }
}

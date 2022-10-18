using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using UITests.Utils;

namespace UITests.PageObjects
{
    class MainMenuPageObject : BaseTest
    {
        public MainMenuPageObject() : base()
        {
        }

        [FindsBy(How = How.CssSelector, Using = "button[class='button button--primary button--large button--block button button--primary'] span[class='button__text']")]
        private IWebElement _acceptCookie { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[rel='nofollow'] span[class='nav__link-text']")]
        private IWebElement _sighInButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@d,'M12 18a6 6')]")]
        private IWebElement _profile { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[class='button button--secondary button--block'] span[class='button__text']")]
        private IWebElement _showCatalogButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='listing__items']//h3[1]")]
        private IWebElement _nameOfCar { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='https://av.by/support']")]
        private IWebElement _askQuestion { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='https://www.instagram.com/insta_avby/']")]
        private IWebElement _goToInstagram { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='https://av.by/pages/faq']")]
        private IWebElement _mostPopularQuestions { get; set; }

        [FindsBy(How = How.XPath, Using = "//u[normalize-space()='info@av.by']")]
        private IWebElement _infoEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='https://av.by/profile/saved-filters']")]
        private IWebElement _saveSearchList { get; set; }

        [FindsBy(How = How.XPath, Using = "   //div[@id='adfox_163240379968878578']//a//img")]
        private IWebElement _banner { get; set; }

        public void AcceptCookie()
        {
            _acceptCookie.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void ClickOnSignInButton()
        {
            _banner.WaitElementToBeClickable(_webDriver, 10);
            _sighInButton.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void ClickOnProfileIcon()
        {
            _profile.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void ClickOnShowCalatogButton()
        {
            _showCatalogButton.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void WaitCarNameAppeared()
        {
            _nameOfCar.WaitElementToBeClickable(_webDriver, 10);
        }

        public void ClickOnInstagramm()
        {
            _goToInstagram.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void ClickOnAskQuestionsButton()
        {
            _askQuestion.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void ChooseMostPopularQuestions()
        {
            _mostPopularQuestions.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void SaveSearchList()
        {
            _saveSearchList.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public bool GetProfileMenu()
        {
            _profile.WaitElementToBeClickable(_webDriver, 10);
            var userName = _profile.Displayed;
            return userName;
        }

        public bool IsLinkEnable()
        {
            var isLinkEnable = _infoEmail.Enabled;
            return isLinkEnable;
        }

        public string GetNameOfCar()
        {
            var showButtom = By.CssSelector("button[class='button button--secondary button--block'] span[class='button__text']");
            showButtom.WaitElementIsVisible(_webDriver, 10);
            var nameOfCar = _nameOfCar.Text;
            return nameOfCar;
        }
    }
}
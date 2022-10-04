using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using UITests.Utils;

namespace UITests.PageObjects
{
    class MainMenuPageObject : BasePageObject
    {
        public MainMenuPageObject() : base()
        {
        }

        [FindsBy(How = How.CssSelector, Using = "a[rel='nofollow'] span[class='nav__link-text']")]
        public IWebElement _sighInButton { get; set; }

        public void ClickOnSignInButton()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);
            wait.Until(ExpectedConditions.ElementToBeClickable(_sighInButton)).Click();
        }

        [FindsBy(How = How.XPath, Using = "//*[contains(@d,'M12 18a6 6')]")]
        public IWebElement _profile { get; set; }

        public void ClickOnProfileIcon()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);
            wait.Until(ExpectedConditions.ElementToBeClickable(_profile)).Click();
        }

        [FindsBy(How = How.CssSelector, Using = "a[class='button button--secondary button--block'] span[class='button__text']")]
        public IWebElement _showCatalogButton { get; set; }

        public void ClickOnShowCalatogButton()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);
            wait.Until(ExpectedConditions.ElementToBeClickable(_showCatalogButton)).Click();
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='listing__items']//h3[1]")]
        public IWebElement _nameOfCar { get; set; }

        public void WaitCarNameAppeared()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);
            wait.Until(ExpectedConditions.TextToBePresentInElement(_nameOfCar, "Audi"));
        }

        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Instagram']")]
        public IWebElement _goToInstagram { get; set; }

        public void ClickOnInstagramm()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);
            wait.Until(ExpectedConditions.ElementToBeClickable(_goToInstagram)).Click();
        }

        [FindsBy(How = How.XPath, Using = "//a[@href='https://av.by/support']")]
        public IWebElement _askQuestion { get; set; }

        public void ClickOnAskQuestionsButton()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);
            wait.Until(ExpectedConditions.ElementToBeClickable(_askQuestion)).Click();
        }

        [FindsBy(How = How.XPath, Using = "//a[@href='https://av.by/pages/faq']")]
        public IWebElement _mostPopularQuestions { get; set; }

        public void ChooseMostPopularQuestions()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);
            wait.Until(ExpectedConditions.ElementToBeClickable(_mostPopularQuestions)).Click();
        }

        [FindsBy(How = How.XPath, Using = "//u[normalize-space()='info@av.by']")]
        public IWebElement _infoEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='https://av.by/profile/saved-filters']")]
        public IWebElement _saveSearchList { get; set; }

        public void SaveSearchList()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);
            wait.Until(ExpectedConditions.ElementToBeClickable(_saveSearchList)).Click();
        }
    }
}
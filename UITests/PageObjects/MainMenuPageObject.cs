using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UITests.PageObjects
{
    class MainMenuPageObject : BasePageObject
    {
        public MainMenuPageObject() : base()
        {
        }

        [FindsBy(How = How.CssSelector, Using = "a[rel='nofollow'] span[class='nav__link-text']")]
        public IWebElement _sighInButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[name()='path' and contains(@d,'M12 18a6 6')]")]
        public IWebElement _profile { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[class='button button--secondary button--block'] span[class='button__text']")]
        public IWebElement _showCatalogButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Audi')]")]
        public IWebElement _nameOfCar { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Instagram']")]
        public IWebElement _goToInstagram { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Задать вопрос')]")]
        public IWebElement _askQuestion { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='https://av.by/pages/faq']")]
        public IWebElement _mostPopularQuestions { get; set; }

        [FindsBy(How = How.XPath, Using = "//u[normalize-space()='info@av.by']")]
        public IWebElement _infoEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title='Сохранённые поиски']")]
        public IWebElement _saveSearchList { get; set; }
    }
}
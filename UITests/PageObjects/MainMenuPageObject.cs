using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UITests.PageObjects
{
    class MainMenuPageObject
    {
        private IWebDriver _webDriver;

        //    private readonly By _sighInButton = By.XPath("//span[contains(text(),'Войти')]");
        //    private readonly By _profile = By.XPath("//*[name()='path' and contains(@d,'M12 18a6 6')]");
        //    private readonly By _showCatalogButton = By.CssSelector(".button.button--secondary.button--block");
        //    private readonly By _nameOfCar = By.XPath("//span[contains(text(),'Audi')]");
        //    private readonly By _goToInstagram = By.XPath("//a[normalize-space()='Instagram']");
        //    private readonly By _askQuestion = By.XPath("//a[contains(text(),'Задать вопрос')]");
        //    private readonly By _mostPopularQuestions = By.XPath("//a[@href='https://av.by/pages/faq']");
        //     private readonly By _infoEmail = By.XPath("//u[normalize-space()='info@av.by']");
        //   private readonly By _saveSearchList = By.XPath("//a[@title='Сохранённые поиски']");

        public MainMenuPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Войти')]")]
        public IWebElement _sighInButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[name()='path' and contains(@d,'M12 18a6 6')]")]
        public IWebElement _profile { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='button button--secondary button--block']")]
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

        public bool GetProfileMenu()
        {
            var userName = _profile.Displayed;

            return userName;
        }

        public string GetNameOfCar()
        {
            var nameOfCar = _nameOfCar.Text;
            return nameOfCar;
        }

        public string GetInstagramUrl()
        {
            _webDriver.SwitchTo().Window(_webDriver.WindowHandles[1]);

            var url = _webDriver.Url;

            return url;
        }

        public bool IsLinkEnable()
        {
            var isLinkEnable = _infoEmail.Enabled;

            return isLinkEnable;
        }

        //  public MainMenuPageObject OpenSaveSearchList() 
        // {
        //    _saveSearchList).Click();

        //            return new MainMenuPageObject(_webDriver);
        //       }

    }
}


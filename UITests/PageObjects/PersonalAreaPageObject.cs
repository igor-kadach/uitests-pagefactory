using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UITests.PageObjects
{
    class PersonalAreaPageObject
    {
        private IWebDriver _webDriver;

      //  private readonly By _bookmarks = By.XPath("//a[@href='/profile/bookmarks']");
     //   private readonly By _nameAudi = By.XPath("//span[contains(text(),'Audi')]");
     //   private readonly By _buttonChange = By.CssSelector("a[class='mycard__action-control'] span");
     //   private readonly By _buttonChoosePhoto = By.XPath("//input[@id='p-21-photo']");
     //   private readonly By _buttonSaveChanges = By.XPath("//button[@class='button button--primary button--large']");
     //   private readonly By _findAddedPhoto = By.XPath("//div[@class='uploader__preview']/ul[@class='uploader__thumbs']/li[10]/div[1]");
      //  private readonly By _settingsButton = By.XPath("//main[@class='main']//li[6]//a");
      //  private readonly By _nameOfSearching = By.XPath("//a[contains(text(),'Audi')]");
      //  private readonly By _points = By.XPath("//main[@class='main']//li[1]//a[1]");
      //  private readonly By _pointsFor10Rubles = By.XPath("//span[contains(text(),'За 10 р.')]");
      //  private readonly By _payByCard = By.XPath("//a[contains(text(),'Банковской картой')]");
     //   private readonly By _goToPayService = By.XPath("//span[contains(text(),'Перейти на платёжный сервис')]");
     //   private readonly By _logoOfPayment = By.XPath("//img[@alt='logo']");

        public PersonalAreaPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        [FindsBy(How = How.XPath, Using = "//a[@href='/profile/bookmarks']")]
        public IWebElement _bookmarks { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Audi')]")]
        public IWebElement _nameAudi { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Изменить')]")]
        public IWebElement _buttonChange { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='p-21-photo']")]
        public IWebElement _buttonChoosePhoto { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='button button--primary button--large']")]
        public IWebElement _buttonSaveChanges { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@class='uploader__thumbs']/li[10]")]
        public IWebElement _findAddedPhoto { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='saved-filter__link']")]
        public IWebElement _nameOfSearching { get; set; }

        [FindsBy(How = How.XPath, Using = "//main[@class='main']//li[1]//a[1]")]
        public IWebElement _points { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'За 10 р.')]")]
        public IWebElement _pointsFor10Rubles { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Банковской картой')]")]
        public IWebElement _payByCard { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Перейти на платёжный сервис')]")]
        public IWebElement _goToPayService { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@alt='logo']")]
        public IWebElement _logoOfPayment { get; set; }

        [FindsBy(How = How.XPath, Using = "//main[@class='main']//li[6]//a")]
        public IWebElement _settingsButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@aria-busy='false']//*[name()='svg']")]
        public IWebElement _deleteBookmark { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='button button--xlink']//*[name()='svg']")]
        public IWebElement _deleteSavedSearching { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Удалить')]")]
        public IWebElement _acceptDeleting { get; set; }



        //span[contains(text(),'Удалить')]


        //public MainMenuPageObject OpenBookmarks()
        //{
        //    _bookmarks.Click();

        //    return new MainMenuPageObject(_webDriver);
        //}

        public bool IsAudiDispayed()
        {
          var IsBookmarkDisplayed = _nameAudi.Displayed;

            return IsBookmarkDisplayed;
        }

        public MainMenuPageObject AddPhoto()
        {                  
            _buttonChoosePhoto.SendKeys(TestDatas.filePath);
                
            return new MainMenuPageObject(_webDriver);
        }


        //public MainMenuPageObject AddPhoto()
        //{
        //    _webDriver.FindElement(_buttonChange).Click();
        //    IWebElement element = _webDriver.FindElement(_buttonChoosePhoto);
        //    element.SendKeys(TestDatas.filePath);

        //    Thread.Sleep(3000);
        //    _webDriver.FindElement(_buttonSaveChanges).Click();
        //    _webDriver.FindElement(_buttonChange).Click();

        //    return new MainMenuPageObject(_webDriver);
        //}


        public bool isAddedPhotoDisplayed()
        {
            var isAddedPhotoDisplayed = _findAddedPhoto.Displayed;

            return isAddedPhotoDisplayed;
        }

       

        //public SettingsPageObject OpenSetting()
        //{
        //    _webDriver.FindElement(_settingsButton).Click();

        //    return new SettingsPageObject(_webDriver);
        //}

        public bool isSearchIsSaved()
        {
            var isSearchIsSaved = _nameOfSearching.Displayed;

            return isSearchIsSaved;
        }

        //public MainMenuPageObject AddMyPoints()
        //{
        //    Thread.Sleep(1000);
        //    _webDriver.FindElement(_points).Click();
        //    _webDriver.FindElement(_pointsFor10Rubles).Click();
        //    _webDriver.FindElement(_payByCard).Click();
        //    _webDriver.FindElement(_goToPayService).Click();

        //    return new MainMenuPageObject(_webDriver);
        //}

        public bool isLogoDisplayed()
        {
            var isLogoDisplayed = _logoOfPayment.Displayed;

            return isLogoDisplayed;
        }
    }
}



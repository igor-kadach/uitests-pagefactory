using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UITests.PageObjects
{
    class PersonalAreaPageObject
    {
        private IWebDriver _webDriver;

    
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


        public bool isAddedPhotoDisplayed()
        {
            var isAddedPhotoDisplayed = _findAddedPhoto.Displayed;

            return isAddedPhotoDisplayed;
        }

        public bool isSearchIsSaved()
        {
            var isSearchIsSaved = _nameOfSearching.Displayed;

            return isSearchIsSaved;
        }
               

        public bool isLogoDisplayed()
        {
            var isLogoDisplayed = _logoOfPayment.Displayed;

            return isLogoDisplayed;
        }
    }
}



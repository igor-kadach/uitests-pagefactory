using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.IO;
using UITests.TestData;
using UITests.Utils;

namespace UITests.PageObjects
{
    class PersonalAreaPageObject : BaseTest
    {
        private Settings _settings;

        public PersonalAreaPageObject() : base()
        {
            _settings = SettingsHelper.GetSettings();
        }

        [FindsBy(How = How.XPath, Using = "//a[@href='/profile/bookmarks']")]
        private IWebElement _bookmarks { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[name()='path' and contains(@d,'M3.491 10.')]")]
        private IWebElement _turnPhoto { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[class='button button--action button--large'] span[class='button__text']")]
        private IWebElement _acceptDeleting { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='uploader__title']")]
        private IWebElement _choosePhotoButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@alt='logo']")]
        private IWebElement _logoOfPayment { get; set; }

        [FindsBy(How = How.XPath, Using = "//main[@class='main']//li[6]")]
        private IWebElement _settingsButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@aria-busy='false']")]
        private IWebElement _deleteBookmark { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='button button--xlink']")]
        private IWebElement _deleteSavedSearching { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[class='bookmarks-empty'] h1")]
        private IWebElement titleNoBookmarks { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@class='uploader__thumbs']")]
        private IWebElement _findAddedPhoto { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='saved-filter__link']")]
        private IWebElement _nameOfSearching { get; set; }

        [FindsBy(How = How.CssSelector, Using = "main[class='main'] li:nth-child(1) a:nth-child(1)")]
        private IWebElement _points { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div:nth-child(2) > button:nth-child(2)")]
        private IWebElement _pointsFor10Rubles { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Банковской картой')]")]  //Css  a[href='/order/a5435649-d55b-4d86-af2e-7334806986d8/payment-type/webpay']
        private IWebElement _payByCard { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[type='submit'] span[class='button__text']")]
        private IWebElement _goToPayService { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='link-text']")]
        private IWebElement _nameAudi { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[class='mycard__action-control'] span")]
        private IWebElement _buttonChange { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='uploader__title']")]
        private IWebElement _titlePhoto { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='p-21-photo']")]
        private IWebElement _buttonChoosePhoto { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='button button--primary button--large']")]
        private IWebElement _buttonSaveChanges { get; set; }

        public void OpenBookmarks()
        {
            _bookmarks.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void WaitNameOfCarAudi()
        {
            _nameAudi.WaitElementToBeClickable(_webDriver, 10);
        }

        public void ClickOnChangeButton()
        {
            _buttonChange.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void WaitButtonChoosePhoto()
        {
            _buttonChoosePhoto.WaitElementToBeClickable(_webDriver, 10);
        }

        public void WaitTiitlePhoto()
        {
            var titlePhotoPage = By.XPath("//div[@class='uploader__title']");
            titlePhotoPage.WaitElementIsVisible(_webDriver, 10);
        }

        public void ChoosePhoto()
        {
            var pathForPhoto = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + "\\FilesForTests"}\\{_settings.FileName}";
            _buttonChoosePhoto.SendKeys(pathForPhoto);
        }

        public void SavePhoto()
        {
            _buttonSaveChanges.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void BuyPoints()
        {
            _points.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void BuyPointsFor10Rubles()
        {
            _pointsFor10Rubles.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void BuyByCard()
        {
            _payByCard.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void GoToPayService()
        {
            _goToPayService.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void ClickOnSettings()
        {
            _settingsButton.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void DeleteBookmark()
        {
            _deleteBookmark.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void WaitTitleOfBookmark()
        {
            var noBookmarks = By.CssSelector("div[class='bookmarks-empty'] h1");
            noBookmarks.WaitInvisibilityOfElementLocated(_webDriver, 10);
        }

        public void DeleteSavedSearching()
        {
            _deleteSavedSearching.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void AcceptDeleting()
        {
            _acceptDeleting.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public void WaitChoosePhotoButton()
        {
            _choosePhotoButton.WaitElementToBeClickable(_webDriver, 10);
        }

        public void TurnPhotoOfCar()
        {
            _turnPhoto.WaitElementToBeClickable(_webDriver, 10).Click();
        }

        public bool IsAddedPhotoDisplayed()
        {
            var isAddedPhotoDisplayed = _findAddedPhoto.Displayed;
            return isAddedPhotoDisplayed;
        }

        public bool IsAudiDispayed()
        {
            WaitNameOfCarAudi();
            var IsBookmarkDisplayed = _nameAudi.Displayed;
            return IsBookmarkDisplayed;
        }

        public bool IsSearchIsSaved()
        {
            var isSearchIsSaved = _nameOfSearching.Displayed;
            return isSearchIsSaved;
        }

        public bool IsLogoDisplayed()
        {
            var isLogoDisplayed = _logoOfPayment.Displayed;
            return isLogoDisplayed;
        }
    }
}
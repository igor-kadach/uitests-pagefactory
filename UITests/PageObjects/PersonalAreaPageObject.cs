using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UITests.PageObjects
{
    class PersonalAreaPageObject : BasePageObject
    {
        public PersonalAreaPageObject() : base()
        {
        }

        [FindsBy(How = How.XPath, Using = "//a[@href='/profile/bookmarks']")]
        public IWebElement _bookmarks { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='link-text']")]
        public IWebElement _nameAudi { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[class='mycard__action-control'] span")]
        public IWebElement _buttonChange { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='p-21-photo']")] 
        public IWebElement _buttonChoosePhoto { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='button button--primary button--large']")]
        public IWebElement _buttonSaveChanges { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@class='uploader__thumbs']")]
        public IWebElement _findAddedPhoto { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='saved-filter__link']")]
        public IWebElement _nameOfSearching { get; set; }

        [FindsBy(How = How.XPath, Using = "//main[@class='main']//li[1]//a[1]")]
        public IWebElement _points { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div:nth-child(2) > button:nth-child(2)")]
        public IWebElement _pointsFor10Rubles { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Банковской картой']")]
        public IWebElement _payByCard { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[type='submit'] span[class='button__text']")]
        public IWebElement _goToPayService { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@alt='logo']")]
        public IWebElement _logoOfPayment { get; set; }

        [FindsBy(How = How.XPath, Using = "//main[@class='main']//li[6]")]
        public IWebElement _settingsButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@aria-busy='false']")]
        public IWebElement _deleteBookmark { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='button button--xlink']")]
        public IWebElement _deleteSavedSearching { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[class='button button--action button--large'] span[class='button__text']")]
        public IWebElement _acceptDeleting { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='uploader__title']")]
        public IWebElement _titlePhoto { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[name()='path' and contains(@d,'M3.491 10.')]")]
        public IWebElement _turnPhoto { get; set; }
    }
}
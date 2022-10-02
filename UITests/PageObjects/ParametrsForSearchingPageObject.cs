using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UITests.PageObjects
{
    class ParametrsForSearchingPageObject : BasePageObject
    {
        public ParametrsForSearchingPageObject() : base()
        {
        }

        [FindsBy(How = How.XPath, Using = "//button[@title='Марка']")]
        public IWebElement _carsName { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[normalize-space()='Audi']")]
        public IWebElement _nameAudi { get; set; }

        [FindsBy(How = How.CssSelector, Using = "label[for= 'p-13-transmission_type_1'] span[class='button-group__text']")]
        public IWebElement _transmissionAutomatic { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@name='p-15-engine_type']")]
        public IWebElement _chooseFuel { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='p-15-engine_type']//li[1]")]
        public IWebElement _benzinFuel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[class='button button--secondary button--block'] span[class='button__text']")] 
        public IWebElement _buttonShow { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[normalize-space()='Все параметры']")]
        public IWebElement _allParametrs { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='p-32-description']")]
        public IWebElement _searchByWords { get; set; }
    }
}
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using UITests.Utils;

namespace UITests.PageObjects
{
    class ParametrsForSearchingPageObject : BasePageObject
    {
        public ParametrsForSearchingPageObject(IWebDriver webDriver) : base(webDriver)
        {
        }

        public ParametrsForSearchingPageObject()
        {
        }

        [FindsBy(How = How.XPath, Using = "//button[@title='Марка']")]
        public IWebElement _carsName { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[normalize-space()='Audi']")]
        public IWebElement _nameAudi { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'автомат')]")]
        public IWebElement _transmissionAutomatic { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@name='p-15-engine_type']//span[@class='dropdown-button__value']")]
        public IWebElement _chooseFuel { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='p-15-engine_type']//li[1]//label[1]//span[1]")]
        public IWebElement _benzinFuel { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Показать')]")]
        public IWebElement _buttonShow { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Все параметры')]")]
        public IWebElement _allParametrs { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='p-32-description']")]
        public IWebElement _searchByWords { get; set; }

        public void EnterParametrsForSearching()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);

            var parametrs = new ParametrsForSearchingPageObject();

            wait.Until(ExpectedConditions.ElementToBeClickable(parametrs._carsName)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(parametrs._nameAudi)).Click();
            parametrs._transmissionAutomatic.Click();
            parametrs._chooseFuel.Click();
            parametrs._benzinFuel.Click();
            parametrs._chooseFuel.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(parametrs._buttonShow)).Click();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
    }
}

using SeleniumExtras.WaitHelpers;
using UITests.TestData;
using UITests.PageObjects;

namespace UITests.Utils
{
    public class Actions : BasePageObject
    {
        private readonly Settings _settings;

        public Actions(Settings settings) : base()
        {
            _settings = settings;
        }

        public void LoginToSite()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);

            var signInButtonClick = new MainMenuPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(signInButtonClick._sighInButton)).Click();

            var login = new AuthorizationPageObject();
            login.ChooseMethodByEmail();
            login.EnterEmailInLoginField();
            login.EnterPassInPasswordField();
            login.ClickOnLogInButton();
        }

        public bool IsMyOfferDisplayed()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);

            var offerDisplayed = new CatalogPageObject();
            wait.Until(ExpectedConditions.TextToBePresentInElement(offerDisplayed._openOffer, "Предложить"));
            var isMyOfferDisplayed = offerDisplayed._myOffer.Displayed;
            return isMyOfferDisplayed;
        }

        public bool IsErrorMessageDisplayed()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);

            var errorMessage = new AuthorizationPageObject();
            wait.Until(ExpectedConditions.TextToBePresentInElement(errorMessage._errorMessage, "Неверный логин"));
            var isErrorMessageDisplayed = errorMessage._errorMessage.Displayed;
            return isErrorMessageDisplayed;
        }

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
            wait.Until(ExpectedConditions.ElementToBeClickable(parametrs._buttonShowForBookmark)).Click();
        }

        public bool IsAudiDispayed()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);

            var getBookmarks = new PersonalAreaPageObject();
            wait.Until(ExpectedConditions.TextToBePresentInElement(getBookmarks._nameAudi, "Audi"));
            var IsBookmarkDisplayed = getBookmarks._nameAudi.Displayed;
            return IsBookmarkDisplayed;
        }

        public bool IsAddedPhotoDisplayed()
        {
            var getAddedPhoto = new PersonalAreaPageObject();
            var isAddedPhotoDisplayed = getAddedPhoto._findAddedPhoto.Displayed;
            return isAddedPhotoDisplayed;
        }

        public bool IsSearchIsSaved()
        {
            var getSavedSearching = new PersonalAreaPageObject();
            var isSearchIsSaved = getSavedSearching._nameOfSearching.Displayed;
            return isSearchIsSaved;
        }

        public bool IsLogoDisplayed()
        {
            var getLogo = new PersonalAreaPageObject();
            var isLogoDisplayed = getLogo._logoOfPayment.Displayed;
            return isLogoDisplayed;
        }

        public void DeleteSavedSerches()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);

            var deleteSearching = new PersonalAreaPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(deleteSearching._deleteSavedSearching)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(deleteSearching._acceptDeleting)).Click();
        }

        public void DeleteSavedBoormarks()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);

            var deleteBookmark = new PersonalAreaPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(deleteBookmark._deleteBookmark)).Click();
        }

        public bool GetProfileMenu()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);

            var getProfile = new MainMenuPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(getProfile._profile));
            var userName = getProfile._profile.Displayed;
            return userName;
        }
        public string GetNameOfCar()
        {
            var getNameOfCar = new MainMenuPageObject();
            var nameOfCar = getNameOfCar._nameOfCar.Text;
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
            var getLink = new MainMenuPageObject();
            var isLinkEnable = getLink._infoEmail.Enabled;
            return isLinkEnable;
        }

        public void ChangePasswordBack()
        {
            var wait = WebDriverWaitUtils.GetWaiter(20);

            // Close authWindow to sighIn again.
            var closeAuthWindow = new AuthorizationPageObject();
            closeAuthWindow._closeAuthWondow.Click();
            // Press button SighIn.
            var signInButtonClick = new MainMenuPageObject();
            signInButtonClick._sighInButton.Click();
            // Choose method by email and enter new credentials.
            var login = new AuthorizationPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(login._byEmail)).Click();
            login._loginInputField.SendKeys(_settings.EmailAdress);
            login._passwordInputField.SendKeys(_settings.NewPasswordForTest);
            login._logInButton.Click();
            // Go to my profile to open settings.
            var goToMyProfile = new MainMenuPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(goToMyProfile._profile)).Click();
            // Open settings to change password.
            var openSetting = new PersonalAreaPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(openSetting._settingsButton)).Click();
            // Change password fron new to old password back.
            var changePass = new SettingsPageObject();
            wait.Until(ExpectedConditions.ElementToBeClickable(changePass._changePassword)).Click();
            changePass._oldPassworField.SendKeys(_settings.NewPasswordForTest);
            changePass._newPasswordField.SendKeys(_settings.Password);
            // Save changes.
            changePass._applyButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(changePass._exitButton)).Click();
        }
    }
}
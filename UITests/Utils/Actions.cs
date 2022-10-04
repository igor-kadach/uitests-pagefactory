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
            var signInButtonClick = new MainMenuPageObject();
            signInButtonClick.ClickOnSignInButton();

            var login = new AuthorizationPageObject();
            login.ChooseMethodByEmail();
            login.EnterEmailInLoginField();
            login.EnterPassInPasswordField();
            login.ClickOnLogInButton();
        }

        public bool IsMyOfferDisplayed()
        {
            var offerDisplayed = new CatalogPageObject();
            offerDisplayed.WaitOfferForExchange();
            var isMyOfferDisplayed = offerDisplayed._myOffer.Displayed;
            return isMyOfferDisplayed;
        }

        public bool IsErrorMessageDisplayed()
        {
            var errorMessage = new AuthorizationPageObject();
            errorMessage.WaitErrorMessage();
            var isErrorMessageDisplayed = errorMessage._errorMessage.Displayed;
            return isErrorMessageDisplayed;
        }

        public void EnterParametrsForSearching()
        {
            var parametrs = new ParametrsForSearchingPageObject();
            parametrs.ChooseCarName();
            parametrs.CarName();
            parametrs.ChooseTramsmission();
            parametrs.ChooseFuel();
            parametrs.BenzinFuel();
            parametrs.ChooseFuel();
            parametrs.ClickOnButtonShowForBookmark();
        }

        public bool IsAudiDispayed()
        {
            var getBookmarks = new PersonalAreaPageObject();
            getBookmarks.WaitNameOfCarAudi();
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
            var deleteSearching = new PersonalAreaPageObject();
            deleteSearching.DeleteSavedSearching();
            deleteSearching.AcceptDeleting();
        }

        public void DeleteSavedBoormarks()
        {
            var deleteBookmark = new PersonalAreaPageObject();
            deleteBookmark.DeleteBookmark();
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
            // Close authWindow to sighIn again.
            var closeAuthWindow = new AuthorizationPageObject();
            closeAuthWindow.CloseAuthWondow();
            // Press button SighIn.
            var signInButtonClick = new MainMenuPageObject();
            signInButtonClick.ClickOnSignInButton();
            // Choose method by email and enter new credentials.
            var login = new AuthorizationPageObject();
            login.ChooseMethodByEmail();
            login.EnterEmailInLoginField();
            login.EnterNewPassInPasswordField();
            login.ClickOnLogInButton();
            // Go to my profile to open settings.
            var goToMyProfile = new MainMenuPageObject();
            goToMyProfile.ClickOnProfileIcon();
            // Open settings to change password.
            var openSetting = new PersonalAreaPageObject();
            openSetting.ClickOnSettings();
            // Change password fron new to old password back.
            var changePass = new SettingsPageObject();
            changePass.ClickOnChangePasswordButton();
            changePass.EnterNewlPasswordForChange();
            changePass.EnterOldPasswordForChange();
            // Save changes.
            changePass.ApplyChanges();
            changePass.ClickOnExitButton();
        }
    }
}
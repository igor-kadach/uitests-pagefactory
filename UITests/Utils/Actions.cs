using UITests.PageObjects;

namespace UITests.Utils
{
    public class Actions : BaseTest
    {
        private readonly MainMenuPageObject _menuActions;

        private readonly AuthorizationPageObject _authorizationActions;

        private readonly ParametrsForSearchingPageObject _parametrsActions;

        private readonly PersonalAreaPageObject _personalActions;

        private readonly SettingsPageObject _settingsActions;

        public Actions() : base()
        {
            _menuActions = new MainMenuPageObject();
            _authorizationActions = new AuthorizationPageObject();
            _parametrsActions = new ParametrsForSearchingPageObject();
            _personalActions = new PersonalAreaPageObject();
            _settingsActions = new SettingsPageObject();
        }

        public void LoginToSite()
        {
            _menuActions.ClickOnSignInButton();
            _authorizationActions.ChooseMethodByEmail();
            _authorizationActions.EnterEmailInLoginField();
            _authorizationActions.EnterPassInPasswordField();
            _authorizationActions.ClickOnLogInButton();
        }

        public void EnterParametrsForSearching()
        {
            _parametrsActions.ChooseCarName();
            _parametrsActions.CarName();
            _parametrsActions.ChooseTramsmission();
            _parametrsActions.ChooseFuel();
            _parametrsActions.BenzinFuel();
            _parametrsActions.ChooseFuel();
            _parametrsActions.ClickOnButtonShowForBookmark();
        }

        public void DeleteSavedSerches()
        {
            _personalActions.DeleteSavedSearching();
            _personalActions.AcceptDeleting();
        }

        public void DeleteSavedBoormarks()
        {
            _personalActions.DeleteBookmark();
        }

        public void TitleNoBookmarks()
        {
            _personalActions.WaitTitleOfBookmark();
        }

        public string GetInstagramUrl()
        {
            _webDriver.SwitchTo().Window(_webDriver.WindowHandles[1]);
            var url = _webDriver.Url;
            return url;
        }

        public void ChangePasswordBack()
        {
            // Close authWindow to sighIn again.
            _authorizationActions.CloseAuthWondow();
            // Press button SighIn.
            _menuActions.ClickOnSignInButton();
            // Choose method by email and enter new credentials.
            _authorizationActions.ChooseMethodByEmail();
            _authorizationActions.EnterEmailInLoginField();
            _authorizationActions.EnterNewPassInPasswordField();
            _authorizationActions.ClickOnLogInButton();
            // Go to my profile to open settings.
            _menuActions.ClickOnProfileIcon();
            // Open settings to change password.
            _personalActions.ClickOnSettings();
            // Change password fron new to old password back.
            _settingsActions.ClickOnChangePasswordButton();
            _settingsActions.EnterNewlPasswordForChange();
            _settingsActions.EnterOldPasswordForChange();
            // Save changes.
            _settingsActions.ApplyChanges();
            _settingsActions.ClickOnExitButton();
        }
    }
}
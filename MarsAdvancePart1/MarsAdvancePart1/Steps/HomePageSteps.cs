using MarsAdvancePart1.Pages.Components;
using MarsAdvancePart1.Pages.Components.ProfileOverview;
using MarsAdvancePart1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancePart1.Steps
{
    public class HomePageSteps : GlobalHelper
    {
        private HomePage homePage;
        private ProfileMenuTabComponents profileMenuTabComponents;

        public HomePageSteps()
        {
            homePage = new HomePage();
            profileMenuTabComponents = new ProfileMenuTabComponents();
        }

        public void ClickOnDescriptionIcon()
        {
            profileMenuTabComponents.ClickDescriptionIcon();
        }

        public void ClickOnProfileIcon() 
        {

            profileMenuTabComponents.ClickUserNameIcon();
        }

        public void ClickOnAvailabilityEditIcon()
        {
            profileMenuTabComponents.ClickAvailabilityEditIcon();
        }

        public void ClickOnHoursEditIcon()
        {
            profileMenuTabComponents.ClickHoursEditIcon();
        }

        public void ClickOnEarnTargetEditIcon()
        {
            profileMenuTabComponents.ClickEarnTargetEditIcon();
        }

        public void ValidateIsLoggedIn()
        {
            homePage.getFirstName();

        }
    }
}

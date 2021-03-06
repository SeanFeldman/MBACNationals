﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace UITestsFramework.Pages
{
    public class TopNavigationPage
    {
        [FindsBy(How = How.LinkText, Using = "Contingent")]
        private IWebElement contingentLink;

        [FindsBy(How = How.LinkText, Using = "Reservations")]
        private IWebElement reservationsLink;

        [FindsBy(How = How.LinkText, Using = "Travel")] 
        private IWebElement travelLink;

        [FindsBy(How = How.LinkText, Using = "Practice")]
        private IWebElement practiceLink;

        [FindsBy(How = How.LinkText, Using = "Profiles")]
        private IWebElement profilesLink;

        [FindsBy(How = How.LinkText, Using = "Log in")]
        private IWebElement loginLink;

        private IWebElement logoutLink { get { return Browser.Driver.FindElement(By.Id("logoff")); } }

        public void Contingent()
        {
            contingentLink.Click();
        }

        public void Reservations()
        {
            reservationsLink.Click();
        }

        public void Travel()
        {
            travelLink.Click();
        }

        public void Practice()
        {
            practiceLink.Click();
        }

        public void Profiles()
        {
            profilesLink.Click();
        }

        public void Logout()
        {
            logoutLink.Click();
        }

        public void Login()
        {
            try
            {
                loginLink.Click();
            }
            catch (NoSuchElementException)
            {
                logoutLink.Click();
                loginLink.Click();
            }
        }

        public bool LoggedIn()
        {
            return logoutLink.GetAttribute("Value").StartsWith("Log off", StringComparison.OrdinalIgnoreCase);
        }
    }
}

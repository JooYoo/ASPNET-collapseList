using System;
using System.Web.Mvc;
using LizenzManager.Controllers;
using LizenzManager.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;


namespace LizenzManager_UnitTests.ControllerTests
{


    [TestClass]
    public class HomeController_UnitTests
    {
        [TestMethod]
        public void LogIn_ValidUserWithAuthorization_LogInSuccess()
        {
            // en: The inputCredentials for this test must have a correct Username and Password.
            // en: The inputCredentials.Authorized must also be 'true'.
            // de: Die variable inputCredentials muss einen validen Benutzernamen und ein Passwort haben.
            // de: inputCredentials.Authorized muss auch 'true' sein.
            Credentials inputCredentials = new Credentials("Test","1234");
            HomeController controller = new HomeController();
            RedirectResult expectedResult = new RedirectResult("/Home/LogInSucceeded");

            var result = controller.LogIn(inputCredentials);
            result.Url.Should().BeEquivalentTo(expectedResult.Url);         
        }

        [TestMethod]
        public void LogIn_ValidUserNoAuthorization_LogInUnauthorized()
        {
            // en: The inputCredentials for this test must have a correct Username and Password.
            // en: The inputCredentials.Authorized must also be 'false'.
            // de: Die variable inputCredentials muss einen validen Benutzernamen und ein Passwort haben.
            // de: inputCredentials.Authorized muss auch 'false' sein.
            Credentials inputCredentials = new Credentials("Bob", "123");
            HomeController controller = new HomeController();
            RedirectResult expectedResult = new RedirectResult("/Home/LogInUnAuthorized");

            var result = controller.LogIn(inputCredentials);
            result.Url.Should().BeEquivalentTo(expectedResult.Url);
            
        }

        [TestMethod]
        public void LogIn_InvalidUser_LogInFailed()
        {
            // en: The inputCredentials for this test must have an incorrect Username and/or Password.
            // de: Die variable inputCredentials muss einen invaliden Benutzernamen und/oder ein Passwort haben.
            Credentials inputCredentials = new Credentials("asdgasgf", "sdfgsdfgsx");
            HomeController controller = new HomeController();
            RedirectResult expectedResult = new RedirectResult("/Home/LogInFailed");

            var result = controller.LogIn(inputCredentials);
            result.Url.Should().BeEquivalentTo(expectedResult.Url);
        }

        [TestMethod]
        public void LogIn_CredentialsNull_ThrowsNullReferenceException()
        {
            HomeController controller = new HomeController();
            RedirectResult expectedResult = new RedirectResult("/Home/LogInFailed");

            // en: The parameter for LogIn() must be null.
            // de: Der Parameter für Login() muss null sein.
            Action action = () => controller.LogIn(null);
            action.Should().Throw<NullReferenceException>();
        }
    }
}

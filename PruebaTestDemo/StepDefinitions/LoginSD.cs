using NUnit.Framework;
using OpenQA.Selenium; // Asegúrate de tener esta referencia
using PruebaTestDemo.Hook;
using PruebaTestDemo.PageObjects;
using Reqnroll;
using Roman.Support;
using System;

namespace PruebaTestDemo.StepDefinitions
{
    /// <summary>
    /// ═══════════════════════════════════════════════════════════════════════════
    /// STEP DEFINITIONS - LoginSD (Login Step Definitions)
    /// ═══════════════════════════════════════════════════════════════════════════
    /// 
    /// CONCEPTO FUNDAMENTAL: Los Step Definitions son el "pegamento" entre:
    /// - Los ESCENARIOS en lenguaje natural (.feature file)
    /// - El CÓDIGO de automatización (Page Objects)

    [Binding]
    public class LoginSD
    {
        /// readonly: Solo se asigna en el constructor, inmutable después
        private readonly LoginPage _login;

        public LoginSD(IWebDriver driver)
        {
            // Crea la instancia del Page Object con el driver compartido.
            _login = new LoginPage(driver);
        }

        [Given("que el usuario ingresa al ambiente {string}")]
        public void GivenQueElUsuarioIngresaAlAmbiente(string url)
        {
            // Delega la acción al Page Object
            // Este Step Definition NO sabe cómo navegar, solo orquesta
            _login.NavigateToUrl(url);
        }


        [When("Ingreso el usuario {string} y la contrasenia {string}")]
        public void WhenIngresoElUsuarioYLaContrasenia(string user, string pass)
        {
            _login.ingresarUsuarioYContrasenia(user, pass);
        }

        [When(@"el usuario hace clic en el boton de iniciar sesion")]
        public void WhenElUsuarioHaceClicEnElBotonDeIniciarSesion()
        {
            _login.ClickLoginButton();
            Console.WriteLine("Clic en el boton de iniciar sesion.");
        }

        [Then("Valido que el login sea fallido")]
        public void ThenValidoQueElLoginSeaFallido()
        {
            Assert.That(_login.LoginFallidoVisible(),
                "No se motro el mensaje de error al intentar loguearse.");

        }

    }
}

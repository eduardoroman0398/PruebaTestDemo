using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PruebaTestDemo.Hook;
using Roman.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTestDemo.PageObjects
{
    /// <summary>
    /// ═══════════════════════════════════════════════════════════════════════════
    /// PAGE OBJECT MODEL (POM) - LoginPage
    /// ═══════════════════════════════════════════════════════════════════════════
    /// 
    /// CONCEPTO FUNDAMENTAL: Page Object Model es un patrón de diseño donde:
    /// - Cada PÁGINA WEB se representa como una CLASE
    /// - Los ELEMENTOS de la página son propiedades privadas
    /// - Las ACCIONES sobre la página son métodos públicos
    /// 
    /// HERENCIA: LoginPage hereda de Util para acceder a métodos comunes
    /// como WaitForClickable, WaitForVisible, TakeScreenshot, etc.
    public class LoginPage : Util
    {
        /// <summary>
        /// Driver: Instancia del navegador que se usa para todas las interacciones.
        /// readonly: Solo se puede asignar en el constructor (inmutable después)
        /// </summary>
        private readonly IWebDriver Driver;
        /// <summary>
        /// LoginUrl: URL del ambiente de prueba.
        /// MEJORA SUGERIDA: Debería venir de un archivo de configuración (appsettings.json)
        /// para poder cambiar fácilmente entre ambientes (DEV, UAT, PROD)
        /// </summary>
        private string LoginUrl;

        /// readonly: Los localizadores no cambian en tiempo de ejecución
        private readonly By _emailInput = By.Id("username");
        private readonly By _passwordInput = By.CssSelector(".p-password-input");
        private readonly By _loginButton = By.CssSelector(".boton-sing-in");

        /// Constructor: Recibe el WebDriver a través de inyección de dependencias.
        public LoginPage(IWebDriver driver)
        {
            Driver = driver;
            // URL hardcodeada aquí
            // MEJORA: Cargar desde configuración externa
            LoginUrl = "https://uatgenesis.cibergestion.com/public/sign-in";
        }

        public void NavigateToUrl(string url)
        {
            if (url == "UAT")
            {
               Driver.Navigate().GoToUrl(LoginUrl);
            }
            TakeScreenshot(Driver,"Navegar a la página");
        }

        public void ingresarUsuarioYContrasenia(string user, string pass)
        {
            // Espera que el campo email sea clickeable, luego escribe el usuario
            WaitForClickable(Driver, _emailInput).SendKeys(user);
            // Espera que el campo password sea clickeable, luego escribe la contraseña
            WaitForClickable(Driver, _passwordInput).SendKeys(pass);
        }

        public void ClickLoginButton()
        {
            // Espera explícita + click en una sola línea
            WaitForClickable(Driver, _loginButton).Click();
        }

    }
}

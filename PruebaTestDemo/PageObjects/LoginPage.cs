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
   
    public class LoginPage : Util
    {
       
        private readonly IWebDriver Driver;
       
        private string LoginUrl;

        /// readonly: Los localizadores no cambian en tiempo de ejecución
        private readonly By _emailInput = By.Id("username");
        private readonly By _passwordInput = By.CssSelector(".p-password-input");
        private readonly By _loginButton = By.CssSelector(".boton-sing-in");
        private readonly By _toastError = By.XPath("//div[contains(@class,'p-toast-message-content')]");

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
            TakeScreenshot(Driver, "Credenciales ingresadas");
        }

        public void ClickLoginButton()
        {
            // Espera explícita + click en una sola línea
            WaitForClickable(Driver, _loginButton).Click();
        }

        public bool LoginFallidoVisible()
        {
            try
            {
                var element = WaitForVisible(Driver, _toastError);
                if (element.Displayed)
                {
                    TakeScreenshot(Driver, "Login Fallido");
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

    }
}

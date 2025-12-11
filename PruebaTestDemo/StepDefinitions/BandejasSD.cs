using NUnit.Framework;
using OpenQA.Selenium;
using PruebaTestDemo.Hook;
using PruebaTestDemo.PageObjects;
using Reqnroll;
using Roman.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTestDemo.StepDefinitions
{

    /// PROPÓSITO: Contiene los steps de VALIDACIÓN (Then) para verificar el resultado
    /// del proceso de login.
    [Binding]
    public class BandejasSD
    {
        /// INYECCIÓN DE DEPENDENCIAS:
        /// El driver se pasa desde Hooks → LoginSD/BandejasSD → Page Objects
        /// Todos comparten la misma instancia del navegador
        /// </summary>
        private readonly BandejasPage bandejasPage;
        public BandejasSD(IWebDriver driver)
        {
            // Se crea la instancia del Page Object con el driver compartido.
            bandejasPage = new BandejasPage(driver);
        }

        // Step que valida el login. Mapeo con el texto del feature: "Then Valido que el login sea exitoso".
        [Then("Valido que el login sea exitoso")]
        public void ThenVerificoQueElLoginSeaExitoso()
        {
            bandejasPage.validarLoginExitoso();
        }

       
    }
}

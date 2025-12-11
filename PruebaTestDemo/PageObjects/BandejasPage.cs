using NUnit.Framework;
using OpenQA.Selenium;
using Roman.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTestDemo.PageObjects
{
    public class BandejasPage : Util
    {
        private readonly IWebDriver Driver;

        // Localizador del elemento "Mis solicitudes"
        private By LabelMisSolicitudes => By.XPath("(//*[contains(text(),'Mis solicitudes')])[2]");

        public BandejasPage(IWebDriver driver)
        {
            Driver = driver;
        }

        /// <summary>
        /// Valida que el login sea exitoso verificando la aparición del texto "Mis solicitudes".
        /// Retorna el texto encontrado por si necesitas usarlo después.
        /// </summary>
        public string validarLoginExitoso()
        {  
            try
            {
                // Espera explícita para que el elemento sea visible
                string titulo = WaitForVisible(Driver, LabelMisSolicitudes).Text;
                // ASSERT de NUnit: valida que sea el texto esperado
                Assert.That(titulo, Is.EqualTo("Mis solicitudes"),
                $"❌ Se esperaba 'Mis solicitudes' pero se obtuvo '{titulo}'");

                Console.WriteLine("✅ Login exitoso – Se encontró el elemento 'Mis solicitudes'");
                return titulo;
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("El login debería ser exitoso pero NO se encontró el elemento 'Mis solicitudes'");
                return null; // Nunca se ejecuta porque Fail detiene la prueba, pero evita warnings
            }

        }
    }
}

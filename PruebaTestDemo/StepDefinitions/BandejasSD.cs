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
            try
            {
                // Obtiene el texto del elemento "Mis solicitudes"
                // Si el elemento no aparece en 10 seg, lanza WebDriverTimeoutException
                var titulo = bandejasPage.obtenerTituloDeLaPagina();
                // ASSERTION CON NUNIT:
                // Assert.That: Sintaxis moderna de NUnit (constraint-based)
                // 
                // PARÁMETROS:
                // 1. Valor actual: titulo (lo que obtuvimos de la UI)
                // 2. Constraint: Is.EqualTo("Mis solicitudes") (lo que esperamos)
                // 3. Mensaje: Se muestra si el assertion falla
                // 
                // COMPORTAMIENTO:
                // ✅ Si titulo == "Mis solicitudes" → Test pasa, continúa
                // ❌ Si titulo != "Mis solicitudes" → Test falla con el mensaje
                Assert.That(titulo, Is.EqualTo("Mis solicitudes"),
                    $"Se esperaba 'Mis solicitudes' pero se obtuvo '{titulo}'");

                Console.WriteLine("✓ Login exitoso - Se encontró el elemento 'Mis solicitudes'");
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("El login debería ser exitoso pero NO se encontró el elemento 'Mis solicitudes'");
            }
        }

        [Then("Valido que el login sea fallido")]
        public void ThenValidoQueElLoginSeaFallido()
        {
            try
            {
                var titulo = bandejasPage.obtenerTituloDeLaPagina();

                // Si llegamos aquí, significa que SÍ encontró "Mis solicitudes" (no debería)
                Assert.Fail($"El login debería fallar pero se encontró '{titulo}' - El usuario accedió al sistema");
            }
            catch (WebDriverTimeoutException)
            {
                // ✅ Esto es lo esperado: NO encontró el elemento porque el login falló
                Console.WriteLine("✓ Login fallido correctamente - NO se encontró el elemento 'Mis solicitudes'");
                Assert.Pass("Login falló correctamente, el usuario no pudo acceder");
            }
        }
    }
}

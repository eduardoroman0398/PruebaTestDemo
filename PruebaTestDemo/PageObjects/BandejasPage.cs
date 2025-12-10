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

        // Localizador: XPath absoluto. En capacitación explicar por qué los XPaths absolutos son frágiles
        // (cambios menores en el DOM rompen el selector). Preferir selectores con IDs, clases estables o
        // atributos data-test.
        private By LabelMisSolicitudes => By.XPath("(//*[contains(text(),'Mis solicitudes')])[2]");

        public BandejasPage(IWebDriver driver)
        {
            Driver = driver;
        }

        // Devuelve el texto del título. Usa una espera explícita para asegurar que el elemento sea visible.
        public string obtenerTituloDeLaPagina()
        {
            return WaitForVisible(Driver, LabelMisSolicitudes).Text;
        }
    }
}

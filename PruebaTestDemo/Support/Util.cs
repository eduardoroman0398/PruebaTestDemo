using Io.Cucumber.Messages.Types;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PruebaTestDemo.Hook;
using SeleniumExtras.WaitHelpers;

namespace Roman.Support
{
    /// <summary>
    /// CLASE UTILITARIA: Contiene métodos reutilizables que se usan en múltiples Page Objects.
    /// 
    /// Principio DRY (Don't Repeat Yourself): En lugar de repetir código de esperas y screenshots
    /// en cada página, lo centralizamos aquí.
    public class Util
    {
        /// <summary>
        /// Timeout por defecto para las esperas explícitas (10 segundos).
        protected const int DefaultTimeOut = 10;

        //ESPERAS
        public IWebElement WaitForVisible(IWebDriver driver, By locator, int seconds = DefaultTimeOut)
        {
            // WebDriverWait: Clase de Selenium que implementa esperas inteligentes
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            // ExpectedConditions: Proviene de SeleniumExtras (DotNetSeleniumExtras.WaitHelpers)
            // Proporciona condiciones predefinidas comunes como ElementIsVisible, ElementToBeClickable, etc.
            // Until(): Espera hasta que la condición se cumpla o se agote el timeout
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public IWebElement WaitForClickable(IWebDriver driver, By locator, int seconds = DefaultTimeOut)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            // ElementToBeClickable: Verifica que el elemento esté visible Y habilitado
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        //JS para SCROLL
        
        public void ScrollByPixels(IWebDriver driver, int pixeles)
        {
            // Cast del driver a IJavaScriptExecutor para habilitar ejecución de JS
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            // window.scrollBy(x, y): Función JS nativa del navegador
            // x = 0 (no hace scroll horizontal)
            // y = pixeles (scroll vertical)
            js.ExecuteScript($"window.scrollBy(0, {pixeles});");
        }

        //SCREENSHOT
        public static string TakeScreenshot(IWebDriver driver, string name)
        {
            try
            {
                // Ruta base solicitada
                string basePath = @"C:\Users\eromans\source\repos\PruebaTestDemo\PruebaTestDemo\Screenshots";

                // Crea el directorio si no existe (previene FileNotFoundException)
                if (!Directory.Exists(basePath))
                    Directory.CreateDirectory(basePath);

                // Genera nombre único usando fecha y hora para evitar sobrescribir screenshots
                string fileName = $"{name}_{DateTime.Now:yyyyMMdd_HHmmss}.png";

                // Path.Combine: Forma segura de combinar rutas (maneja '/' y '\' correctamente)
                string fullPath = Path.Combine(basePath, fileName);

                // ITakesScreenshot: Interfaz que permite capturar la pantalla
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                // SaveAsFile: Guarda el screenshot en formato PNG
                screenshot.SaveAsFile(fullPath);

                return fullPath;
            }
            catch (System.Exception ex)
            {
                // Manejo de errores: Imprime el error pero no detiene la ejecución
                Console.WriteLine($"Error al tomar screenshot: {ex.Message}");
                return null;
            }
        }
    }
}

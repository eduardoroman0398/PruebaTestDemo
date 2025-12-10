using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using Reqnroll.BoDi;

namespace PruebaTestDemo.Hook
{
    /// <summary>
    /// HOOKS: Clase fundamental en SpecFlow/Reqnroll que contiene métodos que se ejecutan
    /// ANTES y DESPUÉS de cada escenario de prueba.
    /// 
    /// Propósito: Centralizar la configuración (setup) y limpieza (teardown) del WebDriver.
    /// Esto asegura que cada escenario comience con un navegador limpio y termine cerrándolo.
    /// 
    /// [Binding]: Atributo que indica a Reqnroll que esta clase contiene pasos o hooks.

    [Binding]
    public class Hooks
    {
        // IObjectContainer: Contenedor de inyección de dependencias de Reqnroll.
        // Permite registrar instancias (como el WebDriver) para que estén disponibles
        // en todas las clases de Step Definitions del mismo escenario.
        private readonly IObjectContainer container;
        public IWebDriver Driver;
        
        public Hooks(IObjectContainer container)
        {
            this.container = container;
        }
        /// <summary>
        /// [BeforeScenario]: Hook que se ejecuta ANTES de cada escenario en el archivo .feature.
        /// 
        /// Responsabilidades:
        /// 1. Crear una nueva instancia de ChromeDriver (abre un navegador Chrome)
        /// 2. Maximizar la ventana del navegador
        /// 3. Registrar el Driver en el contenedor para inyección de dependencias
        [BeforeScenario]
        public void SetUp()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            container.RegisterInstanceAs(Driver);
        }
       
        [AfterScenario]
        public void TearDown()
        {
            Driver.Quit();
            Driver.Dispose(); //Libera recursos
        }
    }
}

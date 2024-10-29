using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

public class PuestoUITest : IDisposable
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public PuestoUITest()
    {
        driver = new ChromeDriver();
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
    }

    [Fact]
    public void VerListaDePuestos()
    {
        driver.Navigate().GoToUrl("http://localhost:5267/Puesto");

        var tablaPuestos = wait.Until(drv => drv.FindElement(By.XPath("//table[contains(@class, 'table')]")));
        Assert.True(tablaPuestos.Displayed, "La tabla de puestos debería estar visible");

        var filas = tablaPuestos.FindElements(By.XPath(".//tbody/tr"));
        Assert.True(filas.Count > 0, "La tabla de puestos no contiene elementos.");
    }
    [Fact]
    public void CrearPuesto()
    {
        driver.Navigate().GoToUrl("http://localhost:5267/Puesto/Create");

        wait.Until(drv => drv.FindElement(By.Id("Nombre")));
        wait.Until(drv => drv.FindElement(By.Id("Descripcion")));

        driver.FindElement(By.Id("Nombre")).SendKeys("Puesto de Prueba");
        driver.FindElement(By.Id("Descripcion")).SendKeys("Descripción de prueba para el puesto");

        driver.FindElement(By.Id("button")).Click();

        wait.Until(drv => drv.Url == "http://localhost:5267/Puesto");

        var listaPuestos = driver.FindElement(By.XPath("//table"));
        Assert.Contains("Puesto de Prueba", listaPuestos.Text);
    }
     [Fact]
    public void EditarPuesto()
    {
        driver.Navigate().GoToUrl("http://localhost:5267/Puesto");
        var btnEditar = wait.Until(drv => drv.FindElement(By.XPath("//a[contains(@href, '/Puesto/Edit')][1]")));
        btnEditar.Click();

        wait.Until(drv => drv.FindElement(By.Id("Nombre"))).Clear();
        driver.FindElement(By.Id("Nombre")).SendKeys("Puesto Modificado");
        driver.FindElement(By.Id("Descripcion")).Clear();
        driver.FindElement(By.Id("Descripcion")).SendKeys("Descripción modificada para el puesto");
        driver.FindElement(By.Id("button")).Click();

        wait.Until(drv => drv.Url == "http://localhost:5267/Puesto");
        var listaPuestos = driver.FindElement(By.XPath("//table"));
        Assert.Contains("Puesto Modificado", listaPuestos.Text);
    }
    
    
    [Fact]
    public void EliminarPuesto()
    {
        driver.Navigate().GoToUrl("http://localhost:5267/Puesto");

        var btnEliminar = wait.Until(drv => drv.FindElement(By.XPath("//a[contains(@href, '/Puesto/Delete')]")));
        btnEliminar.Click();

        var confirmarEliminar = wait.Until(drv => drv.FindElement(By.Id("button")));
        confirmarEliminar.Click();

        wait.Until(drv => drv.Url == "http://localhost:5267/Puesto");
        var listaPuestos = driver.FindElement(By.XPath("//table"));
        Assert.DoesNotContain("Puesto Modificado", listaPuestos.Text);
    }
    [Fact]
    public void VerDetallesDePuesto()
    {
        driver.Navigate().GoToUrl("http://localhost:5267/Puesto");

        var btnDetalles = wait.Until(drv => drv.FindElement(By.XPath("//a[contains(@href, '/Puesto/Details')]")));
        btnDetalles.Click();

        wait.Until(drv => drv.FindElement(By.XPath("//h4[contains(text(), 'Información de los Puestos')]"))); 

        var nombre = driver.FindElement(By.XPath("//dd[contains(@class, 'col-sm-8')][1]")).Text;
        var descripcion = driver.FindElement(By.XPath("//dd[contains(@class, 'col-sm-8')][2]")).Text;

       Assert.Equal("Puesto Modificado", nombre);
       Assert.Equal("Descripción modificada para el puesto", descripcion);

       var btnRegresar = driver.FindElement(By.XPath("//a[contains(text(), 'Regresar')]"));
       btnRegresar.Click();

       wait.Until(drv => drv.Url == "http://localhost:5267/Puesto");
    }


    public void Dispose()
    {
        driver.Quit();
        driver.Dispose();
    }
}

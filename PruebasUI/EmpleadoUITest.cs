using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

public class EmpleadoUITest : IDisposable
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public EmpleadoUITest()
    {
        driver = new ChromeDriver();
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
    }

    [Fact]
    public void VerListaDeEmpleados()
    {
        driver.Navigate().GoToUrl("http://localhost:5267/Empleado");

        var tablaEmpleados = wait.Until(drv => drv.FindElement(By.XPath("//table[contains(@class, 'table')]")));
        Assert.True(tablaEmpleados.Displayed, "La tabla de empleados debería estar visible");

        var filas = tablaEmpleados.FindElements(By.XPath(".//tbody/tr"));
        Assert.True(filas.Count > 0, "La tabla de empleados no contiene elementos.");
    }
    [Fact]
    public void CrearEmpleado()
    {
        driver.Navigate().GoToUrl("http://localhost:5267/Empleado/Create");

        wait.Until(drv => drv.FindElement(By.Id("Nombre")));
        wait.Until(drv => drv.FindElement(By.Id("Apellido")));
        wait.Until(drv => drv.FindElement(By.Id("Telefono")));
        wait.Until(drv => drv.FindElement(By.Id("Email")));
        wait.Until(drv => drv.FindElement(By.Id("PuestoId")));

        driver.FindElement(By.Id("Nombre")).SendKeys("Empleado de Prueba");
        driver.FindElement(By.Id("Apellido")).SendKeys("Apellido de Prueba");
        driver.FindElement(By.Id("Telefono")).SendKeys("123-456-9789");
        driver.FindElement(By.Id("Email")).SendKeys("empleado@prueba.com");
        driver.FindElement(By.Id("PuestoId")).SendKeys("15");

        driver.FindElement(By.Id("button")).Click();

        wait.Until(drv => drv.Url == "http://localhost:5267/Empleado");

        var listaEmpleados = driver.FindElement(By.XPath("//table"));
        Assert.Contains("Empleado de Prueba", listaEmpleados.Text);
    }
    [Fact]
    public void EditarEmpleado()
    {
        driver.Navigate().GoToUrl("http://localhost:5267/Empleado");
        var btnEditar = wait.Until(drv => drv.FindElement(By.XPath("//a[contains(@href, '/Empleado/Edit')][1]")));
        btnEditar.Click();

        wait.Until(drv => drv.FindElement(By.Id("Nombre"))).Clear();
        driver.FindElement(By.Id("Nombre")).SendKeys("Empleado Modificado");
        driver.FindElement(By.Id("Apellido")).Clear();
        driver.FindElement(By.Id("Apellido")).SendKeys("Apellido Modificado");
        driver.FindElement(By.Id("button")).Click();

        wait.Until(drv => drv.Url == "http://localhost:5267/Empleado");
        var listaEmpleados = driver.FindElement(By.XPath("//table"));
        Assert.Contains("Empleado Modificado", listaEmpleados.Text);
    }
    [Fact]
    public void EliminarEmpleado()
    {
        driver.Navigate().GoToUrl("http://localhost:5267/Empleado");

        var btnEliminar = wait.Until(drv => drv.FindElement(By.XPath("//a[contains(@href, '/Empleado/Delete')]")));
        btnEliminar.Click();

        var confirmarEliminar = wait.Until(drv => drv.FindElement(By.Id("button")));
        confirmarEliminar.Click();

        wait.Until(drv => drv.Url == "http://localhost:5267/Empleado");
        var listaEmpleados = driver.FindElement(By.XPath("//table"));
        Assert.DoesNotContain("Empleado Modificado", listaEmpleados.Text);
    }
     [Fact]
    public void VerDetallesDeEmpleado()
    {
        driver.Navigate().GoToUrl("http://localhost:5267/Empleado");

        var btnDetalles = wait.Until(drv => drv.FindElement(By.XPath("//a[contains(@href, '/Empleado/Details')]")));
        btnDetalles.Click();

        wait.Until(drv => drv.FindElement(By.XPath("//h4[contains(text(), 'Información del Empleado')]"))); 

        var nombre = driver.FindElement(By.XPath("//dd[contains(@class, 'col-sm-8')][1]")).Text;
        var apellido = driver.FindElement(By.XPath("//dd[contains(@class, 'col-sm-8')][2]")).Text;

        Assert.Equal("Empleado Modificado", nombre);
        Assert.Equal("Apellido Modificado", apellido);

        var btnRegresar = driver.FindElement(By.XPath("//a[contains(text(), 'Regresar')]"));
        btnRegresar.Click();

        wait.Until(drv => drv.Url == "http://localhost:5267/Empleado");
    }

    public void Dispose()
    {
        driver.Quit();
        driver.Dispose();
    }
}

     
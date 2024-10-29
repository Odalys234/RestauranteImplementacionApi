using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

public class ClienteUITest
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public ClienteUITest()
    {
        driver = new ChromeDriver();
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    [Fact]
    public void VerListaDeClientes()
    {
        driver.Navigate().GoToUrl("http://localhost:5267/Cliente");
        
        var tablaClientes = wait.Until(drv => drv.FindElement(By.XPath("//table[contains(@class, 'table')]")));
        Assert.True(tablaClientes.Displayed, "La tabla de clientes debería estar visible");

        var filas = tablaClientes.FindElements(By.XPath(".//tbody/tr"));
        Assert.True(filas.Count > 0, "La tabla de clientes no contiene elementos.");
    }

    [Fact]
    public void CrearCliente()
    {
        driver.Navigate().GoToUrl("http://localhost:5267/Cliente/Create");

        wait.Until(drv => drv.FindElement(By.Id("nombre"))).SendKeys("Cliente de Prueba");
        driver.FindElement(By.Id("apellido")).SendKeys("Apellido de Prueba");
        driver.FindElement(By.Id("telefono")).SendKeys("123456789");
        driver.FindElement(By.Id("email")).SendKeys("prueba@correo.com");
        
        driver.FindElement(By.Id("button")).Click();
        
        wait.Until(drv => drv.Url == "http://localhost:5267/Cliente");
        
        var listaClientes = driver.FindElement(By.XPath("//table"));
        Assert.Contains("Cliente de Prueba", listaClientes.Text);
    }

    [Fact]
    public void EditarCliente()
    {
        driver.Navigate().GoToUrl("http://localhost:5267/Cliente");
        
        var btnEditar = wait.Until(drv => drv.FindElement(By.XPath("//a[contains(@href, '/Cliente/Edit')][1]")));
        btnEditar.Click();

        wait.Until(drv => drv.FindElement(By.Id("nombre"))).Clear();
        driver.FindElement(By.Id("nombre")).SendKeys("Cliente Modificado");
        driver.FindElement(By.Id("apellido")).Clear();
        driver.FindElement(By.Id("apellido")).SendKeys("Apellido Modificado");
        
        driver.FindElement(By.Id("button")).Click();

        wait.Until(drv => drv.Url == "http://localhost:5267/Cliente");
        var listaClientes = driver.FindElement(By.XPath("//table"));
        Assert.Contains("Cliente Modificado", listaClientes.Text);
    }

    [Fact]
    public void EliminarCliente()
    {
        driver.Navigate().GoToUrl("http://localhost:5267/Cliente");
        
        var btnEliminar = wait.Until(drv => drv.FindElement(By.XPath("//a[contains(@href, '/Cliente/Delete')]")));
        btnEliminar.Click();

        var confirmarEliminar = wait.Until(drv => drv.FindElement(By.Id("button")));
        confirmarEliminar.Click();

        wait.Until(drv => drv.Url == "http://localhost:5267/Cliente");
        var listaClientes = driver.FindElement(By.XPath("//table"));
        Assert.DoesNotContain("katherine odalys", listaClientes.Text);
    }
    [Fact]
public void VerDetallesCliente()
{
  
    driver.Navigate().GoToUrl("http://localhost:5267/Cliente");

   
    var listaClientes = driver.FindElement(By.XPath("//table"));
    if (!listaClientes.Text.Contains("Cliente de Prueba"))
    {
        driver.Navigate().GoToUrl("http://localhost:5267/Cliente/Create");
        wait.Until(drv => drv.FindElement(By.Id("nombre"))).SendKeys("Cliente de Prueba");
        driver.FindElement(By.Id("apellido")).SendKeys("Apellido de Prueba");
        driver.FindElement(By.Id("telefono")).SendKeys("123456789");
        driver.FindElement(By.Id("email")).SendKeys("clienteprueba@example.com");
        driver.FindElement(By.Id("button")).Click();
        wait.Until(drv => drv.Url == "http://localhost:5267/Cliente");
    }

   
    var btnDetalles = wait.Until(drv => drv.FindElement(By.XPath("//a[contains(@href, '/Cliente/Details')]")));
    btnDetalles.Click();
    var detalleCliente = wait.Until(drv => drv.FindElement(By.XPath("//div[contains(@class, 'card')]")));
    Assert.Contains("Cliente Modificado", detalleCliente.Text);
}


    public void Dispose()
    {
        driver.Quit();
        driver.Dispose();
    }
}

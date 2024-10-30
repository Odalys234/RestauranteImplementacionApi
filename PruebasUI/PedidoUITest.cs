using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

public class PedidoUITest 
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public PedidoUITest()
    {
        driver = new ChromeDriver();
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    [Fact]
    public void VerListaDePedidos()
    {
        driver.Navigate().GoToUrl("http://localhost:5267/Pedido");
        
        var tablaPedidos = wait.Until(drv => drv.FindElement(By.XPath("//table[contains(@class, 'table')]")));
        Assert.True(tablaPedidos.Displayed, "La tabla de pedidos debería estar visible");

        var filas = tablaPedidos.FindElements(By.XPath(".//tbody/tr"));
        Assert.True(filas.Count > 0, "La tabla de pedidos no contiene elementos.");
    }

    [Fact]
    public void CrearPedido()
    {
        driver.Navigate().GoToUrl("http://localhost:5267/Pedido/Create");

        wait.Until(drv => drv.FindElement(By.Id("nombre"))).SendKeys("Pedido de Prueba");
        driver.FindElement(By.Id("apellido")).SendKeys("Apellido Prueba");
        driver.FindElement(By.Id("telefono")).SendKeys("123456789");
        driver.FindElement(By.Id("gmail")).SendKeys("correo@prueba.com");
        driver.FindElement(By.Id("detallesPedido")).SendKeys("Detalles del pedido de prueba");
        driver.FindElement(By.Id("fechaPedido")).SendKeys(DateTime.Today.ToString("yyyy-MM-dd"));

        driver.FindElement(By.Id("button")).Click();

        wait.Until(drv => drv.Url == "http://localhost:5267/Pedido");

        var listaPedidos = driver.FindElement(By.XPath("//table"));
        Assert.Contains("Pedido de Prueba", listaPedidos.Text);
    }

    [Fact]
    public void EditarPedido()
    {
        driver.Navigate().GoToUrl("http://localhost:5267/Pedido");

        var btnEditar = wait.Until(drv => drv.FindElement(By.XPath("//a[contains(@href, '/Pedido/Edit')][1]")));
        btnEditar.Click();

        wait.Until(drv => drv.FindElement(By.Id("nombre"))).Clear();
        driver.FindElement(By.Id("nombre")).SendKeys("Pedido Modificado");
        driver.FindElement(By.Id("apellido")).Clear();
        driver.FindElement(By.Id("apellido")).SendKeys("Apellido Modificado");
        driver.FindElement(By.Id("detallesPedido")).Clear();
        driver.FindElement(By.Id("detallesPedido")).SendKeys("Detalles modificados para el pedido");
        
        driver.FindElement(By.Id("button")).Click();

        wait.Until(drv => drv.Url == "http://localhost:5267/Pedido");
        var listaPedidos = driver.FindElement(By.XPath("//table"));
        Assert.Contains("Pedido Modificado", listaPedidos.Text);
    }

    [Fact]
    public void EliminarPedido()
    {
        driver.Navigate().GoToUrl("http://localhost:5267/Pedido");

        var btnEliminar = wait.Until(drv => drv.FindElement(By.XPath("//a[contains(@href, '/Pedido/Delete')]")));
        btnEliminar.Click();

        var confirmarEliminar = wait.Until(drv => drv.FindElement(By.Id("button")));
        confirmarEliminar.Click();

        wait.Until(drv => drv.Url == "http://localhost:5267/Pedido");
        var listaPedidos = driver.FindElement(By.XPath("//table"));
        Assert.DoesNotContain("Pedido Modificado", listaPedidos.Text);
    }

    [Fact]
public void VerDetallesPedido()
{
    driver.Navigate().GoToUrl("http://localhost:5267/Pedido");

    var listaPedidos = driver.FindElement(By.XPath("//table"));
    if (!listaPedidos.Text.Contains("Pedido de Prueba"))
    {
        
        CrearPedido();
        driver.Navigate().GoToUrl("http://localhost:5267/Pedido");
    }

    var btnDetalles = wait.Until(drv => drv.FindElement(By.XPath("//a[contains(@href, '/Pedido/Details')]")));
    btnDetalles.Click();

    var detallePedido = wait.Until(drv => drv.FindElement(By.XPath("//div[contains(@class, 'card')]")));
    
    
    Assert.Contains("Información del Pedido", detallePedido.Text);
    Assert.Contains("Pedido de Prueba", detallePedido.Text);
    Assert.Contains("nombre", detallePedido.Text);
}

    public void Dispose()
    {
        driver.Quit();
        driver.Dispose();
    }
}
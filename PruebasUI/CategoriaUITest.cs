using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

public class CategoriaUITest
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public CategoriaUITest()
    {
        driver = new ChromeDriver();
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    [Fact]
    public void VerListaDeCategorias()
    {
        
        driver.Navigate().GoToUrl("http://localhost:5267/Categoria");

        
        var tablaCategorias = wait.Until(drv => drv.FindElement(By.XPath("//table[contains(@class, 'table')]")));

        Assert.True(tablaCategorias.Displayed, "La tabla de categorías debería estar visible");

       
        var filas = tablaCategorias.FindElements(By.XPath(".//tbody/tr"));
        Assert.True(filas.Count > 0, "La tabla de categorías no contiene elementos.");
    }
     [Fact]
    public void CrearCategoria()
    {
       
        driver.Navigate().GoToUrl("http://localhost:5267/Categoria/Create");

       
        wait.Until(drv => drv.FindElement(By.Id("nombre")));
        wait.Until(drv => drv.FindElement(By.Id("descripcion")));


        driver.FindElement(By.Id("nombre")).SendKeys("Categoría de Prueba");
        driver.FindElement(By.Id("descripcion")).SendKeys("Descripción de prueba para la categoría");

      
      driver.FindElement(By.Id("button")).Click();



        
        wait.Until(drv => drv.Url == "http://localhost:5267/Categoria");

        
        var listaCategorias = driver.FindElement(By.XPath("//table"));
        Assert.Contains("Categoría de Prueba", listaCategorias.Text);
    }
 [Fact]
    public void EditarCategoria()
    {
        driver.Navigate().GoToUrl("http://localhost:5267/Categoria");
        var btnEditar = wait.Until(drv => drv.FindElement(By.XPath("//a[contains(@href, '/Categoria/Edit')][1]")));
        btnEditar.Click();

        wait.Until(drv => drv.FindElement(By.Id("nombre"))).Clear();
        driver.FindElement(By.Id("nombre")).SendKeys("Categoría Modificada");
        driver.FindElement(By.Id("descripcion")).Clear();
        driver.FindElement(By.Id("descripcion")).SendKeys("Descripción modificada para la categoría");
        driver.FindElement(By.Id("button")).Click();

        wait.Until(drv => drv.Url == "http://localhost:5267/Categoria");
        var listaCategorias = driver.FindElement(By.XPath("//table"));
        Assert.Contains("Categoría Modificada", listaCategorias.Text);
    }

   [Fact]
public void EliminarCategoria()
{
   
    driver.Navigate().GoToUrl("http://localhost:5267/Categoria");

   
    var btnEliminar = wait.Until(drv => drv.FindElement(By.XPath("//a[contains(@href, '/Categoria/Delete')]")));
    btnEliminar.Click();

    
    var confirmarEliminar = wait.Until(drv => drv.FindElement(By.Id("button")));
    confirmarEliminar.Click();


    wait.Until(drv => drv.Url == "http://localhost:5267/Categoria");
    var listaCategorias = driver.FindElement(By.XPath("//table"));
    Assert.DoesNotContain("Categoría Modificada", listaCategorias.Text);
}
    public void Dispose()
    {
        driver.Quit();
        driver.Dispose();
    }
}

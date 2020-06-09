using Demoqa_Suite_Project.Assertion;
using Demoqa_Suite_Project.PageHelper;
using Demoqa_Suite_Project.UILayer;
using Demoqa_Suite_Project.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;

namespace Demoqa_Suite_Project
{
    [TestClass]
    public class UnitTest
    {
        public RemoteWebDriver driver;
        private WebDriverWait wait;
        private Common common;

        [TestInitialize]
        public void Initialize()
        {
            common = new Common();
        }

        [TestMethod]
        public void SelectAnItem()
        {
            NavigateHelper.NavigateDemoqa("chrome");
            SelectionObjectHelper selectionObjectHelper = new SelectionObjectHelper();
            SelectionAssertValues selectionAssertValues = new SelectionAssertValues();
            IWebElement selectable = wait.Until(drv => drv.FindElement(By.CssSelector(selectionObjectHelper.selectableLink)));            
            selectable.Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            IWebElement itemSelect = wait.Until(drv => drv.FindElement(By.CssSelector(selectionObjectHelper.firstItem)));
            itemSelect.Click();
            Assert.AreEqual(itemSelect.GetAttribute("class"), selectionAssertValues.selectedItemClass);
        }

        [TestMethod]
        public void SelectItems()
        {
            NavigateHelper.NavigateDemoqa();
            SelectionObjectHelper selectionObjectHelper = new SelectionObjectHelper();
            SelectionAssertValues selectionAssertValues = new SelectionAssertValues();
            IWebElement selectable = wait.Until(drv => drv.FindElement(By.CssSelector(selectionObjectHelper.selectableLink)));
            selectable.Click();
            Actions action = new Actions(driver);
            action.KeyDown(Keys.Control).Build().Perform();
            IWebElement firstItem = wait.Until(drv => drv.FindElement(By.CssSelector(selectionObjectHelper.firstItem)));
            firstItem.Click();
            IWebElement secondItem = wait.Until(drv => drv.FindElement(By.CssSelector(selectionObjectHelper.secondItem)));
            secondItem.Click();
            action.KeyUp(Keys.Control).Build().Perform();
            Assert.AreEqual(firstItem.GetAttribute("class"), selectionAssertValues.expectedValueDictionary["firstItem"]);
            Assert.AreEqual(secondItem.GetAttribute("class"), selectionAssertValues.expectedValueDictionary["secondItem"]);

        }

        [TestMethod]
        public void Resizable()
        {
            NavigateHelper.NavigateDemoqa();
            ResizeObjectHelper resizeObjectLayer = new ResizeObjectHelper();
            IWebElement resizable = wait.Until(drv => drv.FindElement(By.CssSelector(resizeObjectLayer.resizableLink)));
            resizable.Click();
            IWebElement dragElement = wait.Until(drv => drv.FindElement(By.CssSelector(resizeObjectLayer.dragElement)));
            Actions actions = new Actions(driver);
            IWebElement resizableElement = wait.Until(drv => drv.FindElement(By.CssSelector(resizeObjectLayer.resizableElement)));
            var resizableElementHeight = resizableElement.Size.Height;
            actions.DragAndDropToOffset(dragElement,100,100).Build().Perform();
            Assert.AreNotEqual(resizableElementHeight, resizableElement.Size.Height);
        }

        [TestMethod]
        public void DragAndDrop()
        {
            NavigateHelper.NavigateDemoqa();
            DragAndDropAssertValues dragAndDropAssertValues = new DragAndDropAssertValues();
            DragAndDropObjectHelper dragAndDropObjectHelper = new DragAndDropObjectHelper();
            IWebElement dragAndDrop = wait.Until(drv => drv.FindElement(By.CssSelector(dragAndDropObjectHelper.dragAndDropLink)));
            dragAndDrop.Click();
            IWebElement dragElement = wait.Until(drv => drv.FindElement(By.CssSelector(dragAndDropObjectHelper.dragItem)));
            IWebElement dropElement = wait.Until(drv => drv.FindElement(By.CssSelector(dragAndDropObjectHelper.dropItem)));
            Actions actions = new Actions(driver);
            actions.DragAndDrop(dragElement,dropElement).Build().Perform();
            IWebElement droppedTextElement = wait.Until(drv => drv.FindElement(By.CssSelector(dragAndDropAssertValues.droppedTextElement)));
            Assert.AreEqual(droppedTextElement.Text, dragAndDropAssertValues.dropText);
        }

        [TestMethod]
        public void Draggable()
        {
            NavigateHelper.NavigateDemoqa();
            DragObjectHelper dragObjectHelper = new DragObjectHelper();
            IWebElement draggable = wait.Until(drv => drv.FindElement(By.CssSelector(dragObjectHelper.draggableLink)));
            draggable.Click();
            IWebElement dragElement = wait.Until(drv => drv.FindElement(By.CssSelector(dragObjectHelper.dragItem)));
            var oldX = dragElement.Location.X;
            Actions actions = new Actions(driver);
            actions.DragAndDropToOffset(dragElement, 100, 100).Build().Perform();
            Assert.AreNotEqual(oldX, dragElement.Location.X);
        }

        [TestMethod]
        public void SelectableV1()
        {
           
            driver = NavigateHelper.NavigateDemoqa();
            wait=common.Wait(driver);
            SelectableV1ObjectHelper selectableV1ObjectHelper = new SelectableV1ObjectHelper();
            SelectableV1AssertValues selectableV1AssertValues = new SelectableV1AssertValues();
            IWebElement interactions = wait.Until(drv => drv.FindElement(By.CssSelector(selectableV1ObjectHelper.interactionsOptionSelector)));
            interactions.Click();
            driver.ExecuteScript("window.scroll(0,250)");
            IWebElement selectable = wait.Until(drv => drv.FindElement(By.CssSelector(selectableV1ObjectHelper.selectable)));
            selectable.Click();
            //IWebElement firstItem = wait.Until(drv => drv.FindElement(By.CssSelector("#verticalListContainer>li:nth-child(1)")));
            //firstItem.Click();
            IWebElement secondItem = wait.Until(drv => drv.FindElement(By.CssSelector(selectableV1ObjectHelper.secondItem)));
            Actions actions = new Actions(driver);
            actions.MoveToElement(secondItem).Build().Perform();
            secondItem.Click();
            //Assert.AreEqual(secondItem.GetAttribute("class"), "mt-2 list-group-item active list-group-item-action");
            string Color = secondItem.GetCssValue(selectableV1AssertValues.backgroundColor);
            Assert.AreEqual(Color,selectableV1AssertValues.selectedColorCode);
        }


    }
}

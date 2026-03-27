using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace AppSpeseCorrezioneTest
{
    public class Tests
    {
        private WindowsDriver _driver;

        [SetUp]
        public void Setup()
        {
            //Oggetto che contiene le opzioni di Appium per 
            //Accedere all'applicazione
            //Oggetto di tipo AppiumOptions
            var options = new AppiumOptions();

            options.PlatformName = "Windows";
            options.AutomationName = "Windows";
            options.DeviceName = "WindowsPC";
            //Attenzione aggiungere !App alla fine
            options.App = "com.companyname.appspesecorrezione_9zz4h110yvjzm!App";

            //Indica i driver da chiamare al Sistema Operatiovo
            options.AddAdditionalAppiumOption("ms:experimental-webdriver", true);
            //Avvia l'APP e attende 10s
            options.AddAdditionalAppiumOption("ms:waitForAppLaunch", "10");

            //Uniform Resource Identifier
            var serverUri = new Uri("http://127.0.0.1:4723/");

            _driver = new WindowsDriver(serverUri, options);
        }

        [Test]
        public void Test_verificaTitoloApp()
        {
            Assert.That(_driver.Title, Is.EqualTo("AppSpeseCorrezione").Or.Contain("LE MIE SPESE"));
            
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
    }
}
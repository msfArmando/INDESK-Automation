using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndeskAutomation
{
    internal class Automations
    {
        IWebDriver Driver;

        public Automations()
        {
            WebDriver.GetInstance();
            Driver = WebDriver.Driver;
        }

        public void GoToWebSite(string url)
        {
            Driver.Navigate().GoToUrl(url);
            Driver.Manage().Window.Maximize();
        }

        public void Login(string userAdmin, string userPassword)
        {
            try
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;

                var inputUser = WebDriver.TryFindElementWithEx(Paths.inputUser, 10, 500);
                var inputPassword = WebDriver.TryFindElementWithEx(Paths.inputPassword, 10, 500);
                var btnlogin = WebDriver.TryFindElementWithEx(Paths.btnLogin, 10, 500);

                inputUser.SendKeys(userAdmin);
                inputPassword.SendKeys(userPassword);

                WaitSpinner();

                executor.ExecuteScript("arguments[0].click();", btnlogin);

                if (!Driver.PageSource.Contains("Indesk ADM"))
                    throw new Exception();
            }
            catch (Exception)
            {
                throw new Exception("Erro no login");
            }
        }

        public void CadastrarSenha(string codSenhaRegistro, string codSenha)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            try
            {
                List<IWebElement> listSenhas = new List<IWebElement>();
                listSenhas = WebDriver.TryFindElementsWithEx($"//div[contains(@class, 'q-item q-item-type row no-wrap itens bg-secondary') and contains(., '{codSenha}')]/div[contains(@class, 'q-item__section column q-item__section--side justify-center')]/div/i", 10, 500);

                foreach (var item in listSenhas)
                {
                    executor.ExecuteScript("arguments[0].click();", item);
                    WaitSpinner();

                    var inputSenha = WebDriver.TryFindElementWithEx(Paths.inputSenha, 10, 500);
                    inputSenha.SendKeys(codSenhaRegistro);

                    var selectSenha = WebDriver.TryFindElementWithEx(Paths.selectSenha, 10, 500);
                    executor.ExecuteScript("arguments[0].click();", selectSenha);

                    var btnAtualizar = WebDriver.TryFindElementWithEx(Paths.btnAtualizar, 10, 500);
                    executor.ExecuteScript("arguments[0].click()", btnAtualizar);

                    WaitSpinner();
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro no cadastro");
            }
        }

        public void WaitSpinner()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            wait.Until(driver => !Driver.PageSource.Contains("spinner"));
        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}

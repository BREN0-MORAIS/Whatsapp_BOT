using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;

namespace BotWhatsapp
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://web.whatsapp.com/";
            List<String> contatos = new List<string>()
            {
                "Gabriel ADS",
                "",
                "Gabriel ADS"
            };
            //instanciar o chrome 
            ChromeDriver driver = new ChromeDriver();

            //maximizar a tela
            driver.Manage().Window.Maximize();

            //passando a url para abriri no chrome 
            driver.Navigate().GoToUrl(url);

            //tempo para escanear o codigo da tela
            Thread.Sleep(17000);

            foreach (var contato in contatos)
            {
                //<div class="_3FRCZ copyable-text selectable-text" contenteditable="true" data-tab="3" dir="ltr"></div>
                var pesquisaEl = driver.FindElementByClassName("_3FRCZ");
                pesquisaEl.SendKeys(contato);
                Thread.Sleep(2000);

                //pega o elemento com o titulo da propriedade
                //<span class="_357i8"><span dir="auto" title="Gabriel ADS" class="_3ko75 _5h6Y_ _3Whw5"><span class="matched-text _3Whw5">Gab</span>riel ADS</span><div class="_3XFan"></div></span>
                var ContatoEl = driver.FindElementByXPath($"//span[@title='{contato}']");
                Thread.Sleep(1000);
                //clicka no elemento
                ContatoEl.Click();

                //<div class="_3FRCZ copyable-text selectable-text" contenteditable="true" data-tab="1" dir="ltr" spellcheck="true"></div>
                var msg = driver.FindElementByClassName("_3uMse");
                Thread.Sleep(1000);
                msg.SendKeys("Testando  boot");

                var btnEnviar = driver.FindElementByClassName("_1U1xa");
                btnEnviar.Click();


            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndeskAutomation
{
    public static class Paths
    {
        public static string inputUser = "//input[contains(@autocomplete, 'username')]";
        public static string inputPassword = "//input[contains(@autocomplete, 'password')]";
        public static string btnLogin = "//span[contains(@class, 'q-btn__content text-center col items-center q-anchor--skip justify-center row')]";
        public static string inputSenha = "//input[contains(@aria-label, 'Buscar senha')]";
        public static string selectSenha = "//div[contains(@class, 'q-item__section column q-item__section--side q-item__section--top justify-start')]/div/div/div";
        public static string btnAtualizar = "//button[contains(., 'Atualizar')]";

        //div[contains(@class, 'q-item q-item-type row no-wrap itens bg-secondary') and contains(., 'ATFIN')]/div[contains(@class, 'q-item__section column q-item__section--side justify-center')]/div/i
    }
}

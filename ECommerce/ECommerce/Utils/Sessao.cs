using System;
using System.Web;

namespace ECommerce.Utils
{
    public class Sessao
    {
        private const string NOME_SESSAO = "CarrinhoID";
        public static string RetornarCarrinhoID()
        {
            if(HttpContext.Current.Session[NOME_SESSAO] == null)
            {
                Guid guid = Guid.NewGuid();
                HttpContext.Current.Session[NOME_SESSAO] = guid.ToString();
            }
            return HttpContext.Current.Session[NOME_SESSAO].ToString();
        }
    }
}
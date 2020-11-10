using CompartilharJogos.Domain._Base;
using Xunit;

namespace CompartilharJogos.Test._Util
{
    public static class AssertExtension
    {
        public static void WithMessagem(this ExceptionDomain exception, string mensagem)
        {
            if (exception.MessagemErrors.Contains(mensagem))
                Assert.True(true);
            else
                Assert.False(true, $"Esperava a {mensagem}");
        }
    }
}

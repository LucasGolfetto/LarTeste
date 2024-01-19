using LarTeste_API.Models;

namespace LarTeste_API.Data
{
    public static class PessoaData
    {
        public static List<Pessoa> pessoaList = new List<Pessoa> {
                new Pessoa {Id=1, Nome="Lucas", CPF="99999999999", DataNascimento="08/08/1997", EstaAtivo=true},
                new Pessoa {Id=2, Nome="Gustavo", CPF="99999999999", DataNascimento="10/10/2000", EstaAtivo=true}
                };
    }
}

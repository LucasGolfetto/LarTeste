using LarTeste_API.Models;

namespace LarTeste_API.Data
{
    public static class TelefoneData
    {
        public static List<Telefone> telefoneList = new List<Telefone> {
                new Telefone {Id=1, Numero="9898989898", Tipo="Residencial", IsWhatsApp=false, PessoaId=2},
                new Telefone {Id=2, Numero="8989898989", Tipo="Celular", IsWhatsApp=true, PessoaId=1}
                };
    }
}

namespace AjudaFacil.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public DateTime DataDeNascimento { get; set; }
    public string CPF { get; set; }
    public string CNPJ { get; set; }
    public string Endereco { get; set; }
    public string Cidade { get; set; }
    public int CEP { get; set; }
    public string Celular { get; set; }
    public string TelefoneResidencial { get; set; }
    public string Sexo { get; set; }
    public int TotalDoacoes { get; set; }
    public IList<Doacao> Doacoes { get; set; }
}

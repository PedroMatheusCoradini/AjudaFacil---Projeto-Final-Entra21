namespace AjudaFacil.Models;

public class DoacoesDeRoupas
{
    public int Id { get; set; }
    public int QuantidadeDePecasDeRoupa { get; set; }
    public string DescricaoDasRoupas { get; set; }
    public int PesoEmKg { get; set; }
    public string Imagem { get; set; }
    public Doacao Doacao { get; set; }
}

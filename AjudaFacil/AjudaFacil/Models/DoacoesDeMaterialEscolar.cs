namespace AjudaFacil.Models;

public class DoacoesDeMaterialEscolar
{
    public int Id { get; set; }
    public string DescricaoDosMateriais { get; set; }
    public int Peso { get; set; }
    public string Imagem { get; set; }
    public Doacao Doacao { get; set; }
}

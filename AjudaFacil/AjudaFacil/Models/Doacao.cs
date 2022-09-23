namespace AjudaFacil.Models;

public class Doacao
{
    public int Id { get; set; }
    public Usuario Doador { get; set; }
    public IList<DoacoesDeRoupas> DoacoesDeRoupa { get; set; }
    public IList<DoacoesDeMaterialEscolar> DoacoesDeMateriaisEscolares { get; set; }
}

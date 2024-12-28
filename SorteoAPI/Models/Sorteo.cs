namespace SorteoAPI.Models
{
    public class Sorteo
    {
        public int IdSorteo {get; set;}
        public string NombreSorteo {get; set;} = string.Empty;

        public int IdCliente {get; set;}
        public Cliente Cliente { get; set; } = null!;

        public ICollection<NumAsignado> NumAsignados { get; set; } = new List<NumAsignado>();
    }
}

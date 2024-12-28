namespace SorteoAPI.Models
{
    public class NumAsignado
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdSorteo { get; set; }
        public int IdUsuario { get; set; }
        public string NumeroAsignado { get; set; } = string.Empty;
        public Cliente Cliente { get; set; } = null!;
        public Sorteo Sorteo { get; set; } = null!;
        public Usuario Usuario { get; set; } = null!;
    }
}

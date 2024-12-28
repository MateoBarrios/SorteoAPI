namespace SorteoAPI.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; } = null!;

        public ICollection<NumAsignado> NumAsignados { get; set; } = new List<NumAsignado>();
    }
}

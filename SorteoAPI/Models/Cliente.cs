namespace SorteoAPI.Models
{
    public class Cliente
    {
        public int IdCliente {  get; set; }
        public string NombreCliente { get; set; } = string.Empty;
        public ICollection<Sorteo> Sorteos { get; set; } = new List<Sorteo>();
        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public ICollection<NumAsignado> NumAsignados { get; set; } = new List<NumAsignado>();


    }
}

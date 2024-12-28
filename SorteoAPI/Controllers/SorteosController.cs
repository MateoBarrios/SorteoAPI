using Microsoft.AspNetCore.Mvc;
using SorteoAPI.Models;

[ApiController]
[Route("api/numeros")]

public class SorteosController : ControllerBase
{
    private readonly SorteoDBContext _Context;

    public SorteosController(SorteoDBContext context)
    {
        _Context = context;
    }

    [HttpPost("asignar")]

    public async Task<ActionResult> AsignarNumero(int idCliente, int idUsuario, int idSorteo)
    {
        //validar existencia

        var cliente = await _Context.Clientes.FindAsync(idCliente);
        var usuario = await _Context.Usuarios.FindAsync(idUsuario);
        var sorteo = await _Context.Sorteos.FindAsync(idSorteo);    

        if (cliente == null || usuario == null || sorteo == null)
            return NotFound("Cliente, Usuario o Sorte no existe.");

        if (usuario.IdCliente != idCliente)
            return BadRequest("El usuario no pertenece al cliente especificado.");

        if (sorteo.IdCliente != idCliente)
            return BadRequest("El sorteo no pertenece al cliente especificado.");

        //generando nùmero único
        var numerosAsignados = _Context.NumAsignados.Select(n => Convert.ToInt32(n.NumeroAsignado)).ToList();

        var numeroDisponible = Enumerable.Range(1, 99999).Except(numerosAsignados).FirstOrDefault().ToString("D5");

        if (numeroDisponible == "00000")
            return Conflict("No hay números disponibles para asignar");

        var numeroAsignado = new NumAsignado
        {
            IdCliente = idCliente,
            IdUsuario = idUsuario,
            IdSorteo = idSorteo,
            NumeroAsignado = numeroDisponible
        };

        _Context.NumAsignados.Add(numeroAsignado);
        await _Context.SaveChangesAsync();

        return Ok( new {numerosAsignados = numeroDisponible});
    }
        
}
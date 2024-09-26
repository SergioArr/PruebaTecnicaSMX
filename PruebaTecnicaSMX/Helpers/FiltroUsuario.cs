using PruebaTecnicaSMX.Models;

namespace PruebaTecnicaSMX.Helpers
{
    public class FiltroUsuario
    {
        public static List<Usuario> FiltrarUsuariosPorDominio(List<Usuario> usuarios, string dominio)
        {
            return usuarios.Where(u => u.CorreoElectronico.EndsWith($"@{dominio}")).ToList();
        }

    }
}

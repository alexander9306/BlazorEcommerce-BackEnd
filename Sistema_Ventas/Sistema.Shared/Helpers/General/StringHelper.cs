namespace Sistema.Shared.Helpers.General
{
<<<<<<< HEAD
    public class StringHelper : IStringHelper
=======
    public class StringHelper: IStringHelper
>>>>>>> origin/Reynaldo
    {
        public string GetDescripcion(string descripcion, int maxLength = 60)
        {
            if (descripcion == null)
            {
                return string.Empty;
            }

            return descripcion.Length < maxLength ? descripcion : descripcion.Substring(0, maxLength) + "...";
        }

        public string GetEstado(bool estado)
        {
            return estado ? "Activo" : "Desactivado";
        }
    }
}

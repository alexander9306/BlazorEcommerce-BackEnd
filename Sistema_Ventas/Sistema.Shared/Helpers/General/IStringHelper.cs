namespace Sistema.Shared.Helpers.General
{
    public interface IStringHelper
    {
        public string GetDescripcion(string descripcion, int maxLength = 60);

        public string GetEstado(bool estado);
    }
}

namespace ServerDeclara.Servicios
{
    public class CabeceraServicio
    {

        private string Titulo;
        public event Action OnActualizarMenu;

        private void SetTitulo(string titulo)
        {
            Titulo = titulo;
        }

        public string GetTitulo()
        {
            return Titulo;
        }

        public void ActualizarTituloMenu(string titulo)
        {
            SetTitulo(titulo);
            OnActualizarMenu?.Invoke();
        }
    }
}

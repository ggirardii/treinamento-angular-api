namespace Api
{
    public static class IdMusica
    {
        private static int _ultimoId { get; set; } = 0;
        public static int Proximo()
        {
            _ultimoId++;
            return _ultimoId;
        }
    }
}

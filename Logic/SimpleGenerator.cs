namespace Logic
{
    /// <summary>
    /// Class for generating ID for product
    /// </summary>
    public static class SimpleIDGenerator
    {
        private static int Id = 0;

        public static int Generate()
        {
            return Id++;
        }
    }
}

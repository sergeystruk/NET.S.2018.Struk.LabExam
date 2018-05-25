namespace Logic
{
    public class SimpleGenerator : IGenerator
    {
        private static int Id = 0;

        public int Generate()
        {
            return Id++;
        }
    }
}

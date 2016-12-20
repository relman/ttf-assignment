namespace TTF
{
    public class OutputFactory : IOutputFactory
    {
        public IOutput Create()
        {
            return new Output();
        }
    }
}

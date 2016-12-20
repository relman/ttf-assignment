namespace TTF
{
    public interface IInput
    {
        bool A { get; }

        bool B { get; }

        bool C { get; }

        int D { get; }

        int E { get; }

        int F { get; }
    }

    public class Input : IInput
    {
        public bool A { get; private set; }

        public bool B { get; private set; }

        public bool C { get; private set; }

        public int D { get; private set; }

        public int E { get; private set; }

        public int F { get; private set; }

        public Input(bool a, bool b, bool c, int d, int e, int f)
        {
            A = a;
            B = b;
            C = c;
            D = d;
            E = e;
            F = f;
        }
    }
}

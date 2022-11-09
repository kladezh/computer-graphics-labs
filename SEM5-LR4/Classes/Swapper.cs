namespace SEM5_LR4.Classes
{
    public class Swapper
    {
        static public void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
    }
}

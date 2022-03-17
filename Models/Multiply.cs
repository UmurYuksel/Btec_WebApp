namespace Btec_WebApp.Models
{
    public class Multiply : Operator
    {
        public override float Operate(float firstArgument, float secondArgument)
        {
            return firstArgument * secondArgument;
        }
    }
}

namespace Btec_WebApp.Models
{
    public class Add : Operator
    {
        public override float Operate(float firstArgument, float secondArgument)
        {
            return firstArgument + secondArgument;
        }
    }
}

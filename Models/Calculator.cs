namespace Btec_WebApp.Models
{
    public class Calculator
    {
        private float num1;
        private float num2;
        private string choice;

        public float Result { get; set; } = 0;
        public bool IsError { get; set; } = false;
        public string ErrorMessage { get; set; } = "";

        public Calculator(float number1, float number2, string userChoice)
        {
            this.num1 = number1;
            this.num2 = number2;
            this.choice = userChoice;
            Calculate();
        }

        //Main Calculation Operation Happens Here =>
        public void Calculate()
        {
            //If I would use "using" it would be more efficient for the application, after creating an instance from Operator class, I could dispose it automatically,
            //But since this is a lightweight app, I can do it like this =>
            Operator opt;

            switch (choice)
            {
                case "Add":
                    opt = new Add();
                    Result = opt.Operate(num1, num2);
                    break;
                case "Multiply":
                    opt = new Multiply();
                    Result = opt.Operate(num1, num2);
                    break;
                default:
                    IsError = true;
                    ErrorMessage = "Please input * or + ";
                    break;
            }
        }
    }
}

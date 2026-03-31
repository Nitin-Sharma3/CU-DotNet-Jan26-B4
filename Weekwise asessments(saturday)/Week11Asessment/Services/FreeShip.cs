namespace Week11AsessmentDI.Services
{
    public class FreeShip : IPricingService
    {
        int price = 50;

        public decimal ApplyDiscount(int num,string promocode)
        {
            if(promocode == "WINTER25")
            {
                return num-num*.15m;
            }
            if (promocode == "FREESHIP")
            {
                if (num > 5)
                    return num - 5;
                else
                    return num;
            }
            else
                return num;
        }


    }
}

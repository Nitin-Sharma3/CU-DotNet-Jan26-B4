namespace Week11AsessmentDI.Services
{
    public interface IPricingService
    {
        decimal ApplyDiscount(int num, string promocode);

    }
}

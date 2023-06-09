namespace API.Requests.CustomCake
{
    public record AddCustomCakeRequest(string Name, string Description, decimal PriceBrutto, int[] IngredientList);
}

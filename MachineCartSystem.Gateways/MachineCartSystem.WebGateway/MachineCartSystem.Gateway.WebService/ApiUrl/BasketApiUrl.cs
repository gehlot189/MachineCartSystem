namespace MachineCartSystem.Gateway.WebService.ApiUrl
{
    public class BasketApiUrl
    {
        public static string GetItemById(string id) => $"/api/v1/basket/itemByid/{id}";
        public static string UpdateBasket() => "/api/v1/basket";
    }
}

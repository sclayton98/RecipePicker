using Azure;
using Azure.Data.Tables;
using RecipePickerClassLibrary.Models;

namespace RecipePickerClassLibrary
{
    public interface IRecipePort
    {
        Pageable<RecipeTableEntity> GetAllRecipesForMeal(Meal mealType);
    }

    public class RecipePort : IRecipePort
    {
        private TableClient _tableClient;

        public RecipePort(TableClient tableClient)
        {
            _tableClient = tableClient;
        }

        public Pageable<RecipeTableEntity> GetAllRecipesForMeal(Meal mealType)
        {
            return _tableClient.Query<RecipeTableEntity>(filter: $"PartitionKey eq '{mealType}'", maxPerPage: 10000);
        }
    }
}
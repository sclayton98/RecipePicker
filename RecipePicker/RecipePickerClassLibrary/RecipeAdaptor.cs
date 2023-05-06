using Azure;
using RecipePickerClassLibrary.Models;
using System.Text.Json;

namespace RecipePickerClassLibrary
{
    public interface IRecipeAdaptor
    {
        Recipe GetRecipe(Meal mealType);
    }

    public class RecipeAdaptor : IRecipeAdaptor
    {
        private IRecipePort _recipePort;

        public RecipeAdaptor(IRecipePort recipePort)
        {
            _recipePort = recipePort;
        }

        public Recipe GetRecipe(Meal mealType)
        {
            Pageable<RecipeTableEntity> recipes = _recipePort.GetAllRecipesForMeal(mealType);
            Recipe recipe = JsonSerializer.Deserialize<Recipe>(recipes.First().SerialisedRecipe);
            return recipe;
        }
    }
}
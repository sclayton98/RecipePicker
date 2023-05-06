using RecipePickerClassLibrary.Models;

namespace RecipePickerClassLibrary
{
    public class Orchestrator
    {
        private IRecipeAdaptor _adaptor;

        public Orchestrator(IRecipeAdaptor adaptor)
        {
            _adaptor = adaptor;
        }

        public List<Day> GenerateRecipesForWeek()
        {
            List<Day> daysOfTheWeek = new List<Day>();
            for (int dayOfWeek = 0; dayOfWeek < 7; dayOfWeek++)
            {
                Day day = new Day();
                day.Breakfast = _adaptor.GetRecipe(Meal.Breakfast);
                daysOfTheWeek.Add(day);
            }

            return daysOfTheWeek;
        }
    }
}
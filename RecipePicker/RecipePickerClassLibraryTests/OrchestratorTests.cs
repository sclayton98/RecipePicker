using RecipePickerClassLibrary;
using RecipePickerClassLibrary.Models;

namespace RecipePickerClassLibraryTests
{
    public class OrchestratorTests
    {
        [Fact]
        public void ShouldCallRecipeAdaptorForEachMealOfTheDayForTheWholeWeek()
        {
            //Arrange
            Mock<IRecipeAdaptor> mockAdaptor = new Mock<IRecipeAdaptor>();
            Orchestrator orchestrator = new Orchestrator(mockAdaptor.Object);

            //Act
            orchestrator.GenerateRecipesForWeek();

            //Assert
            using (new AssertionScope())
            {
                mockAdaptor.Verify(x => x.GetRecipe(Meal.Breakfast), Times.Exactly(7));
                mockAdaptor.Verify(x => x.GetRecipe(Meal.Lunch), Times.Exactly(7));
                mockAdaptor.Verify(x => x.GetRecipe(Meal.Dinner), Times.Exactly(7));
            }
        }
    }
}
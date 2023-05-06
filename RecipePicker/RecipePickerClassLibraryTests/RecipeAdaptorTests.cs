using RecipePickerClassLibrary;
using RecipePickerClassLibrary.Models;

namespace RecipePickerClassLibraryTests
{
    public class RecipeAdaptorTests
    {

        [Theory]
        [InlineData(Meal.Breakfast)]
        [InlineData(Meal.Lunch)]
        [InlineData(Meal.Dinner)]
        [InlineData(Meal.Snack)]
        public void ShouldCallRecipePort(Meal mealType)
        {
            //Arrange
            Mock<IRecipePort> mockPort = new Mock<IRecipePort>();
            IRecipeAdaptor adaptor = new RecipeAdaptor(mockPort.Object);

            //Act
            adaptor.GetRecipe(mealType);

            //Assert
            mockPort.Verify(x => x.GetAllRecipesForMeal(mealType), Times.Once);
        }
    }
}

using Azure;
using Azure.Data.Tables;
using Microsoft.Extensions.Configuration;
using RecipePickerClassLibrary;
using RecipePickerClassLibrary.Models;

namespace RecipePickerClassLibraryTests
{
    public class RecipePortTests : IClassFixture<RecipePortTestsFixture>
    {
        private TableClient _tableClient;

        public RecipePortTests(RecipePortTestsFixture fixture)
        {
            _tableClient = fixture.TableClient;
        }

        [Theory]
        [InlineData(Meal.Breakfast)]
        [InlineData(Meal.Lunch)]
        [InlineData(Meal.Dinner)]
        [InlineData(Meal.Snack)]
        public void ShouldGetRecipeForEveryMealType(Meal mealType)
        {
            //Arrange
            IRecipePort port = new RecipePort(_tableClient);

            //Act
            Pageable<RecipeTableEntity> response = port.GetAllRecipesForMeal(mealType);

            //Assert
            response.Should().NotBeNull();
        }
    }

    public class RecipePortTestsFixture
    {
        public TableClient TableClient { get; private set; }

        public RecipePortTestsFixture()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddUserSecrets<RecipePortTests>(optional: true)
                .Build();

            TableClient = new TableClient(config["RecipeStorageConnectionString"], "Recipes");
        }
    }
}

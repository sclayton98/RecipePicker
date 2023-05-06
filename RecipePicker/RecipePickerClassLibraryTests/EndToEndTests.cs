using Azure.Data.Tables;
using Microsoft.Extensions.Configuration;
using RecipePickerClassLibrary;

namespace RecipePickerClassLibraryTests
{
    public class EndToEndTests : IClassFixture<EndToEndTestsFixture>
    {
        private TableClient _tableClient;

        public EndToEndTests(EndToEndTestsFixture fixture)
        {
            _tableClient = fixture.TableClient;
        }

        [Fact]
        public void ShouldReturnListOfRecipesForEveryDayOfTheWeek()
        {
            //Arrange
            IRecipePort recipePort = new RecipePort(_tableClient);
            IRecipeAdaptor recipeAdaptor = new RecipeAdaptor(recipePort);
            Orchestrator orchestrator = new Orchestrator(recipeAdaptor);

            //Act
            List<Day> response = orchestrator.GenerateRecipesForWeek();

            //Assert
            response.Should().HaveCount(7);
        }
    }

    public class EndToEndTestsFixture
    {
        public TableClient TableClient { get; private set; }

        public EndToEndTestsFixture()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddUserSecrets<EndToEndTests>(optional: true)
                .Build();

            TableClient = new TableClient(config["RecipeStorageConnectionString"], "Recipes");
        }
    }
}
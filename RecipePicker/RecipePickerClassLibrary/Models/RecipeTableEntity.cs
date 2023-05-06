using Azure;
using Azure.Data.Tables;

namespace RecipePickerClassLibrary.Models
{
    public class RecipeTableEntity : ITableEntity
    {
        public string PartitionKey { get; set; } // Meal type
        public string RowKey { get; set; } // Name of recipe
        public string SerialisedRecipe { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
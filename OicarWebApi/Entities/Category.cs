using System.Text.Json.Serialization;


namespace OicarWebApi.Entities
{
    public class Category
    { 
        public int Idcategory { get; set; }
        public string Title { get; set; } = null!;
        
    }
}

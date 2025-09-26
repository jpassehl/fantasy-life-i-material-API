namespace fantasy_life_i_material_API.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Crafted { get; set; } = false;
        public string?[] GatheredFrom { get; set; }
        public string? LifeRequired { get; set; }
        public string Category { get; set; }
    }
}

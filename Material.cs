namespace fantasy_life_i_material_API
{
    public class Material
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Gatherable { get; set; }
        public string[] GatheredFrom { get; set; }
        public string LifeRequired { get; set; }
        public string Category { get; set; }
    }
}

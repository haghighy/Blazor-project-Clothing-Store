namespace FinalProject.Shared
{
    public class Clothe
    {
        public int price{get; set;}
        public string Name{get; set;}
        public int Id{get; set;}
        public int Count{get; set;}
        public string Color{get; set;}
        public string Image_Src{get; set;}
        public override string ToString() =>
            $"{this.Name}, {this.price}, {this.Id}, {this.Color}";
        
        public override int GetHashCode()
            => this.Id;
        public override bool Equals(object obj)
        {
            var other = obj as Clothe;
            if (obj is null) return false;
            return this.Id == other.Id;
        }

        public void SetValue(Clothe other)
        {
            this.price = other.price;
            this.Name = other.Name;
            this.Count = other.Count;
            // this.Id = other.Id;
            this.Color = other.Color;
            this.Image_Src = other.Image_Src;
        }
    }
}
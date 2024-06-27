namespace Catalogue
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double UnitPrice { get; set; }

        public Product() : this(0, "pname", 0) {}
        public Product(int Id,string Title,double UnitPrice)
        {
            this.Id = Id;
            this.Title = Title;
            this.UnitPrice = UnitPrice;
        }

        public override string ToString() { 
            return "[ Id : "+this.Id+" Title : "+this.Title+" UnitPrice : "+this.UnitPrice+" ]";
        }
    }
}

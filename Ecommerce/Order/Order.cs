using System.Text;

namespace Orderprocessing
{
    public class Order
    {
        private int id { get; set; }
        private int[] prodId { get; set; }
        private double orderAmount { get; set; }
        private DateTime OrderDate { get; set; }

        public Order():this(0,new int[5],0){ }
        public Order(int id, int[] prodId,
            double orderAmount)
        {
            this.id = id;
            this.prodId = prodId;
            this.orderAmount = orderAmount;
            this.OrderDate = DateTime.Now;
        }

        StringBuilder ArrElem()
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < prodId.Length; i++)
            {
                sb.Append(prodId[i] + " ");
            }
            return sb;
        }


        public override string ToString()
        {
            return "[ Order Id : " + this.id + " Prod arr : " +
                ArrElem() + " Order Amount : " + this.orderAmount +
                " Order Date : " + this.OrderDate.ToString() + " ]";
        }


    }
}

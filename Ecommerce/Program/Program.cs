using Catalogue;
using Orderprocessing;
/*
int[] arr=new int[4];

Product p=new Product();
Product p1 = new Product(1,"Crackers",2000);
Product p2 = new Product(2,"Farsan",3000);
Product p3 = new Product(3,"Decoration",4000);
Console.WriteLine(p);
Console.WriteLine(p1);
Console.WriteLine(p2);
Console.WriteLine(p3);

arr[0]=p.Id;
arr[1]=p1.Id;
arr[2]=p2.Id;
arr[3]=p3.Id;

double amount= p.UnitPrice + p1.UnitPrice + p2.UnitPrice+
    p3.UnitPrice;

Order o1 = new Order(1,arr,amount);

System.Console.WriteLine(o1);
*/
Console.WriteLine("Welcome to Shop");
Boolean exit = false;
Product[] parr=new Product[20];
Order[] oarr=new Order[20];
int count = 0, ocount = 0, onum=0;
double ordamt = 0;
int[] pidarr ;

while (!exit)
{
    Console.WriteLine("Enter 0 to Exit:\nEnter 1 to add Product:\n" +
        "Enter 2 to Book an Order:\n" +
        "Enter 3 to Print order details:\nEnter 4 to Print Product details:\n");
    switch (Convert.ToInt32(Console.ReadLine()))
    {
        case 0 :
            exit = true;
            break;
        case 1:
            Console.WriteLine("Enter product Details: product Id, Name, Unit Price");
            Product product = new Product(
                Convert.ToInt16(Console.ReadLine()),
                Console.ReadLine(),
                Convert.ToDouble(Console.ReadLine())
                );
            Console.WriteLine(product);
            parr[count++] = product;
            break;

        case 2:
            pidarr = new int[count];
            for(int k = 0; k < count; k++)
            {
                pidarr[k]= parr[k].Id;
                //Console.WriteLine("parr[k].Id " + parr[k].Id);
                ordamt += parr[k].UnitPrice;
                //Console.WriteLine("parr[k].UnitPrice " + parr[k].UnitPrice);
            }
            oarr[ocount++] = new Order(++onum,pidarr,ordamt);
            count = 0;
            Console.WriteLine("-----------You have Ordered Successfully-----------");
            break;
        case 3:
            Console.WriteLine("Your Product details are : ");
            for (int r = 0; r < parr.Length; r++)
            {
                Console.WriteLine(parr[r]);
            }
            break;
        case 4:
            Console.WriteLine("Your Order details are : ");
            for (int h = 0; h < oarr.Length; h++)
            {
                Console.WriteLine(oarr[h]);
            }
            break;
    }
}


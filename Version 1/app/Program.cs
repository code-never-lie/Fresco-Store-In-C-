using System;  
public class app  
{   public class Basket
    {
       public static int full_size = 30;
       public static int half_size = 20;
       public static int pull_along = 25;
       public static int total_basket = 75;
       public static int cash = 0;
       public static int index = 0;
       public static int most = 0;
       public static int least = 0;
       public static bool flag = true;
       public static  int[] issuedBasketArray = new int[total_basket];
       public static  int[] fullSizeBasket = new int[full_size];
       public static  int[] halfSizeBasket = new int[half_size];
       public static  int[] pullAlongBasket = new int[pull_along];
       public static  int[] mostPopularBasket = new int[total_basket];
       public static  int[] leastPopularBasket = new int[total_basket];
       public static void BasketInit(){
            flag = false;
            for (int i = 0; i < full_size; i++ ) {
                fullSizeBasket.SetValue(1000 + i,i);
            }
            for (int i = 0; i < half_size; i++ ) {
                halfSizeBasket[i] = i + 2000;
            }
            for (int i = 0; i < pull_along; i++ ) {
                pullAlongBasket[i] = i + 3000;
            }
       }

    }
    class Store{
        public void ShowMenu(){
            Console.Write("\n               *************************************\n");
            Console.Write("                     Wel Come to Fresco Store\n");
            Console.Write("               *************************************");
            Console.Write("\n");
            Console.Write("\nHere are the options :\n");
            Console.Write("1: Press 1 for Issued Basket.\n2: Press 2 for Returned Basket.\n3: Press 3 for Check Currently Loaned Basket.\n4: Press 4 for Check Currently not Loaned Basket.\n5: Press 5 for Check Popularity of Basket.\n6: Press 6 for Lost of Basket.\n7: Press 7 for Exit.\n");
        }
        public void IssuedBasket(){
            int choice1, allocate_number;
            Console.Write("\nSelect the Basket Type:\n");
            Console.Write("1: Press 1 for Full-size Basket.\n2: Press 2 for Half-size Basket.\n3: Press 3 for Pull-along Basket.\n4: Press 4 for Main Menu.\n");
            Console.Write("\nEnter your choice :");
            choice1 = Convert.ToInt32(Console.ReadLine());
            switch(choice1) {
            case 1:
                Console.Write("\nIssued Basket in range (1001-1030)\n");
                allocate_number = Convert.ToInt32(Console.ReadLine());
                if(allocate_number >= 1001 && allocate_number <= 1030){
                    if(Array.Exists(Basket.issuedBasketArray, x => x == allocate_number)){
                        Console.Write("\nThis Basket Already Issue!!\n");
                        IssuedBasket();
                    }else{
                        Basket.cash += 5;
                        Basket.issuedBasketArray.SetValue(allocate_number, Basket.index++);
                        Basket.fullSizeBasket = Basket.fullSizeBasket.Except(new int[]{allocate_number}).ToArray();
                        Basket.full_size--;
                        Console.WriteLine("{0} Basket issued to the customer", allocate_number);
                        Console.WriteLine("Press any key...");
                        Console.ReadKey();
                    }
                }
               Console.Write("Enter correct option\n");
                IssuedBasket();
               break;
            case 2:
                Console.Write("\nIssued Basket in range (2001-2020)\n");
                allocate_number = Convert.ToInt32(Console.ReadLine());
                if(allocate_number >= 2001 && allocate_number <= 2020){
                    if(Array.Exists(Basket.issuedBasketArray, x => x == allocate_number)){
                        Console.Write("\nThis Basket Already Issue!!\n");
                        IssuedBasket();
                    }else{
                        Basket.cash += 5;
                        Basket.issuedBasketArray.SetValue(allocate_number, Basket.index++);
                        Basket.halfSizeBasket = Basket.halfSizeBasket.Except(new int[]{allocate_number}).ToArray();
                        Basket.half_size--;
                        Console.WriteLine("{0} Basket issued to the customer", allocate_number);
                        Console.WriteLine("Press any key...");
                        Console.ReadKey();
                    }
                }
               Console.Write("Enter correct option\n");
                IssuedBasket();
                break;
                
            case 3:
                Console.Write("\nIssued Basket in range (3001-3025)\n");
                allocate_number = Convert.ToInt32(Console.ReadLine());
                if(allocate_number >= 3001 && allocate_number <= 3025){
                    if(Array.Exists(Basket.issuedBasketArray, x => x == allocate_number)){
                        Console.Write("\nThis Basket Already Issue!!\n");
                        IssuedBasket();
                    }else{
                        Basket.cash += 5;
                        Basket.issuedBasketArray.SetValue(allocate_number, Basket.index++);
                        Basket.pullAlongBasket = Basket.pullAlongBasket.Except(new int[]{allocate_number}).ToArray();
                        Basket.pull_along--;
                        Console.WriteLine("{0} Basket issued to the customer", allocate_number);
                        Console.WriteLine("Press any key...");
                        Console.ReadKey();
                    }
                }
               Console.Write("Enter correct option\n");
                IssuedBasket();
                break;  
            case 4: 
                Main();
                break;
            default:
                Console.Write("Enter correct option\n");
                IssuedBasket();
                break; 
            }
        }
        public void ReturnedBasket(){
            int basket_number, basket_review;
            if(Basket.issuedBasketArray[0] != 0){
                Console.Write("\nList of Issued Basket\n"); 
                for (int j = 0; j < Basket.issuedBasketArray.Length; j++ ) {
                    if(Basket.issuedBasketArray[j]  >= 1001 && Basket.issuedBasketArray[j] <= 1030)
                        Console.WriteLine("{0} -> {1} (Full-Size Basket)  ",j, Basket.issuedBasketArray[j]);
                    if(Basket.issuedBasketArray[j]  >= 2001 && Basket.issuedBasketArray[j] <= 2020)
                        Console.WriteLine("{0} -> {1} (Half-Size Basket)  ",j, Basket.issuedBasketArray[j]);
                    if(Basket.issuedBasketArray[j]  >= 3001 && Basket.issuedBasketArray[j] <= 3025)
                        Console.WriteLine("{0} -> {1} (Pull-Allong Basket)  ",j, Basket.issuedBasketArray[j]);
                }
                Console.Write("\nPlease enter which type of basket return\n"); 
                basket_number = Convert.ToInt32(Console.ReadLine());
                if(Array.Exists(Basket.issuedBasketArray, x => x == basket_number)){
                    Console.Write("\nEnter customer review for this Trolley/Basket (1-5)\n"); 
                    basket_review = Convert.ToInt32(Console.ReadLine());
                    if(basket_review >= 1 && basket_review <= 5){
                        if( basket_review > 3){
                            Basket.mostPopularBasket.SetValue(basket_number, Basket.most++);
                        }else{
                            Basket.leastPopularBasket.SetValue(basket_number, Basket.least++);
                        }
                        if(basket_number  >= 1001 && basket_number <= 1030){
                            Basket.full_size++;
                            // Basket.fullSizeBasket.SetValue(basket_number, Basket.full_size++);
                        }
                        if(basket_number  >= 2001 && basket_number <= 2020){
                            Basket.half_size++;
                            // Basket.halfSizeBasket.SetValue(basket_number, Basket.half_size++);
                        }
                        if(basket_number  >= 3001 && basket_number <= 3025){
                            Basket.pull_along++;
                            // Basket.pullAlongBasket.SetValue(basket_number, Basket.pull_along++);
                        }
                        Basket.issuedBasketArray = Basket.issuedBasketArray.Except(new int[]{basket_number}).ToArray();
                        Basket.index--;
                        Basket.cash -= 5;
                    }else{
                    Console.Write("\nEnter correct input!!\n"); 
                    ReturnedBasket();
                }
                    
                }else{
                Console.Write("\nEnter correct input!!\n"); 
                ReturnedBasket();
                }
            }else{
             Console.Write("\nPlease Issue Trolley/Basket first!\n"); 
            }
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            Main();
        }
        public void CheckLoanedBasket(){
             Console.Write("\n               *************************************\n");
            Console.Write("                   Currenty Loaned Trolleys/Baskets\n");
            Console.Write("               *************************************");
            int fb = 0, hb = 0, pb = 0, count = 0;
            for (int j = 0; j < Basket.issuedBasketArray.Length; j++ ) {
                if(Basket.issuedBasketArray[j]  >= 1001 && Basket.issuedBasketArray[j] <= 1030){
                    fb++;
                    count++;
                }
                if(Basket.issuedBasketArray[j]  >= 2001 && Basket.issuedBasketArray[j] <= 2020){
                    hb++;
                    count++;
                }
                if(Basket.issuedBasketArray[j]  >= 3001 && Basket.issuedBasketArray[j] <= 3025){
                    pb++;
                    count++;
                }     
            }
            Console.Write("\n               Total Trolleys/Baskets on loaned: {0}\n", count);
            Console.Write("\n               Total Full-Size Trolleys/Baskets on loaned: {0}\n", fb);
            Console.Write("\n               Total Half-Size Trolleys/Baskets on loaned: {0}\n", hb);
            Console.Write("\n               Total Pull-Allong Trolleys/Baskets on loaned: {0}\n", pb);
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            Main();
        }
        public void CheckNotLoanedBasket(){
             Console.Write("\n               *************************************\n");
            Console.Write("                   Currenty not on Loaned Trolleys/Baskets\n");
            Console.Write("               *************************************");
            Console.Write("\n               Total Trolleys/Baskets not on loaned: {0}\n", (Basket.full_size + Basket.half_size + Basket.pull_along));
            Console.Write("\n               Total Full-Size Trolleys/Baskets not on loaned: {0}\n", Basket.full_size);
            Console.Write("\n               Total Half-Size Trolleys/Baskets not on loaned: {0}\n", Basket.half_size);
            Console.Write("\n               Total Pull-Allong Trolleys/Baskets not on loaned: {0}\n", Basket.pull_along);
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            Main();
        }
        public void CheckBasketPopularity(){
            Console.Write("\n               *************************************\n");
            Console.Write("                   Most Popular Trolleys/Baskets\n");
            Console.Write("               *************************************\n");
             for (int j = 0; j < Basket.mostPopularBasket.Length; j++ ) {
                if(Basket.mostPopularBasket[j]  >= 1001 && Basket.mostPopularBasket[j] <= 1030)
                    Console.WriteLine("             {0} -> {1} (Full-Size Basket)  ",j, Basket.mostPopularBasket[j]);
                if(Basket.mostPopularBasket[j]  >= 2001 && Basket.mostPopularBasket[j] <= 2020)
                    Console.WriteLine("             {0} -> {1} (Half-Size Basket)  ",j, Basket.mostPopularBasket[j]);
                if(Basket.mostPopularBasket[j]  >= 3001 && Basket.mostPopularBasket[j] <= 3025)
                    Console.WriteLine("             {0} -> {1} (Pull-Allong Basket)  ",j, Basket.mostPopularBasket[j]);
            }
            Console.Write("\n               *************************************\n");
            Console.Write("                   Least Popular Trolleys/Baskets\n");
            Console.Write("               *************************************\n");
             for (int j = 0; j < Basket.leastPopularBasket.Length; j++ ) {
                if(Basket.leastPopularBasket[j]  >= 1001 && Basket.leastPopularBasket[j] <= 1030)
                    Console.WriteLine("             {0} -> {1} (Full-Size Basket)  ",j, Basket.leastPopularBasket[j]);
                if(Basket.leastPopularBasket[j]  >= 2001 && Basket.leastPopularBasket[j] <= 2020)
                    Console.WriteLine("             {0} -> {1} (Half-Size Basket)  ",j, Basket.leastPopularBasket[j]);
                if(Basket.leastPopularBasket[j]  >= 3001 && Basket.leastPopularBasket[j] <= 3025)
                    Console.WriteLine("             {0} -> {1} (Pull-Allong Basket)  ",j, Basket.leastPopularBasket[j]);
            }
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            Main();
        }
        public void ShowLostBasket(){
             Console.Write("\n               *************************************\n");
            Console.Write("                   Total Lost Trolleys/Baskets\n");
            Console.Write("               *************************************");
            int  count = 0;
            for (int j = 0; j < Basket.issuedBasketArray.Length; j++ ) {
                    if(Basket.issuedBasketArray[j]  >= 1001 && Basket.issuedBasketArray[j] <= 1030){
                        count++;
                        Console.WriteLine("                 {0} -> {1} (Full-Size Basket)  ",j, Basket.issuedBasketArray[j]);
                    }
                    if(Basket.issuedBasketArray[j]  >= 2001 && Basket.issuedBasketArray[j] <= 2020){
                        count++;
                        Console.WriteLine("                 {0} -> {1} (Half-Size Basket)  ",j, Basket.issuedBasketArray[j]);
                    } 
                    if(Basket.issuedBasketArray[j]  >= 3001 && Basket.issuedBasketArray[j] <= 3025){
                        count++;
                        Console.WriteLine("                 {0} -> {1} (Pull-Allong Basket)  ",j, Basket.issuedBasketArray[j]);
                    }
                        
                }
            Console.Write("\n               Total lost Trolleys/Baskets today: {0}\n", count);
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            Main();
        }
        public void Exit(){
            Console.Write("Thank you for doing bussiness with us! Have a nice day\n");
            Basket.flag = false;
            Environment.Exit(0);
        }
        public static void Main()  
        {
            int choice;
            Store str = new Store();
            if(Basket.flag){
                Basket.BasketInit();
            }
            str.ShowMenu();
            Console.Write("\nEnter your choice :");
            choice = Convert.ToInt32(Console.ReadLine());

            switch(choice) {
            case 1:
                str.IssuedBasket();
                break;
                
            case 2:
                str.ReturnedBasket();
                break;
                
            case 3:
                str.CheckLoanedBasket();
                break;  
            
            case 4: 
                str.CheckNotLoanedBasket();
                break;
                
            case 5:
                str.CheckBasketPopularity(); 
                break; 
            case 6: 
                str.ShowLostBasket();
                break; 
            case 7: 
                str.Exit();
                break;
            default:
                Console.Write("Enter correct option\n");
                Main();
                break; 
            }
        }
    }
   
}

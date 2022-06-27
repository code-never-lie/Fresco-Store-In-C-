using System;
using System.Linq;
public class StoreManagement  
{  
    public class Global{
        public static int payLoan = 0, fs = 0, hs = 0, ps = 0, ms = 0, ls = 0;
        public static int fullSizeBasket = 30;
        public static int halfSizeBasket = 20;
        public static int pullAlongBasket = 25;
        public static  int[] recordFullSizeBasket  = new int[fullSizeBasket];
        public static  int[] recordHalfSizeBasket  = new int[halfSizeBasket];
        public static  int[] recordPullAlongBasket  = new int[pullAlongBasket];
        public static  int[] mostBasket = new int[50];
        public static  int[] leastBasket = new int[50];
    }
    class BasketRecord{
        public int basket_number, basket_type;
        public void RcordToIssuedTrolley(){
            Console.Write("\n                    *** Issued Basket ***\n");
            Console.Write("Press 1 to issued full size Trolley\n");
            Console.Write("Press 2 to issued half size Trolley\n");
            Console.Write("Press 3 to issued pull along Trolley\n");
            Console.Write("Press 4 to returned Main Menu\n");
            Console.Write("\nPlease select which type of you want to issued\n");
            basket_type = Convert.ToInt32(Console.ReadLine());
            switch(basket_type) {
                case 1:
                    Console.Write("\nPlease enter Basket/Trolley number from 1001 to 1030\n");
                    basket_number = Convert.ToInt32(Console.ReadLine());
                    if(basket_number >= 1001 && basket_number <= 1030){
                        if(!Array.Exists(Global.recordFullSizeBasket, element => element == basket_number)){
                            Global.payLoan += 5;
                            Global.recordFullSizeBasket.SetValue(basket_number, Global.fs);
                            Global.fs += 1;
                            Global.fullSizeBasket -= 1;
                            Console.WriteLine("Basket {0} Assigned to the customer on 5 Euro loan", basket_number);
                            Console.WriteLine("Press Enter to return issued again");
                            Console.ReadKey();
                            RcordToIssuedTrolley();
                            
                        }else{
                            Console.Write("\nThis Basket Already on loan.Please enter other\n");
                            RcordToIssuedTrolley();
                        }
                    }else{
                        Console.Write("Incorret Input!! Plase enter number from 1001 to 1030\n");
                        RcordToIssuedTrolley();
                    }
                   
                    break;
                case 2:
                    Console.Write("\nPlease enter Basket/Trolley number from 2001 to 2020\n");
                    basket_number = Convert.ToInt32(Console.ReadLine());
                    if(basket_number >= 2001 && basket_number <= 2020){
                        if(!Array.Exists(Global.recordHalfSizeBasket, element => element == basket_number)){
                            Global.payLoan += 5;
                            Global.recordHalfSizeBasket.SetValue(basket_number, Global.hs);
                            Global.hs += 1;
                            Global.halfSizeBasket -= 1;
                            Console.WriteLine("Basket {0} Assigned to the customer on 5 Euro loan", basket_number);
                            Console.WriteLine("Press Enter to return issued again");
                            Console.ReadKey();
                            RcordToIssuedTrolley();
                            
                        }else{
                            Console.Write("\nThis Basket Already on loan.Please enter other\n");
                            RcordToIssuedTrolley();
                        }
                    }else{
                        Console.Write("Incorret Input!! Plase enter number from 2001 to 2020\n");
                        RcordToIssuedTrolley();
                    }
                    break;
                    
                case 3:
                    Console.Write("\nPlease enter Basket/Trolley number from 3001 to 3025\n");
                    basket_number = Convert.ToInt32(Console.ReadLine());
                    if(basket_number >= 3001 && basket_number <= 3025){
                        if(!Array.Exists(Global.recordPullAlongBasket, element => element == basket_number)){
                            Global.payLoan += 5;
                            Global.recordPullAlongBasket.SetValue(basket_number, Global.ps);
                            Global.ps += 1;
                            Global.pullAlongBasket -= 1;
                            Console.WriteLine("Basket {0} Assigned to the customer on 5 Euro loan", basket_number);
                            Console.WriteLine("Press Enter to return issued again");
                            Console.ReadKey();
                            RcordToIssuedTrolley();
                            
                        }else{
                            Console.Write("\nThis Basket Already on loan.Please enter other\n");
                            RcordToIssuedTrolley();
                        }
                    }else{
                        Console.Write("Incorret Input!! Plase enter number from 3001 to 3025\n");
                        RcordToIssuedTrolley();
                    }
                    break;  
                case 4: 
                    Main();
                    break;
                default:
                    Console.Write("Invalid Input!!\n");
                    RcordToIssuedTrolley();
                    break; 
            }
        }
        public void RcordToReturnedTrolley(){
            int starRate;
            Console.Write("\n\n                    *** Returned Basket ***\n");
            Console.Write("Press 1 to returned full size Trolley\n");
            Console.Write("Press 2 to returned half size Trolley\n");
            Console.Write("Press 3 to returned pull along Trolley\n");
            Console.Write("Press 4 to returned Main Menu\n");
            Console.Write("\nPlease select which type of Basket you want to returned\n");
            basket_type = Convert.ToInt32(Console.ReadLine());
            switch(basket_type) {
                case 1:
                    if(Global.recordFullSizeBasket[0] != 0){
                        Console.Write("\n\n\n        Full size Basket currently on loaned\n");
                        Console.Write("              ------------------------------------\n");
                        for (int i=0; i< Global.recordFullSizeBasket.Count(i => i != 0); i++){
                            Console.Write("{0} => {1}   ",i, Global.recordFullSizeBasket[i]);
                        }
                        Console.Write("\nPlease enter Basket/Trolley number from above list\n");
                        basket_number = Convert.ToInt32(Console.ReadLine());
                        if(Array.Exists(Global.recordFullSizeBasket, element => element == basket_number)){
                            Global.recordFullSizeBasket = Global.recordFullSizeBasket.Where(val => val != basket_number).ToArray();
                            Global.fullSizeBasket += 1;
                            Global.payLoan -= 5;
                            Global.fs -= 1;
                            Console.WriteLine("\nBasket {0} is return from the customer and give customer's 5 Euro loan back\n", basket_number);
                            
                        }else{
                            Console.Write("Incorrect please enter number from above list\n");
                           RcordToReturnedTrolley();
                        }
                    }else{
                        Console.Write("No Full size basket currently on loan\n");
                        RcordToIssuedTrolley();
                    }
                    Console.Write("\nRate this Basket by giving the star from 1-6 (*******)\n");
                    starRate = Convert.ToInt32(Console.ReadLine());
                    if(starRate >= 4 && starRate <= 5){
                        if(!Array.Exists(Global.mostBasket, element => element == basket_number)){
                            Global.mostBasket.SetValue(basket_number, Global.ms);
                            Global.ms += 1;
                        }
                    }else if(starRate >= 1 && starRate <= 3){
                        if(!Array.Exists(Global.leastBasket, element => element == basket_number))
                        {
                            Global.leastBasket.SetValue(basket_number, Global.ls);
                            Global.ls += 1; 
                        }
                    }
                    Console.WriteLine("Press Enter to return basket");
                    Console.ReadKey();
                    RcordToReturnedTrolley();
                    break;
                case 2:
                    if(Global.recordHalfSizeBasket[0] != 0){
                        Console.Write("\n\n          Half size Basket currently on loaned\n");
                        Console.Write("              ------------------------------------\n");
                        for (int i=0; i< Global.recordHalfSizeBasket.Count(i => i != 0); i++){
                            Console.Write("{0} => {1}   ",i, Global.recordHalfSizeBasket[i]);
                        }
                        Console.Write("\nPlease enter Basket/Trolley number from above list\n");
                        basket_number = Convert.ToInt32(Console.ReadLine());
                        if(Array.Exists(Global.recordHalfSizeBasket, element => element == basket_number)){
                            Global.recordHalfSizeBasket = Global.recordHalfSizeBasket.Where(val => val != basket_number).ToArray();
                            Global.halfSizeBasket += 1;
                            Global.payLoan -= 5;
                            Global.hs -= 1;
                            Console.WriteLine("\nBasket {0} is return from the customer and give customer's 5 Euro loan back\n", basket_number);
                        }else{
                           Console.Write("Incorrect please enter number from above list\n");
                           RcordToReturnedTrolley();
                        }
                    }else{
                        Console.Write("No Full size basket currently on loan\n");
                        RcordToIssuedTrolley();
                    }
                    Console.Write("\nRate this Basket by giving the star from 1-6 (*******)\n");
                    starRate = Convert.ToInt32(Console.ReadLine());
                    if(starRate >= 4 && starRate <= 5){
                        if(!Array.Exists(Global.mostBasket, element => element == basket_number)){
                            Global.mostBasket.SetValue(basket_number, Global.ms);
                            Global.ms += 1;
                        }
                    }else if(starRate >= 1 && starRate <= 3){
                        if(!Array.Exists(Global.leastBasket, element => element == basket_number))
                        {
                            Global.leastBasket.SetValue(basket_number, Global.ls);
                            Global.ls += 1; 
                        }
                    }
                    Console.WriteLine("Press Enter to return basket");
                    Console.ReadKey();
                    RcordToReturnedTrolley();
                    break;
                    
                case 3:
                    if(Global.recordPullAlongBasket[0] != 0){
                        Console.Write("\n\n          Pull along Basket currently on loaned\n");
                        Console.Write("              ------------------------------------\n");
                        for (int i=0; i< Global.recordPullAlongBasket.Count(i => i != 0); i++) {
                            Console.Write("{0} => {1}   ",i, Global.recordPullAlongBasket[i]);
                        }
                        Console.Write("\nPlease enter Basket/Trolley number from above list\n");
                        basket_number = Convert.ToInt32(Console.ReadLine());
                        if(Array.Exists(Global.recordPullAlongBasket, element => element == basket_number)){
                            Global.recordPullAlongBasket = Global.recordPullAlongBasket.Where(val => val != basket_number).ToArray();
                            Global.fullSizeBasket += 1;
                            Global.payLoan -= 5;
                            Global.ps -= 1;
                            Console.WriteLine("\nBasket {0} is return from the customer and give customer's 5 Euro loan back\n", basket_number);
                            
                        }else{
                            Console.Write("Incorrect please enter number from above list\n");
                            RcordToReturnedTrolley();
                        }
                    }else{
                        Console.Write("No Full size basket currently on loan\n");
                        RcordToIssuedTrolley();
                    }
                    Console.Write("\nRate this Basket by giving the star from 1-6 (*******)\n");
                    starRate = Convert.ToInt32(Console.ReadLine());
                    if(starRate >= 4 && starRate <= 5){
                        if(!Array.Exists(Global.mostBasket, element => element == basket_number)){
                            Global.mostBasket.SetValue(basket_number, Global.ms);
                            Global.ms += 1;
                        }
                    }else if(starRate >= 1 && starRate <= 3){
                        if(!Array.Exists(Global.leastBasket, element => element == basket_number))
                        {
                            Global.leastBasket.SetValue(basket_number, Global.ls);
                            Global.ls += 1; 
                        }
                    }
                    Console.WriteLine("Press Enter to return basket");
                    Console.ReadKey();
                    RcordToReturnedTrolley();
                    break;  
                case 4: 
                    Main();
                    break;
                default:
                    Console.Write("Invalid Input!!\n");
                    RcordToReturnedTrolley();
                    break; 
            }
        }
        public void ViewOnLoaned(){
            int totalBasket = 0, total_full = 0, total_half = 0, total_plalong = 0;
            Console.Write("                   Full size Basket Currenty on Loaned\n");
            Console.Write("                   -----------------------------------\n\n");
            for (int i=0; i< Global.recordFullSizeBasket.Count(i => i != 0); i++) {
                Console.Write("{0}: {1}   ",i, Global.recordFullSizeBasket[i]);
                totalBasket += 1;
                total_full += 1;
            }
            Console.Write("\nTotal: {0}\n", total_full);
            Console.Write("\n\n               Half size Basket Currenty on Loaned\n");
            Console.Write("                  -----------------------------------\n\n");
            for (int i=0; i< Global.recordHalfSizeBasket.Count(i => i != 0); i++) {
                Console.Write("{0}: {1}   ",i, Global.recordHalfSizeBasket[i]);
                totalBasket += 1;
                total_half += 1;
            }
            Console.Write("\nTotal: {0}\n", total_half);
            Console.Write("\n                 Pull Along Basket Currenty on Loaned\n");
            Console.Write("                  -----------------------------------\n\n");
            for (int i=0; i< Global.recordPullAlongBasket.Count(i => i != 0); i++) {
                Console.Write("{0}: {1}   ",i, Global.recordPullAlongBasket[i]);
                totalBasket += 1;
                total_plalong += 1;
            }
            Console.Write("\nTotal: {0}\n", total_plalong);
            Console.Write("\nOverall Basket on loaned: {0}\n", totalBasket);
            Console.WriteLine("Press enter to returned Main Menu");
            Console.ReadKey();
            Main();
        }
        public void ViewNotOnLoaned(){
            Console.Write("\n\n                 Full size Basket Currenty not on Loaned: {0}\n", Global.fullSizeBasket);
            Console.Write("                 Half size Basket Currenty not on Loaned: {0}\n", Global.halfSizeBasket);
            Console.Write("                 Pull Along Basket Currenty not on Loaned: {0}\n", Global.pullAlongBasket);
            Console.Write("                 Overall Baskets Currenty not on Loaned: {0}\n", (Global.fullSizeBasket + Global.halfSizeBasket + Global.pullAlongBasket));
            Console.WriteLine("Press enter to returned Main Menu");
            Console.ReadKey();
            Main();
        }
        public void ViewMostAndLeastPupolarBasket(){
            Console.Write("\n\n                 Most Popular Baskets according to customer's rating\n");
            Console.Write("                  ---------------------------------------------------\n");
            for (int i=0; i< Global.mostBasket.Count(i => i != 0); i++) {
                Console.Write("{0}: {1}   ",i, Global.mostBasket[i]);
            }
            Console.Write("\n\n                  Least Popular Baskets according to customer's rating\n");
            Console.Write("                  ---------------------------------------------------\n");
           for (int i=0; i< Global.leastBasket.Count(i => i != 0); i++) {
                Console.Write("{0}: {1}   ",i, Global.leastBasket[i]);
            }
            Console.WriteLine("Press enter to returned Main Menu");
            Console.ReadKey();
            Main();
        }
        public void ViewLostBasket(){
            Console.Write("\n\n                Lost Baskets Today\n");
            Console.Write("                  ------------------");
            int  totalLostBaskets = 0; 
            if(Global.recordFullSizeBasket[0] != 0){
                Console.Write("\n\nFull size Baskets Lost: {0}\n", (30 - Global.fullSizeBasket));
                for (int i=0; i< Global.recordFullSizeBasket.Count(i => i != 0); i++) {
                    Console.Write("{0}: {1}   ",i, Global.recordFullSizeBasket[i]);
                    totalLostBaskets += 1;
                }
            }
            if(Global.recordHalfSizeBasket[0] != 0){
                Console.Write("\n\nHalf size Baskets Lost: {0}\n", (20 - Global.halfSizeBasket));
                for (int i=0; i< Global.recordHalfSizeBasket.Count(i => i != 0); i++) {
                    Console.Write("{0}: {1}   ",i, Global.recordHalfSizeBasket[i]);
                    totalLostBaskets += 1;
                }

            }
            if(Global.recordPullAlongBasket[0] != 0){
                Console.Write("\n\nPull Along Baskets Lost : {0}\n", (25 - Global.pullAlongBasket));
                for (int i=0; i< Global.recordPullAlongBasket.Count(i => i != 0); i++) {
                    Console.Write("{0}: {1}   ",i, Global.recordPullAlongBasket[i]);
                    totalLostBaskets += 1;
                }
            }
            Console.Write("\nTotal overall Trolleys/Baskets lost today: {0}\n", totalLostBaskets);
            Console.WriteLine("Press enter to returned Main Menu");
            Console.ReadKey();
            Main();
        }
        public void ExitProgram(){
            Console.Write("Exiting Program....\n");
            Environment.Exit(0);
        }
        public static void Main()  
        {
            int option;
            BasketRecord br = new BasketRecord();
            Console.Write("\n                                   *** MAIN MENU ***\n\n");
            Console.Write("Press 1 for Issued Trolley to the customer\n");
            Console.Write("Press 2 for Returned Trolley from the customer\n");
            Console.Write("Press 3 to view currently on loaned Trolley\n");
            Console.Write("Press 4 to view currently not on loaned Trolley\n");
            Console.Write("Press 5 to view most and least pupolar Trolley\n");
            Console.Write("Press 6 to view Lost Trolley today\n");
            Console.Write("Press 7 for Exit Program\n");
            Console.Write("\nChoose Option From Above:");
            option = Convert.ToInt32(Console.ReadLine());

            switch(option) {
            case 1:
                br.RcordToIssuedTrolley();
                break;
                
            case 2:
                br.RcordToReturnedTrolley();
                break;
                
            case 3:
                br.ViewOnLoaned();
                break;  
            
            case 4: 
                br.ViewNotOnLoaned();
                break;
                
            case 5:
                br.ViewMostAndLeastPupolarBasket(); 
                break; 
            case 6: 
                br.ViewLostBasket();
                break; 
            case 7: 
                br.ExitProgram();
                break;
            default:
                Console.Write("Invalid input!!\n");
                Main();
                break; 
            }
        }
    }
   
}

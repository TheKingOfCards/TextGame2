string pText = "restart";
int hp = 20;
int enemyHealth = 10;
int pDamage;
int enemyDamage;
int coins = 0;
int coinDrop;   
bool axe = false;
bool healthPotion = false;
bool pTurn = true;
bool dead = false;
bool whileEnemyDead = false;
bool shopping = false;

Random rng = new Random();


battle();
void battle(){
    if(pText == "continue" || pText == "exit"){
        Console.Clear();
        Console.WriteLine("Another monster stands before you");
    }
    if(pText == "restart"){
        Console.Clear();
        Console.WriteLine("You wake up\nWhere are you?\nAll you have left is your sword\nYour thoughts get interupted by a monster\nWrite \"attack\" to attack the monster");
    }
    while(dead == false){
    //Player turn
        while(pTurn == true){
            pText = Console.ReadLine();
        //Light Attack
            if(pText == "attack"){
                pDamage = rng.Next(5,11);
                enemyHealth -= pDamage;
                Console.WriteLine($"\nYou attack the enemy dealing {pDamage} damage");
                Console.WriteLine($"Enemy health = {enemyHealth}");
                pTurn = false;
            }
            else if(axe == true){
                if(pText == "heavy"){
                    pDamage = rng.Next(10,21);
                    enemyHealth -= pDamage;
                    Console.WriteLine($"\nYou attack the enemy wiht the axe dealing {pDamage} damage");
                    Console.WriteLine($"Enemy health = {enemyHealth}");
                    pTurn = false;
                }
            }
            else{
                Console.WriteLine("Try something else");
            }
        }

    //If enemy dead
        if(enemyHealth <= 0){
            coinDrop = rng.Next(50,101);
            coins += coinDrop;
            Console.WriteLine("\nYou killed the monster");
            Console.WriteLine($"The monster dropped {coinDrop} coins");
            Console.WriteLine("\nWrite \"continue\" to fight again\nWrite \"shop\" to go into the shop");
            whileEnemyDead = true;
        }
//Enemy dead
while(whileEnemyDead == true){  
    pText = Console.ReadLine();
    if(pText == "shop"){
        shopping = true;
        Console.Clear();
        shop();
    }
    else if(pText == "continue"){
            whileEnemyDead = false;
            pTurn = true;
            battle();
        }
    else{
        Console.WriteLine("Try something else");
    }
}
    //Enemy turn
        while(pTurn == false){
            enemyDamage = rng.Next(5,11);
            hp -= enemyDamage;
            Console.WriteLine("\nThe enemy attacked you");
            Console.WriteLine($"Dealing {enemyDamage}");
            Console.WriteLine($"Your health = {hp}");
            pTurn = true;
        }
        
    //If player dead
        if(hp <= 0){
            dead = true;
        }
    }
}


//Shop
void shop(){
    Console.WriteLine("You enter the shop\nThe only thing you can buy is an axe for 50 coins\nWrite \"axe\" to buy\nWrite \"exit to\" leave the shop");
    Console.WriteLine($"You have {coins} coins");
    while(shopping == true){
        pText = Console.ReadLine();
        //axe
        if(pText == "axe"){
            if(axe == false){
                Console.WriteLine("You have bought the axe\nWrite \"heavy\" to make a heavy attack");
                axe = true;
                coins -= 50;
            }
            else{
                Console.WriteLine("You already have the axe");
            }

        }
        //leave
        else if(pText == "exit"){
            shopping = false;
            pTurn = true;
            battle();
        }
        else{
            Console.WriteLine("Try someting else");
        }
    }
}

//Player dead
while(dead == true){
    Console.WriteLine("You died\nWrite \"restart\" to try again or \"end\" to exit");
    pText = Console.ReadLine();
    if(pText == "restart"){
        dead = false;
        pTurn = true;
        axe = false;
        healthPotion = false;
        battle();
    }
}


Console.ReadLine();
string pText = "restart";
int hp = 20;
int enemyHealth = 30;
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
    while(dead == false){
    //Player turn
    if(pText == "continue" || pText == "exit"){
        Console.Clear();
        Console.WriteLine("Another monster stands before you");
    }
    if(pText == "restart"){
        Console.Clear();
        Console.WriteLine("You wake up\nWhere are you?\nAll you have left is your sword\nYour thoughts get interupted by a monster\nWrite \"attack\" to attack the monster");
    }
        while(pTurn == true){
            pText = Console.ReadLine();
        //Light Attack
            if(pText == "attack"){
                pDamage = rng.Next(5,11);
                enemyHealth -= pDamage;
                Console.WriteLine($"You attack the enemy {pDamage}");
                Console.WriteLine($"Enemy health = {enemyHealth}");
                pTurn = false;
            }
            else{
                Console.WriteLine("Try something else");
            }
        }

    //If enemy dead
        if(enemyHealth <= 0){
            coinDrop = rng.Next(50,101);
            coins += coinDrop;
            Console.WriteLine("You killed the monster");
            Console.WriteLine();
            Console.WriteLine("Write \"continue\" to fight again\nWrite \"shop\" to go into the shop");
            whileEnemyDead = true;
        }

        while(whileEnemyDead == true){  
            pText = Console.ReadLine();
            if(pText == "shop"){
                shop();
            }
            else if(pText == "continue"){
                whileEnemyDead = false;
                pTurn = true;
            }
            else{
                Console.WriteLine("Try something else");
            }
        }

    //Enemy turn
        while(pTurn == false){
            enemyDamage = rng.Next(5,11);
            hp -= enemyDamage;
            Console.WriteLine("The enemy attacked you");
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
    while(shopping == true){
        Console.Clear();
        Console.WriteLine("You enter the shop\nThe only thing you can buy is an axe for 50 coins\nWrite \"axe\" to buy\nWrite \"exit to\" leave the shop");
        pText = Console.ReadLine();
        if(pText == "axe"){
            if(axe == false){
                
            }

        }
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
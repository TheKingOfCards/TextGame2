string pText = "restart";
int hp = 20;
int enemyHealth = 20;
int pDamage;
int enemyDamage = 0;
int coins = 0;
int coinDrop;   
int shieldBlock = 3;

bool healthPotion = false;
bool pTurn = true;
bool dead = false;
bool whileEnemyDead = false;
bool shopping = false;

bool axe = false;
bool shield = true;

Random rng = new Random();


battle();
void battle(){
    if(pText == "continue" || pText == "exit"){
        Console.Clear();
        Console.WriteLine("Another monster stands before you");
    }
    if(pText == "restart"){
        Console.Clear();
        Console.WriteLine("You wake up\nWhere are you?\nAll you have left is your sword and armour\nYour thoughts get interupted by a monster\nWrite \"attack\" to attack the monster");
    }
    while(dead == false){
    //Player turn
        while(pTurn == true){
            enemyDamage = rng.Next(10,12);
            pText = Console.ReadLine();
        //Light Attack
            if(pText == "attack"){
                pDamage = 10;
                enemyHealth -= pDamage;
                Console.WriteLine($"\nYou attack the enemy dealing {pDamage} damage");
                Console.WriteLine($"Enemy health = {enemyHealth}");
                pTurn = false;
            }
            else if(axe == true){
                if(pText == "heavy"){
                    pDamage = 20;
                    enemyHealth -= pDamage;
                    Console.WriteLine($"\nYou attack the enemy wiht the axe dealing {pDamage} damage");
                    Console.WriteLine($"Enemy health = {enemyHealth}");
                    pTurn = false;
                }
            }
            else if(shield == true){
                if(pText == "shield"){
                    Console.WriteLine($"You block the monsters strike (-{shieldBlock})");
                    enemyDamage -= 3;
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
    if(axe == false){
        Console.WriteLine("You can buy an \"axe\" for 50 coins (deals 20 damage can be upgraded)");
    }
    if(shield == false){
        Console.WriteLine("You can buy a \"shield\" for 25 gold (blocks 3 damage points and can be upgraded)");
    }
    Console.WriteLine("\nWrite \"exit\" to leave the shop");
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
        else if(pText == "shield"){
            if(shield == false){
                Console.WriteLine("You have bought the shield\nWrite \"shield\" to make a block");
                shield = true;
                coins -= 25;
            }
            else{
                Console.WriteLine("You already have the shield");
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
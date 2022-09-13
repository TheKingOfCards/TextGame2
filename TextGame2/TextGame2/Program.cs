string pText = "";
int hp = 20;
int enemyHealth = 20;
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

Console.WriteLine("You wake up\nWhere are you?\nAll you have left is your sword\nYour thoughts get interupted by a monster\nWrite \"attack\" to attack the monster");

battle();
void battle(){
    while(dead == false){
    //Player turn
    if(pText == "continue"){
        Console.WriteLine("Another monster stands before you");
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
            Console.WriteLine("You killed the monster");
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
            coinDrop = rng.Next(50,101);
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
        Console.WriteLine("THE SHOP!!!!");
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
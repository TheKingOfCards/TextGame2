string pText = "restart";
int hp = 10;
int hpHeal = 30;
int enemyHealth = 20;
int enemyProgression = 20;
int enemyProgressionPlus;
int pDamage;
int pBaseDamage = 10;
int pAxeDamage = 20;
int enemyDamage = 0;
int coins = 0;
int coinDrop;   
int critchance = 0;
int healthPotionAmount = 0;
int enemyKilled = 0;
int dodgeChange = 0;
int dodgeUpgrade = 20;
int healtpotionPouch = 1;
int healthpotionPouchCost = 25;
int axeChance;


bool pTurn = true;
bool dead1 = false;
bool whileEnemyDead = false;
bool shopping = false;

bool axe = false;
bool boots = false;

Random rng = new Random();



battle();
void battle(){
    if(pText == "continue" || pText == "exit"){
        Console.Clear();
        Console.WriteLine("Another monster stands before you");
        Console.WriteLine($"You enter the fight with {hp} health");
    }
    if(pText == "restart"){
        Console.Clear();
        Console.WriteLine("You wake up\nWhere are you?\nAll you have left is your sword and armour\nYour thoughts get interupted by a monster\nWrite \"attack\" to attack the monster");
    }
    enemyHealth = enemyProgression;
    while(dead1 == false){
    //Player turn
        while(pTurn == true){
            enemyDamage = rng.Next(10,13);
            critchance = rng.Next(0,100);
            pText = Console.ReadLine();
        //Light Attack
            if(pText == "attack"){
                pDamage = pBaseDamage;
                if(critchance <= 20){
                    pDamage = pDamage * 2;
                    enemyHealth -= pDamage;
                    Console.WriteLine("\nYou got a critical hit!");
                    Console.WriteLine($"You attack the enemy dealing {pDamage} damage");
                    Console.WriteLine($"Enemy health = {enemyHealth}");
                    pTurn = false;
                }
                else{
                    enemyHealth -= pDamage;
                    Console.WriteLine($"\nYou attack the enemy dealing {pDamage} damage");
                    Console.WriteLine($"Enemy health = {enemyHealth}");
                    pTurn = false;
                }
            }

            if(pText == "heavy"){
                if(axe == true){
                    axeChance = rng.Next(0,100);
                    if(axeChance <= 80){
                pDamage = pAxeDamage;
                    if(critchance <= 10){
                    pDamage = pDamage * 2;
                    enemyHealth -= pDamage;
                    Console.WriteLine("A critical hit!");
                    Console.WriteLine($"\nYou attack the enemy with the axe dealing {pDamage} damage");
                    Console.WriteLine($"Enemy health = {enemyHealth}");
                    pTurn = false;
                }
                else{
                    enemyHealth -= pDamage;
                    Console.WriteLine($"\nYou attack the enemy with the axe dealing {pDamage} damage");
                    Console.WriteLine($"Enemy health = {enemyHealth}");
                    pTurn = false;
                }
            }
            else{
                Console.WriteLine("You attack the monster but he it manages to dodge it");
                pTurn = false;
            }
        }
        else{
            Console.WriteLine("You don't have that");
        }
        }
            if(pText == "healthpotion"){
                if(healthPotionAmount >= 1){
                    healthPotionAmount--;
                    Console.WriteLine($"You used a healthpotion, you have {healthPotionAmount} left");
                    Console.WriteLine("You feel fully restored");
                    hp = hpHeal;
                }
            else if(healthPotionAmount == 0 && pText == "healthpotion"){
                Console.WriteLine("You don't have any healthpotions");
            }
            }
            if(pText != "attack" && pText != "heavy" && pText != "healthpotion"){
                Console.WriteLine("Try something else");
            }
        }

    //If enemy dead
        if(enemyHealth <= 0){
            enemyKilled++;
            coinDrop = rng.Next(25,51);
            coins += coinDrop;
            Console.WriteLine("\nYou killed the monster");
            Console.WriteLine($"The monster dropped {coinDrop} coins");
            Console.WriteLine("\nWrite \"continue\" to fight again\nWrite \"shop\" to go into the shop");
            enemyProgressionPlus = rng.Next(3,6);
            enemyProgression += enemyProgressionPlus;
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
            if(boots == true){
            dodgeChange = rng.Next(0,100);
                if(dodgeChange <= dodgeUpgrade){
                    Console.WriteLine("\nYou manage to dodge the attack, taking zero damage");
                    Console.WriteLine($"Your health {hp}");
                    pTurn = true;
                }
                else{
                    hp -= enemyDamage;
                    Console.WriteLine("\nThe enemy attacked you");
                    Console.WriteLine($"Dealing {enemyDamage}");
                    Console.WriteLine($"Your health = {hp}");
                    pTurn = true;
                }
            }
            else{
                hp -= enemyDamage;
                Console.WriteLine("\nThe enemy attacked you");
                Console.WriteLine($"Dealing {enemyDamage}");
                Console.WriteLine($"Your health = {hp}");
                pTurn = true;
            }
        }
        
        
    //If player dead
        if(hp <= 0){
            dead1 = true;
            dead();
        }
    }
}


//Shop
void shop(){
    if(axe == false){
        Console.WriteLine("\nYou can buy an \"axe\" for 100 coins (deals 20 damage but it's heavy so monsters have a change to dodge)");
    }

    if(boots == false){
        Console.WriteLine("\nYou can buy a \"boots\" for 30 gold (gives a 20% change to dodge an attack can be upgraded)");
    }
    else if(dodgeChange < 50){
        Console.WriteLine("\nYou can upgrade your \"boots\" for a higher chance to dodge");
    }

    if(healtpotionPouch != 3){
        Console.WriteLine($"\nUprgrade the amount of healthpotions you can carry, costs {healthpotionPouchCost}. Write \"upgrade\" too increase amount\n(Right now you can carry {healtpotionPouch}, max is 3)");
    }

    
    Console.WriteLine("\nYou can buy \"healthpotion\" for 20 gold (Fully restors your health)");
    
    Console.WriteLine("\nWrite \"exit\" to leave the shop");
    Console.WriteLine($"You have {coins} coins");
    while(shopping == true){
        pText = Console.ReadLine();
        //Axe
        if(pText == "axe"){
            if(axe == true){
                Console.WriteLine("\nYou already have the axe");
            }
        if(axe == false){
            if(coins > 100){
                Console.WriteLine("\nYou have bought the axe\nWrite \"heavy\" to make a heavy attack");
                axe = true;
                coins -= 50;
                Console.WriteLine($"You have {coins} coins left");
            }
            else{
                Console.WriteLine("\nYou can't afford that");
            }
        }
        }
        //Boots
        else if(pText == "boots"){
            if(boots == true){
                if(dodgeUpgrade < 50){
                    dodgeUpgrade += 10;
                    Console.WriteLine($"You upgraded your boots (dodge chnace is now {dodgeUpgrade}%)");
                }
                else{
                    Console.WriteLine("You have already fully upgraded your boots");
                }
            }
            if(boots == false){
                if(coins > 30){
                Console.WriteLine("\nYou have bought the boots, you know have a change to dodge attacks");
                boots = true;
                coins -= 30;
                Console.WriteLine($"You have {coins} coins left");
            }
            else{
                Console.WriteLine("\nYou can't afford that");
            }
            }
        }
        //Healthpotion
        else if(pText == "healthpotion"){
            if(healthPotionAmount == healtpotionPouch){
                Console.WriteLine("\nYou cannot buy more healthpotions");
            }
            if(coins > 20 && healthPotionAmount != healtpotionPouch){
                healthPotionAmount++;
                Console.WriteLine("\nYou bought a healthpotion");
                Console.WriteLine($"You have {healthPotionAmount} healthpotions");
                coins -= 20;
                Console.WriteLine($"You have {coins} coins left");
            }
            else if(coins<20){
                Console.WriteLine("\nYou can't afford that");
            }
        }
        //Healthpotion upgrade
        else if(pText == "upgrade"){
            if(healtpotionPouch == 3){
                Console.WriteLine("You can't upgrade that more");
            }
            else{
                healtpotionPouch++;
                coins -= healthpotionPouchCost;
                healthpotionPouchCost += 25;
                Console.WriteLine($"You upgraded the amount of healthpotions to {healtpotionPouch}");
                Console.WriteLine($"You have {coins} coins left");
            }
        }
        //leave
        else if(pText == "exit"){
            shopping = false;
            pTurn = true;
            whileEnemyDead = false;
            battle();
        }
        else{
            Console.WriteLine("\nTry someting else");
        }
    
}
}


//Player dead
void dead(){
while(dead1 == true){
    Console.Clear();
    Console.WriteLine("You died\nWrite \"restart\" to try again or \"end\" to exit");
    Console.WriteLine($"You killed {enemyKilled} monsters");
    pText = Console.ReadLine();
    if(pText == "restart"){
        hp = 30;
        hpHeal = 30;
        enemyHealth = 20;
        enemyProgression = 20;
        coins = 0;
        healthPotionAmount = 0;
        enemyKilled = 0;
        dodgeUpgrade = 20;
        healtpotionPouch = 1;
        healthpotionPouchCost = 25;
        pTurn = true;
        dead1 = false;
        whileEnemyDead = false;
        shopping = false;
        axe = false;
        boots = false;
        battle();
    }
    else if(pText == "end"){
        Console.WriteLine("Thanks for playing, hope to see you again!");
        dead1 = false;
    }
    else{
        Console.WriteLine("Try something else");
    }
}
    Console.ReadLine();
    Environment.Exit(0);
}



Console.ReadLine();
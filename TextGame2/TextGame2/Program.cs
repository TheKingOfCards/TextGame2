string pText;
int pHealth = 20;
int enemyHealth = 20;
int pDamage;
int enemyDamage;
bool axe = false;
bool healthPotion = false;
bool pTurn = true;
bool dead = false;

Random rng = new Random();

Console.WriteLine("You wake up\nWhere are you?\nAll you have left is your sword\nYour thoughts get interupted by a monster\nWrite \"attack\" to attack the monster");
battle();

void battle(){
    while(dead == false){
    //Player turn
        while(pTurn == true){
            pText = Console.ReadLine();
        //Light Attack
            if(pText == "attack"){
                pDamage = rng.Next(5,11);
                enemyHealth = enemyHealth - pDamage;
                Console.WriteLine($"You attack the enemy {pDamage}");
                if(enemyHealth < 0){
                    enemyHealth = 0;
                    Console.WriteLine($"Enemy health = {enemyHealth}");
                }
                else{
                Console.WriteLine($"Enemy health = {enemyHealth}");
                }
                pTurn = false;
            }
        }
    //Enemy turn
        while(pTurn == false){
            enemyDamage = rng.Next(5,11);
            pHealth = pHealth - enemyDamage;
            Console.WriteLine("The enemy attacked you");
            Console.WriteLine($"Dealing {enemyDamage}");
            Console.WriteLine($"Your health = {pHealth}");
            pTurn = true;
        }
    //If enemy dead
        if(enemyHealth <= 0){
            pText = Console.ReadLine();
           if(pText == "shop"){
                shop();
           }
           else if(pText == "continue"){
                pTurn = true;
           }
           else{
            Console.WriteLine("Try something else");
           }
        }

    //If player dead
        if(pHealth <= 0){
            dead = true;
        }
    }
}


void shop(){

}

if(dead == true){

}


Console.ReadLine();
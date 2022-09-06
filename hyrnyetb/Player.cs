class Player{
    public int maxHealth = 25;
    public float health = 25;
    int def = 1;
    float defMod = 0f;
    public int baseAtk = 10;
    float atkMod = 1.0f;
    public int actCount = 1;
    public float dmgTaken = 0;

    public void hurt(float dmg){
        for(int i = 0; i < def; i++){
            dmg = dmg/2;
        }
        health = health - (dmg  * (1f+defMod));
        dmgTaken = (dmg  * (1f+defMod));
    }

    public int act(int[] actions){
        int attacks = 0;
        for(int i = 0; i < actions.Length; i++){
            switch(actions[i]-1){
                case 0:
                attacks++;
                break;

                case 1:
                defend();
                break;

                case 2:
                heal();
                break;

                default:
                Console.WriteLine("ERROR 2");
                break;
            }
        }
        return attacks;
    }

    public float doDmg(){
        return baseAtk*atkMod;
    }

    void defend(){
        def++;
    }

    void heal(){
        health = health + (maxHealth/3);
        if(health > maxHealth) health = maxHealth;
    }
}
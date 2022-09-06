class Enemy{
    Random gen = new Random();
    public float hp;
    public float maxHp;
    int action = 0;
    public int type;
    float[] modifier = new float[] {1.25f, 0.50f, 1.50f};
    public bool defend = false;
    public float mdifficulty = 0.1f;
    public float dmgTaken = 0;
    
    public string[] names = {"Goblin", "Kobold", "Gnoll"};

    public void InitEnemy(){
        hp = gen.Next(0 + (int) (10*mdifficulty), (int) (20f * (1f + mdifficulty)));
        maxHp = hp;
        type = gen.Next(0,2);
        mdifficulty = (float) Math.Pow((1f + mdifficulty), 1.5) - 1f;
    }

    public string getAction(){
        switch(action){
            case 0:
            return "attack";
            case 1:
            return "defend";
            case 2:
            return "heal";
            default:
            return "ERROR";
        }
    }

    public int Act(){
        defend = false;
        bool atk = false;
        switch (action){
            case 0:
            atk = true;
            break;
            case 1:
            defend = true;
            break;
            case 2:
            hp = heal() + hp;
            break;
            default:
            Console.WriteLine("ERROR");
            break;
        }
        action = gen.Next(0,4);
        if(action == 3) action = type;
        if(atk == true) return 1;
        return 0;
    }
    
    public float doDamage(){
        float dmg = 10f * (float) gen.NextDouble();
        if(type == 0) dmg = dmg*modifier[0];
        return dmg;
    }

    public void hurt(float rawDmg){
        float dmg;
        if(type != 1){
            dmg = rawDmg;
        } else {
            dmg = rawDmg*modifier[1];
        }
        if(defend){
            dmg = dmg/2;
        }
        hp = hp - dmg;
        dmgTaken = dmg;
    }

    float heal(){
        float health = maxHp/4;
        if(type == 2){
            health = health*modifier[2];
        }
        health = health * 1f+mdifficulty;
        if(health > maxHp-hp){
            health = maxHp-hp;
        }
        return health;
    }


}
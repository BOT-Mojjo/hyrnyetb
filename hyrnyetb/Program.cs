using System;
namespace hyrnyetb{
    class Program{
        static void Main(){
            Enemy e1 = new Enemy();
            Player p1 = new Player();
            while(p1.health > 0){
                e1.InitEnemy();
                while(e1.hp > 0){
                    Console.Clear();
                    Console.WriteLine(e1.names[e1.type]);
                    Console.WriteLine(e1.hp+"/"+e1.maxHp);
                    Console.WriteLine("The "+ e1.names[e1.type] + " plans to " + e1.getAction());
                    Console.WriteLine();
                    Console.WriteLine("Paladin");
                    Console.WriteLine(p1.health + "/" + p1.maxHealth);
                    Console.WriteLine("Choose " + p1.actCount + " things to do:");
                    Console.WriteLine("1: Attack  2: Defend  3: Heal");
                    Console.WriteLine(e1.dmgTaken +" "+p1.dmgTaken + " "+ e1.mdifficulty);

                    int[] actions = new int[p1.actCount];
                    for(int i = 0; i < p1.actCount; i++){
                        int.TryParse(Console.ReadLine().Trim(), out actions[i]);
                    }

                    int atk = p1.act(actions);
                    for(int i = 0; i < atk; i++){
                        e1.hurt(p1.doDmg());
                    }

                    atk = e1.Act();
                    for(int i = 0; i < atk; i++){
                        p1.hurt(e1.doDamage());
                    }
                }
            }
        }
    }
}
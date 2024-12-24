using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;

namespace Search_for_Carry
{
    public abstract class Enemy
    {
        public string Name {  get; protected set; }
        public int Hp { get; protected set; }
        public int Atk { get; protected set; }
        public int Def {  get; protected set; }
        public int Level {  get; protected set; }
        public int DropCredit { get; protected set; }
        public int DropEXP {  get; protected set; }
        List<Items> _dropItems;
        public static Dictionary<string,Enemy> _enemyDictionary;

        public abstract Enemy Clone(int level);
        public virtual int Attack()
        {
            Console.WriteLine("뭔가 잘못 됨");
            return _enemyDictionary.Count;
        }
        
        //플레이어 체력 - 공격력

        public virtual Items Dead()
        {
            Console.WriteLine("뭔가 잘못 됨");
            return Items.CopyItem("운석");
        }
        //드랍 아이템 설정
        //돈 설정

    }

    public class Chicken : Enemy
    {
        //int _atk = 10;
        //int _def = 2;
        //int _hp = 120;
        //int _dropCredit = 3;
        //int _dropExp = 5;
        
       
        //Player _player;

        public Action LevelChange;
       

        public void LVChangeAtk()
        {
            Atk += 10;
        }
        public void LVChangeDef()
        {

            Def += 1;
        }
        public void LVChangeHp()
        {

            Hp += 120;
        }
        public void LVChangeCredit()
        {
            DropCredit += 1;
        }
        public void LVChangeEXP()
        {
            DropEXP += 10;
        }
        public Chicken()
        {
           
        }
        public Chicken(int level)
        {
            Name = "닭";
            Atk = 10;
            Def = 2;
            Hp = 120;
            DropCredit = 3;
            DropEXP = 5;

            LevelChange += LVChangeAtk;
            LevelChange += LVChangeDef;
            LevelChange += LVChangeHp;
            LevelChange += LVChangeCredit;
            LevelChange += LVChangeEXP;
            Level += level;

            //기본 스탯이 기본 레벨
            for(int  i = 1; i < Level; i++)
            {
                LevelChange.Invoke();
            }
        }


        public override int Attack()
        {
            Console.WriteLine("꼬꼬닥!!");
            return Atk;
        }

        public override Items Dead()
        {
            Console.WriteLine("꼬꼬옥!! 꼬꼬..");
            return Items.CopyItem("운석");
        }
        public override Enemy Clone(int level)
        {
            return new Chicken(level)
            {
                Level = level,
                Name = this.Name,
                Atk = this.Atk,
                Def = this.Def,
                Hp = this.Hp,
                DropCredit = this.DropCredit,
                DropEXP = this.DropEXP

            };
        }

    }

    public class Bat : Enemy
    {
        
        public Action LevelChange;
       

        public void LVChangeAtk()
        {
            Atk += 12;
        }
        public void LVChangeDef()
        {

            Def += 2;
        }
        public void LVChangeHp()
        {

            Hp += 100;
        }
        public void LVChangeCredit()
        {
            DropCredit += 1;
        }

        public Bat()
        {
            LevelChange += LVChangeAtk;
            LevelChange += LVChangeDef;
            LevelChange += LVChangeHp;
            LevelChange += LVChangeCredit;
      
            Name = "박쥐";
            Level = 1;
            Atk = 10;
            Def = 5;
            Hp = 160;
            DropCredit = 5;
            DropEXP = 10;

        }

        public Bat(int level)
        {
            Level += level;
            for(int i = 1;  i < Level; i++)
            {
                LevelChange.Invoke();
            }
        }


        public override int Attack()
        {
            Console.WriteLine("찌직!");
            return Atk;
        }

        public override Items Dead()
        {
            Console.WriteLine("뀌익..");
            return Items.CopyItem("");
        }
        public override Enemy Clone(int level)
        {
            return new Bat(level)
            {
                Level = level,
                Name = this.Name,
                Atk = this.Atk,
                Def = this.Def,
                Hp = this.Hp,
                DropCredit = this.DropCredit,
                DropEXP = this.DropEXP
            };
        }
    }

    public class Dog : Enemy
    {

        public Action LevelChange;
       

        public void LVChangeAtk()
        {
            Atk += 20;
        }
        public void LVChangeDef()
        {

            Def += 1;
        }
        public void LVChangeHp()
        {

            Hp += 100;
        }
        public void LVChangeCredit()
        {
            DropCredit += 2;
        }


        public Dog()
        {
           
            Name = "들개";
            Level = 2;
            Atk = 20;
            Def = 5;
            Hp = 300;
            DropCredit = 8;
            DropEXP = 20;
            LevelChange += LVChangeAtk;
            LevelChange += LVChangeDef;
            LevelChange += LVChangeHp;
            LevelChange += LVChangeCredit;
        }
        public Dog(int level)
        {
            
            Level += level;
            for (int i = 0; i < Level; i++)
            {
                LevelChange.Invoke();
            }

        }


        public override int Attack()
        {
            Console.WriteLine("컹!!");
            return Atk;
        }

        public override Items Dead()
        {
            Console.WriteLine("끼우웅..");
            return Items.CopyItem("");
        }
        public override Enemy Clone(int level)
        {
            return new Dog(level)
            {
                Level = level,
                Name = this.Name,
                Atk = this.Atk,
                Def = this.Def,
                Hp = this.Hp,
                DropCredit = this.DropCredit,
                DropEXP = this.DropEXP
            };
        }

    }

    public class Wolf : Enemy
    {
        
       

        public Action LevelChange;
   
        public void LVChangeAtk()
        {
            Atk += 25;
        }
        public void LVChangeDef()
        {

            Def += 2;
        }
        public void LVChangeHp()
        {

            Hp += 150;
        }
        public void LVChangeCredit()
        {
            DropCredit += 3;
        }

        public Wolf()
        {
           
            

        }
        public Wolf(int level)
        {
            Name = "늑대";
            Level = 3;
            Atk = 30;
            Def = 3;
            Hp = 600;
            DropCredit = 20;
            DropEXP = 40;
            LevelChange += LVChangeAtk;
            LevelChange += LVChangeDef;
            LevelChange += LVChangeHp;
            LevelChange += LVChangeCredit;
            Level += level;
            for (int i = 0; i < Level; i++)
            {
                LevelChange.Invoke();
            }
        }


        public override int Attack()
        {
            Console.WriteLine("크르르르");
            return Atk;
        }

        public override Items Dead()
        {
            Console.WriteLine("크허엉..");
            return Items.CopyItem("미스릴");
        }
        public override Enemy Clone(int level)
        {
            return new Wolf(level)
            {
                Level = level,
                Name = this.Name,
                Atk = this.Atk,
                Def = this.Def,
                Hp = this.Hp,
                DropCredit = this.DropCredit,
                DropEXP = this.DropEXP
            };
        }
    }

    public class Bear : Enemy
    {
       
       

        public Action LevelChange;
       

        public void LVChangeAtk()
        {
            Atk += 30;
        }
        public void LVChangeDef()
        {

            Def += 5;
        }
        public void LVChangeHp()
        {

            Hp += 300;
        }
        public void LVChangeCredit()
        {
            DropCredit += 5;
        }

        public Bear()
        {
            Name = "곰";
            Level = 6;
            Atk = 50;
            Def = 12;
            Hp = 1000;
            DropCredit = 40;
            DropEXP= 50;
            LevelChange += LVChangeAtk;
            LevelChange += LVChangeDef;
            LevelChange += LVChangeHp;
            LevelChange += LVChangeCredit;
           

        }

        public Bear(int level)
        {
            Level += level;
            for (int i = 0; i < Level; i++)
            {
                LevelChange.Invoke();
            }
        }

        public override int Attack()
        {
            Console.WriteLine("크어엉");
            return Atk;
        }

        public override Items Dead()
        {
            Console.WriteLine("꾸어엉..");
            return Items.CopyItem("");
        }
        public override Enemy Clone(int level)
        {
            return new Bear(level)
            {
                Level = level,
                Name = this.Name,
                Atk = this.Atk,
                Def = this.Def,
                Hp = this.Hp,
                DropCredit = this.DropCredit,
                DropEXP = this.DropEXP
            };
        }


    }

    public class Alpha : Enemy
    {
       


        public Alpha()
        {
            Name = "알파";
            Level = 12;
            Atk = 300;
            Def = 4;
            Hp = 5250;
            DropCredit = 100;
            DropEXP = 500;
        }
       
        public Alpha(int level)
        {
            Level += level;
        }



        public override int Attack()
        {
            Console.WriteLine("위이이잉");
            return Atk;
        }

        public override Items Dead()
        {
            Console.WriteLine("삐유웅..");
            return Items.CopyItem("미스릴");
        }
        public override Enemy Clone(int level)
        {
            return new Alpha(level)
            {
                Level = level,
                Name = this.Name,
                Atk = this.Atk,
                Def = this.Def,
                Hp = this.Hp,
                DropCredit = this.DropCredit,
                DropEXP = this.DropEXP
            };
        }

    }

    public class Omega : Enemy
    {

        public Omega()
        {
            Name = "오메가";
            Level = 16;
            Atk = 400;
            Def = 20;
            Hp = 8800;
            DropCredit = 200;
            DropEXP = 1000;
        }
        public Omega(int level)
        {
            Level += level;
        }

        public override int Attack()
        {
            Console.WriteLine("위이이잉");
            return Atk;
        }

        public override Items Dead()
        {
            Console.WriteLine("삐유우우웅..");
            return Items.CopyItem("뽀쮸코어");
        }
        public override Enemy Clone(int level)
        {
            return new Omega(level)
            {
                Level = level,
                Name = this.Name,
                Atk = this.Atk,
                Def = this.Def,
                Hp = this.Hp,
                DropCredit = this.DropCredit,
                DropEXP = this.DropEXP
            };
        }
    }

    public class DrWickline : Enemy
    {
       
      
        public DrWickline()
        {
            Name = "위클라인 박사";
            Level = 20;
            Atk = 800;
            Def = 100;
            Hp = 12500;
            DropCredit = 150;
            DropEXP = 2000;
        }

        public DrWickline(int level)
        {
            Level += level;
        }

        public override int Attack()
        {
            Console.WriteLine("크흐흐흐..");
            return Atk;
        }

        public override Items Dead()
        {
            Console.WriteLine("으어얽..");
            return Items.CopyItem("혀랙팩");
        }

        public override Enemy Clone(int level)
        {
            return new DrWickline(level)
            {
                Level = level,
                Name = this.Name,
                Atk = this.Atk,
                Def = this.Def,
                Hp = this.Hp,
                DropCredit = this.DropCredit,
                DropEXP = this.DropEXP
            };
        }


    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;

namespace Search_for_Carry
{
    public class Enemy
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
        

        public virtual int Attack()
        {
            Console.WriteLine("뭔가 잘못 됨");
            return _enemyDictionary.Count;
        }
        
        //플레이어 체력 - 공격력

        public virtual void Dead()
        {
            Console.WriteLine("뭔가 잘못 됨");
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
        }
        public Chicken(int level)
        {  
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

        public override void Dead()
        {
            Console.WriteLine("꼬꼬옥!! 꼬꼬..");
            
        }
        public Enemy Clone(int level)
        {
            return new Chicken(level)
            {
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

        public override void Dead()
        {
            Console.WriteLine("뀌익..");

        }
        public Enemy Clone(int level)
        {
            return new Bat(level)
            {
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

        public override void Dead()
        {
            Console.WriteLine("끼우웅..");

        }
    }

    public class Wolf : Enemy
    {
        string _name = "늑대";
        int _level = 3;
        int _atk = 30;
        int _def = 3;
        int _hp = 600;
        int _dropCredit = 20;
        int _dropExp = 40;
        Player _player;

        public Action LevelChange;
        public int Level
        {
            get { return _level; }
            set { _level += value; }
        }

        public void LVChangeAtk()
        {
            _atk += 25;
        }
        public void LVChangeDef()
        {

            _def += 2;
        }
        public void LVChangeHp()
        {

            _hp += 150;
        }
        public void LVChangeCredit()
        {
            _dropCredit += 3;
        }

        public Wolf()
        {
            LevelChange += LVChangeAtk;
            LevelChange += LVChangeDef;
            LevelChange += LVChangeHp;
            LevelChange += LVChangeCredit;
            for (int i = 0; i < _level; i++)
            {
                LevelChange.Invoke();
            }

        }


        public override int Attack()
        {
            Console.WriteLine("크르르르");
            return _atk;
        }

        public override void Dead()
        {
            Console.WriteLine("크허엉..");

        }
    }

    public class Bear : Enemy
    {
        string _name = "곰";
        int _level = 6;
        int _atk = 50;
        int _def = 12;
        int _hp = 1000;
        int _dropCredit = 40;
        int _dropExp = 50;
        Player _player;

        public Action LevelChange;
        public int Level
        {
            get { return _level; }
            set { _level += value; }
        }

        public void LVChangeAtk()
        {
            _atk += 30;
        }
        public void LVChangeDef()
        {

            _def += 5;
        }
        public void LVChangeHp()
        {

            _hp += 300;
        }
        public void LVChangeCredit()
        {
            _dropCredit += 5;
        }

        public Bear()
        {
            LevelChange += LVChangeAtk;
            LevelChange += LVChangeDef;
            LevelChange += LVChangeHp;
            LevelChange += LVChangeCredit;
            for (int i = 0; i < _level; i++)
            {
                LevelChange.Invoke();
            }

        }


        public override int Attack()
        {
            Console.WriteLine("크어엉");
            return _atk;
        }

        public override void Dead()
        {
            Console.WriteLine("꾸어엉..");

        }
    }

    public class Alpha : Enemy
    {
        string _name = "알파";
        int _level = 12;
        int _atk = 300;
        int _def = 4;
        int _hp = 5250;
        int _dropCredit = 100;
        int _dropExp = 500;

       


        public override int Attack()
        {
            Console.WriteLine("위이이잉");
            return _atk;
        }

        public override void Dead()
        {
            Console.WriteLine("삐유웅..");

        }
    }

    public class Omega : Enemy
    {
        string _name = "오메가";
        int _level = 16;
        int _atk = 400;
        int _def = 20;
        int _hp = 8600;
        int _dropCredit = 200;
        int _dropExp = 1000;

        public override int Attack()
        {
            Console.WriteLine("위이이잉");
            return _atk;
        }

        public override void Dead()
        {
            Console.WriteLine("삐유우우웅..");

        }
    }

    public class DrWickline : Enemy
    {
        string _name = "위클라인 박사";
        int _level = 20;
        int _atk = 800;
        int _def = 100;
        int _hp = 12500;
        int _dropCredit = 150;
        int _dropExp = 2000;
      

        public override int Attack()
        {
            Console.WriteLine("크흐흐흐..");
            return _atk;
        }

        public override void Dead()
        {
            Console.WriteLine("으어얽..");

        }
    }

}

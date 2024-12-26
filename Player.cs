using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search_for_Carry
{
    public enum EquipmentsAbleTo
    {
        무기, 옷, 머리, 팔, 다리
    }
    public enum ItemRank
    {
        영웅, 전설, 초월, 고유
    }

    
    
    //장비 제작 구현 -> 재료 아이템이 있으면 해당 상위 아이템 제작 가능 및 재료 삭제, 아이템 추가

    public class Player 
    {
        static int _atk = 41;
        static int _def = 10;
        static int _critical = 0;
        static int _hp = 890;
        static int _maxHp = 890;
        static int _level = 9;
        static int _exp = 0;
        static int _maxExp = 50;
        static int _credit = 100;
        
        Random chance = new Random();
        //시간 되면 특성도 ㄱㄱ
        string userInput;
        List<Items> items;
        List<Equipment> equipments;
        protected static LinkedList<IInventory> inventory;
        

        //레벨업 할 때 변하는 스탯
        public Action LevelChange;
        //public Player()
        //{
        //    여기에 액션이랑 다 넣어놨는데, 자식 클래스가 생성될 때 부모 생성자도 호출함
        //    즉, 계속해서 인벤토리 생성 + 액션에 중복된 함수를 때려 넣게 됨.
        //}
        public void Activate()
        {
            inventory = new LinkedList<IInventory>();
            LevelChange += LVChangeAtk;
            LevelChange += LVChangeDef;
            LevelChange += LVChangeHp;

            for (int i = 1; i < _level; i++)
            {
                LevelChange.Invoke();
            }
        }
        public void AddItem(Items item)
        {
            inventory.AddFirst(item);
        }
        public void DeleteItem(Items item)
        {
            inventory.Remove(item);
        }
        public void ShowInventory()
        {
            foreach (var item in inventory)
            {
                if(item != null)
                {
                    Console.Write(item.Name + "   ");
                }
                else
                {
                    Console.WriteLine("\t");
                }
                
            } 
        }

        public void MakeItem()
        {
            foreach(var item in inventory)
            {
                if(item.Name == "운석")
                {
                    Console.WriteLine("운석으로 무엇을 만들까요?");
                    Console.WriteLine("무기\t옷\t머리\t다리");
                    userInput = Console.ReadLine();
                    switch(userInput)
                    {
                        case "무기": inventory.AddFirst(Equipment.CopyItem("안드로메다"));
                            inventory.Remove(item);
                            Console.WriteLine("안드로메다를 만들었습니다!");
                            break;
                    }
                    break;
                }
                else if(item.Name == "미스릴")
                {
                    Console.WriteLine("미스릴로 무엇을 만들까요?");
                    Console.WriteLine("무기\t옷\t머리\t다리");
                }
                else
                {
                    Console.WriteLine("해당 아이템은 가지고 있지 않습니다.");
                    break; 
                }
               }
        }

        #region 레벨업과 스탯 변경
        public void LVChangeAtk()
        {
             _atk += 30;
        }
        public void LVChangeDef()
        {
            _def += 6;
        }
        public void LVChangeHp()
        {
            _maxHp += 270;
        }

        public void LVChangeMaxExp()
        {
                _level++;
                LevelChange.Invoke();
                _exp = _maxExp - _exp;
                _maxExp += 200;
                Console.WriteLine($"레벨업! 레벨{_level}이 되셨어요!");
        }
        #endregion
        //돈을 변화시키는 프로퍼티
        public int Credit
        {
            get { return _credit; }
            set { _credit += value; }
        }
        //경험치 변화
        public int Exp
        {
            get { return _exp; }
            set { _exp += value; }
        }
        //공격 당할 때 가져올 값
        public int Hp
        {
            get { return _hp; }
            set { _hp -= value; }
        }
        
        #region 장비로 스탯 더하는 프로퍼티
        public int MaxHp
        {
            get { return _maxHp; } protected set { _maxHp += value; }
        }
        public int Atk
        {
            get { return _atk; } protected set { _atk += value; }
        }
        public int Def
        {
            get { return _def; } protected set { _def += value; }
        }
        public int Critical
        {
            get { return _critical; } protected set { _critical += value; }
        }
        #endregion
        #region 장비 교체할 때 기존 장비 스탯 제거할 때 쓰는 프로퍼티
        public int MinusMaxHp
        {
            get { return _maxHp; }
            protected set { _maxHp -= value; }
        }
        public int MinusAtk
        {
            get { return _atk; }
            protected set { _atk -= value; }
        }
        public int MinusDef
        {
            get { return _def; }
            protected set { _def -= value; }
        }
        public int MinusCritical
        {
            get { return _critical; }
            protected set { _critical -= value; }
        }
        #endregion

        //공격 함수
        public int Attack()
        {
            //치명타 구현
            if(_critical != 0 && chance.Next(1, 101) <= _critical)
            {
                Console.WriteLine($"치명타! {_atk * 2} 피해!");
                return _atk * 2;
            }
            Console.WriteLine($"공격! {_atk}피해!");
            return _atk;
        }


        //현재 플레이어 스탯
        public void ShowPlayerInfo()
        {
            Console.WriteLine($"공격력: {_atk}");
            Console.WriteLine($"방어력: {_def}");
            Console.WriteLine($"치명타 확률: {_critical}");
            Console.WriteLine($"체력: {_maxHp} / {_hp}");
            //Console.WriteLine($"보유 크레딧: {_}"); 이건 선택지에서 표기하는 게 좋아보임
            Console.WriteLine($"");
            Console.WriteLine($"경험치: {_maxExp} / {Exp}");
         }
    }

   
   
   
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
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
        static int _atk = 4111;
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
        LinkedList<IInventory> willBeDeleteditems = new LinkedList<IInventory>();
        LinkedList<Equipment> madeByCraft = new LinkedList<Equipment>();
        
        protected static LinkedList<IInventory> inventory;
        //bool makeItem;

        static int qSkill = 0;
        static int wSkill = 0;
        static int eSkill = 0;
        static int rSkill = 0;
        bool ableToUse = true;
        int skillDamage;
        

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
        public void DeleteItemByCraft()
        {
            foreach(var item in willBeDeleteditems)
            {
                inventory.Remove(item);
            }
        }
        public void AddEquipmentMadeByCraft()
        {
            foreach (var item in madeByCraft)
            {
                inventory.AddFirst(item);
            }
        }
        public void MakeItem(string name)
        {
            willBeDeleteditems.Clear();
            
            madeByCraft .Clear();

            foreach (var item in inventory)
                {
                    if (item.Name == "운석" && name == "운석")
                    {
                        Console.WriteLine("운석으로 무엇을 만들까요?");
                        Console.WriteLine($"무기\t옷\t머리\t다리\t1. 취소");
                        userInput = Console.ReadLine();
                        if (userInput != "무기" || userInput != "옷" || userInput != "머리" || userInput != "다리" || userInput != "1")
                        {
                            while (userInput != "무기" && userInput != "옷" && userInput != "머리" && userInput != "다리" && userInput != "1")
                            {
                                Console.WriteLine("다시 입력해주세요");
                                userInput = Console.ReadLine();
                            }
                        }
                        switch (userInput)
                        {
                            case "무기":
                                madeByCraft.AddFirst(Equipment.CopyItem("안드로메다"));
                                willBeDeleteditems.AddFirst(item);
                                Console.WriteLine("안드로메다를 만들었습니다!");
                                Equipment.ShowEquipInfo("안드로메다");
                                Console.WriteLine("진행하시려면 엔터를 입력해주세요");
                                Console.ReadLine();
                                
                                break;
                            case "옷":
                                madeByCraft.AddFirst(Equipment.CopyItem("고스트"));
                                willBeDeleteditems.AddFirst(item);
                                Console.WriteLine("고스트를 만들었습니다!");
                                Equipment.ShowEquipInfo("고스트");
                                Console.WriteLine("진행하시려면 엔터를 입력해주세요");
                                Console.ReadLine();
                                
                                break;
                            case "머리":
                                madeByCraft.AddFirst(Equipment.CopyItem("빛의 증표"));
                                willBeDeleteditems.AddFirst(item);
                                Console.WriteLine("빛의 증표를 만들었습니다!");
                                Equipment.ShowEquipInfo("빛의 증표");
                                Console.WriteLine("진행하시려면 엔터를 입력해주세요");
                                Console.ReadLine();
                                
                                break;
                            case "다리":
                                madeByCraft.AddFirst(Equipment.CopyItem("레이싱 부츠"));
                                willBeDeleteditems.AddFirst(item);
                                Console.WriteLine("레이싱 부츠를 만들었습니다!");
                                Equipment.ShowEquipInfo("레이싱 부츠");
                                Console.WriteLine("진행하시려면 엔터를 입력해주세요");
                                Console.ReadLine();
                                
                                break;
                            case "1":  break;


                        }
                        break;
                    }
                    else if (item.Name == "생명의 나무" && name == "생명의 나무")
                    {
                        Console.WriteLine("생명의 나무로 무엇을 만들까요?");
                        Console.WriteLine("옷\t머리\t다리\t1. 취소");
                        userInput = Console.ReadLine();
                        if (userInput != "옷" || userInput != "머리" || userInput != "다리" || userInput != "1")
                        {
                            while (userInput != "옷" && userInput != "머리" && userInput != "다리" && userInput != "1")
                            {
                                Console.WriteLine("다시 입력해주세요");
                                userInput = Console.ReadLine();
                            }
                        }

                        switch (userInput)
                        {
                            case "1": break;
                            case "옷":
                                madeByCraft.AddFirst(Equipment.CopyItem("길리슈트"));
                                willBeDeleteditems.AddFirst(item);
                                Console.WriteLine("길리슈트를 만들었습니다!");
                                Equipment.ShowEquipInfo("길리슈트");
                                Console.WriteLine("진행하시려면 엔터를 입력해주세요");
                                Console.ReadLine();
                                
                                break;
                            case "머리":
                                madeByCraft.AddFirst(Equipment.CopyItem("월계관"));
                                willBeDeleteditems.AddFirst(item);
                                Console.WriteLine("월계관을 만들었습니다!");
                                Equipment.ShowEquipInfo("월계관");
                                Console.WriteLine("진행하시려면 엔터를 입력해주세요");
                                Console.ReadLine();
                                
                                break;
                            case "다리":
                                madeByCraft.AddFirst(Equipment.CopyItem("알렉산드로"));
                                willBeDeleteditems.AddFirst(item);
                                Console.WriteLine("알렉산드로를 만들었습니다!");
                                Equipment.ShowEquipInfo("알렉산드로");
                                Console.WriteLine("진행하시려면 엔터를 입력해주세요");
                                Console.ReadLine();
                                
                                break;
                        }
                    }
                    else if (item.Name == "미스릴" && name == "미스릴")
                    {
                        Console.WriteLine("미스릴로 무엇을 만들까요?");
                        Console.WriteLine("무기\t옷\t머리\t팔\t1. 취소");
                        userInput = Console.ReadLine();
                        if (userInput != "무기" || userInput != "옷" || userInput != "머리" || userInput != "팔" || userInput != "1")
                        {
                            while (userInput != "무기" && userInput != "옷" && userInput != "머리" && userInput != "팔" && userInput != "1")
                            {
                                Console.WriteLine("다시 입력해주세요");
                                userInput = Console.ReadLine();
                            }
                        }

                        switch (userInput)
                        {
                            case "1":  break;
                            case "무기":
                                madeByCraft.AddFirst(Equipment.CopyItem("인터벤션"));
                                willBeDeleteditems.AddFirst(item);
                                Console.WriteLine("인터벤션을 만들었습니다!");
                                Equipment.ShowEquipInfo("인터벤션");
                                Console.WriteLine("진행하시려면 엔터를 입력해주세요");
                                Console.ReadLine();
                                
                                break;
                            case "옷":
                                madeByCraft.AddFirst(Equipment.CopyItem("미스릴 갑옷"));
                                willBeDeleteditems.AddFirst(item);
                                Console.WriteLine("미스릴 갑옷을 만들었습니다!");
                                Equipment.ShowEquipInfo("미스릴 갑옷");
                                Console.WriteLine("진행하시려면 엔터를 입력해주세요");
                                Console.ReadLine();
                                
                                break;
                            case "머리":
                                madeByCraft.AddFirst(Equipment.CopyItem("쿼드아이"));
                                willBeDeleteditems.AddFirst(item);
                                Console.WriteLine("쿼드아이를 만들었습니다!");
                                Equipment.ShowEquipInfo("쿼드아이");
                                Console.WriteLine("진행하시려면 엔터를 입력해주세요");
                                Console.ReadLine();
                                
                                break;
                            case "팔":
                                madeByCraft.AddFirst(Equipment.CopyItem("미스릴 방패"));
                                willBeDeleteditems.AddFirst(item);
                                Console.WriteLine("미스릴 방패를 만들었습니다!");
                                Equipment.ShowEquipInfo("미스릴 방패");
                                Console.WriteLine("진행하시려면 엔터를 입력해주세요");
                                Console.ReadLine();
                                
                                break;
                        }
                    }
                    else if (item.Name == "포스 코어" && name == "포스 코어")
                    {
                        Console.WriteLine("포스 코어로 무엇을 만들까요?");
                        Console.WriteLine("머리\t팔\t1. 취소");
                        userInput = Console.ReadLine();
                        if (userInput != "머리" || userInput != "팔" || userInput != "1")
                        {
                            while (userInput != "머리" && userInput != "팔" && userInput != "1")
                            {
                                Console.WriteLine("다시 입력해주세요");
                                userInput = Console.ReadLine();
                            }
                        }

                        switch (userInput)
                        {
                            case "1":  break;

                            case "머리":
                                madeByCraft.AddFirst(Equipment.CopyItem("레가투스"));
                                willBeDeleteditems.AddFirst(item);
                                Console.WriteLine("레가투스를 만들었습니다!");
                                Equipment.ShowEquipInfo("레가투스");
                                Console.WriteLine("진행하시려면 엔터를 입력해주세요");
                                Console.ReadLine();
                                
                                break;
                            case "팔":
                                madeByCraft.AddFirst(Equipment.CopyItem("행운의 주사위"));
                                willBeDeleteditems.AddFirst(item);
                                Console.WriteLine("행운의 주사위를 만들었습니다!");
                                Equipment.ShowEquipInfo("행운의 주사위");
                                Console.WriteLine("진행하시려면 엔터를 입력해주세요");
                                Console.ReadLine();
                                
                                break;
                        }
                    }
                    else if (item.Name == "혈액팩" && name == "혈액팩")
                    {
                        Console.WriteLine("혈액팩으로 무엇을 만들까요?");
                        Console.WriteLine("무기\t옷\t머리\t팔\t다리\t1. 취소");
                        userInput = Console.ReadLine();
                        if (userInput != "팔" || userInput != "무기" || userInput != "옷" || userInput != "머리" || userInput != "다리" || userInput != "1")
                        {
                            while (userInput != "옷" && userInput != "무기" && userInput != "머리" && userInput != "옷" && userInput != "1")
                            {
                                Console.WriteLine("다시 입력해주세요");
                                userInput = Console.ReadLine();
                            }
                        }
                        switch (userInput)
                        {
                            case "무기":
                                madeByCraft.AddFirst(Equipment.CopyItem("위도우메이커"));
                                willBeDeleteditems.AddFirst(item);
                                Console.WriteLine("위도우메이커를 만들었습니다!");
                                Equipment.ShowEquipInfo("위도우메이커");
                                Console.WriteLine("진행하시려면 엔터를 입력해주세요");
                                Console.ReadLine();
                                
                                break;
                            case "옷":
                                madeByCraft.AddFirst(Equipment.CopyItem("버건디 47"));
                                willBeDeleteditems.AddFirst(item);
                                Console.WriteLine("버건디 47을 만들었습니다!");
                                Equipment.ShowEquipInfo("버건디 47");
                                Console.WriteLine("진행하시려면 엔터를 입력해주세요");
                                Console.ReadLine();
                                
                                break;
                            case "머리":
                                madeByCraft.AddFirst(Equipment.CopyItem("핏빛 왕관"));
                                willBeDeleteditems.AddFirst(item);
                                Console.WriteLine("핏빛 왕관을 만들었습니다!");
                                Equipment.ShowEquipInfo("핏빛 왕관");
                                Console.WriteLine("진행하시려면 엔터를 입력해주세요");
                                Console.ReadLine();
                                
                                break;
                            case "다리":
                                madeByCraft.AddFirst(Equipment.CopyItem("분홍신"));
                                willBeDeleteditems.AddFirst(item);
                                Console.WriteLine("분홍신을 만들었습니다!");
                                Equipment.ShowEquipInfo("분홍신");
                                Console.WriteLine("진행하시려면 엔터를 입력해주세요");
                                Console.ReadLine();
                                
                                break;
                            case "팔":
                                madeByCraft.AddFirst(Equipment.CopyItem("혈사조"));
                                willBeDeleteditems.AddFirst(item);
                                Console.WriteLine("혈사조를 만들었습니다!");
                                Equipment.ShowEquipInfo("혈사조");
                                Console.WriteLine("진행하시려면 엔터를 입력해주세요");
                                Console.ReadLine();
                                
                                break;
                            case "1":  break;

                        }
                    }


                
                }
            AddEquipmentMadeByCraft();
            DeleteItemByCraft();
             
            
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
           
            while(_exp >= _maxExp && _level <= 20)
            {
                _level++;
                LevelChange.Invoke();
                _exp = _exp - _maxExp;
                _maxExp += 100;
                Console.WriteLine($"레벨업! 레벨{_level}이 되셨어요!");
            }
                
        }
        #endregion
        //돈을 변화시키는 프로퍼티
        public int Credit
        {
            get { return _credit; }
            set { _credit += value; }
        }
        public int MinusCredit
        {
            get { return _credit; }
            set { _credit -= value; }
        }
        //경험치 변화
        public int Exp
        {
            get { return _exp; }
            set { _exp += value; }
        }
        
        public int Hp
        {
            get { return _hp; }
            set { _hp = value; }
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
        //공격 당할 때 가져올 값
        public int MinusHp
        {
            get { return _hp; }
            set { _hp -= value; }
        }
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
        public int Skill()
        {
            ableToUse = true;
            while (ableToUse == true)
            {
                if(qSkill <= 0)
                {
                    qSkill = 0;
                }
                if(wSkill <= 0)
                {
                    wSkill = 0;
                }
                if(eSkill <= 0)
                {
                    eSkill = 0;
                }
                if(rSkill <= 0)
                {
                    rSkill = 0;
                }
                Console.WriteLine("어떤 스킬을 사용하시겠습니까?");
                Console.WriteLine($"Q 쿨타임: {qSkill}\nW 쿨타임: {wSkill}\nE 쿨타임: {eSkill}\nR 쿨타임: {rSkill}\n1. 돌아가기");
                userInput = Console.ReadLine();
                //입력 검사
                if (userInput != "Q" || userInput != "W" || userInput != "E" || userInput != "R" || userInput != "1")
                {
                    while (userInput != "Q" && userInput != "W" && userInput != "E" && userInput != "R" && userInput != "1")
                    {
                        Console.WriteLine("다시 입력해주세요.");
                        userInput = Console.ReadLine();
                    }
                    
                }
                //검사 후 입력에 따른 출력
                switch (userInput)
                {
                    case "Q":
                        if (qSkill <= 0)
                        {
                            Console.WriteLine($"Q스킬 사용! {_atk + 300} 피해를 입혔습니다.");
                            qSkill = 2;
                            ableToUse = false;
                            skillDamage = _atk + 300;
                            break;
                        }
                        //잘못된 입력시 재입력 받도록 함. 입력 초기화
                        else
                        {
                            Console.WriteLine("쿨타임입니다.");
                            userInput = " ";
                            break;
                        }

                    case "W":
                        if (wSkill <= 0)
                        {
                            Console.WriteLine($"W스킬 사용! {_atk * 2} 피해를 입혔습니다.");
                            wSkill = 3;
                            ableToUse = false;
                            skillDamage = _atk * 2;
                            break;
                        }
                        else
                        {

                            Console.WriteLine("쿨타임입니다.");
                            userInput = " ";
                            break;
                        }
                    case "E":
                        if (eSkill <= 0)
                        {
                            Console.WriteLine($"E스킬 사용! {(_atk + 200) * 2} 피해를 입혔습니다.");
                            eSkill = 4;
                            ableToUse = false;
                            skillDamage = (_atk + 200) * 2;
                            break;
                        }

                        else
                        {

                            Console.WriteLine("쿨타임입니다.");
                            userInput = " ";
                            break;
                        }
                    case "R":
                        if (rSkill <= 0)
                        {
                            Console.WriteLine($"궁극기! {_atk * 5}의 피해를 입혔습니다.");
                            rSkill = 8;
                            ableToUse = false;
                            skillDamage = _atk * 5;
                            break;
                        }

                        else
                        {

                            Console.WriteLine("쿨타임입니다.");
                            userInput = " ";
                            break;
                        }
                    case "1":
                        ableToUse = false;
                        return 0;
                   
                }
            }
            return skillDamage;          
        }

        public void DecreaseCooltime()
        {
            qSkill--;
            wSkill--;
            eSkill--;
            rSkill--;
        }

        public void ResetCooltime()
        {
            qSkill = 0;
            wSkill = 0;
            eSkill = 0;
            rSkill = 0;
        }


        //현재 플레이어 스탯
        public void ShowPlayerInfo()
        {
            Console.WriteLine($"레벨: {_level}");
            Console.WriteLine($"공격력: {_atk}");
            Console.WriteLine($"방어력: {_def}");
            Console.WriteLine($"치명타 확률: {_critical}");
            Console.WriteLine($"체력: {_maxHp}");
            //Console.WriteLine($"보유 크레딧: {_}"); 이건 선택지에서 표기하는 게 좋아보임
            Console.WriteLine($"");
            Console.WriteLine($"경험치: {_maxExp} / {Exp}");
         }
    }

   
   
   
}

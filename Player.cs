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
        영웅, 전설, 초월
    }


    public class Player 
    {
        int _atk = 41;
        int _def = 10;
        int _critical = 0;
        int _hp = 890;
        int _maxHP = 890;
        int _level = 9;
        int _exp = 0;
        int _maxExp = 50;
        int _credit = 100;
        Random chance;
        //시간 되면 특성도 ㄱㄱ

        List<Items> items;
        List<Equipment> equipments;



        //레벨업 할 때 변하는 스탯
        public Action LevelChange;
        public Player()
        {
            //액션에 다 때려박기
            //LevelChange += LVChangeMaxExp;
            LevelChange += LVChangeAtk;
            LevelChange += LVChangeDef;
            LevelChange += LVChangeHp;
            //LevelChange.Invoke();
            //랜덤도 뉴 할당
            chance = new Random();
            for(int i = 1; i < _level; i++)
            {
                LevelChange.Invoke();
            }
        }

        #region 레벨업과 스탯 변경
        public void LVChangeAtk()
        {
            
            _atk += 15;
        }
        public void LVChangeDef()
        {
           
            _def += 3;
        }
        public void LVChangeHp()
        {
            
            _maxHP += 90;
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
            Console.WriteLine($"체력: {_maxHP}");
            //Console.WriteLine($"보유 크레딧: {_}"); 이건 선택지에서 표기하는 게 좋아보임
            Console.WriteLine($"");
            Console.WriteLine($"경험치: {_maxExp} / {_exp}");
        }


    }


   
    public class Equipment 
    {
        string _name;
        int _atk;
        int _def;
        int _hp;
        int _critical;
        static List<Equipment> _equipments;// = new List<Equipment>();
        ItemRank itemRank;
        EquipmentsAbleTo equipmentsAbleTo;

       

        #region 무기
        //장비 생성기
        public Equipment(string name, int atk, int def, int hp, int critical, ItemRank rank, EquipmentsAbleTo part)
        {
            if(_equipments == null)
            {
                _equipments = new List<Equipment>();
            }
            _name = name;
            atk = _atk;
            _def = def;
            _hp = hp;
            _critical = critical;
            itemRank = rank;
            equipmentsAbleTo = part;
            _equipments.Add(this);
        }

        public Equipment()
        {
           
            //모든 장비 추가
            //무기
           new Equipment("폴라리스", 210, 0, 100, 0, ItemRank.영웅, EquipmentsAbleTo.무기);
           new Equipment("안드로메다", 260, 0, 400, 0, ItemRank.전설, EquipmentsAbleTo.무기);
           new Equipment("인터벤션", 220, 0, 0, 33, ItemRank.전설, EquipmentsAbleTo.무기);
           new Equipment("위도우메이커", 500, 0, 200, 0, ItemRank.초월, EquipmentsAbleTo.무기);
           
           new Equipment("광학미체슈트", 138, 0, 200, 24, ItemRank.영웅, EquipmentsAbleTo.옷);
           new Equipment("고스트", 170, 12, 300, 33, ItemRank.전설, EquipmentsAbleTo.옷);
           new Equipment("길리슈트", 200, 10, 200, 33, ItemRank.전설, EquipmentsAbleTo.옷);
           new Equipment("미스릴갑옷", 100, 20, 400, 0, ItemRank.전설, EquipmentsAbleTo.옷);
           new Equipment("버건디 47", 250, 20, 600, 0, ItemRank.초월, EquipmentsAbleTo.옷);
           
           new Equipment("전술 Ops헬멧", 50, 0, 100, 0, ItemRank.영웅, EquipmentsAbleTo.머리); 
           new Equipment("빛의 증표", 80, 0, 0, 35, ItemRank.전설, EquipmentsAbleTo.머리); 
           new Equipment("월계관", 150, 10, 0, 0, ItemRank.전설, EquipmentsAbleTo.머리); 
           new Equipment("쿼드아이", 130, 0, 0, 35, ItemRank.전설, EquipmentsAbleTo.머리); 
           new Equipment("레가투스", 250, 0, 0, 35, ItemRank.전설, EquipmentsAbleTo.머리); 
           new Equipment("핏빛 왕관", 350, 50, 0, 0, ItemRank.초월, EquipmentsAbleTo.머리);
           
           new Equipment("샤자한의 검집", 70, 5, 0, 0, ItemRank.영웅, EquipmentsAbleTo.팔);
           new Equipment("미스릴 방패", 100, 30, 200, 0, ItemRank.전설, EquipmentsAbleTo.팔);
           new Equipment("행운의 주사위", 240, 0, 0, 35, ItemRank.전설, EquipmentsAbleTo.팔);
           new Equipment("혈사조", 350, 50, 0, 0, ItemRank.초월, EquipmentsAbleTo.팔);

           
            new Equipment("부케팔로스", 50, 0, 100, 25, ItemRank.영웅, EquipmentsAbleTo.다리);
            new Equipment("알렉산드로", 80, 0, 100, 33, ItemRank.전설, EquipmentsAbleTo.다리);
            new Equipment("레이싱 부츠", 100, 15, 0, 33, ItemRank.전설, EquipmentsAbleTo.다리);
            new Equipment("분홍신", 200, 25, 300, 0, ItemRank.전설, EquipmentsAbleTo.다리);
        }

        public void ShowEquip()
        {
            Console.WriteLine(_equipments.Count);
            foreach(var equip in _equipments)
            {
                Console.WriteLine(equip._name);
            }
        }


        #endregion

    }
}

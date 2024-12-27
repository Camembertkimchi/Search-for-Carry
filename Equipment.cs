using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search_for_Carry
{
    public class Equipment : IInventory
    {
        public string Name { get; private set; }
        public int Atk { get; private set; }
        public int Def { get; private set; }
        public int Hp { get; private set; }
        public int Critical { get; private set; }
        static List<Equipment> _equipments;// = new List<Equipment>();
        public ItemRank ItemRank { get; private set; }
        public EquipmentsAbleTo EquipmentsAbleTo { get; private set; }

        #region 장비 생성
        //장비 생성기
        private Equipment(string name, int atk, int def, int hp, int critical, ItemRank rank, EquipmentsAbleTo part)
        {
            if (_equipments == null)
            {
                _equipments = new List<Equipment>();
            }
            Name = name;
            Atk = atk;
            Def = def;
            Hp = hp;
            Critical = critical;
            ItemRank = rank;
            EquipmentsAbleTo = part;
            _equipments.Add(this);
        }

        public Equipment()
        {

            //모든 장비 추가
            //무기
            new Equipment("폴라리스", 210, 0, 100, 0, ItemRank.영웅, EquipmentsAbleTo.무기);
            new Equipment("안드로메다", 260, 0, 400, 0, ItemRank.전설, EquipmentsAbleTo.무기);
            new Equipment("인터벤션", 220, 0, 0, 33, ItemRank.전설, EquipmentsAbleTo.무기);
            new Equipment("위도우메이커", 800, 0, 400, 0, ItemRank.초월, EquipmentsAbleTo.무기);
            //옷
            new Equipment("광학미체슈트", 138, 0, 200, 24, ItemRank.영웅, EquipmentsAbleTo.옷);
            new Equipment("고스트", 170, 12, 300, 33, ItemRank.전설, EquipmentsAbleTo.옷);
            new Equipment("길리슈트", 200, 10, 200, 33, ItemRank.전설, EquipmentsAbleTo.옷);
            new Equipment("미스릴 갑옷", 100, 20, 400, 0, ItemRank.전설, EquipmentsAbleTo.옷);
            new Equipment("버건디 47", 400, 80, 600, 0, ItemRank.초월, EquipmentsAbleTo.옷);
            //머리
            new Equipment("전술 Ops헬멧", 50, 0, 100, 0, ItemRank.영웅, EquipmentsAbleTo.머리);
            new Equipment("빛의 증표", 80, 0, 0, 35, ItemRank.전설, EquipmentsAbleTo.머리);
            new Equipment("월계관", 150, 10, 0, 0, ItemRank.전설, EquipmentsAbleTo.머리);
            new Equipment("쿼드아이", 130, 0, 0, 35, ItemRank.전설, EquipmentsAbleTo.머리);
            new Equipment("레가투스", 250, 0, 0, 35, ItemRank.전설, EquipmentsAbleTo.머리);
            new Equipment("핏빛 왕관", 700, 100, 0, 0, ItemRank.초월, EquipmentsAbleTo.머리);
            //팔
            new Equipment("샤자한의 검집", 70, 5, 0, 0, ItemRank.영웅, EquipmentsAbleTo.팔);
            new Equipment("미스릴 방패", 100, 30, 200, 0, ItemRank.전설, EquipmentsAbleTo.팔);
            new Equipment("행운의 주사위", 240, 0, 0, 35, ItemRank.전설, EquipmentsAbleTo.팔);
            new Equipment("혈사조", 550, 100, 0, 0, ItemRank.초월, EquipmentsAbleTo.팔);
            //다리
            new Equipment("부케팔로스", 50, 0, 100, 25, ItemRank.영웅, EquipmentsAbleTo.다리);
            new Equipment("알렉산드로", 80, 0, 100, 33, ItemRank.전설, EquipmentsAbleTo.다리);
            new Equipment("레이싱 부츠", 100, 15, 0, 33, ItemRank.전설, EquipmentsAbleTo.다리);
            new Equipment("분홍신", 400, 50, 500, 0, ItemRank.전설, EquipmentsAbleTo.다리);
        }
        #endregion
        //장비 스탯을 보여주는 함수
        public static void ShowEquipInfo(string name)
        {
            foreach (var equip in _equipments)
            {
                if(equip.Name == name)
                {
                    Console.WriteLine(equip.Name);
                    Console.Write($"부위: {equip.EquipmentsAbleTo}/등급: {equip.ItemRank}/공격력: {equip.Atk}, 방어력: {equip.Def}, 체력: {equip.Hp}, 치명타 확률: {equip.Critical}");
                    Console.WriteLine();
                }
            }
        }

        public static Equipment CopyItem(string name)
        {
            foreach (Equipment item in _equipments)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            
            return null;
        }


    }
}

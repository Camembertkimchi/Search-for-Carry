using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search_for_Carry
{
    public interface IInventory
    {
        string Name { get; }
    }
    public class Items : IInventory
    {
        protected static List<Items> _items;
        ItemRank _rank;
        static string _name;

        public string Name
        {
            get;
            private set;
        }
        public ItemRank Rank
        {
            get;
            private set;
        }
        
        private Items(string name, ItemRank rank)
        {
            if(_items == null)
            {
                _items = new List<Items>();
            }
            Name = name;
            _rank = rank;
            _items.Add(this);
        }

        public Items()
        {
            new Items("운석", ItemRank.Hero);
            new Items("생명의 나무", ItemRank.Hero);
            new Items("미스릴", ItemRank.Hero);
            new Items("포스 코어", ItemRank.Hero);
            new Items("혈액 샘플", ItemRank.Overwhelming);
            new Items("뽀쮸코어", ItemRank.Unique);
            new Items("혀랙팩", ItemRank.Unique);

        }

        public static Items CopyItem(string name)
        {
            foreach(Items item in _items)
            {
                if(item.Name == name)
                {
                    return item;
                }
                else if(item.Name == " ")
                {
                    break;
                }
            }
            return null;
        }

        

    }
}

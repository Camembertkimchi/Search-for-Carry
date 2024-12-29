using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Search_for_Carry
{
    public class Loadout : Player
    {
        //EquipmentsAbleTo _enablePart;
        
        Dictionary<EquipmentsAbleTo, Equipment> _equippeditems;
        LinkedList<Equipment> _hasBeenEquipped;
        public Loadout()
        {
            if (_equippeditems == null)
            {
                _equippeditems = new Dictionary<EquipmentsAbleTo, Equipment>();
                _hasBeenEquipped = new LinkedList<Equipment>(); 
            }

        }
        public void ShowEquipment()
        {
           
            foreach(var item in _hasBeenEquipped)
            {
                if(item == null) continue;
                switch (item.EquipmentsAbleTo)
                {
                    
                    case EquipmentsAbleTo.Weapon : Console.WriteLine($"무기: {item.Name}");
                        break;
                    case EquipmentsAbleTo.Cloth : Console.WriteLine($"옷: {item.Name}"); break;
                    case EquipmentsAbleTo.Helmet: Console.WriteLine($"머리: {item.Name}"); break;
                    case EquipmentsAbleTo.Arm: Console.WriteLine($"팔: {item.Name}"); break;
                    case EquipmentsAbleTo.Shoes: Console.WriteLine($"다리: {item.Name}"); break;
                    
                }
            }
        }
        public void UseEquipment(string name)
        {
            foreach (var item in inventory)
            {
                if (item.Name == name)
                {
                    var equipment = item as Equipment;
                    _hasBeenEquipped.AddFirst(equipment);
                    Console.WriteLine($"{item.Name} 장비!");
                    if (_equippeditems.ContainsKey(equipment.EquipmentsAbleTo))
                    {
                        var oldEquipment = _equippeditems[equipment.EquipmentsAbleTo];
                        inventory.AddFirst(oldEquipment);
                        _hasBeenEquipped.Remove(oldEquipment);
                        MinusMaxHp = oldEquipment.Hp;
                        MinusAtk = oldEquipment.Atk;
                        MinusDef = oldEquipment.Def;
                        MinusCritical = oldEquipment.Critical;

                        _equippeditems[equipment.EquipmentsAbleTo] = equipment;
                        MaxHp = equipment.Hp;
                        Atk = equipment.Atk;
                        Def = equipment.Def;
                        Critical = equipment.Critical;
                        inventory.Remove(item);
                    }
                    else
                    {
                        _equippeditems[equipment.EquipmentsAbleTo] = equipment;
                        MaxHp = equipment.Hp;
                        Atk = equipment.Atk;
                        Def = equipment.Def;
                        Critical = equipment.Critical;
                        inventory.Remove(item);
                    }
                    break;
                    
                }
                else
                {
                    Console.WriteLine("그런 장비는 없습니다...");
                    break;
                }
            }


        }
    }
}

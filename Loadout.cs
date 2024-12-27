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
        public Loadout()
        {
            if (_equippeditems == null)
            {
                _equippeditems = new Dictionary<EquipmentsAbleTo, Equipment>();
            }

        }

        public void UseEquipment(string name)
        {
            foreach (var item in inventory)
            {
                if (item.Name == name)
                {
                    var equipment = item as Equipment;
                    Console.WriteLine($"{item.Name} 장비!");
                    if (_equippeditems.ContainsKey(equipment.EquipmentsAbleTo))
                    {
                        var oldEquipment = _equippeditems[equipment.EquipmentsAbleTo];
                        inventory.AddFirst(oldEquipment);
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

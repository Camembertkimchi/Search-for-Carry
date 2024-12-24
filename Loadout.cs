using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void WearEquipment(Equipment equipment)
        {
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
            }
            else
            {
                _equippeditems[equipment.EquipmentsAbleTo] = equipment;
                MaxHp = equipment.Hp;
                Atk = equipment.Atk;
                Def = equipment.Def;
                Critical = equipment.Critical;
            }



        }
    }
}

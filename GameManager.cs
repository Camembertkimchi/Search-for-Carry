using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search_for_Carry
{
    internal class GameManager
    {
        
        public GameManager()
        {
            Player player = new Player();
            player.Activate();
            EnemyManager enemyManager = new EnemyManager();
            Items items = new Items();
            Equipment equipment = new Equipment();
            equipment.ShowEquip();
            Loadout loadout = new Loadout();
            //player.ShowPlayerInfo();
            //
            //loadout.WearEquipment(Equipment.CopyItem("폴라리스"));
            //player.ShowPlayerInfo();
            //
            //loadout.WearEquipment(Equipment.CopyItem("위도우메이커"));
            //player.ShowPlayerInfo();
            var enemy = enemyManager.GetEnemy("닭", 3);
            if(enemy != null)
            {
                var a1 = enemy.Dead();
                player.AddItem(a1);
                player.ShowInventory();
                
            }
            enemy = enemyManager.GetEnemy("늑대", 6);
            {
                var a1 = enemy.Dead();
                player.AddItem(a1);
                player.ShowInventory();
            }
            player.MakeItem();
            player.ShowInventory();
            
            
        }
    }
}

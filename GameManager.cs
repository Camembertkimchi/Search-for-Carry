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
            Enemy enemy = new Enemy();
            
            Equipment equipment = new Equipment();
            equipment.ShowEquip();
            enemy.ShowInfo();

            
            
            
            
        }
    }
}

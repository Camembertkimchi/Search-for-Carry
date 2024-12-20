using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search_for_Carry
{
    internal class Program
    {
        static void Main(string[] args)
        {
             Player player = new Player();
            player.ShowPlayerInfo();
            Equipment equipment = new Equipment();
            equipment.ShowEquip();
        }
    }
}

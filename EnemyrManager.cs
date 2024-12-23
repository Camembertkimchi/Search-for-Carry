using Search_for_Carry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search_for_Carry
{
    internal class EnemyManager
    {
        public static Dictionary<string, Enemy> _enemyDictionary;

        public EnemyManager()
        {
            if (_enemyDictionary == null)
            {
                _enemyDictionary = new Dictionary<string, Enemy>
                {
                    { "닭", new Chicken() },
                    { "박쥐", new Bat() },
                    { "들개", new Dog() },
                    { "늑대", new Wolf() },
                    { "곰", new Bear() },
                    { "알파", new Alpha() },
                    { "오메가", new Omega() },
                    { "위클라인 박사", new DrWickline() }
                };
            }
        }
          
            
    }
}

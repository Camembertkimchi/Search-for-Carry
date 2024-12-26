using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;
using System.Threading;


namespace Search_for_Carry
{
    
    internal class GameManager
    {
        string userInput;
        int userNum;
        bool endGame = false;
        bool enterBattle = false;
        bool correct;

        int turn;
        int day;
        bool night = false;
        string dayorNight = "낮";
        int rndNum;

        Random rnd;
        EnemyManager enemyManager;
        Player player;
        Items items;
        Equipment equipment;
        Loadout loadout;
        public GameManager()
        {
            player = new Player();
            player.Activate();
            enemyManager = new EnemyManager();
            items = new Items();
            equipment = new Equipment();
            loadout = new Loadout();
            rnd = new Random();

        }

        void ClearConsole()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        ");
            Console.SetCursorPosition(0, 0);
        }

        public void StartGame()
        {
           
            Console.WriteLine("&&&&&&&&&+.x&&&&&&&&X:....+&+....:$&&&&&&x......:X&&&&X:+&x.....X$;..................\r\n&$:...... .x&+..... ..  ..+&+.  .:$$:....+&+ ..X$;... ..;&x.  ..X$;  .  .  .  .  .  .\r\n&$: .  .. .x&+  . .. ...+&+.x&+. :$$: . .+&+.x&+.  .. ..;&x.....X$;....;$X.......... \r\n&&&&&&&&&+.x&&&&&&&&X: .+&+.x&+. :$&&&&&&x...x&+... .. .+&&&&&&&&$;. ;$X:.. .. ..X$;.\r\n. .. ..+&+.x&+.. .. .. .+&&&&&;..:$$:..+&x.  x&; .. .. .+&x.. ..X$;:$&&&&X... ...X&&&\r\n.. .. .+&+.x&+ .. .. .+&x.. ..X$;:$$: .+&x.....X$;.. .. ;&x.. ..X$; .;$X:..+&&&+.X$;.\r\n&&&&&&&&&+.x&&&&&&&&X:+&x.. ..X$;:$$:.  .+&+....:X&&&&X:+&x ....X$;. ;$X: .+&&&+.X$; \r\n .. .. .. ... .. .. . ..  ...... .  .......  .. .  .. ... .. ..... .... .............\r\n. .. .. ..  .. .. ... .... . . .....  .. .... ..... ..  .. ..  . .. . .. . .  ..  . .\r\n. .. .. .... .. :$&&&&&&x. ...X&&$;... +&&&&&&&&$;. ;$&&&&&&&&+..:X&&$:. ....+&&&+. .\r\n.. .. ..  .. .:X$;.. ..  .. ..X&&$;. ..;&x. .. .:X$;;$X:... ..x&+:X&&&&X: .+&&&&&+ ..\r\n .. .. ... ..X$;. .. .... ..x&+..:$$: .+&x.. ...:X$;;$X: .. ..x&+ .:$&&&&&&&&&&+.. ..\r\n .. .. ... ..X$;. ...  .. ..x&+ .:$$:. +&x .. . :X$;;$X:. ..  x&+. .. .;$&&x.... .. .\r\n. .. ..  ....X$;..  ... ..  x&&&&&&$:. +&&&&&&&&$;..;$&&&&&&&&+. .. .. ;$&&x.  .. .. \r\n.. .. ... ...X$; ... .. ....x&+. :$$:..;&x.. x&+. ..;$X:.. .+&+.. .. ..;$&&x... .. ..\r\n .. .. .. ...X$;. .. ...  +&+.. .. ;$X:+&x...x&+. . ;$X: ...+&+.. .. ..;$&&x .. .. ..\r\n .. .. ... ...:X$;. .. ...+&+.. .. ;$X:+&x  ...X$;. ;$X:. . ..x&+. ..  ;$&&x. .. .. .\r\n. .. ..  .. .. .:$&&&&&&x.+&+... ..;$X:;&x.. ...:X$;;$X:. .. ...X$;....;$&&x. .. .. .\r\n. .. .... .. .. .. .. .. ....  .. ... ... .. .. .. ... ... .. ... .  .. ... .. .. .. \r\n.. ..  .. .. .. .. .. .. .  ... ..  .. .. ... .. ..  ..  .. .. ...... ..  .. .. .. ..");
            Console.WriteLine("1. 게임 시작\n2.게임 종료");
            userInput = Console.ReadLine();
            correct = int.TryParse(userInput, out userNum);
            if(correct == false || userNum > 2)
            {
                while(correct == false || userNum > 2)
                {
                    Console.WriteLine("다시 입력해주세요");
                    userInput = Console.ReadLine();
                    correct = int.TryParse(userInput, out userNum);
                }
            }
            if(userNum == 1)
            {
                ClearConsole();

                Console.WriteLine("야 김쁠뿡!!!!!!");
                //Thread.Sleep(2000);
                ClearConsole();
                Console.WriteLine("내가 캐리해줋꼐!!!!");
                Console.WriteLine("대신 뽀쮸코어랑 혀랙팩을 가져와!!!! 아랐찌??!!");
                //Thread.Sleep(4000);
                ClearConsole();
                Console.WriteLine("샬럿의 요구에 따라서, 당신은 '뽀쮸코어'와 '혀랙팩'을 가지고 가야합니다.\n만약 가져가지 못한다면 샬럿이 파이프로 당신을 쥐어 팰것입니다...\n살고 싶다면 샬럿의 협박을 들어주세요!");
                //Thread.Sleep(8000);
                ClearConsole();
                day = 1;
                turn = 3;
                while(endGame == false)
                {
                    if (turn == 0)
                    {
                        if (night == false)
                        {
                            dayorNight = "밤";
                            night = true;
                            //break;
                        }
                        else if (night)
                        {
                            dayorNight = "낮";
                            day++;
                            night = false;
                        }
                        turn = 3;
                        
                    }
                    
                    Console.WriteLine($"무엇을 할까?\t{day}일차 {dayorNight}\t남은 턴: {turn}");
                    Console.WriteLine("1.동물 잡기\n2.보스 사냥\n3.인벤토리\n4.상태창\n5.아이템 제작\n6.포기하기");


                    userInput = Console.ReadLine();
                    correct = int.TryParse (userInput, out userNum);
                    if(correct == false || userNum > 6)
                    {
                        while( correct == false || userNum > 6)
                        {
                            Console.WriteLine("다시 입력해주세요");
                            userInput = Console.ReadLine();
                            correct = int.TryParse(userInput, out userNum);
                        }
                    }

                    switch (userNum)
                    {
                        case 1: Console.WriteLine("어떤 동물을 사냥할까요?");
                            Console.WriteLine("1.나약한 동물\n2.강한 동물");
                            rndNum = rnd.Next(1, 4);
                            userInput = Console.ReadLine();
                            correct = int.TryParse(userInput, out userNum);
                            if (correct == false || userNum > 2)
                            {
                                while (correct == false || userNum > 2)
                                {
                                    Console.WriteLine("다시 입력해주세요");
                                    userInput = Console.ReadLine();
                                    correct = int.TryParse(userInput, out userNum);
                                }
                            }


                            switch (userNum)
                            {
                                case 1: if(rndNum == 1)
                                    {
                                        //ClearConsole();
                                        Console.WriteLine("닭이 나타났습니다!");
                                        //여기 아스키 아트 Console.WriteLine("");
                                        enemyManager.GetEnemy("닭", 1 * day + turn);
                                        //Thread.Sleep(1000);
                                        //ClearConsole();
                                        Battle();
                                       
                                    }
                                if(rndNum == 2)
                                    {
                                        //ClearConsole();
                                        Console.WriteLine("박쥐가 나타났습니다!");
                                        //여기 아스키 아트 Console.WriteLine("");
                                        enemyManager.GetEnemy("박쥐", 1 * day + turn);
                                        //Thread.Sleep(1000);
                                        //ClearConsole();
                                        Battle();
                                        
                                    }
                                if(rndNum == 3)
                                    {
                                        //ClearConsole();
                                        Console.WriteLine("들개가 나타났습니다!");
                                        //여기 아스키 아트 Console.WriteLine("");
                                        enemyManager.GetEnemy("들개", 2 * day + turn);
                                        //Thread.Sleep(1000);
                                        //ClearConsole();
                                        Battle();
                                        
                                    }
                                    break;
                                case 2:
                                    if (rndNum > 1)
                                    {
                                        ClearConsole();
                                        Console.WriteLine("늑대가 나타났습니다!");
                                        //여기 아스키 아트 Console.WriteLine("");
                                        enemyManager.GetEnemy("늑대", 3 * day + turn);
                                        //Thread.Sleep(1000);
                                        //ClearConsole();
                                        Battle();

                                    }
                                    else
                                    {
                                        ClearConsole();
                                        Console.WriteLine("곰이 나타났습니다!");
                                        //여기 아스키 아트 Console.WriteLine("");
                                        enemyManager.GetEnemy("곰", 6 * day + turn);
                                        //Thread.Sleep(1000);
                                        //ClearConsole();
                                        Battle();
                                    }
                                    break;
                            }
                            break;
                    }


                }

            }


            //게임 종료 버튼
            else
            {
                ClearConsole();
                Console.WriteLine("안녕히가세요");
            }
            


        }

        public void Battle()
        {
            enterBattle = true;
            while ( enterBattle )
            {

            }
        }
    }
}

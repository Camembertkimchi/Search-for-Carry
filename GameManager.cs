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
        bool clearGame = false;

        int turn;
        int day;
        bool night = false;
        string dayorNight = "낮";
        int rndNum;
        int skillDamage;

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
                    ClearConsole();
                    Console.WriteLine($"무엇을 할까?\t{day}일차 {dayorNight}\t남은 턴: {turn}");
                    Console.WriteLine("1.동물 잡기\n2.보스 사냥\n3.인벤토리\n4.상태창\n5.아이템 제작\n6.키오스크\n7.샬럿에게 맞아 죽기");
                    Console.WriteLine($"\n\n\n보유 중인 크레딧{player.Credit}");

                    //보스 스폰 알림
                    if( day == 2 && night == true)
                    {
                        Console.WriteLine("알파가 스폰 되었습니다!");
                        Console.WriteLine("알파를 처치하면 미스릴을 얻을 수 있습니다!");
                    }
                    else if (day == 3 && night == true)
                    {
                        Console.WriteLine("오메가가 스폰 되었습니다!");
                        Console.WriteLine("오메가는 샬럿이 찾는 아이템을 가지고 있습니다!");
                    }
                    else if (day == 4 && night == true)
                    {
                        Console.WriteLine("위클라인 박사가 스폰 되었습니다!");
                        Console.WriteLine("위클라인 박사는 샬럿이 찾는 아이템을 가지고 있습니다!");
                    }

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
                                        ClearConsole();
                                        Console.WriteLine("닭이 나타났습니다!");
                                        //여기 아스키 아트 Console.WriteLine("");
                                        
                                        Thread.Sleep(1000);
                                       
                                        Battle("닭", 1);
                                       
                                    }
                                else if(rndNum == 2)
                                    {
                                        ClearConsole();
                                        Console.WriteLine("박쥐가 나타났습니다!");
                                        //여기 아스키 아트 Console.WriteLine("");
                                        
                                        Thread.Sleep(1000);
                                        //ClearConsole();
                                        Battle("박쥐", 1);
                                        
                                    }
                                else if(rndNum == 3)
                                    {
                                        ClearConsole();
                                        Console.WriteLine("들개가 나타났습니다!");
                                        //여기 아스키 아트 Console.WriteLine("");
                                        
                                        Thread.Sleep(1000);
                                        
                                        Battle("들개", 2);
                                        
                                    }
                                    break;
                                case 2:
                                    if (rndNum > 1)
                                    {
                                        ClearConsole();
                                        Console.WriteLine("늑대가 나타났습니다!");
                                        //여기 아스키 아트 Console.WriteLine("");
                                        
                                        Thread.Sleep(1000);
                                        //ClearConsole();
                                        Battle("늑대", 3);

                                    }
                                    else
                                    {
                                        ClearConsole();
                                        Console.WriteLine("곰이 나타났습니다!");
                                        //여기 아스키 아트 Console.WriteLine("");
                                        
                                        Thread.Sleep(1000);
                                        //ClearConsole();
                                        Battle("곰", 6);
                                    }
                                    break;

                                
                            }

                            break;
                        case 2: if(day == 2 && night == true)
                            {
                                ClearConsole();
                                Console.WriteLine("알파가 나타났어. 조심해.");
                                //아스키 아트

                                Thread.Sleep(1000);
                                Battle("알파", 12);
                                
                            }
                        else if(day == 3 && night == true)
                            {
                                ClearConsole();
                                Console.WriteLine("오메가가 나타났어!");
                                //아스키 아트
                                Thread.Sleep(1000);
                                Battle("오메가", 16);
                            }
                        else if( day == 4 && night == true)
                            {
                                ClearConsole();
                                Console.WriteLine("위클라인 박사야!");
                                //아스키 아트
                                Thread.Sleep(1000);
                                Battle("위클라인 박사", 20);
                            }
                            else
                            {
                                Console.WriteLine("지금은 보스가 없어요.");
                                Console.WriteLine("보스는 2, 3, 4일차 밤에 나타납니다!");
                                Thread.Sleep(1000);
                                break;
                            }
                            break;
                            case 3:
                            ClearConsole();
                            Console.WriteLine("인벤토리\n");
                            player.ShowInventory();
                            Console.WriteLine("\n\n\n1.장비 교체\n2.장비 정보 확인\n3.돌아가기");
                            userInput = Console.ReadLine();
                            correct = int.TryParse(userInput, out userNum);
                            if (correct == false || userNum > 3)
                            {
                                while (correct == false || userNum > 3)
                                {
                                    Console.WriteLine("다시 입력해주세요");
                                    userInput = Console.ReadLine();
                                    correct = int.TryParse(userInput, out userNum);
                                }
                                    
                            }
                            if (userNum == 1)
                            {
                                Console.WriteLine("새로 낄 장비를 입력해주세요");
                                loadout.UseEquipment(Console.ReadLine());
                                Console.WriteLine("계속 하시려면 엔터를 눌러주세요");
                                Console.ReadLine();

                            }
                            else if(userNum == 2)
                            {
                                Console.WriteLine("확인하고 싶은 장비 이름을 입력해주세요");
                                Equipment.ShowEquipInfo(Console.ReadLine());
                            }
                            
                            break;
                        case 4: ClearConsole();
                            Console.WriteLine();
                                Console.WriteLine("플레이어 상태창");
                            player.ShowPlayerInfo();

                            Console.WriteLine("\n\n\n\n");
                            Console.WriteLine("계속하려면 엔터를 누르세요");
                            Console.ReadLine();
                           
                            break;
                        case 5:
                            ClearConsole();
                            Console.WriteLine("아이템을 제작할 재료 이름을 입력해주세요");
                            
                            Console.WriteLine("인벤토리\n");
                            Console.WriteLine();
                            player.ShowInventory();
                            player.MakeItem(Console.ReadLine());
                            player.DeleteItemByCraft();
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

        public void Battle(string name, int level)
        {
            var enemy = enemyManager.GetEnemy(name, (level + turn) * day);
            enterBattle = true;
            player.ResetCooltime();
            player.Hp = player.MaxHp;
            while ( enterBattle == true )
            {
                ClearConsole();
                if (player.Hp <= 0)
                {
                    enterBattle = false;
                    Ending();
                    break;
                }
                if (enemy.Hp <= 0)
                {
                    turn--; 
                    Console.WriteLine($"{enemy.Name} 처치!");
                    player.Credit = enemy.DropCredit;
                    player.Exp = enemy.DropEXP;
                    var item = enemy.Dead();
                    player.AddItem(item);
                    enterBattle = false;
                    player.LVChangeMaxExp();
                    Thread.Sleep(1500);
                    break;
                }
                Console.WriteLine($"{enemy.Name} 레벨:{enemy.Level} 체력: {enemy.Hp}\t\t 플레이어 체력: {player.Hp}");
                Console.WriteLine("무엇을 할까?");
                Console.WriteLine("1.평타\n2.스킬\n3.모든 걸 내려놓고 포기한다");
                userInput = Console.ReadLine();
                correct = int.TryParse(userInput, out userNum);
                if (correct == false || userNum > 3)
                {
                    while (correct == false || userNum > 3)
                    {
                        Console.WriteLine("다시 입력해주세요");
                        userInput = Console.ReadLine();
                        correct = int.TryParse(userInput, out userNum);
                    }
                }

                switch(userNum)
                {
                    case 1: enemy.MinusHp = player.Attack();
                        player.MinusHp = enemy.Attack();
                        Thread.Sleep(700);
                        player.DecreaseCooltime();
                        break;
                    case 2:
                        
                        skillDamage = player.Skill();
                        if (skillDamage == 0)
                        {
                            break;
                        }
                        enemy.MinusHp = skillDamage;
                        player.MinusHp = enemy.Attack();
                        Thread.Sleep(1300);
                        player.DecreaseCooltime();
                        break;
                    case 3:
                        enterBattle = false;
                        Ending();
                        break;
                }
            }
        }

        public void Ending()
        {
            if(clearGame == false)
            {
                Console.WriteLine("당신은 사망하셨습니다...");
                Console.WriteLine("실험체는 다시 부활하지만, 샬럿이 당신을 용서하지 않을 것 같아요.");
                Thread.Sleep(3000);
                ClearConsole();
                Console.WriteLine("야 김쁠뿡!!!!!!!");
                Thread.Sleep(1000);
                ClearConsole();
                Console.WriteLine("                                                                                                                                                                                                                  \r\n                                                               ::-  -                                        :                                    =.                                                              \r\n                                                                                                                                                           -                                                      \r\n                                                       *                .                                      .                           -                =                                                     \r\n                                                                       -                                                                    *                                                                     \r\n                                                -       +             -                         @@@@@@@@@@@@@@@@@@                           .              @.                                                    \r\n                                          @@%@@@@@@@-      --        :                       @@                   @@                          :          @@ @@@@%#@                                               \r\n                                          # +      .@@@@ .     +                               @+                @@                                   @@@@         @                                              \r\n                                          @- .=    ##  @.   :    ..      =:     +         @@@@@@@                    @@@@@    @ @+       %-      -   @   @    -= . @ =                                            \r\n                                           *@@@@+=@@@ #@= . ::+            @@@@ @@@@@@@@=       @               *=         =@@@   @        -         @+ -@@@ @@@@@-                                               \r\n                                              -@+@@   @@               .@@      :               @               @            @      @                @%=  *@@**       -                                           \r\n                                                 -@   %@      % .    @@          @                              #           @        @@      =:=-    @*=  :@                                                      \r\n                                                 *@   *@           #@            -#          *@@@@@@@@@@@@@@-               @          @             @#-  :@                                                      \r\n                                                 @@- #@@@         @@              %    +@@@@%=             :%@@@@@         @            @@           @@%..%@-                                                     \r\n                                                  @- =*%            @@@            @@@@+     #@@@@@@@@@@@@@#.    =@@@@    @              @@           @=  @.                                                      \r\n                                                  @*=%%@           @   @        @@@=    @@@@@               @@@@+    =@@@                  @          @##=@@                                                      \r\n                                                  @.  #@         :@     @*   @@@=   #@@@  %                     :@@@    =@@@                @*        @   @@                                                      \r\n                                                  @  :@@        @@         @@#   +@@     @+                         @@@    *@@               @@@      @=  .@                                                      \r\n                                                  @  =@@       @#        @@=   @@-      @@                       -     @@@   -@@            :-@:@@    @*  .@                                                      \r\n                   *.                             @  %@*      @        @@:   @@         @                        @        @@    @@        @ :@   #@   @#: :@                                   .+                 \r\n                    .    :=                       @  %@   @@@@        @-  :@@          @                         @=         @@:  :@    +@     @.   @@ @#  =@                             *-    .                  \r\n                      .            -.             @  ## @@    @@    @@  .@@           @@                         =@           @@   @@          @-   @@#=:  @                   +=.           :                    \r\n                       .% -                       @  @=@%          @%  @@             @                           @             @@  =@          @#    @+.  @                            :- #                      \r\n                                                  @  @#@          @- -@=             @@                           @              @@. -@          @@@# @+*  @                                                      \r\n                                                  @  @@          @  @@               @                            @                @+ :@          - @ #*.  @                      .     .                         \r\n                               -  ::      .       @  %@         @  @+                @                            @                 @@ .@    .@@    .@=*+  @                    =   .                             \r\n                                                  @  %@        @ =@                 .@                            @                   @:.@  %        @.#+  @                                                      \r\n                              #             :     @  %@@@@    @.+@                  %@                            @                    @*:@          @ ++  @                         +                            \r\n                                             *    @  +@    @@@@ @                   @@                            @                     @@+@        @@@#=  @          =                                           \r\n                                                 .@  *@   *@  #@                   @@@                            @                      @@@   @@@@@   @+  @                                                      \r\n                                                 :@  #@   @@ @@                  @@*@@                            @                       @@@@#.@#     @-  @                                                      \r\n                                                 +@  *@   +* @                @@@*  %@                            @#         @             @#*   @     @+  @                                                      \r\n                                                 +@  *@   @@@@              @@-     @@                           +@@:        @              @@ @@@     @*  @                                                      \r\n                                                 ##  +@  @@ @             %@+        @                           @= @@       @               #   @-   @@-  @                                                      \r\n                                                 #@ .+@  @  @           @@-          @                           @:  @@@     @              %% : .@    @+ .@                                                      \r\n                                                 @* -#@ @@ #@          @     @@@@@@  @                           @@@    @@   @              @% .  @ @@@@+  @                                                      \r\n                         #                       @: :*# @  @+         @     @@     @  @                          @  @@@@@@@  @              @+ .. #@   @+  @      *                      :+                       \r\n                         =                       @: ++ @@  @          #@  =@   @@:  .@@                        - @@@       @@@              @-...  @   @#  @       =                      .                       \r\n                            .                  + @  +-:@ .#@           @  @  @@@@      @@                      %@    @@@@    @              @ :- . @@  @#  @        .                                             \r\n                                                 @  * @@   @           @     @@@@@@@.    +@=                @@@.     +@@@@   @@             @  @+-. @  @#. @.       =                :.                           \r\n                          -   .+              -  @  * @ *  @           @@   @@@-    :@@@   #:                     =@@@@@@@  -@              @    :==:@ @#  @-                      :=    :                        \r\n                        :.       +            =  @  + @  %@@            @   -@-  .    . :*@@@@           -@@  %@@@=    @@@  @@              @    %%  @ -%: @-                    +*       -                       \r\n                       @       .                 @. * @   @@           @@    @@            @            @@+             @.  @               @  .@*   @@-#  @- :   .                         *                     \r\n                        =          ::   -   ::   @  *-@-   @      +@@@@@%@@   @@@%++=#@@@@               @@=         .:@+   @              #@ @@   .@@ .#- #@         : .  #   -.          %                      \r\n                          .      .=:   +% ..:=+= @  +# @@=%@     @       :#@@%=  :#@@@-.::-@@@@@@@@@@@@%=:.-@@@@@@@@@@+:+@@++%@@@@#        @@ @    @:  @#= *@    .-+#+-:-  @    ==:      =                        \r\n                                                 @  *@   @@@    @@@@@@    %@@@@ :.:+%=:==#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@         @    =@@@@  +@+ #@ :                                                   \r\n                                 *+.          :  @  +@     :@  @     @*@@@                                                 @               @*@@@.      *@: %@       *           -#*.                              \r\n                               .              %  @  +@% -*  @  @*: @%@   :@@                                               @              @@=  #       +@= #@        :              -                             \r\n                             .                +  @  +@      =@ @ = .@      = @@@                                         :@@              @    @+      :@= #@                        :                            \r\n                                                 @  =@       @- -+-@       @:@  #@@@@              @@@@@-  .@@@@@@@@@@@@. @              @@     @      @@+ *@     . -                                             \r\n                                                 @  =@@       @:           =@   @   -@@@@@@@@@@@@@  + -  @@@@%+=-:::-+@@ @@              @       @   @@=@= *@                                                     \r\n                                                 @@@@@ @@     @@@  @@       @  @: ...  @:-====-:@  :      @=+--=++*++=@* @           @  @+        @@@   @@@@@                                                     \r\n                                                         @@@ @:  @@@:@@      @+@  .... @%=++**@%@         @@@@@@++*++=@ @#          @@ @%      @@@                                                                \r\n                                                            :@@@       @@@#   @   ...   @#+**+==%@  * .  *@==-=++++*+-@=@         @@*@@@    @@*                                                                   \r\n                                                                :@@@.      @@@@@@ ..... @@=++=+:-@@@   @@@=--=+++*+*+-@%       @@@= @@ + @@. %                                                                    \r\n                                                    *              ..-@@@     @   ... . +@=%@@@@@*=%@@@+*@@@@@@%=--==*@@@@@@@@@   @@   @     @              .  :                                                  \r\n                                                                   +*     @@   @@.       @@@  @+-+=@@ @==--*#  @@@@@@=        .@@@    @#    +@                                                                    \r\n                                                       .           +@    @+%@    +@@@@@@.    @%+++*@  @@-**+@@     @@@@@@@@@@@       @+@=   *@                                                                    \r\n                                                         .         *@   @*  #@             @@+*+*=@:   @*+++-@=                    @@. .@   *@                                                                    \r\n                                                            :      @%  @=  .  @@@      @@@@@==+*+*@    @@-+++*@@@@             +@@@   . :@   @        :.                                                          \r\n                                                                   @  @   ...    @@@@@@    @@-=*+@@     @++++=#@  %@@@@@@@@@@@@-    ...  =@  @                                                                    \r\n                                                                   %=@  :..:....      ..:.  #@+-%@   .  @@=+=+#@+               ........  +@ @                                                                    \r\n                                                                   @@  ....................   @@@.  @ @  @+#@@@%  .......................  .@@                                                                    \r\n                                                                   @                                      @+   *                             @.                                                                   ");
                Console.WriteLine("내가 주겨주게써!!!!!!!!!!!!!!!!!!!!");
                endGame = true;
            }
        }
    }
}

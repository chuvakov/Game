using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_11__games_.Enums
{
    public enum BaseCommand
    {
        CreatePlayer = 1,  // можно поменять нумерацию
        DeletePlayer,
        SelectPlayer,
        CreateGame,
        DeleteGame,
        ShowListGame,
        Exit
    }
}

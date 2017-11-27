using System;
using System.Collections.Generic;
using System.Text;

namespace Wishes.Core.Managers
{
    public static class GameManager
    {
        public static Color MenuBackground { get; private set; }
        public static Color UnselectedText { get; private set; }
        public static Color SelectedText { get; private set; }

        public static Color InGameBackground { get; private set; }

        public static void InitialiseGame(Color menuBackground, Color unselectedText, Color selectedText, Color inGameBackground)
        {
            MenuBackground = menuBackground;
            UnselectedText = unselectedText;
            SelectedText = selectedText;
            InGameBackground = inGameBackground;
        }
    }
}

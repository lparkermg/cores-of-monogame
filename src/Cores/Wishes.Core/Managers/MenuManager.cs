using System;
using System.Collections.Generic;
using System.Text;

namespace Wishes.Core.Managers
{
    public static class MenuManager
    {
        private static List<MenuPack> _menus;
        public static MenuPack CurrentMenu { get; private set; }

        //TODO: convert to an Enum of locations rather than a string.
        private static Dictionary<string, Texture2D> _currentImages = new Dictionary<string, Texture2D>();

        private static int _selectedItemIndex = 0;

        public static bool LoadMenus(string path, GraphicsDevice gd)
        {
            var files = Directory.GetFiles(path);

            _menus = new List<MenuPack>();
            try
            {
                foreach (var file in files)
                {
                    using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        DataContractSerializer dcs = new DataContractSerializer(typeof(MenuPack));
                        XmlDictionaryReader binReader =
                            XmlDictionaryReader.CreateBinaryReader(fs, new XmlDictionaryReaderQuotas());
                        var menuPack = (MenuPack)dcs.ReadObject(binReader);
                        _menus.Add(menuPack);
                    }
                }
                CurrentMenu = _menus[0];
                _currentImages.Add("BackgroundImage", GenerateImage(CurrentMenu.BackgroundImage, gd));
                if (CurrentMenu.Logo != null) _currentImages.Add("Logo", GenerateImage(CurrentMenu.Logo, gd));
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public static void SetPackByType(int type)
        {
            CurrentMenu = _menus.FirstOrDefault(t => t.Type == type);
        }

        public static string GetSelectedName()
        {
            return CurrentMenu.Items[_selectedItemIndex];
        }

        public static string Update()
        {
            //TODO: Update variables based on input manager.
            if (CurrentMenu.Layout == 1)
            {
                if (InputManager.LeftPressed)
                    ChangeSelection(false);
                else if (InputManager.RightPressed)
                    ChangeSelection(true);
            }
            else if (CurrentMenu.Layout == 0)
            {
                if (InputManager.DownPressed)
                    ChangeSelection(true);
                else if (InputManager.UpPressed)
                    ChangeSelection(false);
            }
            //TODO: Generate command to send (if needed).
            if (InputManager.APressed)
            {
                var command = GenerateCommand();
                return command;
            }

            return "";
        }

        public static List<MenuRenderEvent> GenerateMenuRenderEventsEvents(GraphicsDevice gd)
        {
            var renderEvents = new List<MenuRenderEvent>();
            //TODO: Generate menu render events based on the menupack and current settings.

            renderEvents.Add(new MenuRenderEvent(new MenuRenderData(_currentImages.FirstOrDefault(t => t.Key == "BackgroundImage").Value, "", false, Vector2.Zero, 0.0f), DateTime.Now));

            var count = 0;
            var amountToAdd = (gd.Viewport.Height / 4) / CurrentMenu.Items.Count - 1;
            var xPosition = (gd.Viewport.Width - gd.Viewport.Width / 4);
            var yPosition = (gd.Viewport.Height / 5);
            foreach (var item in CurrentMenu.Items)
            {
                if (count == _selectedItemIndex)
                    renderEvents.Add(new MenuRenderEvent(new MenuRenderData(null, item, true, new Vector2(xPosition, yPosition), 0.1f), DateTime.Now));
                else
                    renderEvents.Add(new MenuRenderEvent(new MenuRenderData(null, item, false, new Vector2(xPosition, yPosition), 0.1f), DateTime.Now));
                yPosition += amountToAdd;
                count += 1;
            }

            return renderEvents;
        }

        private static Texture2D GenerateImage(this ImageData id, GraphicsDevice gd)
        {
            using (var ms = new MemoryStream(id.Data))
            {
                return Texture2D.FromStream(gd, ms);
            }
        }

        private static void ChangeSelection(bool goingUp)
        {
            if (goingUp)
            {
                if (_selectedItemIndex >= CurrentMenu.Items.Count - 1)
                    _selectedItemIndex = 0;
                else
                    _selectedItemIndex += 1;
            }
            else
            {
                if (_selectedItemIndex <= 0)
                    _selectedItemIndex = CurrentMenu.Items.Count - 1;
                else
                    _selectedItemIndex -= 1;
            }
        }

        private static string GenerateCommand()
        {
            var menuItem = CurrentMenu.Items[_selectedItemIndex];

            //TODO: Move to have commands within the menu packs.
            switch (menuItem)
            {
                case ("Start"):
                    return "START MANUAL";
                case ("Start Auto"):
                    return "START AUTO";
                case ("Quit"):
                    return "QUIT GAME";
                default:
                    return "";
            }
        }
    }
}

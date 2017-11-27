using System;
using System.Collections.Generic;
using System.Text;

namespace Wishes.Core.Managers
{
    public static class RenderManager
    {
        public static void RenderMenu(SpriteBatch sb, SpriteFont font, List<MenuRenderEvent> events)
        {
            var selectedColour = GameManager.SelectedText;
            var unselectedColour = GameManager.UnselectedText;

            sb.Begin(SpriteSortMode.FrontToBack);
            foreach (var evnt in events)
            {
                if (evnt.Data.Image != null)
                    sb.Draw(evnt.Data.Image, evnt.Data.Position, evnt.Data.Image.Bounds, Color.White, 0.0f, Vector2.Zero, Vector2.One, SpriteEffects.None, evnt.Data.Layer);
                else
                    sb.DrawString(font, evnt.Data.Text, evnt.Data.Position, evnt.Data.Selected ? selectedColour : unselectedColour, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, evnt.Data.Layer);

            }
            sb.End();
        }

        public static void RenderGame(SpriteBatch sb, SpriteFont font, List<RenderEvent> events)
        {
            sb.Begin(SpriteSortMode.FrontToBack);
            sb.DrawString(font, "IN GAME!!", Vector2.Zero, Color.Black, 0.0f, Vector2.One * 150, 0.0f, SpriteEffects.None, 1.0f);
            sb.End();
        }
    }
}

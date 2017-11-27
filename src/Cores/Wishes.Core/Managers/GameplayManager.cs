using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Wishes.Core.Managers
{
    public static class GameplayManager
    {
        //TODO: Move over to Enum list.
        private static Dictionary<string, List<Texture2D>> _loadedGraphics;

        public static void SetupGraphicsDictionary(Dictionary<string, List<Texture2D>> images)
        {
            _loadedGraphics = images;
        }

        public static List<RenderEvent> RunGameLogic(GameTime gameTime, Vector2 screenMax, bool initialGo)
        {
            //TODO: Update on screen objects.
            CheckOnScreenObjects(screenMax);
            //TODO: Spawn new ones using randomisation, story progression and whats in the loaded images.
            SpawnSystem(gameTime, initialGo);
            //TODO: Generate events.

            //TODO: Return events.
            return new List<RenderEvent>();
        }

        private static List<RenderEvent> GenerateRenderEvents()
        {
            return new List<RenderEvent>();
        }

        private static void SpawnSystem(GameTime gameTime, bool initialGo)
        {
            if (initialGo)
            {
                //TODO:Spawn all the things.
                //Spawn starting area.
            }
        }

        private static void CheckOnScreenObjects(Vector2 screenMax)
        {
            foreach (var currentItem in _onScreenObjects)
            {
                if (currentItem.NeedsRemoving(screenMax))
                    _onScreenObjects.Remove(currentItem);

                currentItem.CurrentLocation += currentItem.Velocity;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Wishes.Core.Managers
{
    public static class InputManager { 
        public static bool APressed { get; private set; }
        public static bool BPressed { get; private set; }
        //Not Needed in this.
        public static bool LeftPressed { get; private set; }
        public static bool RightPressed { get; private set; }
        public static bool UpPressed { get; private set; }
        public static bool DownPressed { get; private set; }

        public static bool PausePressed { get; private set; } //? Is there even a pause?

        public static bool GamePadConnected { get; private set; }

        private static KeyboardState _lastFrameKeyboardState = new KeyboardState();
        private static KeyboardState _currentKeyboardState = new KeyboardState();

        private static GamePadState _lastFrameGamePadState;
        private static GamePadState _currentGamePadState;


        public static void UpdateInput()
        {
            UpdateKeyboardInput();
            UpdateGamepadInput();
        }

        private static void UpdateKeyboardInput()
        {
            _lastFrameKeyboardState = _currentKeyboardState;
            _currentKeyboardState = Keyboard.GetState();

            APressed = _currentKeyboardState.IsKeyDown(Keys.E) && _lastFrameKeyboardState.IsKeyUp(Keys.E);
            BPressed = _currentKeyboardState.IsKeyDown(Keys.Q) && _lastFrameKeyboardState.IsKeyUp(Keys.Q);
            LeftPressed = _currentKeyboardState.IsKeyDown(Keys.A) && _lastFrameKeyboardState.IsKeyUp(Keys.A)
                || _currentKeyboardState.IsKeyDown(Keys.Left) && _lastFrameKeyboardState.IsKeyUp(Keys.Left);
            RightPressed = _currentKeyboardState.IsKeyDown(Keys.D) && _lastFrameKeyboardState.IsKeyUp(Keys.D)
                || _currentKeyboardState.IsKeyDown(Keys.Right) && _lastFrameKeyboardState.IsKeyUp(Keys.Right);

            UpPressed = _currentKeyboardState.IsKeyDown(Keys.W) && _lastFrameKeyboardState.IsKeyUp(Keys.W)
                || _currentKeyboardState.IsKeyDown(Keys.Up) && _lastFrameKeyboardState.IsKeyUp(Keys.Up);
            DownPressed = _currentKeyboardState.IsKeyDown(Keys.S) && _lastFrameKeyboardState.IsKeyUp(Keys.S)
                || _currentKeyboardState.IsKeyDown(Keys.Down) && _lastFrameKeyboardState.IsKeyUp(Keys.Down);


            //TODO: Implement pause button?
        }

        private static void UpdateGamepadInput()
        {

            _lastFrameGamePadState = _currentGamePadState;
            _currentGamePadState = GamePad.GetState(PlayerIndex.One);

            if (!_currentGamePadState.IsConnected)
            {
                GamePadConnected = false;
                return;
            }

            GamePadConnected = true;

            APressed = _currentGamePadState.Buttons.A == ButtonState.Pressed && _lastFrameGamePadState.Buttons.A == ButtonState.Released;
            BPressed = _currentGamePadState.Buttons.B == ButtonState.Pressed && _lastFrameGamePadState.Buttons.B == ButtonState.Released;
            LeftPressed = _currentGamePadState.DPad.Left == ButtonState.Pressed && _lastFrameGamePadState.DPad.Left == ButtonState.Released
                || _currentGamePadState.ThumbSticks.Left == new Vector2(-1.0f, 0.0f) && _lastFrameGamePadState.ThumbSticks.Left != new Vector2(-1.0f, 0.0f);
            RightPressed = _currentGamePadState.DPad.Right == ButtonState.Pressed && _lastFrameGamePadState.DPad.Right == ButtonState.Released
                || _currentGamePadState.ThumbSticks.Left == new Vector2(1.0f, 0.0f) && _lastFrameGamePadState.ThumbSticks.Left != new Vector2(1.0f, 0.0f);
            UpPressed = _currentGamePadState.DPad.Up == ButtonState.Pressed && _lastFrameGamePadState.DPad.Up == ButtonState.Released
                || _currentGamePadState.ThumbSticks.Left == new Vector2(0.0f, 1.0f) && _lastFrameGamePadState.ThumbSticks.Left != new Vector2(0.0f, 1.0f);
            DownPressed = _currentGamePadState.DPad.Down == ButtonState.Pressed && _lastFrameGamePadState.DPad.Down == ButtonState.Released
                || _currentGamePadState.ThumbSticks.Left == new Vector2(0.0f, -1.0f) && _lastFrameGamePadState.ThumbSticks.Left != new Vector2(0.0f, -1.0f);
        }
    }
}

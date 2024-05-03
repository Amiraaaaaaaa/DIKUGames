// using System;
// using DIKUArcade.State;
// using DIKUArcade.Entities;
// using DIKUArcade.Events;
// using DIKUArcade.Graphics;
// using DIKUArcade.Input;
// using System.IO;
// using DIKUArcade.Math;

// namespace Breakout.BreakoutStates {
//     public class GamePaused : IGameState {
//         private static GamePaused instance;
//         private Entity backGroundImage = new(new DynamicShape(0, 0, 1, 1), 
//             new Image(Path.Combine("..", "Breakout", "Assets", "Images", "SpaceBackground.png")));

//         private Text[] menuButtons = {
//             new("Continue", new Vec2F(0.3f, 0.6f), new Vec2F(0.2f, 0.2f)),
//             new("Main Menu", new Vec2F(0.4f, 0.4f), new Vec2F(0.2f, 0.2f))
//         };

//         public static GamePaused GetInstance() {
//             if (instance == null) {
//                 instance = new GamePaused();
//                 instance.ResetState();
//             }
//             return instance;
//         }

//         private int activeMenuButton = 0;
//         private int maxMenuButtons = 2;

//         public void HandleKeyEvent(KeyboardAction action, KeyboardKey key) {
//             if (action == KeyboardAction.KeyRelease) {
//                 switch (key) {
//                     case KeyboardKey.Up:
//                         activeMenuButton = (activeMenuButton == 0) ? maxMenuButtons - 1 : activeMenuButton - 1;
//                         break;
//                     case KeyboardKey.Down:
//                         activeMenuButton = (activeMenuButton + 1) % maxMenuButtons;
//                         break;
//                     case KeyboardKey.Enter:
//                         string nextState = (activeMenuButton == 0) ? "GAME_RUNNING" : "MAIN_MENU";
//                         BreakoutBus.GetBus().RegisterEvent(new GameEvent {
//                             EventType = GameEventType.GameStateEvent,
//                             Message = "CHANGE_STATE",
//                             StringArg1 = nextState
//                         });
//                         break;
//                 }
//             }
//         }

//         public void RenderState() {
//             backGroundImage.RenderEntity();
//             for (int i = 0; i < menuButtons.Length; i++) {
//                 menuButtons[i].SetColor(i == activeMenuButton ? new Vec3F(1, 1, 1) : new Vec3F(1, 0, 1));
//                 menuButtons[i].RenderText();
//             }
//         }

//         public void ResetState() {
//             // Reset any necessary state-specific details here.
//         }

//         public void UpdateState() {
//             // Update state-specific details, such as animations or timers.
//         }
//     }
// }



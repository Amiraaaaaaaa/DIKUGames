// namespace Breakout.BreakoutStates; 
// using DIKUArcade.State;
// using DIKUArcade.Entities;
// using DIKUArcade.Graphics;
// using DIKUArcade.Input;
// using DIKUArcade.Math;
// using DIKUArcade.Events;
// using DIKUArcade.Physics;
// using System.Collections.Generic;
// using System;
// using System.IO;

// public class GameRunning : IGameState {
//     private static GameRunning instance = null;
//     private Entity backGroundImage = new Entity(
//         new DynamicShape(0, 0, 1, 1),
//         new Image(Path.Combine("..", "Breakout", "Assets", "Images", "SpaceBackground.png"))
//     );

//     // NEW
//     // Player and health
//     private Player player; //move

//     // Level system
//     private int gameLevel;
//     private bool gameOver;
//     private Text display;

//     // Playershots
//     private IBaseImage playerShotImage;

//     // Animations
//     private AnimationContainer enemyExplosions;
//     private List<Image> explosionStrides;
//     private List<Image> enemyStridesBlue;
//     private List<Image> enemyStridesRed;
//     private const int EXPLOSION_LENGTH_MS = 500;

//     public static GameRunning GetInstance() {
//         if (GameRunning.instance == null) {
//             GameRunning.instance = new GameRunning();
//             GameRunning.instance.ResetState();
//         }
//         return GameRunning.instance;
//     }

//     public void HandleKeyEvent(KeyboardAction action, KeyboardKey key) {
//         if (action == KeyboardAction.KeyPress) {
//             this.KeyPress(key);
//         }
//         if (action == KeyboardAction.KeyRelease) {
//             this.KeyRelease(key);
//         }
//     }

//     private void KeyPress(KeyboardKey key) {
//         if (key == KeyboardKey.Escape) {
//             BreakoutBus.GetBus().RegisterEvent(
//                                 new GameEvent {
//                                     EventType = GameEventType.GameStateEvent,
//                                     Message = "CHANGE_STATE",
//                                     StringArg1 = "GAME_PAUSED"
//                                 }
//                             );
//         }

//         switch (key) {
//             case KeyboardKey.Left:
//                 BreakoutBus.GetBus().RegisterEvent(new GameEvent() {
//                     EventType = GameEventType.PlayerEvent,
//                     Message = "move-left"
//                 });
//                 break;
//             case KeyboardKey.Right:
//                 BreakoutBus.GetBus().RegisterEvent(new GameEvent() {
//                     EventType = GameEventType.PlayerEvent,
//                     Message = "move-right"
//                 });
//                 break;
//             case KeyboardKey.Space:
//                 // float fromHere = player.GetPosition() + 0.05f;
//                 // DynamicShape dynamicShape = new DynamicShape(fromHere, 0.1f, 0.08f, 0.021f);
//                 // Vec2F position = new Vec2F(fromHere, 0.1f);
//                 // PlayerShot playerShot = new PlayerShot(position, playerShotImage);
//                 // playerShots.AddEntity(playerShot);
//                 break;
//         }
//     }

//     private void KeyRelease(KeyboardKey key) {
//     }

//     public void RenderState() {
//     }

//     public void ResetState() {

//     }

//     public void UpdateState() {
//     }


//     // game elements



//     public void CheckCollision() {
//     }

//     public void CheckForNewLevel() {
//     }

// }
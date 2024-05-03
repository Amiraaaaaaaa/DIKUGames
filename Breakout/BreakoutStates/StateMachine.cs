// using DIKUArcade.State;
// using DIKUArcade.Entities;
// using DIKUArcade.Graphics;
// using DIKUArcade.Input;
// using DIKUArcade.Math;
// using DIKUArcade.Events;
// using System.IO;
// using System;


// namespace Breakout.BreakoutStates {
//     public class StateMachine : IGameEventProcessor {
//         public IGameState ActiveState { get; private set; }
//         public StateMachine() {
//             BreakoutBus.GetBus().Subscribe(GameEventType.GameStateEvent, this);
//             BreakoutBus.GetBus().Subscribe(GameEventType.InputEvent, this);
//             ActiveState = MainMenu.GetInstance();
//             GameRunning.GetInstance();
//             GamePaused.GetInstance();
//         }
//         private void SwitchState(GameStateType stateType) {
//             switch (stateType) {
//                 case GameStateType.GameRunning:
//                     ActiveState= GameRunning.GetInstance();
//                     break;
//                 case GameStateType.MainMenu:
//                     ActiveState = MainMenu.GetInstance();
//                     break;

//                 case GameStateType.GamePaused:
//                     ActiveState = GamePaused.GetInstance();
//                     break;
//                 default:
//                     throw new ArgumentException("Invalid GameStateType");

//             }
//         }

//         public void ProcessEvent(GameEvent gameEvent){
//             if (gameEvent.EventType == GameEventType.GameStateEvent){
//                 if (gameEvent.Message=="CHANGE_STATE")
//                 SwitchState(StateTransformer.TransformStringToState(gameEvent.StringArg1));
//             }
//         }
//     } 
// }   
// using System;
// using DIKUArcade.State;
// using DIKUArcade.Entities;
// //using DIKUArcade.Entities;
// using DIKUArcade.Graphics;
// using DIKUArcade.Math;
// using DIKUArcade.Input;
// using System.IO;
// using DIKUArcade.Events;

// namespace Breakout.BreakoutStates{
//     public class MainMenu :IGameState{
//         private static MainMenu instance = null;
//         private Entity backGroundImage = 
//         new (new DynamicShape(0, 0,1,1),
//         new Image(Path.Combine("..", "Breakout", "Assets", "Images", "TitleImage.png")));

//         private Text[] menuButtons= new Text[] {
//             new("New Game", new Vec2F(0.4f, 0.7f), new Vec2F(0.2f, 0.2f)),
//             new ("Quit", new Vec2F(0.4f, 0.4f), new Vec2F(0.2f,0.2f))
//         };

//         private int activeMenuButton= 0;
//         private int maxMenuButtons = 2;

//         public static MainMenu GetInstance() {
//             if (MainMenu.instance == null) {
//                 MainMenu.instance = new MainMenu();
//                 MainMenu.instance.ResetState();
//             }
//             return MainMenu.instance;
//         }

//         //Dene methode er implementeret ind i GameRunning klass. 
//         //her bare vi kalde det
//         public void ResetState(){ 
            
//         }

//         //Dene methode er implementeret ind i GameRunning klass. 
//         //her bare vi kalde det
//          public void UpdateState(){
            
//         }

//         // Denne methode give farve til menue,s mulighederne, 
//         //dvs. at vi vælge for eksampel new game, farven er vide elleres fraven er lyserød.
//          public void RenderState(){
//             backGroundImage.RenderEntity();
//             int i=0;
//             foreach (Text button in menuButtons) {
//                 if (i == activeMenuButton) {
//                     button.SetColor(new Vec3F(1, 1, 1));// Set color to white for the active menu button

//                 }else {
//                     button.SetColor(new Vec3F(1, 0, 1));// Set color to magenta for inactive buttons
//                 }
//                 button.RenderText();
//                 i++;
//             }
            
//         }



//         public void HandleKeyEvent(KeyboardAction action, KeyboardKey key){
//             if (action == KeyboardAction.KeyRelease) {
//                 switch(key){
//                     case KeyboardKey.Up:
//                         if (activeMenuButton >0){
//                             activeMenuButton--;

//                         }
//                         break;
//                     case KeyboardKey.Down:
//                         if (activeMenuButton + 1 < maxMenuButtons){
//                             activeMenuButton ++;
//                         }
//                         break;
//                     case KeyboardKey.Enter or KeyboardKey.KeyPadEnter:

//                         if (activeMenuButton == 0){//The "activeMenuButton == 0" is a conditional check used to determine if the "New Game" option is currently selected in the main menu, triggering actions to start a new game session upon confirmation.
//                             GameRunning.GetInstance().ResetState();
//                             BreakoutBus.GetBus().RegisterEvent(
//                                 new GameEvent{
//                                     EventType = GameEventType.GameStateEvent,
//                                     Message = "CHANGE_STATE",
//                                     StringArg1 ="GAME_RUNNING"
//                                 }
//                             );
                          
//                         } else if (activeMenuButton == 1){
//                             BreakoutBus.GetBus().RegisterEvent(new GameEvent(){
//                                 EventType = GameEventType.WindowEvent,
//                                 Message = "CLOSE_WINDOW"
//                             });
//                         }
//                         break;


//                 }

//             }
            
//         }
    
       
//     }            
           
// }



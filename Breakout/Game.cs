using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Input;
using DIKUArcade.Events;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
//using static System.Reflection.Metadata.BlobBuilder;
using Breakout.MapLoad;
using Breakout.Entities;

namespace Breakout {
    public class Game : DIKUGame, IGameEventProcessor {
        //Player player;
        private Player? player;
        private Ball ball;
        public Ball? Ball {get => ball;}
        public Player? Player { get => player; }
        //private int health;
        GameEventBus eventBus;
        //Dictionary<string,Blobs> blockDict;
        //Har tilføjet neste tree linjer og udkomentier oeren linjer
        MapMaker? mapMaker;
        Dictionary<(int, int), Block>? blockDict;
        public string? Level="1";

        public Game(WindowArgs windowArgs) : base(windowArgs) {
            window.SetKeyEventHandler(KeyHandler);
           
            // Player
            player = new Player(
                new DynamicShape(0.4f, 0.1f, 0.2f, 0.025f, 0.0f, 0.0f),
                new Image(Path.Combine("Assets", "Images", "player.png"))
                );

            //Ball
            ball = new Ball(
                new DynamicShape(0.475f, 0.125f, 0.05f, 0.05f, 0.0f, 0.0f),
                new Image(Path.Combine("Assets", "Images", "ball.png"))
            );

          
            
            mapMaker = new MapMaker(Path.Combine("Assets", "Levels", $"level{this.Level}.txt"));
            blockDict = mapMaker?.BlockDictCreator();
                

            eventBus = new GameEventBus();
            eventBus.InitializeEventBus(new List<GameEventType> { GameEventType.PlayerEvent });
            eventBus.Subscribe(GameEventType.PlayerEvent, player);
        }



        /*
        Handle inputs 
        */
        private void KeyHandler(KeyboardAction action, KeyboardKey key) {
            if (action == KeyboardAction.KeyPress) {
                this.KeyPress(key);
            }
            if (action == KeyboardAction.KeyRelease) {
                this.KeyRelease(key);
            }
        }

        private void KeyPress(KeyboardKey key) {
            if (key == KeyboardKey.Left) {
                eventBus.RegisterEvent(new GameEvent {
                    EventType = GameEventType.PlayerEvent,
                    Message = "MOVE_LEFT"
                });
            } else if (key == KeyboardKey.Right) {
                eventBus.RegisterEvent(new GameEvent {
                    EventType = GameEventType.PlayerEvent,
                    Message = "MOVE_RIGHT"
                });
            }

        }
        private void KeyRelease(KeyboardKey key) { 
            if (key == KeyboardKey.Left || key == KeyboardKey.Right) {
            eventBus.RegisterEvent(new GameEvent {
            EventType = GameEventType.PlayerEvent,
            Message = "STOP_MOVE"
        });
        }
        }

        /*
        Handle rendering the screen 
        */
        public override void Render() {
            ball.RenderEntity();
            player?.RenderEntity();
            player?.RenderEntity();
                if (blockDict != null) {
                foreach (var block in blockDict.Values) {
                    block?.RenderEntity();
                }
            }
        }



        /*
        Handle updating game logic
        */
        public override void Update() {
            eventBus.ProcessEventsSequentially();
            player?.Move();
            ball?.MoveBall(blockDict, player);
        
        }
        public void ProcessEvent(GameEvent gameEvent) { }
    }
}

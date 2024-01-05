using Services.StateMachine.States;

namespace Services.StateMachine
{
    public class GameStatesFactory
    {
        public IGameState CreateGameState(GameStateMachine stateMachine)
        {
            return new GameState(stateMachine);
        }
    }
}
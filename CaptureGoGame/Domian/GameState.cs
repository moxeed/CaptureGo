using System.Collections.Generic;

namespace CaptureGoGame.Domian
{
    public enum States 
    {
        WaitForOpponent,
        YourTurn,
        Finished,
    }

    public class GameState
    {
        public GameState(States state, bool? winnerColor, IReadOnlyList<IReadOnlyList<Point>> board)
        {
            State = state;
            WinnerColor = winnerColor;
            Board = board;
        }

        public States State { get;}
        public string StateName => State.ToString();
        public bool? WinnerColor { get;} 
        public IReadOnlyList<IReadOnlyList<Point>> Board { get;}
    }
}

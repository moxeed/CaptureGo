using System;

namespace CaptureGoGame.Domian
{
    public class Game
    {
        private Guid? _firstPlayer;
        private Guid? _secondPlayer;

        private bool _turn;
        private Board _board;
        private object _lockObject = new object();

        public Game()
        {
            _board = new Board();
        }

        public Guid RegisterPlayer()
        {
            if (_firstPlayer is not null
             && _secondPlayer is not null)
                throw new OverflowException("No More Room For Another Player");

            lock(_lockObject)
            {
                if(_firstPlayer is null)
                {
                    _firstPlayer = Guid.NewGuid();
                    return _firstPlayer.Value;
                }

                _secondPlayer = Guid.NewGuid();
                return _secondPlayer.Value;
            }
        }

        private bool IsPlayersReady => _firstPlayer is not null && _secondPlayer is not null;

        private bool IsPlayerTurn(Guid player)
        {
            if (!IsPlayersReady) return false;

            if (player == _firstPlayer && !_turn)
                return true;
            if (player == _secondPlayer && _turn)
                return true;

            return false;
        }

        public GameState GetState(Guid player)
        {
            var state = IsPlayerTurn(player) ? States.YourTurn : States.WaitForOpponent;
            if (!IsPlayersReady) state = States.WaitForOpponent;
            if (_board.IsGameOver()) state = States.Finished;

            return new GameState(state, state == States.Finished ? !_turn : null, _board.Data);
        }

        public void NewGame()
        {
            lock(_lockObject)
            {
                _firstPlayer = null;
                _secondPlayer = null;

                _board.Clear();
                _turn = false;
            }
        }

        public void PlaceStone(Guid player, int x, int y)
        {
            if(IsPlayerTurn(player))
            {
                _board.PlaceStone(x, y, _turn);
            }
            else 
            {
                throw new InvalidOperationException();    
            }
            _turn = !_turn;
        }
    }
}

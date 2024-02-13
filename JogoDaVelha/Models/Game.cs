namespace JogoDaVelha.Models
{
    public class Game
    {
        public Board Board { get; init; }
        public IReadOnlyCollection<PlayerMarker> PlayerMarker => Array.AsReadOnly<PlayerMarker>([.. _playerMarkers]);
        private readonly PlayerMarker[] _playerMarkers;
        public Marker Next { get; private set; }

        public Game(Board board, PlayerMarker[] playerMarkers, Marker markerToStart = Marker.First)
        {
            Board = board;
            _playerMarkers = playerMarkers;
            Next = markerToStart;

            ThrowIfInvalidGame();
        }

        void ThrowIfInvalidGame()
        {
            ArgumentNullException.ThrowIfNull(Board);
            ArgumentNullException.ThrowIfNull(_playerMarkers);

            if (_playerMarkers.GroupBy(x => x.Player.Guid).Count() != 1)
            {
                throw new Exception("");
            }

            if (_playerMarkers.GroupBy(x => x.Marker).Any(x => x.Count() > 1))
            {
                throw new Exception("only 1 player per marker");
            }
        }
    }
}
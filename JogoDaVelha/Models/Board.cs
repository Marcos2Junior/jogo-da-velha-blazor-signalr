namespace JogoDaVelha.Models
{
    public class Board
    {
        public int Length { get; init; }
        public IReadOnlyCollection<Position> Positions => Array.AsReadOnly<Position>([.. _positions]);
        private readonly List<Position> _positions = [];

        public Board(int length = 3)
        {
            Length = length;
            ThrowIfInvalidBoard();
        }

        void ThrowIfInvalidBoard()
        {
            ArgumentOutOfRangeException.ThrowIfNegative(Length);
        }

        public bool SetPosition(Position position)
        {
            ArgumentNullException.ThrowIfNull(position);

            if (position.Row >= Length || position.Column >= Length || position.Row < 0 || position.Column < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(position));
            }

            if (!_positions.Any(x => x.Column == position.Column && x.Row == position.Row))
            {
                _positions.Add(new Position(position.Row, position.Column, position.Marker));
                return true;
            }

            return false;
        }
    }
}

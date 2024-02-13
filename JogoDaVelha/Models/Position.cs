namespace JogoDaVelha.Models
{
    public class Position(int row, int column, Marker marker)
    {
        public int Row { get; init; } = row;
        public int Column { get; init; } = column;
        public Marker Marker { get; init; } = marker;
    }
}

using JogoDaVelha.Extensions;

namespace JogoDaVelha.Models
{
    public class PlayerMarker
    {
        public Marker Marker { get; init; }
        public Player Player { get; init; }

        public PlayerMarker(Player player, Marker marker)
        {
            Player = player;
            Marker = marker;
            ThrowIfInvalidPlayerMarker();
        }

        void ThrowIfInvalidPlayerMarker()
        {
            ArgumentNullException.ThrowIfNull(Marker);
            ArgumentNullException.ThrowIfNull(Player);
            if (!Enum.IsDefined(typeof(PlayerMarker), Marker))
            {
                throw new ArgumentOutOfRangeException(nameof(Marker));
            }

            var validationPlayer = Player.GetValidationResults();
            if (validationPlayer.Any())
            {
                throw new Exception(string.Join(Environment.NewLine, validationPlayer.Select(x => x.ErrorMessage)));
            }
        }
    }
}
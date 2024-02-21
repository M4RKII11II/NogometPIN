using NogometPIN.Data;

namespace NogometPIN.Services
{
    public class PlayerService
    {
        AppDbContext _context;
        public PlayerService(AppDbContext context)
        {
            _context=context;
        }
        public async Task<List<Player>> GetPlayersAsync()
        {
            var result = _context.Players;
            return await Task.FromResult(result.ToList());
        }
        public async Task<Player> GetPlayerByIdAsync(string id)
        {
            return await _context.Players.FindAsync(id);
        }
        public async Task<Player> InsertPlayerAsync(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            return player;
        }
        public async Task<Player> UpdatePlayerAsync(string id, Player s)
        {
			if (string.IsNullOrEmpty(id))
			{
				throw new ArgumentException("Player ID cannot be null or empty.", nameof(id));
			}
			if (s == null)
			{
				throw new ArgumentNullException(nameof(s), "Player data cannot be null.");
			}
			var player = await _context.Players.FindAsync(id);
            if(player==null)
			{
				throw new InvalidOperationException($"Player with ID {id} not found.");
			}
			player.Name = s.Name;
            player.Club = s.Club;
            player.Position = s.Position;
            _context.Players.Update(player);
            await _context.SaveChangesAsync();
            return player;
        }
        public async Task<Player> DeletePlayerAsync(string id)
        {
            var player=await _context.Players.FindAsync(id);
            if (player == null)
                return null;
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
            return player;
        }
        private bool PlayerExists(string id)
        {
            return _context.Players.Any(e => e.Id == id);
        }
        public async Task<List<Position>> GetPositionsAsync()
        {
            var result=_context.Positions.ToList();
            return await Task.FromResult(result);
        }
    }
}
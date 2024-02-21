namespace NogometPIN.Data
{
    public class Player
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Club {  get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        
    }
}

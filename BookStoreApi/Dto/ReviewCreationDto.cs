namespace BookStoreApi.Dto
{
  public class ReviewCreationDto
  {
    public Guid Book { get; set; }
    public int Score { get; set; }
    public string Content { get; set; }
  }
}

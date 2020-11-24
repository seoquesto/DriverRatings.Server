using System.Collections.Generic;
using System.Linq;

namespace src.DriverRatings.Server.Core.Models
{
  public class PlateDetails : Plate
  {
    private ISet<PlateComment> _comments = new HashSet<PlateComment>();

    public IEnumerable<PlateComment> Comments
    {
      get => this._comments;
      private set => this._comments = new HashSet<PlateComment>(value);
    }

    public decimal Note => (decimal)this._comments.Average(x => x.Note);

    protected PlateDetails()
    {
    }

    public PlateDetails(string identifier, string number) : base(identifier, number)
    {
    }

    public void AddComment(PlateComment comment)
    {
      if (Comments.Any(x => x.CommentId == comment.CommentId))
      {
        return;
      }

      _comments.Add(comment);
    }
  }
}
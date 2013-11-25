using System.Linq;
using Raven.Client.Indexes;

namespace Prognet.ConsoleApp
{
    public class PhotoWithVoteTotalIndex : AbstractIndexCreationTask<PhotoVote, PhotoView>
    {
        public PhotoWithVoteTotalIndex()
        {
            Map = docs => from d in docs
                          select new
                          {
                              PhotoId = d.PhotoId,
                              VoteTotal = d.Delta
                          };
            Reduce = results => from r in results
                                group r by r.PhotoId
                                    into g
                                    select new
                                    {
                                        PhotoId = g.Key,
                                        VoteTotal = g.Sum(p => p.VoteTotal)
                                    };
            // Old skool
            TransformResults = (database, results) =>
                               from r in results
                               let photo = database.Load<Photo>(r.PhotoId)
                               let user = database.Load<User>(photo.UserId)
                               select new
                               {
                                   PhotoId = r.PhotoId,
                                   PhotoTitle = photo.Title,
                                   PhotoUri = photo.Uri,
                                   UserFullName = user.FullName,
                                   VoteTotal = r.VoteTotal
                               };
        }
    }
}
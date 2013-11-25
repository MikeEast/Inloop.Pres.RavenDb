using System.Linq;
using Raven.Client.Indexes;

namespace Prognet.ConsoleApp
{
    internal class VotePerPhotoIndex : AbstractIndexCreationTask<PhotoVote, VoteTotalPerPhoto>
    {
        protected VotePerPhotoIndex()
        {
            Map = docs => 
                from d in docs
                select new
                {
                    PhotoId = d.PhotoId,
                    VoteTotal = 1
                };

            Reduce = results => 
                from r in results
                group r by r.PhotoId into g
                select new
                {
                    PhotoId = g.Key,
                    VoteTotal = g.Sum(p => p.VoteTotal)
                };
        }
    }

    
}
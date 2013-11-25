using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prognet.ConsoleApp
{
    public class User
    {
        public string Id { get; private set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public DateTime LastLogin { get; set; }

        public User(string userName)
        {
            UserName = userName;
        }
    }

    public class Photo
    {
        public string Id { get; private set; }
        public string Title { get; set; }
        public string Uri { get; set; }
        public string UserId { get; set; }
        public List<string> Tags { get; set; }

        public Photo(string userId, string uri)
        {
            UserId = userId;
            Uri = uri;
        }
    }

    public class PhotoVote
    {
        public string PhotoId { get; set; }
        public string UserId { get; set; }
        public int Delta { get; set; }

        public PhotoVote(string photoId, string userId, int delta)
        {
            PhotoId = photoId;
            UserId = userId;
            Delta = delta;
        }
    }

    /////////////////////////////////////////////////////////////////

    public class VoteTotalPerPhoto
    {
        public string PhotoId { get; set; }
        public int VoteTotal { get; set; }
    }

    public class PhotoView
    {
        public string PhotoId { get; set; }
        public string PhotoTitle { get; set; }
        public string PhotoUri { get; set; }
        public string UserFullName { get; set; }
        public int VoteTotal { get; set; }
    }
}








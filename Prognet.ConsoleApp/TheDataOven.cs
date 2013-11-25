using System.Collections.Generic;
using System.Linq;
using Raven.Abstractions.Indexing;
using Raven.Client;
using Raven.Client.Linq;

namespace Prognet.ConsoleApp
{
    public class TheDataOven
    {
        // The Oven
        public static void CreatePhotosAndVotes(IDocumentSession session)
        {
            var user1 = session.Query<User>().FirstOrDefault(u => u.UserName == "Micke");
            if (user1 == null)
            {
                user1 = new User("Micke");
                session.Store(user1);
            }
                
            var photo1 = new Photo(user1.Id, "photo1.jpg") { 
                Title = "A Beautiful Day on the Beach", 
                Tags = new List<string> { "Dog", "Vacation", "Beach" }
            };

            var user2 = session.Query<User>().FirstOrDefault(u => u.UserName == "Martin");
            if (user2 == null)
            {
                user2 = new User("Martin");
                session.Store(user2);
            }

            var photo2 = new Photo(user2.Id, "photo2.jpg") {
                Title = "A Bumblebee in Flight Looking for a Flower", 
                Tags = new List<string> { "Bumblebee", "Countryside", "Flower", "Outdoor" }
            };
            session.Store(photo1);
            session.Store(photo2);

            session.Store(new PhotoVote(photo1.Id, "users/1", 1));
            session.Store(new PhotoVote(photo1.Id, "users/1", 1));
            session.Store(new PhotoVote(photo1.Id, "users/1", 1));
            session.Store(new PhotoVote(photo1.Id, "users/1", 1));
            session.Store(new PhotoVote(photo1.Id, "users/1", 1));
            session.Store(new PhotoVote(photo1.Id, "users/1", 1));
            session.Store(new PhotoVote(photo1.Id, "users/1", 1));
            session.Store(new PhotoVote(photo1.Id, "users/1", -1));
            session.Store(new PhotoVote(photo1.Id, "users/1", -1));
            session.Store(new PhotoVote(photo1.Id, "users/1", -1));

            session.Store(new PhotoVote(photo2.Id, "users/1025", 1));
            session.Store(new PhotoVote(photo2.Id, "users/1025", 1));
            session.Store(new PhotoVote(photo2.Id, "users/1025", 1));
            session.Store(new PhotoVote(photo2.Id, "users/1025", 1));
            session.Store(new PhotoVote(photo2.Id, "users/1025", 1));
            session.Store(new PhotoVote(photo2.Id, "users/1025", 1));
            session.Store(new PhotoVote(photo2.Id, "users/1025", 1));
            session.Store(new PhotoVote(photo2.Id, "users/1025", -1));
            session.Store(new PhotoVote(photo2.Id, "users/1025", -1));
            session.Store(new PhotoVote(photo2.Id, "users/1025", -1));
            session.Store(new PhotoVote(photo2.Id, "users/1025", -1));
        } 
    }
}
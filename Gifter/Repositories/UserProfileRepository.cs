using Gifter.Models;
using Gifter.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Gifter.Repositories
{
    public class UserProfileRepository : BaseRepository, IUserProfileRepository
    {
        public UserProfileRepository(IConfiguration configuration) : base(configuration) { }

        public List<UserProfile> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                SELECT Id, Name, Email, ImageUrl, DateCreated FROM UserProfile
              ORDER BY DateCreated";

                    var reader = cmd.ExecuteReader();

                    var userProfiles = new List<UserProfile>();
                    while (reader.Read())
                    {
                        userProfiles.Add(new UserProfile()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Email = DbUtils.GetString(reader, "Email"),
                            ImageUrl = DbUtils.GetString(reader, "ImageUrl"),

                            DateCreated = DbUtils.GetDateTime(reader, "DateCreated"),


                        });
                    }

                    reader.Close();

                    return userProfiles;
                }
            }
        }

        public UserProfile GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                         SELECT Id, Name, Email, ImageUrl, DateCreated FROM UserProfile
              ORDER BY DateCreated";


                    DbUtils.AddParameter(cmd, "@Id", id);

                    var reader = cmd.ExecuteReader();

                    UserProfile userProfile = new UserProfile();
                    while (reader.Read())
                    {

                        userProfile.Id = DbUtils.GetInt(reader, "Id");
                        userProfile.Name = DbUtils.GetString(reader, "Name");
                        userProfile.Email = DbUtils.GetString(reader, "Email");
                        userProfile.ImageUrl = DbUtils.GetString(reader, "ImageUrl");
                        userProfile.DateCreated = DbUtils.GetDateTime(reader, "DateCreated");



                    }

                    reader.Close();

                    return userProfile;
                }


            }
        }


        public UserProfile GetByIdWithPosts(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                         SELECT up.Id, up.Name, up.Email, up.ImageUrl, up.DateCreated,

                          p.Id AS PostId, p.Title, p.Caption, p.DateCreated AS PostDateCreated,
                       p.ImageUrl AS PostImageUrl, p.UserProfileId,


                        c.Id AS CommentId, c.Message, c.UserProfileId AS CommentUserProfileId, c.PostId AS CommentPostId

                        FROM UserProfile up
                        Left Join Post p ON p.UserProfileId = up.Id
                        Left Join Comment c ON c.PostId = p.Id
                        WHERE @Id = up.Id
              ORDER BY up.DateCreated";


                    DbUtils.AddParameter(cmd, "@Id", id);

                    var reader = cmd.ExecuteReader();

                    UserProfile userProfile = null;
                    Post post = null;
                 
                    while (reader.Read())
                    {
                        if (userProfile == null)
                        {
                            userProfile = new UserProfile();

                            userProfile.Id = DbUtils.GetInt(reader, "Id");
                            userProfile.Name = DbUtils.GetString(reader, "Name");
                            userProfile.Email = DbUtils.GetString(reader, "Email");
                            userProfile.ImageUrl = DbUtils.GetString(reader, "ImageUrl");
                            userProfile.DateCreated = DbUtils.GetDateTime(reader, "DateCreated");
                            userProfile.Posts = new List<Post>();

                            

                        }
                        if (DbUtils.IsNotDbNull(reader, "PostId"))
                        {
                            
                            if(post == null || post != null){
                                post = new Post()
                                {
                                    Id = DbUtils.GetInt(reader, "PostId"),
                                    Title = DbUtils.GetString(reader, "Title"),
                                    Caption = DbUtils.GetString(reader, "Caption"),
                                    DateCreated = DbUtils.GetDateTime(reader, "PostDateCreated"),
                                    ImageUrl = DbUtils.GetString(reader, "PostImageUrl"),
                                    UserProfileId = DbUtils.GetInt(reader, "UserProfileId"),
                                    Comments = new List<Comment>()
                                };

                             

                                userProfile.Posts.Add(post);
                                
                                if (DbUtils.IsNotDbNull(reader, "CommentId"))
                                    
                                {
                                    

                                      
                                            Comment comment = new Comment()
                                            {
                                                Id = DbUtils.GetInt(reader, "CommentId"),
                                                Message = DbUtils.GetString(reader, "Message"),
                                                PostId = DbUtils.GetInt(reader, "CommentId"),
                                                UserProfileId = DbUtils.GetInt(reader, "CommentUserProfileId")
                                            };


                                            post.Comments.Add(comment);
                                       

                                    
                                }
                            };
                           


                        }
                        


                    }

                    reader.Close();

                    return userProfile;
                }


            }
        }
        public void Add(UserProfile userProfile)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO UserProfile (Name, Email, Bio, ImageUrl, DateCreated)
                        OUTPUT INSERTED.ID
                        VALUES (@Name, @Email, @Bio,  @ImageUrl, @DateCreated)";

                    DbUtils.AddParameter(cmd, "@Name", userProfile.Name);
                    DbUtils.AddParameter(cmd, "@Email", userProfile.Email);
                    DbUtils.AddParameter(cmd, "@Bio", null);
                    DbUtils.AddParameter(cmd, "@ImageUrl", userProfile.ImageUrl);
                    DbUtils.AddParameter(cmd, "@DateCreated", userProfile.DateCreated);

                    userProfile.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(UserProfile userProfile)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE UserProfile
                           SET Name = @Name,
                               Email = @Email,
                               Bio = @Bio,
                               ImageUrl = @ImageUrl,
                                DateCreated = @DateCreated
                              
                         WHERE Id = @Id";

                    DbUtils.AddParameter(cmd, "@Name", userProfile.Name);
                    DbUtils.AddParameter(cmd, "@Email", userProfile.Email);
                    DbUtils.AddParameter(cmd, "@Bio", null);
                    DbUtils.AddParameter(cmd, "@ImageUrl", userProfile.ImageUrl);
                    DbUtils.AddParameter(cmd, "@DateCreated", userProfile.DateCreated);

                    DbUtils.AddParameter(cmd, "@Id", userProfile.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM UserProfile WHERE Id = @Id";
                    DbUtils.AddParameter(cmd, "@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

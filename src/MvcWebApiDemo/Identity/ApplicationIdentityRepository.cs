using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Identity
{
    public class ApplicationIdentityRepository : IApplicationIdentityRepository
    {
        private ApplicationIdentityContext _context;
        public ApplicationIdentityRepository(ApplicationIdentityContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteUserProfilePictureAsync(int UserId)
        {
            var UserProfilePicture = await GetUserProfilePictureByIdAsync(UserId);

            if (UserProfilePicture == null)
            {
                return false;
            }
            _context.UserProfilePictures.Remove(UserProfilePicture);
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<UserProfilePicture> GetUserProfilePictureByIdAsync(int UserId)
        {
            return await _context.UserProfilePictures
                                        .Where(v => v.UserId == UserId)
                                        .FirstOrDefaultAsync();
        }

        public async Task<bool> SaveProfilePic(int UserId, string DisplayName, byte[] imageBytes)
        {
            try
            {
                //user for display name
                var user = (from q in _context.Users
                            where q.Id == UserId
                            select q).FirstOrDefault();

                if (user != null)
                {
                    //var userProfile = await _repository.GetUserProfilePictureByIdAsync(UserId);
                    var userProfile = (from p in _context.UserProfilePictures
                                       where p.UserId == UserId
                                       select p).FirstOrDefault();

                    if (userProfile != null)//has previous data update
                    {
                        userProfile.Image = imageBytes;
                    }
                    else
                    {
                        UserProfilePicture UserProfilePicture = new UserProfilePicture { UserId = UserId, Image = imageBytes, ImageType = 0, CreatedOn = DateTime.Now };
                        _context.UserProfilePictures.Add(UserProfilePicture);
                    }

                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
    }
}

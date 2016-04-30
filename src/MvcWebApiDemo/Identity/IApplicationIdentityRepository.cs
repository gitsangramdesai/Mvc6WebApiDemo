using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Identity
{
    public interface IApplicationIdentityRepository
    {
        Task<bool> DeleteUserProfilePictureAsync(int UserId);
        Task<UserProfilePicture> GetUserProfilePictureByIdAsync(int UserId);
        Task<bool> SaveProfilePic(int UserId, string DisplayName, byte[] imageBytes);
    }
}

using Illegible_Cms_V2.Identity.Application.Configurations;
using Illegible_Cms_V2.Identity.Domain.Users;

namespace Illegible_Cms_V2.Identity.Application.Helpers
{
    public static class UserHelper
    {
        public static LockoutConfig LockoutConfig;

        //public static Employee CreateEmployee(CreateEmployeeCommand command) => new Employee
        //{

        //    FirstName = command.FirstName,
        //    LastName = command.LastName,
        //    LatinFirstName = command.LatinFirstName,
        //    LatinLastName = command.LatinLastName,
        //    NationalCode = command.NationalCode,
        //    BirthCertificateNumber = command.BirthCertificateNumber,
        //    Address = command.Address,
        //    PostalCode = command.PostalCode,
        //    WorkAddress = command.WorkAddress,
        //    WorkFax = command.WorkFax,
        //    WorkTelephone = command.WorkTelephone,

        //    User = new User
        //    {
        //        Username = command.Username,
        //        PasswordHash = new PasswordHasher().Hash(command.Password),
        //        Mobile = command.Mobile,
        //        Email = command.Email,
        //        State = UserState.Active,
        //        SecurityStamp = Guid.NewGuid().ToString("N"),
        //        ConcurrencyStamp = Guid.NewGuid().ToString("N"),
        //        CreatedAt = DateTime.UtcNow,
        //        UpdatedAt = DateTime.UtcNow,
        //        CreatorId = command.RequestInfo.UserId,
        //        UpdaterId = command.RequestInfo.UserId,

        //    }

        //};

        public static void Activate(this User user)
        {
            user.State = UserState.Active;
        }

        public static bool CanLogin(this User user) =>
            user.State == UserState.Active &&
            user.UserRoles.Count > 0 &&
            !(user.LockoutEndTime > DateTime.UtcNow);

        public static bool IsLockedOut(this User user) => user.LockoutEndTime > DateTime.UtcNow;

        public static void TryToLockout(this User user)
        {
            user.FailedLoginCount++;
            if (user.FailedLoginCount >= LockoutConfig.FailedLoginLimit)
                user.LockoutEndTime = DateTime.UtcNow.Add(LockoutConfig.Duration);
        }

        public static void ResetLockoutHistory(this User user)
        {
            user.FailedLoginCount = 0;
            user.LockoutEndTime = null;
        }
    }
}

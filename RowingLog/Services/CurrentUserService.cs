using RowingLog.Models;
using RowingLog.Repository.Local;

namespace RowingLog.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private const string CurrentUserId = "currentuser";

        private readonly ILocalRepo<User> repo;

        public CurrentUserService(ILocalRepo<User> repo)
        {
            this.repo = repo;

            InitializeCurrentUser();
        }

        public User CurrentUser { get; private set; }

        public void SetStravaUser(StravaUser stravaUser)
        {
            CurrentUser.StravaUser = stravaUser;

            this.repo.Upsert(this.CurrentUser);

            CurrentUser = this.repo.Get(CurrentUserId);
        }

        private void InitializeCurrentUser()
        {
            CurrentUser = this.repo.Get(CurrentUserId) ?? new User { Id = CurrentUserId };
        }
    }
}

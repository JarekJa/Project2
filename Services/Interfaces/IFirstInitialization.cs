namespace Project2.Services.Interfaces
{
    public interface IFirstInitialization
    {
        public Task InitializeRolesAsync();
        public Task InitializeAdminAsync();
        public Task InitializeBossAsync();
    }
}

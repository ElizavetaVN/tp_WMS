namespace Persistence
{
    public class DbInitializer //используется при старте приложения, проверяет создана ли БД, если нет то, она будет создана на основе контекста
    {
        public static void Initialize(StaffDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}

using Common.Snowflake;

namespace Common.Utilities
{
    public class ObjectId
    {
        private static readonly IdWorker work = new IdWorker(1, 1);
        public static string GenerateNewId()
        {
            return work.NextId().ToString();
        }
    }
}

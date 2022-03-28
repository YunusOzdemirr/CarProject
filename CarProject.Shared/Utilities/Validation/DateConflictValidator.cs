using System;
namespace CarProject.Shared.Utilities.Validation
{
    public static class DateConflictValidator
    {
        public static bool CheckDateConflict(DateTime start, DateTime end, DateTime query)
        {
            if (query.Ticks > start.Ticks && query.Ticks < end.Ticks)
            {
                return true;
            }
            return false;
        }
    }
}

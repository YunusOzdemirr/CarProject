using System;
namespace CarProject.Business.Utilities
{
    public class Messages
    {
        public static class General
        {
            public static string ValidationError()
            {
                return $"Bir veya daha fazla validasyon hatası ile karşılaşıldı";
            }
        }
        public static class NullOrEmpty
        {
            public static string ValidationError()
            {
                return $"Boş ya da atanmamış değer";
            }
        }
        public static class NotFoundArgument
        {
            public static string ValidationError(string name)
            {
                return $"Böyle bir {name} bulunamadı";
            }
        }
    }
}


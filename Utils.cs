using System;

namespace CopyFileContentToClipboard
{
    internal class Utils
    {
        public const long Kilo = 1000;
        public const long Mega = 1000 * 1000;

        public static string PrettyPrint(long byteCount)
        {
            if (byteCount > Kilo)
            {
                if (byteCount > Mega)
                {
                    return String.Format("{0}MB", (byteCount / (double) Mega).ToString("N"));
                }
                else
                {
                    return String.Format("{0}kB", Math.Ceiling(byteCount / (double) Kilo));
                }
            }
            else
            {
                return String.Format("{0} bytes", byteCount.ToString("N"));
            }
        }
    }
}
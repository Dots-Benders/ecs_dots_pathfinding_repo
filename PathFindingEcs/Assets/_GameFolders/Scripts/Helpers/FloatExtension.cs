using Unity.Mathematics;

namespace PathFindingEcs.Helpers
{
    public static class FloatExtensions
    {
        /// <summary> verilen iki float deger arasindaki esitligi kontrol eder </summary>
        public static bool CompareFloat(this float3 p1, float3 p2, float tolerance = 0.1f)
        {
            bool equalsX = math.abs(p1.x - p2.x) < tolerance;
            bool equalsY = math.abs(p1.y - p2.y) < tolerance;
            bool equalsZ = math.abs(p1.z - p2.z) < tolerance;

            return equalsX & equalsY & equalsZ;
        }

        /// <summary> verilen iki float deger arasindaki esitligi kontrol eder </summary>
        public static bool CompareFloat(this float2 p1, float2 p2, float tolerance = 0.1f)
        {
            bool equalsX = math.abs(p1.x - p2.x) < 0.1f;
            bool equalsY = math.abs(p1.y - p2.y) < 0.1f;

            return equalsX & equalsY;
        }

        /// <summary>
        /// Verilen saniye cinsinden degeri, tarihe cevirip string döndürür.
        /// </summary>
        /// <param name="totalSeconds"></param>
        /// <returns></returns>
        public static string ConvertToDate(this float totalSeconds)
        {
            int days = (int)(totalSeconds / (60 * 60 * 24));
            totalSeconds %= (60 * 60 * 24);
            int hours = (int)(totalSeconds / (60 * 60));
            totalSeconds %= (60 * 60);
            int minutes = (int)(totalSeconds / 60);
            int seconds = (int)(totalSeconds % 60);

            string date = string.Empty;

            if (days > 0)
            {
                date += $"{days}d, ";
            }

            if (days > 0 || hours > 0)
            {
                date += $"{hours}h, ";
            }

            if (hours > 0 || minutes > 0)
            {
                date += $"{minutes}m, ";
            }

            date += $"{seconds}s";

            return date;
        }
        
        /// <summary>
        /// Verilen saniye cinsinden degeri, tarihe cevirip string döndürür.
        /// </summary>
        /// <param name="totalSeconds"></param>
        /// <returns></returns>
        public static string ConvertToStaticDate(this float totalSeconds)
        {
            int days = (int)(totalSeconds / (60 * 60 * 24));
            totalSeconds %= (60 * 60 * 24);
            int hours = (int)(totalSeconds / (60 * 60));
            totalSeconds %= (60 * 60);
            int minutes = (int)(totalSeconds / 60);
            int seconds = (int)(totalSeconds % 60);

            string date = string.Empty;

            if (days > 0)
            {
                date += $"{days}d, ";
            }

            if (days > 0 || hours > 0)
            {
                date += $"{hours}h, ";
            }

            if (hours > 0 || minutes > 0)
            {
                date += $"{minutes}m";
            }

            if (seconds > 0)
            {
                if (days > 0 || hours > 0 || minutes > 0)
                {
                    date += $", ";
                }
                date += $"{seconds}s";
            }

            return date;
        }

        // floatin max alabilecegi deger 20! oldugu icin o sekilde elle yazdim
        static readonly float[] Factorial = new float[]{
            1.0f,
            1.0f,
            2.0f,
            6.0f,
            24.0f,
            120.0f,
            720.0f,
            5040.0f,
            40320.0f,
            362880.0f,
            3628800.0f,
            39916800.0f,
            479001600.0f,
            6227020800.0f,
            87178291200.0f,
            1307674368000.0f,
            20922789888000.0f,
            355687428096000.0f,
            6402373705728000.0f,
            121645100408832000.0f,
            2432902008176640000.0f };

        static float Binom(int upper, int lower)
        {
            float a1 = Factorial[upper];
            float a2 = Factorial[lower];
            float a3 = Factorial[upper - lower];

            return a1 / (a2 * a3);
        }

        public static float Bernstein(this float t, int n, int v)
        {
            return Binom(n, v) * math.pow(t, v) * math.pow(1 - t, n - v);
        }

        public static float FloatRemap(this float value, float from1, float to1, float from2, float to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }
    }
}
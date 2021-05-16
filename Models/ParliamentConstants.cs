using System.Collections.Generic;

namespace ParliamentApp.Models
{
    public static class ParliamentConstants
    {
        /// <summary>
        /// The current parliament number
        /// </summary>
        public const int CURRENT_PARLIAMENT_NUMBER = 43;
        /// <summary>
        /// Current session number (2nd session of 43 parliament)
        /// </summary>
        public const int CURRENT_SESSION_NUMBER = 2;
        /// <summary>
        /// Current parliament session identifier (parliament number - session)
        /// </summary>
        public const string CURRENT_PARLIAMENT_SESSION = "43-2";
        /// <summary>
        /// Get list of all sessions available on open parliament
        /// </summary>
        public static IEnumerable<string> Sessions
        {
            get => new string[] {
            "43-2",
            "43-1",
            "42-1",
            "41-2",
            "41-1",
            "40-3",
            "40-2",
            "40-1",
            "39-2",
            "39-1",
            "38-1"
            };
        }
    }
}

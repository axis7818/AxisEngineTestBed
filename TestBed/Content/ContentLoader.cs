using Microsoft.Xna.Framework.Content;

namespace TestBed.Content
{
    /// <summary>
    /// allows for content to be quickly loaded without objects needing to hold a direct reference to the Game's ContentManager
    /// </summary>
    public static class ContentLoader
    {
        /// <summary>
        /// Loads content
        /// </summary>
        public static ContentManager Content;
    }
}

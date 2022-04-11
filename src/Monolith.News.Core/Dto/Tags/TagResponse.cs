namespace Monolith.News.Core.Dto.Tags
{
    public class TagResponse
    {
        /// <summary>
        /// The tag identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of tag.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The background of tag.
        /// </summary>
        public string? BackgroundColor { get; set; }

        /// <summary>
        /// The color of tag.
        /// </summary>
        public string? Color { get; set; }
    }
}

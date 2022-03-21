namespace Querist
{
     /// <summary>
     /// Defines forground colors for different queries and inputs.
     /// </summary>
    public class Theme
    {
         /// <summary>
         /// Forground color of the query.
         /// </summary>
        public ConsoleColor QueryColor { get; set; }
        /// <summary>
        /// Forground color for text inputs.
        /// </summary>
        public ConsoleColor TextInputColor { get; set; }
        /// <summary>
        /// Forground color for integer inputs.
        /// </summary>
        public ConsoleColor IntInputColor { get; set; }
        /// <summary>
        /// Forground color for double inputs.
        /// </summary>
        public ConsoleColor DoubleInputColor { get; set; }
        /// <summary>
        /// Forground color for the current selection in a select input.
        /// </summary>
        public ConsoleColor SelectedOptionColor { get; set; }
        /// <summary>
        /// Forground color for boolean inputs.
        /// </summary>
        public ConsoleColor BooleanOptionColor { get; set; }
        /// <summary>
        /// Forground color for suggestting color for autosuggest input.
        /// </summary>
        public ConsoleColor AutosuggestColor { get; set; }
        /// <summary>
        /// Default, out of the box theme used by inputs.
        /// </summary>
        public static readonly Theme DefaultTheme = new()
        {
            QueryColor = ConsoleColor.Yellow,
            TextInputColor = ConsoleColor.Blue,
            IntInputColor = ConsoleColor.Green,
            DoubleInputColor = ConsoleColor.DarkGreen,
            SelectedOptionColor = ConsoleColor.Magenta,
            BooleanOptionColor = ConsoleColor.Cyan,
            AutosuggestColor = ConsoleColor.DarkBlue,
        };
        /// <summary>
        /// Sets the forground color.
        /// </summary>
        public static void SetColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
        /// <summary>
        /// Writes to the console using the <see cref="QueryColor"/> as the forground color.
        /// </summary>
        public void Write(object value)
        {
            SetColor(this.QueryColor);
            Console.Write(value);
            Console.ResetColor();
        }
        /// <summary>
        /// Writes a line to the console using the <see cref="QueryColor"/> as the forground color.
        /// </summary>
        public void WriteLine(object value)
        {
            SetColor(this.QueryColor);
            Console.WriteLine(value);
            Console.ResetColor();
        }
        /// <summary>
        /// Reads a line from the console and resets the console colors.
        /// </summary>
        public static string? ReadLine()
        {
            var rl = Console.ReadLine();
            Console.ResetColor();
            return rl;
        }
    }
}
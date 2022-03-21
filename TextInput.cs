namespace Querist
{
    public class TextInput : InputBase<string?>
    {
        /// <summary>
        /// Creates a instance of the Text Input.
        /// </summary>
        /// <param name="query">Query string for the Input.</param>
        /// <param name="isNextLineInput">Determines whether the input is asked at the next line of the query. </param>
        /// <param name="theme"><see cref="Theme"/> object to customise foreground colours.</param>
        public TextInput(string query, bool isNextLineInput = false,Theme? theme=null):base(query + "(Text) ", theme)
        {
        }
        public override string? Get()
        {
            if (IsNextLineInput)
            {
                Theme.WriteLine(Query);
            }
            else
            {
                Theme.Write(Query);
            }
            Theme.SetColor(Theme.TextInputColor);
            return Theme.ReadLine();
        }
    }
}
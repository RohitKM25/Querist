namespace Querist
{
    public class IntInput : InputBase<int?>
    {
        /// <summary>
        /// Creates a instance of the Int Input.
        /// </summary>
        /// <param name="query">Query string for the Input.</param>
        /// <param name="isNextLineInput">Determines whether the input is asked at the next line of the query. </param>
        /// <param name="theme"><see cref="Theme"/> object to customise foreground colours.</param>
        public IntInput(string query, bool isNextLineInput = false,Theme? theme=null):base(query + "(Integer) ", theme,isNextLineInput)
        {}
        public override int? Get()
        {
            if (IsNextLineInput)
            {
                Theme.WriteLine(Query);
            }
            else
            {
                Theme.Write(Query);
            }
            
            Theme.SetColor(Theme.IntInputColor);
            try
            {
               return int.Parse(Theme.ReadLine()!);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
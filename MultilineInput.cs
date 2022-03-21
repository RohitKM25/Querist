namespace Querist
{
    public class MultilineInput : InputBase<IEnumerable<string>>
    {
        /// <summary>
        /// Creates a instance of the Multiline Text Input.
        /// </summary>
        /// <param name="query">Query string for the Input.</param>
        /// <param name="theme"><see cref="Theme"/> object to customise foreground colours.</param>
        public MultilineInput(string query,Theme? theme=null):base(query + "(Multiline Text) ", theme, true)
        {}
        public override IEnumerable<string> Get()
        {
            List<string> ret = new();
            Theme.WriteLine(Query);
            while (true)
            {
                Theme.SetColor(Theme.TextInputColor);
                var rl = Theme.ReadLine()!;
                if (rl=="") break;
                else ret.Add(rl);
            }
            return ret;
        }
    }
}
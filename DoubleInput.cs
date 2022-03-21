namespace Querist
{
    public class DoubleInput : InputBase<double?>
    {
        /// <summary>
        /// Creates a instance of the Double Input.
        /// </summary>
        /// <param name="query">Query string for the Input.</param>
        /// <param name="isNextLineInput">Determines whether the input is asked at the next line of the query. </param>
        /// <param name="theme"><see cref="Theme"/> object to customise foreground colours.</param>
        public DoubleInput(
            string query,
            bool isNextLineInput = false,
            Theme? theme=null):base(query + "(Float) ", theme, isNextLineInput)
        {}
        public override double? Get()
        {
            if (IsNextLineInput) Theme.WriteLine(Query);
            else Theme.Write(Query);

            Theme.SetColor(Theme.DoubleInputColor);
            try
            {
                return double.Parse(Theme.ReadLine()!);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
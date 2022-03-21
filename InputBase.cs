namespace Querist
{
    /// <summary>
    /// Base class for inputs.
    /// </summary>
    /// <typeparam name="T">Type the user input should be returned in.</typeparam>
    public class InputBase<T> : IInputBase<T>
    {
        /// <summary>
        /// Initialises The Input Base.
        /// </summary>
        /// <param name="query">Question or Prompt to expect a input.</param>
        /// <param name="isNextLineInput">Determines whether the input is asked at the next line of the query. </param>
        /// <param name="theme">Defines forground colors for different queries and inputs.</param>
        public InputBase(string query, Theme? theme, bool isNextLineInput = false)
        {
            Query = query;
            Theme = theme ?? Theme.DefaultTheme;
            IsNextLineInput = isNextLineInput;
        }
        public string Query { get; set; }
        public bool IsNextLineInput { get; set; }
        public Theme Theme { get; }
        public virtual T? Get()
        {
            throw new NotImplementedException();
        }
    }
}
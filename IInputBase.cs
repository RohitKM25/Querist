namespace Querist
{
     /// <summary>
     /// Interface of the input base.
     /// </summary>
     /// <typeparam name="T">Type of input.</typeparam>
    public interface IInputBase<T>
    {
         /// <summary>
         /// Determines whether the input is on the next line of the query.
         /// </summary>
        bool IsNextLineInput { get; set; }
        /// <summary>
        /// Question or Prompt to expect a input.
        /// </summary>
        string Query { get; set; }
        /// <summary>
        /// Defines forground colors for different queries and inputs.
        /// </summary>
        Theme Theme { get; }
        /// <summary>
        /// Prints the prompt and return user input in type of <typeparamref name="T"/>
        /// </summary>
        /// <returns><typeparamref name="T"/> from user input</returns>
        T? Get();
    }
}
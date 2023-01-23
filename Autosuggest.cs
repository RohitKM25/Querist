namespace Querist
{
     public class AutosuggestInput : InputBase<string>
     {
          /// <summary>
          /// Creates a instance of the Autosuggest Input.
          /// </summary>
          /// <param name="query">Query string for the Input.</param>
          /// <param name="suggestions">List of suggestions to suggest from.</param>
          /// <param name="isNextLineInput">Determines whether the input is asked at the next line of the query. </param>
          /// <param name="theme"><see cref="Theme"/> object to customise foreground colours.</param>
          public AutosuggestInput(
              string query,
              IEnumerable<string> suggestions,
              bool isNextLineInput = false,
              Theme? theme = null) : base(query + "(Text, Use Arrow Keys) ", theme, isNextLineInput)
          {
               Suggestions = suggestions.ToList();
          }
          /// <summary>
          /// List of suggestions to suggest from.
          /// </summary>
          public List<string> Suggestions { get; set; }
          private List<string> _getSuggestions(string inp)
          {
               List<string> suggestions = new();
               foreach (var item in Suggestions) if (item.Length > inp.Length) if (item.StartsWith(inp)) suggestions.Add(item);
               return suggestions;
          }
          private void _clearSpace()
          {
               // The Underlying code is solely the result of my laziness...
               Console.Write("                    ");
               Console.SetCursorPosition(Console.CursorLeft - 20, Console.CursorTop);
          }
          private void _reloadAutosuggest(List<string> suggestions, int currentSuggestionIndex, string val)
          {
               if (suggestions.Count == 0) return;
               else
               {
                    Theme.SetColor(Theme.AutosuggestColor);
                    Console.Write(suggestions[currentSuggestionIndex][(val.Length)..]);
                    Console.SetCursorPosition(Console.CursorLeft - suggestions[currentSuggestionIndex][(val.Length)..].Length, Console.CursorTop);
               }
               Console.ResetColor();
               return;
          }
          public override string? Get()
          {
               if (IsNextLineInput) Theme.WriteLine(Query);
               else Theme.Write(Query);

               string val = "";
               int currentSuggestionIndex = 0;
               List<string> suggestions = new();

               while (true)
               {
                    var rk = Console.ReadKey(false);
                    var valLength = val.Length;
                    switch (rk.Key)
                    {
                         case ConsoleKey.Enter:
                              Console.WriteLine();
                              return val;
                         case ConsoleKey.RightArrow:
                              val += suggestions[currentSuggestionIndex][(val.Length)..];
                              Console.SetCursorPosition(Console.CursorLeft - valLength, Console.CursorTop);
                              Console.Write(val);
                              break;
                         case ConsoleKey.Backspace:
                              _clearSpace();
                              if (val != "")
                              {
                                   val = val[..(val.Length - 1)];
                                   Console.SetCursorPosition(Console.CursorLeft - val.Length, Console.CursorTop);
                                   Console.Write(val + " ");
                                   Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                              }
                              suggestions = _getSuggestions(val);
                              _reloadAutosuggest(suggestions, currentSuggestionIndex, val);
                              break;
                         case ConsoleKey.DownArrow:
                              _clearSpace();
                              if (currentSuggestionIndex + 1 < suggestions.Count) currentSuggestionIndex++;
                              _reloadAutosuggest(suggestions, currentSuggestionIndex, val);
                              break;
                         case ConsoleKey.UpArrow:
                              _clearSpace();
                              if (currentSuggestionIndex - 1 >= 0) currentSuggestionIndex--;
                              _reloadAutosuggest(suggestions, currentSuggestionIndex, val);
                              break;
                         default:
                              _clearSpace();
                              val += rk.KeyChar;
                              suggestions = _getSuggestions(val);
                              currentSuggestionIndex = 0;
                              _reloadAutosuggest(suggestions, currentSuggestionIndex, val);
                              break;
                    }
               }
          }
     }
}
namespace Querist
{
     public class SelectInput : InputBase<string>
     {
          /// <summary>
          /// Creates a instance of the Select Input.
          /// </summary>
          /// <param name="query">Query string for the Input.</param>
          /// <param name="options">Options to choose from</param>
          /// <param name="theme"><see cref="Theme"/> object to customise foreground colours.</param>
          public SelectInput(string query, IEnumerable<string> options, Theme? theme = null) : base(query + "(Select) ", theme)
          {
               Options = options.ToList();
          }
          /// <summary>
          /// Options to choose from
          /// </summary>
          public List<string> Options { get; set; }
          private void _remColor(int pos)
          {
               Console.ResetColor();
               Console.Write("[ ] " + Options[pos]);
               Console.SetCursorPosition(0, Console.CursorTop);
          }
          private void _addColor(int pos)
          {
               Theme.SetColor(Theme.SelectedOptionColor);
               Console.Write("[✓] " + Options[pos]);
               Console.ResetColor();
               Console.SetCursorPosition(0, Console.CursorTop);
          }

          public override string? Get()
          {
               Theme.Write(Query);
               for (int i = 0; i < Options.Count; i++)
               {
                    Console.WriteLine();
                    if (i != Options.Count - 1) Console.Write("[ ] " + Options[i]);
                    else Console.Write("[✓] " + Options[i]);
               }
               Console.SetCursorPosition(0, Console.CursorTop);
               var at = Options.Count - 1;
               _addColor(at);
               while (true)
               {
                    var k = Console.ReadKey(true).Key;
                    if (k == ConsoleKey.Enter) break;
                    else if (k == ConsoleKey.UpArrow)
                    {
                         if (at != 0)
                         {
                              _remColor(at);
                              Console.SetCursorPosition(0, Console.CursorTop - 1);
                              at--;
                              _addColor(at);
                         }
                    }
                    else if (k == ConsoleKey.DownArrow)
                    {
                         if (at != Options.Count - 1)
                         {
                              _remColor(at);
                              Console.SetCursorPosition(0, Console.CursorTop + 1);
                              at++;
                              _addColor(at);
                         }
                    }
                    else continue;
               }
               if (Console.CursorTop + (Options.Count - at) < Console.BufferHeight)
                    Console.SetCursorPosition(0, Console.CursorTop + (Options.Count - at));
               else
               {
                    Console.SetCursorPosition(0, Console.CursorTop + (Options.Count - at - 1));
               }
               return Options[at];
          }
     }
}
namespace Querist
{
     public class BooleanInput : InputBase<bool?>
     {
          /// <summary>
          /// Creates a instance of the Boolean Input.
          /// </summary>
          /// <param name="query">Query string for the Input.</param>
          /// <param name="trueClause"><see langword="true"/> option.</param>
          /// <param name="falseClause"><see langword="false"/> option.</param>
          /// <param name="isNextLineInput">Determines whether the input is asked at the next line of the query. </param>
          /// <param name="theme"><see cref="Theme"/> object to customise foreground colours.</param>
          public BooleanInput(
              string query,
              string trueClause = "Yes",
              string falseClause = "No",
              bool isNextLineInput = false,
              Theme? theme = null) : base(query + $"({trueClause}/{falseClause}) ", theme, isNextLineInput)
          {
               Clauses = (trueClause, falseClause);
          }
          /// <summary>
          /// Options for <see langword="true"/> and <see langword="false"/>
          /// </summary>
          public (string True, string False) Clauses { get; set; }

          /// <summary>
          /// Writes the query and gets either values from <see cref="Clauses"/> 
          /// </summary>
          /// <returns><see langword="true"/> if true clause is entered and <see langword="false"/> is false clause is entered.</returns>
          public override bool? Get()
          {
               if (IsNextLineInput) Theme.WriteLine(Query);
               else Theme.Write(Query);
               Theme.SetColor(Theme.BooleanOptionColor);
               var rl = Theme.ReadLine();
               if (rl == Clauses.True) return true;
               else return false;
          }
     }
}
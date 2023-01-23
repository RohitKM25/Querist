# Querist

A library for user-prompts in dotnet.

# Installation

```csharp
using Querist;
```

# Usage

- ## Text Input

### Parameters:

|       Name        |   Type   |                             Description                              | Optional |    Default Value     |
| :---------------: | :------: | :------------------------------------------------------------------: | :------: | :------------------: |
|      `query`      | `string` |               Question or prompt the user replies to.                |    ❌    |          -           |
| `isNextLineInput` |  `bool`  | Determines whether the input is asked on the next line of the query. |    ✅    |       `false`        |
|      `theme`      | `Theme`  |                      Defines forground colors.                       |    ✅    | `Theme.DefaultTheme` |

```csharp
var input = new TextInput(query, isNextLineInput, theme);
var answer = input.Get(); // returns a Nullable string
```

- ## Boolean Input

### Parameters:

|       Name        |   Type   |                             Description                              | Optional |    Default Value     |
| :---------------: | :------: | :------------------------------------------------------------------: | :------: | :------------------: |
|      `query`      | `string` |               Question or prompt the user replies to.                |    ❌    |          -           |
|   `trueClause`    | `string` |                           True statement.                            |    ✅    |       `"Yes"`        |
|   `falseClause`   | `string` |                           False statement.                           |    ✅    |        `"No"`        |
| `isNextLineInput` |  `bool`  | Determines whether the input is asked on the next line of the query. |    ✅    |       `false`        |
|      `theme`      | `Theme`  |                      Defines forground colors.                       |    ✅    | `Theme.DefaultTheme` |

```csharp
var input = new BooleanInput(query, trueClause, falseClause, isNextLineInput, theme);
var answer = input.Get(); // returns a Nullable bool
```

- ## Int Input

### Parameters:

|       Name        |   Type   |                             Description                              | Optional |    Default Value     |
| :---------------: | :------: | :------------------------------------------------------------------: | :------: | :------------------: |
|      `query`      | `string` |               Question or prompt the user replies to.                |    ❌    |          -           |
| `isNextLineInput` |  `bool`  | Determines whether the input is asked on the next line of the query. |    ✅    |       `false`        |
|      `theme`      | `Theme`  |                      Defines forground colors.                       |    ✅    | `Theme.DefaultTheme` |

```csharp
var input = new IntInput(query, isNextLineInput, theme);
var answer = input.Get(); // returns a Nullable int
```

- ## Double Input

### Parameters:

|       Name        |   Type   |                             Description                              | Optional |    Default Value     |
| :---------------: | :------: | :------------------------------------------------------------------: | :------: | :------------------: |
|      `query`      | `string` |               Question or prompt the user replies to.                |    ❌    |          -           |
| `isNextLineInput` |  `bool`  | Determines whether the input is asked on the next line of the query. |    ✅    |       `false`        |
|      `theme`      | `Theme`  |                      Defines forground colors.                       |    ✅    | `Theme.DefaultTheme` |

```csharp
var input = new DoubleInput(query, isNextLineInput, theme);
var answer = input.Get(); // returns a Nullable double
```

- ## Multiline Input

### Parameters:

|  Name   |   Type   |               Description               | Optional |    Default Value     |
| :-----: | :------: | :-------------------------------------: | :------: | :------------------: |
| `query` | `string` | Question or prompt the user replies to. |    ❌    |          -           |
| `theme` | `Theme`  |        Defines forground colors.        |    ✅    | `Theme.DefaultTheme` |

```csharp
var input = new MultilineInput(query, theme);
var answer = input.Get(); // returns a IEnumerable<string>
```

- ## Select Input

### Parameters:

|   Name    |         Type          |               Description               | Optional |    Default Value     |
| :-------: | :-------------------: | :-------------------------------------: | :------: | :------------------: |
|  `query`  |       `string`        | Question or prompt the user replies to. |    ❌    |          -           |
| `options` | `IEnumerable<string>` |  Options the user will choose between.  |    ❌    |          -           |
|  `theme`  |        `Theme`        |        Defines forground colors.        |    ✅    | `Theme.DefaultTheme` |

```csharp
var input = new SelectInput(query, isNextLineInput, theme);
var answer = input.Get(); // returns a Nullable string
```

- ## Autosuggest Input

### Parameters:

|       Name        |         Type          |                             Description                              | Optional |    Default Value     |
| :---------------: | :-------------------: | :------------------------------------------------------------------: | :------: | :------------------: |
|      `query`      |       `string`        |               Question or prompt the user replies to.                |    ❌    |          -           |
|   `suggestions`   | `IEnumerable<string>` |                 List of suggestions to suggest from                  |    ❌    |          -           |
| `isNextLineInput` |        `bool`         | Determines whether the input is asked on the next line of the query. |    ✅    |       `false`        |
|      `theme`      |        `Theme`        |                       Defines forground colors                       |    ✅    | `Theme.DefaultTheme` |

```csharp
var input = new AutosuggestInput(query, suggestions, isNextLineInput, theme);
var answer = input.Get(); // returns a Nullable string
```

# Theming

|      Property       |                        Description                         | Default Value (In `Theme.DefaultTheme`) |
| :-----------------: | :--------------------------------------------------------: | :-------------------------------------: |
|     QueryColor      |              Forground Color for the prompt.               |          `ConsoleColor.Yellow`          |
|   TextInputColor    |              Forground Color for text input.               |           `ConsoleColor.Blue`           |
|    IntInputColor    |            Forground Color for integer inputs.             |          `ConsoleColor.Green`           |
|  DoubleInputColor   |             Forground Color for double inputs.             |        `ConsoleColor.DarkGreen`         |
| SelectedOptionColor | Forground Color for the selected option in a select input. |         `ConsoleColor.Magenta`          |
| BooleanOptionColor  |           Forground Color for true/false inputs.           |           `ConsoleColor.Cyan`           |
|  AutosuggestColor   | Forground Color for suggestion color in Autosuggest input. |         `ConsoleColor.DarkBlue`         |

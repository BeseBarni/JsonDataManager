# JsonDataManager
Sources:
https://stackoverflow.com/questions/16921652/how-to-write-a-json-file-in-c
https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializer?source=recommendations&view=net-7.0
https://stackoverflow.com/questions/64797090/c-sharp-blazor-countdown-timer

# C# conventions, best practices

# Naming conventions
- Properties, Method names, Class names, enums
  - PascalCase
- Interfaces
  - IPascalCase prefixed with "I"

- public fields, temp variables
  - camelCase
- private backing-fields
  - \_camelCase prefixed with "\_"
- const fields, enum members
  - LIKE_THIS
  
 ```
public class RandomClassName : IRandomInterfaceName
{
  private const string RANDOM_CONST_VALUE = "asd";
  
  private int _backingField;
  public int publicField;
  public int RandomProperty {get; private set}
  
  private async Task RandomMethodAsync()
  {
    throw new NotImplementedException();
  }
  public void RandomMethod()
  {
    throw new NotImplementedException();
  }
}
```

# File names should be the same as class names
# No file should contain more than one class

# Use of principles, object oriented programming and design patterns
- SOLID
- KISS
- DRY
- 23 design patterns, Gang of four
- MVVM
- MVC
- 3 layer architecture



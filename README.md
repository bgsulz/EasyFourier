WIP!

# EasyFourier
Ultra-simplified, Unity-ready FFT.

## Quick start guide

```
using System;
using System.Collections.Generic;
using EasyFourier;

static class Program
{
    static void Main(string[] args)
    {
        var signalFreq = 64;
        var listOfValues = new List<float>(){0, 1, 4, 5, 7, 5, 3, -2, -10, -13, -5, -2};
        
        var listOfFrequencyBins = listOfValues.ToFrequencyDomain(signalFreq);
        
        Console.WriteLine(listOfFrequencyBins[0]);
    } 
}
```

### How do I download it?
1. Click the green "Code" button to the upper left of the project files.
2. Click "Download ZIP." A .zip file will download.
3. Unzip the .zip file and store the resulting folder wherever you like.

### How do I import it into a C# project?
This step depends on your IDE.
[Visual Studio Instructions](https://docs.microsoft.com/en-us/visualstudio/ide/managing-references-in-a-project?view=vs-2019)
[Rider Instructions](https://www.jetbrains.com/help/rider/Extending_Your_Solution.html)

### How do I import it into a Unity project?
Simply drag the folder into the Unity Project pane.

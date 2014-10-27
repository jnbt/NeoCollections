# NeoCollections: A class library for AOT-safe collection for `Unity3D`

NeoCollections is a simple class library which allows AOT-safe iterations in [Unity3D](http://unity3d.com). This may sound strange as
[Mono](http://www.mono-project.com) / `C#` supports standard collection classes and the famous `foreach` loop, but
these feature sometime break on iOS. (Further information about this can be found [here](http://forum.unity3d.com/threads/system-string-doesnt-implement-interface-system-collections-ienumerator-crash.168019/)
and [here](http://www.makegamessa.com/discussion/1493/its-official-foreach-is-bad-in-unity/p1)).

## Installation

If you don't have access to [Microsoft VisualStudio](http://msdn.microsoft.com/de-de/vstudio) you can just use Unity3D and its compiler.
Or use your VisualStudio installation in combination with [Visual Studio Tools for Unity](http://unityvs.com) to compile a DLL-file, which
can be included into your project.

### Using Unity3D

* Clone the repository
* Copy the files from `Assets\NeoCollections` into your project

### Using VisualStudio

* Clone the repository
* Open the folder as a Unity3D project
* Install the *free* [Unity Testing Tools](https://www.assetstore.unity3d.com/#/content/13802) from the AssetStore
* Install the *free* [Visual Studio Tools for Unity](http://unityvs.com) and import its Unity-package
* Open `UnityVS.NeoCollections.sln`
* [Build a DLL-File](http://forum.unity3d.com/threads/video-tutorial-how-to-use-visual-studio-for-all-your-unity-development.120327)
* Import the DLL into your Unity3D project

## Usage

### Array Extensions

For convenience the default Array classes are extended to directly iterate over them:

```csharp
var someStrings = new string[]{"Here", "are", "some", "strings"};

// Without NeoCollections
foreach(var s in someStrings){
  UnityEngine.Debug.Log(s);
}

// With NeoCollections
someStrings.ForEach(s => UnityEngine.Debug.Log(s));

// or even shorter as you can provide the called function
// as a reference
someStrings.ForEach(UnityEngine.Debug.Log);
```

### Standard collection classes

The library contains improved subclasses of the most common standard generic collection classes:
* Dictionary
* List
* NameValueCollection
* Queue
* Set
* Stack

```csharp
// Without NeoCollections
using System.Collections.Generic;

var someStrings = new List<string>(){"Here", "are", "some", "strings"};

foreach(var s in someStrings){
  UnityEngine.Debug.Log(s);
}

// With NeoCollections
using Neo.Collections;

var someStrings = new List<string>(){"Here", "are", "some", "strings"};

someStrings.ForEach(s => UnityEngine.Debug.Log(s));
```

## Testing

You can run the tests using the offical [Unity Testing Tools](https://www.assetstore.unity3d.com/#/content/13802). Just install the Unity package and use the [Unit Test Runner](http://www.tallior.com/introduction-to-unity-test-tools/).

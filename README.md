# NeoCollections: A class library for (AOT-safe) collections for `Unity3D`

---

**03/25/2015:** Unity now supports the new IL2CPP compiler for iOS the bug regarding the AOT compilation of generic interfaces went away. Just update NeoCollections to get rid of the overhead introduced to circumvent the AOT-bug.

---

NeoCollections is a legacy class library which allowed AOT-safe iterations in [Unity3D](http://unity3d.com). This may sound strange as
[Mono](http://www.mono-project.com) / `C#` supports standard collection classes and the famous `foreach` loop, but
these feature sometime break on iOS. (Further information about this can be found [here](http://forum.unity3d.com/threads/system-string-doesnt-implement-interface-system-collections-ienumerator-crash.168019/)
and [here](http://www.makegamessa.com/discussion/1493/its-official-foreach-is-bad-in-unity/p1)).

## Installation

You can either use to copy the source files of this project into your Unity3D project or use Visual Studio to compile a DLL-file to be included in your project.

### Using Unity3D

* Clone the repository
* Copy the files from `Assets\NeoCollections` into your project
  * This folder also includes an Assembly definition file

### Using VisualStudio

* Clone the repository
* Open the folder as a Unity3D project
* Build the solution using "Build -> Build NeoNetwork"
* Import the DLL (`obj/Release/NeoCollections.dll`) into your Unity3D project

Hint: Unity currently always reset the LangVersion to "7.3" which isn't supported by Visual Studio. Therefor you need to manually
set / revert the `LangVersion` to `6` in `NeoCollections.csproj`:

    <LangVersion>6</LangVersion>


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

Use Unity's embedded Test Runner via `Window -> General -> Test Runner`.


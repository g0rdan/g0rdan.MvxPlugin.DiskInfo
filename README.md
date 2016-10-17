# g0rdan.MvxPlugin.DiskInfo

We have two methods for getting information about your storage space:
###GetTotalSpace() and GetFreeSpace()

For example, you can initialize plugin and call method like this:

```csharp
var totalSpace = Mvx.Resolve<IDiskInfoPlugin> ().GetTotalSpace();
```

Each of methods have a few parameters like:
- StorageType - Inner storage or SD
- MemorySizeType - bytes, Kb, Mb or Gb
- digits - how many digits you want after comma

For example, code like this:

```csharp
var totalSpace = Mvx.Resolve<IDiskInfoPlugin> ().GetTotalSpace(StorageType.Inner, MemorySizeType.GBytes, 2);
```

get total space from inner storage in gygabytes up to 2 digits.

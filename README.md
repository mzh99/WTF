**WTF** is a C# WinForms Program to search and process files and folders with custom C# scripting/processing.
The program can also be used in automated tasks by passing command-line parameters.

Written for .Net Framework 4.8.

**Use Cases**: Advanced file/folder filtering, renaming, copying, processing that cannot be achieved with Windows/DOS commands.

Yes, Powershell is also an option, but for C# developers, this is likely a much easier option.

Some examples:
* Produce a list of files that have an extension of .jpg, .jpeg, .gif, .tiff, .tif that are older than 18 months.
* Produce a list of files with attributes hidden or system and larger than 100MB
* Collect a list of files that match filter "Img*.jpg" and produce a rename batch file using the Creation date in YYYYMMDD_HHMMSS.jpg format.

**How it works:**
During the file/folder search, each object is passed to your C# scripting code through global variables. The variables that are available:

* **FileInfo**: a FileInfo type for files. See: [https://learn.microsoft.com/en-us/dotnet/api/system.io.fileinfo](https://learn.microsoft.com/en-us/dotnet/api/system.io.fileinfo)
* **FolderInfo**: a DirectoryInfo type for folders. See: [https://learn.microsoft.com/en-us/dotnet/api/system.io.directoryinfo](https://learn.microsoft.com/en-us/dotnet/api/system.io.directoryinfo)
* **OutputSB**: a StringBuilder type object for manipulating the output file. The contents of this will be written to your output file at the end of processing. You can utilize this for your own purposes. You can use the script to create other DOS commands such as "copy," "rename," "move," "del," etc.
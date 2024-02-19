using OCSS.Util.DirSearch;
using OCSS.Util;
using System.IO;

namespace WTF {

   public class SearchProcessor {

      public RunParms RunParms { get; private set; }

      private readonly DirSearch dirSearch;
      private readonly SearchDef searchDefinition;
      private GlobalVars globalVars;

      public SearchProcessor(RunParms runParms) {
         RunParms = runParms;
         searchDefinition = new SearchDef(runParms.StartFolder, runParms.SearchMask, runParms.ProcessSubFolders, AttrSearchType.AnyMatch, AttributeHelper.AllAttributes);
         dirSearch = new DirSearch(searchDefinition);
      }

      public void Search() {
         // initialize our global var class
         globalVars = new GlobalVars();
         // setup our own delegates for calling compiled code
         dirSearch.OnFileMatch += OnFileMatch;
         dirSearch.OnFolderMatch += OnFolderMatch;
         dirSearch.OnFolderFilter += MyCustomFolderFilter;
         dirSearch.Execute();
         // remove delegates
         dirSearch.OnFolderFilter -= MyCustomFolderFilter;
         dirSearch.OnFileMatch -= OnFileMatch;
         dirSearch.OnFolderMatch -= OnFolderMatch;

         // Console.WriteLine($"Output length: {globalVars.OutputSB.Length}");
         File.WriteAllText(RunParms.OutputFilename, globalVars.OutputSB.ToString());
      }

      private void MyCustomFolderFilter(DirectoryInfo oneFolder, ref bool skip, ref bool skipChildFolders) {
         // set skip to true to skip the current folder
         // set skipChildFolders to true to skip all child folders
      }

      private bool OnFileMatch(FileInfo fileInfo) {
         if (RunParms.OnFileScript.HasCode) {
            // assign file data to globals so caller can use it
            globalVars.FileInfo = fileInfo;
            return RunParms.OnFileScript.Execute(globalVars);
         }
         return false;  // do not cancel if no OnFile processing
      }

      private bool OnFolderMatch(DirectoryInfo folderData) {
         if (RunParms.OnFolderScript.HasCode) {
            // assign folder data to globals so caller can use it
            globalVars.FolderInfo = folderData;
            // caller will tell us to cancel or not
            return RunParms.OnFolderScript.Execute(globalVars);
         }
         return false;  // do not cancel if no OnFolder processing
      }

   }

}
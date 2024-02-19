using System.Collections.Generic;

namespace WTF {
   
   public static class WTFErrors {

      public static readonly int Err_NoStartFolder = 1;
      public static readonly int Err_InvalidStartFolder = 2;
      public static readonly int Err_NoSearchMask = 3;
      public static readonly int Err_NoOutputFile = 4;
      public static readonly int Err_InvalidOutputPath = 10;
      public static readonly int Err_InvalidFileOnFile = 11;
      public static readonly int Err_InvalidFileOnFolder = 12;
      public static readonly int Err_CompileOnFile = 13;
      public static readonly int Err_CompileOnFolder = 14;
      public static readonly int Err_OnFileOrFolderRequired = 15;

      public static readonly Dictionary<int, string> ErrorLookupEN = new Dictionary<int, string>() {
         { Err_NoStartFolder, "No folder name specified." },
         { Err_InvalidStartFolder, "Invalid folder name; folder must exist on disk." },
         { Err_NoSearchMask, "No search mask specified." },
         { Err_NoOutputFile, "No output file specified." },
         { Err_InvalidOutputPath, "Invalid output path." },
         { Err_InvalidFileOnFile, "Invalid OnFile code file name." },
         { Err_InvalidFileOnFolder, "Invalid OnFolder code file name." },
         { Err_CompileOnFile, "Failed compile of OnFile code." },
         { Err_CompileOnFolder, "Failed compile of OnFolder code." },
         { Err_OnFileOrFolderRequired, "OnFile or OnFolder code required." },
   };

      public static string GetErrorMessageEN(int errCode) {
         return ErrorLookupEN.TryGetValue(errCode, out string errMsg) ? $"(Error: {errCode}) {errMsg}" : $"Unclassified error code: {errCode}";
      }

      public static IEnumerable<string> GetErrorMessagesEN(IEnumerable<int> errCodes) {
         foreach (var errCode in errCodes) {
            yield return GetErrorMessageEN(errCode);
         }

      }

   }

}

using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Text;
using System.Text.Json.Serialization;

namespace WTF {

   public class RunParms {
      public string StartFolder { get; set; }
      public string SearchMask { get; set; }
      public string OutputFilename { get; set; }
      public bool ProcessSubFolders { get; set; }
      public string OnFileCodeLoc { get; set; }
      public string OnFolderCodeLoc { get; set; }

      [JsonIgnore]
      public string FileCodeTxt { get; private set; }
      [JsonIgnore]
      public string FolderCodeTxt { get; private set; }
      [JsonIgnore]
      public string LastException { get; private set; }
      [JsonIgnore]
      public ScriptPrep<bool> OnFileScript { get; private set; }
      [JsonIgnore]
      public ScriptPrep<bool> OnFolderScript { get; private set; }

      /// <summary>Flag whether either code snipped has compiler errors</summary>
      /// <remarks>Surface compiler errors from ScriptPrep items</remarks>
      public bool HasCompileErrors { get { return (OnFolderScript == null || OnFileScript == null) ? false : (OnFileScript.HasCompileErrors || OnFolderScript.HasCompileErrors); } }
      /// <summary>Get compiler errors from code</summary>
      /// <remarks>Surface compiler errors from ScriptPrep items</remarks>
      public string CompileErrors { get { return GetCompileErrors(); } }

      public RunParms() {
         StartFolder = string.Empty;
         SearchMask = "*.*";
         OutputFilename = string.Empty;
         ProcessSubFolders = false;
         OnFileCodeLoc = string.Empty;
         OnFolderCodeLoc = string.Empty;
         FileCodeTxt = string.Empty;
         FolderCodeTxt = string.Empty;
         LastException = string.Empty;
         OnFileScript = null;
         OnFolderScript = null;
      }

      /// <summary>Get compiler errors from code</summary>
      public string GetCompileErrors() {
         if (HasCompileErrors == false)
            return string.Empty;
         StringBuilder sb = new StringBuilder();
         if (OnFileScript.HasCompileErrors)
            sb.AppendLine($"OnFile Compile Errors: {OnFileScript.CompileErrors}");
         if (OnFolderScript.HasCompileErrors)
            sb.AppendLine($"OnFolder Compile Errors: {OnFolderScript.CompileErrors}");
         return sb.ToString();
      }

      public IEnumerable<int> GetValidationErrors() {
         FileCodeTxt = string.Empty;
         FolderCodeTxt = string.Empty;
         // check start folder
         if (string.IsNullOrEmpty(StartFolder)) {
            yield return WTFErrors.Err_NoStartFolder;
            // return immediately for this error
            yield break;   
         }
         if (Directory.Exists(StartFolder) == false)
            yield return WTFErrors.Err_InvalidStartFolder;
         
         // check output folder
         if (string.IsNullOrEmpty(OutputFilename)) {
            yield return WTFErrors.Err_NoOutputFile;
            // return immediately for this error
            yield break;
         }
         if (Directory.Exists(Path.GetDirectoryName(OutputFilename)) == false)
            yield return WTFErrors.Err_InvalidOutputPath;
         
         // check search mask
         if (string.IsNullOrEmpty(SearchMask))
            yield return WTFErrors.Err_NoSearchMask;
         
         // validate file names of code snippets
         if (string.IsNullOrEmpty(OnFileCodeLoc) && string.IsNullOrEmpty(OnFolderCodeLoc)) {
            yield return WTFErrors.Err_OnFileOrFolderRequired;
            // return immediately for this error
            yield break;
         }
         if (IsValidFilePath(OnFileCodeLoc)) {
            int err = TryLoadCodeFile(OnFileCodeLoc, WTFErrors.Err_InvalidFileOnFile, out string code);
            FileCodeTxt = code;
            if (err != 0)
               yield return err;
         }
         else {
            yield return WTFErrors.Err_InvalidFileOnFile;
         }
         if (IsValidFilePath(OnFolderCodeLoc)) {
            int err = TryLoadCodeFile(OnFolderCodeLoc, WTFErrors.Err_InvalidStartFolder, out string code);
            FolderCodeTxt = code;
            if (err != 0)
               yield return err;
         }
         else {
            yield return WTFErrors.Err_InvalidFileOnFolder;
         }
         OnFileScript = new ScriptPrep<bool>(FileCodeTxt);
         if (OnFileScript.HasCompileErrors)
            yield return WTFErrors.Err_CompileOnFile;
         OnFolderScript = new ScriptPrep<bool>(FolderCodeTxt);
         if (OnFolderScript.HasCompileErrors)
            yield return WTFErrors.Err_CompileOnFolder;
      }
      /// <summary>Validates file path</summary>
      /// <param name="filename">file name</param>
      /// <returns>True if empty or null path. Otherwise, a flag whether file exists on disk</returns>
      private bool IsValidFilePath(string filename) {
         return string.IsNullOrEmpty(filename) ? true : File.Exists(filename);
      }

      private int TryLoadCodeFile(string filename, int errOnFail, out string code) {
         code = string.Empty;
         if (string.IsNullOrEmpty(filename))
            return 0;   // no error as nothing to load
         try {
            code = File.ReadAllText(filename);
            return 0;   // no error
         }
         catch (IOException e) {
            LastException = e.Message;
            return errOnFail;
         }
         catch (UnauthorizedAccessException e) {
            LastException = e.Message;
            return errOnFail;
         }
         catch (NotSupportedException e) {
            LastException = e.Message;
            return errOnFail;
         }
         catch (SecurityException e) {
            LastException = e.Message;
            return errOnFail;
         }
      }


   }

}

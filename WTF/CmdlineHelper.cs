using OCSS.Util.CmdLine;
using System.Text;

namespace WTF {

   public class CmdlineHelper {
      // required flags
      public static readonly string CmdLineParm_StartFolder = "a";
      public static readonly string CmdLineParm_SearchMask = "m";
      public static readonly string CmdLineParm_OutputFile = "o";
      
      // optional flags
      public static readonly string CmdLineParm_ProcessSubFolders = "s";
      public static readonly string CmdLineParm_FileCodeLoc = "f";
      public static readonly string CmdLineParm_FolderCodeLoc = "d";

      public static readonly string TypicalFlagPrefix = @"\";

      public bool RunViaCommandLine { get; private set; }
      public bool AllReqParmsPresent { get; private set; }
      // Return package is only non-null when RunViaCommandLine=true
      public RunParms ReturnPackage { get; private set; }
      public CmdLine CmdLineParser { get; private set; }

      public CmdlineHelper(string[] args) {
         ReturnPackage = null;
         CmdLineParser = null;
         AllReqParmsPresent = false;
         RunViaCommandLine = args.Length > 1;
         // if command line parms, process them
         if (RunViaCommandLine) {
            CmdFlag[] flags = {
               // required parms
               new CmdFlag(CmdLineParm_StartFolder, true),
               new CmdFlag(CmdLineParm_SearchMask, true),
               new CmdFlag(CmdLineParm_OutputFile, true),
               new CmdFlag(CmdLineParm_ProcessSubFolders, false),
               new CmdFlag(CmdLineParm_FileCodeLoc, false),
               new CmdFlag(CmdLineParm_FolderCodeLoc, false)
            };
            CmdLineParser = new CmdLine(flags);
            AllReqParmsPresent = CmdLineParser.ProcessCmdLine(args);
            ReturnPackage = new RunParms() {
               StartFolder = GetParmOrDefault(CmdLineParm_StartFolder, string.Empty),
               SearchMask = GetParmOrDefault(CmdLineParm_SearchMask, string.Empty),
               OutputFilename = GetParmOrDefault(CmdLineParm_OutputFile, string.Empty),
               ProcessSubFolders = CmdLineParser.ParmExists(CmdLineParm_ProcessSubFolders),
               OnFileCodeLoc = GetParmOrDefault(CmdLineParm_FileCodeLoc, string.Empty),
               OnFolderCodeLoc = GetParmOrDefault(CmdLineParm_FolderCodeLoc, string.Empty)
            };
         }

      }

      private string GetParmOrDefault(string flag, string defaultVal) {
         return CmdLineParser.ParmExists(flag) ? CmdLineParser.GetParm(flag) : defaultVal;
      }

      public static string ConstructCommandLineString(RunParms parms, string prefix = @"/") {
         StringBuilder sb = new StringBuilder();
         // start with required flags
         string quote = "\"";
         sb.Append(quote);
         sb.Append(prefix);
         sb.Append(CmdLineParm_StartFolder);
         sb.Append(parms.StartFolder);
         sb.Append(quote);
         sb.Append(" ");

         sb.Append(quote);
         sb.Append(prefix);
         sb.Append(CmdLineParm_SearchMask);
         sb.Append(parms.SearchMask);
         sb.Append(quote);
         sb.Append(" ");

         sb.Append(quote);
         sb.Append(prefix);
         sb.Append(CmdLineParm_OutputFile);
         sb.Append(parms.OutputFilename);
         sb.Append(quote);
         sb.Append(" ");

         // add optional flags
         if (parms.ProcessSubFolders) {
            sb.Append(prefix);
            sb.Append(CmdLineParm_ProcessSubFolders);
            sb.Append(" ");
         }
         if (parms.OnFileCodeLoc != string.Empty) {
            sb.Append(quote);
            sb.Append(prefix);
            sb.Append(CmdLineParm_FileCodeLoc);
            sb.Append(parms.OnFileCodeLoc);
            sb.Append(quote);
            sb.Append(" ");
         }
         if (parms.OnFolderCodeLoc != string.Empty) {
            sb.Append(quote);
            sb.Append(prefix);
            sb.Append(CmdLineParm_FolderCodeLoc);
            sb.Append(parms.OnFolderCodeLoc);
            sb.Append(quote);
            sb.Append(" ");
         }

         return sb.ToString().TrimEnd();
      }

   }

}

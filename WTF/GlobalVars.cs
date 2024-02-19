using System.IO;
using System.Text;

namespace WTF {

   /// <summary>Global vars for passing into dynamic run-time scripts</summary>
   public class GlobalVars {
      public FileInfo FileInfo { get; set; }
      public DirectoryInfo FolderInfo { get; set; }
      public StringBuilder OutputSB { get; private set; }

      public GlobalVars() { 
         OutputSB = new StringBuilder();
      }

   }

}

using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO.Compression;

namespace UiPath.Activities.Zip
{
    public class UnZip : CodeActivity
    {
        [Category("Input")]
        [RequiredArgument]
        public InArgument<string> ZipPath { get; set; }

        [Category("Input")]
        [RequiredArgument]
        public InArgument<string> OutputFolderPath { get; set; }

        [Category("Output")]
        [RequiredArgument]
        public OutArgument<bool> Result { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string zipPath = ZipPath.Get(context);
            string outputFolderPath = OutputFolderPath.Get(context);
            bool result;

            try
            {
                ZipFile.ExtractToDirectory(zipPath, outputFolderPath);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            Result.Set(context, result);
        }
    }

}

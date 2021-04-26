using SwiftGenerator.Authentication;
using SwiftGenerator.Utility;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace SwiftGenerator
{
    internal class ReaderAndWriter
    {
        private readonly PaymentBody payment = new PaymentBody();
        private readonly DateFormat dateFormat = new DateFormat();
        private readonly FileNaming naming = new FileNaming();
        private string titleDate;
        private string executionDate;
        private string fileName;

        public string ReadFile(string ccy)
        {
            string template;
            string resourceName;
            var exeAssembly = Assembly.GetExecutingAssembly();

            {
                if (ccy.Equals("EUR"))
                {
                    template = "Resources.swiftTemplateEUR.txt";
                }
                else
                {
                    template = "Resources.swiftTemplateOther.txt";
                }

                resourceName = exeAssembly.GetManifestResourceNames().Single(str => str.EndsWith(template));

                try
                {
                    return new StreamReader(exeAssembly.GetManifestResourceStream(resourceName)).ReadToEnd();
                }
                catch (Exception e)
                {
                    Debug.WriteLine("<<< catch : " + e.ToString());
                }
            }
            return null;
        }

        public void WriteFile(string env, string bic, string date, string name, string account, string amount, string ccy, int count, Boolean moreThanOnce)
        {
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "Output");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                titleDate = dateFormat.GetNewDateFormat(date, "MM-dd");
                executionDate = dateFormat.GetNewDateFormat(date, "yyMMdd");

                fileName = env + "-TGT2-MT103-" + titleDate + "T" + DateTime.Now.ToString("HH.mm.ss") + naming.GetName(count, moreThanOnce);

                File.WriteAllText(path + "/" + fileName + ".so", payment.Create(bic, executionDate, name, account, amount, ccy));
            }
            catch (Exception e)
            {
                Debug.WriteLine("<<< catch : " + e.ToString());
            }
        }

        public void WriteFileToNetwork(string env, string bic, string date, string name, string account, string amount, string ccy, int count, Boolean moreThanOnce, string sid, string password)
        {
            titleDate = dateFormat.GetNewDateFormat(date, "MM-dd");
            executionDate = dateFormat.GetNewDateFormat(date, "yyMMdd");

            fileName = env + "-TGT2-MT103-" + titleDate + "T" + DateTime.Now.ToString("HH.mm.ss") + naming.GetName(count, moreThanOnce);
            FileUploader fileUploader = new FileUploader();
            EnvPath envPath = new EnvPath();
            // fileUploader.UploadToFTP(payment.Create(bic, executionDate, name, account, amount, ccy), envPath.GetNetPath(env) + fileName + ".so", sid, password);
            fileUploader.UploadToNet(payment.Create(bic, executionDate, name, account, amount, ccy), envPath.GetNetPath(env), sid, password, fileName);
        }
    }
}
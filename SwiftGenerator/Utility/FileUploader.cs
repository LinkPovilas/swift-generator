using Namespace;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Permissions;
using System.Text;

namespace SwiftGenerator.Utility
{
    internal class FileUploader
    {
        public void UploadToNet(string fileContent, string domain, string sid, string password, string fileName)
        {
            using (var impersonation = new ImpersonatedUser(sid, domain, password))
            {
               // string filePath = "\\\\10.1.2.179\\source\\";
                //StreamWriter SW1;
                FileIOPermission myPerm = new FileIOPermission(FileIOPermissionAccess.AllAccess, domain); // +fileName
                myPerm.Assert();
               // SW1 = File.CreateText(domain + fileName);
                File.WriteAllText(domain + "\\" + fileName + ".so", fileContent);
            }
        }
/*        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            request.Credentials = new NetworkCredential(sid, password);

            byte[] fileContents = Encoding.ASCII.GetBytes(fileContent);

            request.ContentLength = fileContents.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(fileContents, 0, fileContents.Length);
            }

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                Debug.WriteLine($"Upload File Complete, status {response.StatusDescription}");
            }
        }*/
    }
}

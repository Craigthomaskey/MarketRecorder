using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarketRecorder
{
    public class DriveManager
    {
        static string[] Scopes = { DriveService.Scope.Drive };
        static string ApplicationName = "Shadow Services Application";
        DriveService DS;
        string ParentFolder = "1oGrt0LEcAJdgM4VYJUosffeojNeHxlKU";
        Form1 MainForm;

        public bool Init(Form1 f)
        {
            MainForm = f;
            try
            {
                UserCredential credential;
                using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = "token.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets, Scopes, "user", CancellationToken.None, new FileDataStore(credPath, true)).Result;
                    Console.WriteLine("Credential file saved to: " + credPath);
                }
                DS = new DriveService(new BaseClientService.Initializer() { HttpClientInitializer = credential, ApplicationName = ApplicationName, });
            }
            catch { return false; }
            return true;
        }

        public void UploadFile(string path, string name)
        {
            MainForm.AddDriveStatus("Processing drive upload request...");            MainForm.DriveChangeProcessLbl();
            string tempFileID = CheckForFile(name);
            if (tempFileID == null)
            {
                var fileMetadata = new Google.Apis.Drive.v3.Data.File() { Name = name + ".csv", Parents = new List<string> { ParentFolder } };
                FilesResource.CreateMediaUpload request;
                using (var stream = new System.IO.FileStream(path, System.IO.FileMode.Open))
                {
                    request = DS.Files.Create(fileMetadata, stream, "text/plain");
                    request.Fields = "id";
                    request.ProgressChanged += Request_ProgressChanged;
                    request.ResponseReceived += Request_ResponseReceived;
                    request.Upload();
                }
                var file = request.ResponseBody;
            }
            else
            {
                var fileMetadata = new Google.Apis.Drive.v3.Data.File() { Name = name + ".csv", };
                FilesResource.UpdateMediaUpload request;
                using (var stream = new System.IO.FileStream(path, System.IO.FileMode.Open))
                {
                    request = DS.Files.Update(null, tempFileID, stream, "text/plain");
                    request.Fields = "id";
                    request.ProgressChanged += Request_ProgressChanged;
                    request.ResponseReceived += Request_ResponseReceived;
                    request.Upload();
                }
                var file = request.ResponseBody;
            }

        }

        private void Request_ResponseReceived(Google.Apis.Drive.v3.Data.File obj)
        {
           MainForm.AddDriveStatus("File transfer complete - File ID: " + obj.Id);
            Console.WriteLine("File transfer complete - File ID: " + obj.Id);
        }
        private void Request_ProgressChanged(Google.Apis.Upload.IUploadProgress obj)
        {
             MainForm.AddDriveStatus("Change to file transfer request: " + obj.Status);
            Console.WriteLine("Change to file transfer request: " + obj.Status);
        }

        public string CheckForFile(string name)
        {
            // Define parameters of request.
            FilesResource.ListRequest listRequest = DS.Files.List();
            listRequest.PageSize = 100;
            listRequest.Fields = "nextPageToken, files(id, name)";
            listRequest.Q = "'" + ParentFolder + "' in parents";

            // List files.
            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute().Files;
            if (files != null && files.Count > 0)
                foreach (var file in files)
                    if (file.Name == name + ".csv") return file.Id;
                    else MainForm.AddDriveStatus("File - " + file.Id);
            else MainForm.BuildNotification("No files found.", Properties.Resources.ErrorNote, MainForm);
            return null;
        }




    }
}

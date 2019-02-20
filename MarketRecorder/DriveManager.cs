using System;
using Google.Apis.Drive.v2;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using Google.Apis.Drive.v2.Data;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;
using System.IO;

namespace MarketRecorder
{
    public class DriveManager
    {
        DriveService service;
        Form1 MainForm; SettingForm SetForm;
        IList Files = new List<Google.Apis.Drive.v2.Data.File>();

        public bool DriveConnection(Form1 f, SettingForm sf)
        {
            try
            {
                MainForm = f; SetForm = sf;
                string[] scopes = new string[] { DriveService.Scope.Drive, DriveService.Scope.DriveFile }; var clientId = "405890327257-a1k1hget3m0a1vpi1s1ht96hme2k1fmd.apps.googleusercontent.com"; var clientSecret = "ZHF8Od5AvmsV0MXAsndHhREG";
                var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { ClientId = clientId, ClientSecret = clientSecret },
                scopes, Environment.UserName, CancellationToken.None, new FileDataStore("SSA.GoogleDrive.Auth.Store")).Result;
                var newservice = new DriveService(new BaseClientService.Initializer() { HttpClientInitializer = credential, ApplicationName = "Shadow UD", });
                service = newservice;
                return true;
            }
            catch { return false; }
        }
        // returns files list, find folder to save items to
        int count = 0;
        public void GetAllFiles()
        {
            try
            {
                FilesResource.ListRequest list = service.Files.List(); list.MaxResults = 5000;
                list.Q = "trashed = false";
                //list.Q = "mimeType = 'application/vnd.google-apps.folder' and trashed = false";
                FileList filesFeed = list.Execute();
                while (filesFeed.Items != null)
                {
                    foreach (Google.Apis.Drive.v2.Data.File item in filesFeed.Items) { Files.Add(item); count++; }
                    if (filesFeed.NextPageToken == null) break;
                    list.PageToken = filesFeed.NextPageToken;
                    filesFeed = list.Execute();
                }
            }
            catch (Exception ex) { MainForm.BuildNotification("An error occurred: " + ex.Message, Properties.Resources.ErrorNote, MainForm); }
        }

        // When updating send the file name here to find type
        private string GetMimeType(string fileName)
        {
            string mimeType = "application/unknown"; string ext = System.IO.Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null) mimeType = regKey.GetValue("Content Type").ToString();
            return mimeType;
        }
        public Google.Apis.Drive.v2.Data.File uploadFile(string _uploadFile, string _parent)
        {
            if (System.IO.File.Exists(_uploadFile))
            {
                Google.Apis.Drive.v2.Data.File body = new Google.Apis.Drive.v2.Data.File();
                body.Title = System.IO.Path.GetFileName(_uploadFile);
                body.Description = "File uploaded by Shadow Service Applications";
                body.MimeType = GetMimeType(_uploadFile);
                body.Parents = new List<ParentReference>() { new ParentReference() { Id = _parent } };
                byte[] byteArray = System.IO.File.ReadAllBytes(_uploadFile);
                System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
                try { FilesResource.InsertMediaUpload request = service.Files.Insert(body, stream, GetMimeType(_uploadFile)); request.Upload(); return request.ResponseBody; }
                catch (Exception e) { MainForm.BuildNotification("An error occurred: " + e.Message, Properties.Resources.ErrorNote, MainForm); return null; }
            }
            else { MainForm.BuildNotification("File does not exist: " + _uploadFile, Properties.Resources.ErrorNote, MainForm); return null; }

        }
        public Google.Apis.Drive.v2.Data.File updateFile(string _uploadFile, string _parent, string _fileId)
        {
            if (System.IO.File.Exists(_uploadFile))
            {
                Google.Apis.Drive.v2.Data.File body = new Google.Apis.Drive.v2.Data.File();
                body.Title = System.IO.Path.GetFileName(_uploadFile);
                body.Description = "File updated by Shadow Service Applications";
                body.MimeType = GetMimeType(_uploadFile);
                body.Parents = new List<ParentReference>() { new ParentReference() { Id = _parent } };
                byte[] byteArray = System.IO.File.ReadAllBytes(_uploadFile);
                System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
                try { FilesResource.UpdateMediaUpload request = service.Files.Update(body, _fileId, stream, GetMimeType(_uploadFile)); request.Upload(); return request.ResponseBody; }
                catch (Exception e) { MainForm.Text = "An error occurred: " + e.Message; return null; }
            }
            else { MainForm.BuildNotification("File does not exist: " + _uploadFile, Properties.Resources.ErrorNote, MainForm); return null; }
        }
        public void DeleteRequest(string id) { FilesResource.DeleteRequest DeleteRequest = service.Files.Delete(id); DeleteRequest.Execute(); }
        string ParentID;
        public async Task<string> RunFileSearchAsync()
        {
            count = 0;

            await Task.Run(() => GetAllFiles());
            

            //Task myFirstTask = Task.Factory.StartNew(GetAllFiles); myFirstTask.Wait();




            foreach (Google.Apis.Drive.v2.Data.File f in Files) if (f.Title == "KDM") ParentID = f.Id;
            SetForm.DriveFileCount(count);
            MainForm.DriveFilesDownloaded();
            return count.ToString();
        }





        public string UploadFiles(string path, string fileNmae)
        {
            Dictionary<string, string> TempList = new Dictionary<string, string>();
            foreach (Google.Apis.Drive.v2.Data.File f in Files) TempList[f.Title] = f.Id;
            Google.Apis.Drive.v2.Data.File result = null;
            if (System.IO.File.Exists(path))
            {
                if (TempList.ContainsKey(fileNmae)) result = updateFile(path, ParentID, TempList[path]);
                else result = uploadFile(path, ParentID);
            }
            if (result != null) return result.Title + " uploaded successfully."; else return "Error uploading files.";
        }

    }
}

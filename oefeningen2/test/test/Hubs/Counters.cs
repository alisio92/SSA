using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using test.DataAccess;

namespace test.Hubs
{
    public class Counters : Hub
    {
        public void GetDownloadedFiles()
        {
            int aantalDownloads = DAFileRegistration.GetLogs().Count;
            Clients.All.NumberOffFilesDownloaded(aantalDownloads);
        }

        public void GetUploadedFiles()
        {
            int aantalUploads = DAFileRegistration.GetFileRegistration().Count;
            Clients.All.NumberOffFilesUploaded(aantalUploads);
        }
    }
}
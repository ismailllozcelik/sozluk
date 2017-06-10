using System; 
using Xamarin.Forms;
using OsmLugat.Droid.Connection;
using System.IO;
using OsmLugat.Connection;
 
using SQLite.Net.Platform.XamarinAndroid;


 
using SQLite.Net;
 
 
 
 


[assembly: Dependency(typeof(DroidConnection))]
namespace OsmLugat.Droid.Connection
{
  public  class DroidConnection : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
 

            var filename = "Kelimelerim.sqlite";
          //  var documentspath = Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string dbPath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), filename);
         //   var path = Path.Combine(documentspath, filename);

         
            
            if (!File.Exists(dbPath))
            {
                using (BinaryReader br = new BinaryReader(Android.App.Application.Context.Assets.Open(filename)))
                {
                    using (BinaryWriter bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int len = 0;
                        while ((len = br.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            bw.Write(buffer, 0, len);
                        }
                    }
                }
 
               
            }
            var platform = new SQLitePlatformAndroid();
            var connection = new SQLiteConnection(platform, dbPath);
           
            return connection;



        }

    }

     
}
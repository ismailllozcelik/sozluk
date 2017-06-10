using OsmLugat.Model;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace OsmLugat
{
    public class App : Application
    {
        private const string ilkVeritabaniGiris = "ilkGiris";
      //  private SQLiteConnection _sqlconnection;
        //private ObservableCollection<Kelimeler> _kelime;

        private const string KubbeKey = "kubbe";
        private const string AbdullahKey = "abdullah";
        private const string KamusKey = "kamus";
        private const string IsamKey = "isam";
        private const string VankuluKey = "vankulu";
     

        public App()
        {
            // The root page of your application



            MainPage = new AranacakSozluklerPage();


            /*  MainPage = new NavigationPage(new ContactDetailPage(new Sozlukler { Name = "Kubbealtı", ID = "1" })) {
                  BarBackgroundColor = Color.Blue,
                  BarTextColor = Color.White
              };*/
            /*    MainPage = new NavigationPage(new ArananKelimePage())
                {
                    BarBackgroundColor = Color.Blue,
                    BarTextColor = Color.White
                }; */
         //  MainPage = new NavigationPage(new ArananKelimePage());

            //  MainPage = new NavigationPage(new WelcomePage());
            //   MainPage =new IntroductionPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public bool Kamus
        {

            get{
                if (Properties.ContainsKey(KamusKey))
                    return (bool)Properties[KamusKey];

                return true;
            }
            set{ Properties[KamusKey] = value; }
        }

        public bool Isam
        {

            get{
                if (Properties.ContainsKey(IsamKey))
                    return (bool)Properties[IsamKey];

                return true;
            }
            set{ Properties[IsamKey] = value; }
        }

        public bool Kubbe
        {

            get{
                if (Properties.ContainsKey(KubbeKey))
                    return (bool)Properties[KubbeKey];

                return true;
            }
            set{ Properties[KubbeKey] = value; }
        }


        public bool Abdullah
        {

            get
            {
                if (Properties.ContainsKey(AbdullahKey))
                    return (bool)Properties[AbdullahKey];

                return true;
            }
            set { Properties[AbdullahKey] = value; }
        }


        public bool Vankulu
        {

            get{
                if (Properties.ContainsKey(VankuluKey))
                    return (bool)Properties[VankuluKey];

                return true;
            }
            set{
                Properties[VankuluKey] = value;
            }
        }



        public int IlkGiris
        {

            get {if( Properties.ContainsKey(ilkVeritabaniGiris))
                    return (int)Properties[ilkVeritabaniGiris];
                return 1;
            }

            set { Properties[ilkVeritabaniGiris] = value; }

        }
    }
}

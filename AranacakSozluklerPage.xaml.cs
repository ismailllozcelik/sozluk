using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using OsmLugat.Model;
using System.Reflection.Emit;

namespace OsmLugat
{
    public partial class AranacakSozluklerPage : MasterDetailPage
    {

        protected override void OnDisappearing()
        {

            //  DisplayAlert("ekran kapandı", "ekranı şimdi kapattım", "kapat");
          
          Application.Current.SavePropertiesAsync();

            base.OnDisappearing();
        }


        protected override void OnAppearing()
        {
            Application.Current.SavePropertiesAsync();
            
            IsPresented = false;
            Detail = new NavigationPage(new ArananKelimePage());
            // 
           
            base.OnAppearing();

        }

   
        public AranacakSozluklerPage()
        {// var app = Application.Current as App;

            InitializeComponent();
            BindingContext = Application.Current;
          //  Application.Current.SavePropertiesAsync();
          
            //  Application.Current.SavePropertiesAsync();
        
            
    
            //   OnAdd();
          

           

        }
    }
}

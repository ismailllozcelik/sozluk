using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OsmLugat.Model;

using Xamarin.Forms;
using SQLite.Net;
using System.Collections.ObjectModel;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;

using Foundation;
using Android.Widget;
using System.Text.RegularExpressions;

namespace OsmLugat
{
    public partial class ArananKelimePage : ContentPage
    {
        

          private SQLiteConnection _sqlconnection;
     //   private ObservableCollection<Kelimeler> _kelime;




        void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {


            if (listView.IsVisible == false)
            {
                listView.IsVisible = true;

                Browser.IsVisible = false;
                adim.IsVisible = false;

              
                
                listView.SeparatorColor = Color.Blue;
            }
            /*   osmanlicaYazimi.Text = "";

               kelime.Text = "";
               mana.Text = "";
               */
           // listView.ItemsSource = GetSozlukler(e.NewTextValue);
         
           
            if(String.IsNullOrEmpty(e.NewTextValue))
            {

               listView.ItemsSource = GetSozlukler(e.NewTextValue);
            }
            else
            {


                var deneme = GetSozlukler(e.NewTextValue);
              //  listView.ItemsSource = deneme;
              List<Kelimeler> items = new List<Kelimeler>();
                foreach (var item in deneme)
                {
                    string son;
                    var htlmsiz = Regex.Replace(item.TemizMana, @"<(.|\n)*?>", string.Empty);


                      if (htlmsiz.Length > 25)
                      {
                          son = htlmsiz.Substring(0, 25);
                      }
                      else son = htlmsiz.ToString();
                 

                   

                    item.Mana = son;
                    items.Add(item);

                }
                listView.ItemsSource = items;
            }
            ///  @Html.Raw(item.icerik.Substring(0, 150)) ...

        }

    

        protected override void OnAppearing()
        {
          
            
        //    _sqlconnection.CreateTable<Kelimeler>();
          //  var kelimeler = _sqlconnection.Table<Kelimeler>().ToList();
           
          //  _kelime = new ObservableCollection<Kelimeler>(kelimeler);
            //    listView.ItemsSource = _kelime;

            adim.TextColor = Color.Green;
            
            Browser.BackgroundColor = Color.DarkGray;
            // Browser.Margin = 20;
            Browser.IsVisible = false;
            adim.IsVisible = false;
       

            base.OnAppearing();

        }

       
       
        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {

            listView.IsVisible = false;
            var secilen = e.SelectedItem as Kelimeler;
            //   osmanlicaYazimi.Text = secilen.HattiKuran;
            Browser.IsVisible = true;
            
            adim.IsVisible = true;
            adim.FontSize = 15;
        

            //    Sozlukidisi.Text ="Sözlüğün Idisi..: "+ selectedSozluk.ID.ToString();
            //    KendIidisi.Text ="Kelimenin Kendi Idisi..: "+ secilen.ID.ToString();
            //     kelime.Text = "Kelime..: " + secilen.Kelime;
            //  mana.Text = "Kelimenin manası..:" + secilen.TemizMana;


            var htmlSource = new HtmlWebViewSource();

            htmlSource.Html = secilen.TemizMana;
            Browser.Source = htmlSource;
            adim.Text = "Aranan Kelime:   "+secilen.Kelime;

            



        }





        public static string RemoveHtml(string text) { return Regex.Replace(text, @"<(.|\n)*?>", string.Empty); }  
       IEnumerable<Kelimeler>  GetSozlukler(string aranan = null)
        {

            if (String.IsNullOrEmpty(aranan))
            {
                //şimdilik hepsini gönder
                //    return _kelime;
                return null;
            }

          
            Application.Current.SavePropertiesAsync();
           
            var app = Application.Current as App;
            return _sqlconnection.Table<Kelimeler>().Where((c => c.TemizKelime.StartsWith(aranan) && ((app.Kubbe == true && c.SozlukAdi == "Kubbe Altı") || (app.Kamus == true && c.SozlukAdi == "Kamus") || (app.Isam == true && c.SozlukAdi == "İsam") || (app.Vankulu == true && c.SozlukAdi == "Vankulu") || (app.Abdullah == true && c.SozlukAdi == "Abdullah Yeğin")))).Take(10).ToList();
        
         

        }

        protected override void OnDisappearing()
        {
            

              Application.Current.SavePropertiesAsync();
            base.OnDisappearing();
        }
        public ArananKelimePage()
        {
            _sqlconnection = DependencyService.Get<Connection.ISQLite>().GetConnection();


            //   selectedSozluk = secilenSozluk;
            InitializeComponent();

           

        }

      

    }
}

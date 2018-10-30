using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;
using System.Text;
using Xamarin.Forms.Xaml;

namespace Kelompok42
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; internal set; }
      

        public App()
        {
            if (!IsUserLoggedIn) 
            {
                MainPage = new NavigationPage(new LoginPage());

            }
            else
            {
                MainPage = new NavigationPage(new HalamanUtama());
            }
        }
        protected override void OnStart()
        {
            //Handle when yout app starts
        }
        protected override void OnSleep()
        {
            //Handle when your app sleeps
        }
        protected override void OnResume()
        {
            //Handle when your app resumes
        }

     }
 }

using Kelompok42.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Kelompok42
{
    public class HalamanUtama : ContentPage
    {
        public HalamanUtama()
        {
            this.Title = "Data Mahasiswa";

            StackLayout stacklayout = new StackLayout();
            Button button = new Button();
            button.Text = "Tambah Data";
            button.Clicked += Button_Tambah_Clicked;
            stacklayout.Children.Add(button);

            button = new Button();
            button.Text = "Lihat Data";
            button.Clicked += Button_Lihat_Clicked;
            stacklayout.Children.Add(button);

            button = new Button(); //untuk membuat sebuah button
            button.Text = "Edit"; //membuat nama di tombol button
            button.Clicked += Button_Edit_Clicked; //ketika button di click akan langsung di sambungkan ke Button_Edit_Clicked
            stacklayout.Children.Add(button); //untuk membuat history ke layout sebelumnya

            button = new Button(); //untuk membuat sabuah button
            button.Text = "Hapus"; //untuk membuat nama di tombol button
            button.Clicked += Button_Delete_Clicked; //ketika button di click akan langsung ke Button_Delete_Clicked
            stacklayout.Children.Add(button);

            Content = stacklayout; //untuk menyimpan semua histori stacklayout
        }

        private async void Button_Tambah_Clicked(object sender, EventArgs e) //methode untuk tombol button yang dibuat tadi
        {
            await Navigation.PushAsync(new HalamanTambahData()); //ketika button di tekan maka akan langsung di teruskan ke content halaman tambah data
        }
        private async void Button_Lihat_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HalamanLihatData());//ketika button di tekan maka akan langsung di teruskan ke content halaman lihat data
        }
        private async void Button_Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HalamanEdit());//ketika button di tekan maka akan langsung di teruskan ke content halaman edit
        }
        private async void Button_Delete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HalamanDelete()); //ketika button di tekan maka akan langsung di teruskan ke content halaman delete
        }
    }
}

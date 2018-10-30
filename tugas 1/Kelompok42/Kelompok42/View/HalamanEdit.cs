using Kelompok42.Model; //library ke model yang dibuat
using SQLite; //library untuk SQLite
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Kelompok42.View
{
    public class HalamanEdit : ContentPage
    {
        private ListView _listView; 
        private Entry _id; 
        private Entry _nama;
        private Entry _jurusan;
        private Button _simpan;

        DataMahasiswa _datamahasiswa = new DataMahasiswa(); //membuat class datamahasiswa baru dengan nama _datamahasiswa

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db4"); //merupakan database dimana data yang kita ubah aka langsung ke simpan di database myDB.db4
        public HalamanEdit()
        {
            this.Title = "Edit Data"; //memberi judul di halaman edit
            var db = new SQLiteConnection(_dbPath); // untuk databasenya
            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<DataMahasiswa>().OrderBy(x => x.Nama).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _id = new Entry(); //membuat entry baru bernama _id
            _id.Placeholder = "ID"; //penamaan pada entry yang dibuat
            _id.IsVisible = false;
            stackLayout.Children.Add(_id); //data akan langsung di simpan di _id

            _nama = new Entry(); //membuat entry baru bernama _nama
            _nama.Keyboard = Keyboard.Text;//untuk menampilkan edit teks di halaman edit
            _nama.Placeholder = "Nama Mahasiswa";//untuk menamai edit teks yang di buat tadi
            stackLayout.Children.Add(_nama); //data yang di edit di edit teks tadi akan di simpan di _nama

            _jurusan = new Entry();
            _jurusan.Keyboard = Keyboard.Text;
            _jurusan.Placeholder = "Jurusan";
            stackLayout.Children.Add(_jurusan);

            _simpan = new Button(); //membuat button
            _simpan.Text = "Edit"; //nama button
            _simpan.Clicked += _simpan_Clicked; //ketika di tekan akan langsung ke _simpan_Clicked
            stackLayout.Children.Add(_simpan); 

            Content = stackLayout;// untuk menyimpan histori stacklayout
        }

        private async void _simpan_Clicked(object sender, EventArgs e) //methode memanggil _simpan_Clicked ketika di click
        {
            var db = new SQLiteConnection(_dbPath);//
            DataMahasiswa dataMahasiswa = new DataMahasiswa()
            {
                Id = Convert.ToInt32(_id.Text),//mengkonvert ID ke int 32 yang di simpan ke _id.text
                Nama = _nama.Text, //_nama.text untuk menyimpan nama
                Jurusan = _jurusan.Text
            };
            db.Update(dataMahasiswa); //update database pada datamahasiswa
            await DisplayAlert(null, "Data " + dataMahasiswa.Nama + " Berhasil di Edit", "Ok"); //untuk pop out ketika button di tekan
            await Navigation.PopAsync();
        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _datamahasiswa = (DataMahasiswa)e.SelectedItem;
            _id.Text = _datamahasiswa.Id.ToString();
            _nama.Text = _datamahasiswa.Nama;
            _jurusan.Text = _datamahasiswa.Jurusan;
                    }
    	}
}

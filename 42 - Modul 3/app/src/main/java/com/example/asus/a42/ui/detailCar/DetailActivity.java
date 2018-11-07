package com.example.asus.a42.ui.detailCar;

import android.content.DialogInterface;
import android.content.Intent;
import android.provider.ContactsContract;
import android.support.annotation.Nullable;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.example.asus.a42.data.model.DataCar;
import com.example.asus.a42.utility.Constant;
import com.example.asus.a42.R;
import com.example.asus.a42.ui.home.HomeActivity;
import com.example.asus.a42.adapter.car.CarAdapter;
import com.example.asus.a42.ui.addCar.AddActivity;

import java.util.List;

public class DetailActivity extends AppCompatActivity implements DetailView {

    private DataCar dataCar;
    private DetailPresenter mPresenter;
    private TextView tvYear;
    private TextView tvName;
    private TextView tvModel;
    private TextView tvMerk;
    private Button btn_delete;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_detail);
        initView();
        initIntentData();
        initPresenter();
        initData();
        deleteCar(dataCar);
    }

    private void initView() {
        tvName = findViewById(R.id.tvName);
        tvYear = findViewById(R.id.tvYear);
        tvMerk = findViewById(R.id.tvMerk);
        tvModel = findViewById(R.id.tvModel);
        btn_delete = findViewById(R.id.btn_delete);
    }

    private void initData() {
        mPresenter.getCarById(dataCar);
    }

    private void initPresenter() {
        mPresenter = new DetailPresenter(this);
    }

    private void initIntentData() {
        dataCar = getIntent().getParcelableExtra(Constant.Extra.DATA);
        if (dataCar == null) finish();
    }

    @Override
    public void showErrorCarById(String message) {
        Toast.makeText(this, message, Toast.LENGTH_SHORT).show();
    }

    @Override
    public void showSuccessCarById(List<DataCar> dataCar) {
        tvName.setText(dataCar.get(0).getName());
        tvMerk.setText(dataCar.get(0).getMerk());
        tvModel.setText(dataCar.get(0).getModel());
        tvYear.setText(dataCar.get(0).getYear());
    }


    private void deleteCar(DataCar dataCar) {
        btn_delete.setOnClickListener(view -> showAlertDialog());
    }

    public void showAlertDialog() {
        new AlertDialog.Builder(this)
                .setMessage("Hapus Data?")
                .setCancelable(false)
                .setPositiveButton("Ya", new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {
                        mPresenter.deleteCar(dataCar);
                    }
                })
                .setNegativeButton("Gak", null)
                .show();
    }

    @Override
    public void showSuccessDeleteCar(DataCar dataCar) {
        Toast.makeText(DetailActivity.this, "Data berhasil dihapus", Toast.LENGTH_SHORT).show();
        Intent home = new Intent(DetailActivity.this, HomeActivity.class);
        startActivity(home);
        finish();
    }
    @Override
    public void showErrorDeleteCar(String message) {
        Toast.makeText(this, message, Toast.LENGTH_SHORT).show();
    }

}
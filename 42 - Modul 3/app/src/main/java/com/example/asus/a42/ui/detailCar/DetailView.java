package com.example.asus.a42.ui.detailCar;

import com.example.asus.a42.data.model.DataCar;

import java.util.List;

public interface DetailView {
    void showErrorCarById(String message);
    void showSuccessCarById(List<DataCar> dataCar);
    void showSuccessDeleteCar(DataCar dataCar);
    void showErrorDeleteCar(String message);
}
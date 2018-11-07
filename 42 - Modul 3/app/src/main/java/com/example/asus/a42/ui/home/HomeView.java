package com.example.asus.a42.ui.home;

import com.example.asus.a42.data.model.DataCar;

import java.util.List;

public interface HomeView {
    void successShowCar(List<DataCar> dataCars);
    void failedShowCar(String message);

}

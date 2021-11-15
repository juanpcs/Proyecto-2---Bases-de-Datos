package com.example.appnutritec;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Spinner;

public class MenuAgregarProducto extends AppCompatActivity {

    private Spinner spinner;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu_agregar_producto);

        spinner = (Spinner)findViewById(R.id.spinner);
        String [] opciones = {"Arroz xxxxx, 25 gr, 200", "Frijoles xxxxx, 25 gr, 200",
                "Pan xxxxx, 25 gr, 200", "a","b","c","d","e","f","g","h","i","j","k"};
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(this,R.layout.spinner_item2, opciones);
        spinner.setAdapter(adapter);
    }

    public void Volver(View view) {
        /*
        Intent i = new Intent(this, RegistroConsumo.class);
        i.putExtra("correo_usuario",getIntent().getStringExtra("correo_usuario"));
        startActivity(i);
         */
        finish();
    }

}
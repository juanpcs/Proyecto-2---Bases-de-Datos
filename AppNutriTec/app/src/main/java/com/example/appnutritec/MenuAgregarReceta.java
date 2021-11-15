package com.example.appnutritec;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Spinner;
import android.widget.Toast;

public class MenuAgregarReceta extends AppCompatActivity {

    private Spinner spinner;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu_agregar_receta);

        spinner = (Spinner)findViewById(R.id.spinner);
        String [] opciones = {"Pinto, 25 gr, 200", "Batido, 25 gr, 200",
                "Ensalada, 25 gr, 200", "a","b","c","d","e","f","g","h","i","j","k"};
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(this,R.layout.spinner_item2, opciones);
        spinner.setAdapter(adapter);

        String correo_usuario = getIntent().getStringExtra("correo_usuario");
        Toast.makeText(this, "Correo del usuario: " + correo_usuario, Toast.LENGTH_SHORT ).show();
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
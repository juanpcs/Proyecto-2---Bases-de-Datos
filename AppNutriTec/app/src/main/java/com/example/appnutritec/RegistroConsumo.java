package com.example.appnutritec;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.text.method.ScrollingMovementMethod;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

public class RegistroConsumo extends AppCompatActivity {

    private Spinner spinner;
    private TextView tvConsumoActual;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_registro_consumo);

        tvConsumoActual = (TextView) findViewById(R.id.tvConsumoActual);
        tvConsumoActual.setMovementMethod(new ScrollingMovementMethod());

        spinner = (Spinner)findViewById(R.id.spinner);
        String [] opciones = {"Desayuno","Merienda mañana","Almuerzo", "Merienda tarde","Cena"};
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(this,R.layout.spinner_item, opciones);
        spinner.setAdapter(adapter);

        String correo_usuario = getIntent().getStringExtra("correo_usuario");
        Toast.makeText(this, "Correo del usuario: " + correo_usuario, Toast.LENGTH_SHORT ).show();


    }

    public void AñadirProducto(View view) {
        Intent i = new Intent(this, MenuAgregarProducto.class);
        startActivity(i);
    }

    public void AñadirReceta(View view) {
        Intent i = new Intent(this, MenuAgregarReceta.class);
        i.putExtra("correo_usuario",getIntent().getStringExtra("correo_usuario"));
        startActivity(i);
    }

}
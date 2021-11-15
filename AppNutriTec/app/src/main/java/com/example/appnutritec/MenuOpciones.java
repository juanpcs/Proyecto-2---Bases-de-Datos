package com.example.appnutritec;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

public class MenuOpciones extends AppCompatActivity {

    String correo_usuario;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu_opciones);
/*
        Button btnRCD = (Button)findViewById(R.id.btnRCD);

        Button btnGR = (Button)findViewById(R.id.btnGR);

 */

        correo_usuario = getIntent().getStringExtra("correo_usuario");
        Toast.makeText(this, "Bienvenido: " + correo_usuario, Toast.LENGTH_SHORT ).show();

/*
        btnRCD.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent menuRCD = new Intent(MenuOpciones.this,RegistroConsumo.class);
                menuRCD.putExtra("correo_cliente",getIntent().getStringExtra("correo_usuario"));
                MenuOpciones.this.startActivity(menuRCD);
            }
        });

        btnGR.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent menuGR = new Intent(MenuOpciones.this,MenuGestionRecetas.class);
                MenuOpciones.this.startActivity(menuGR);
            }
        });

 */

    }

    public void RegistroConsumo(View view) {
        Intent i = new Intent(this, RegistroConsumo.class);
        i.putExtra("correo_usuario",correo_usuario);
        startActivity(i);
    }

    public void GestionRecetas(View view) {
        Intent i = new Intent(this, MenuGestionRecetas.class);
        i.putExtra("correo_usuario",correo_usuario);
        startActivity(i);
    }
}
package com.example.appnutritec;

import androidx.appcompat.app.AppCompatActivity;
import android.os.Bundle;
import android.text.method.ScrollingMovementMethod;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

public class MenuGestionRecetas extends AppCompatActivity{

    private Spinner spinner;
    private EditText etNombreReceta;
    private EditText etCantidadProducto;
    private TextView tvProductosReceta;
/*
    private ListView lvProductosReceta;
    private List<String> ListaProductos = new ArrayList<>();
    private ArrayAdapter<String> Adapter;

    private String Productos [] =  {"Prueba"};
    private String Cantidades[] = {"1"};

 */

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu_gestion_recetas);

        etNombreReceta = (EditText)findViewById(R.id.etNombreReceta);
        etCantidadProducto = (EditText)findViewById(R.id.etCantidadProducto);

        tvProductosReceta = (TextView) findViewById(R.id.tvProductosReceta);
        tvProductosReceta.setMovementMethod(new ScrollingMovementMethod());

        spinner = (Spinner)findViewById(R.id.spinner);
        String [] opciones = {"Arroz xxxxx, 25 gr, 200", "Frijoles xxxxx, 25 gr, 200",
                "Pan xxxxx, 25 gr, 200", "a","b","c","d","e","f","g","h","i","j","k"};
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(this,R.layout.spinner_item2, opciones);
        spinner.setAdapter(adapter);

        String correo_usuario = getIntent().getStringExtra("correo_usuario");
        Toast.makeText(this, "Correo del usuario: " + correo_usuario, Toast.LENGTH_SHORT ).show();
    }

    public void AddProduct(View view){
        String correo_usuario = getIntent().getStringExtra("correo_usuario");
        String NombreReceta = etNombreReceta.getText().toString();
        String Producto = spinner.getSelectedItem().toString();
        String CantidadProducto = etCantidadProducto.getText().toString();
        String ProductosAñadidos = tvProductosReceta.getText().toString();
/*
        Toast.makeText(this, "pasa de aquí: " + correo_usuario, Toast.LENGTH_SHORT ).show();

        //ListaProductos.add("Producto X");
        Adapter = new ArrayAdapter<String>(this, R.layout.list_item_personalized, Productos);
        lvProductosReceta.setAdapter(Adapter);

 */
        tvProductosReceta.setText(ProductosAñadidos+"\n"+Producto +" | "+CantidadProducto+"\n");

    }

/*
    @Override
    public void onClick(View view) {
        switch (view.getId()){
            case R.id.btnAgregarProducto2:
                String texto="holamundo";
                ListaProductos.add(texto);
                Adapter = new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1,ListaProductos);
                lvProductosReceta.setAdapter(Adapter);
        }
    }

 */


}
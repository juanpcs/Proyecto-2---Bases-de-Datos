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

import com.android.volley.NoConnectionError;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.ServerError;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.Volley;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.List;

public class MenuGestionRecetas extends AppCompatActivity{
    private RequestQueue queue;
    private Spinner spinner;
    private EditText etNombreReceta;
    private EditText etCantidadProducto;
    private TextView tvProductosReceta;
    private List<String> productos = new ArrayList<String>();

    private static final String url2="http://192.168.100.22:3000/api/producto";


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu_gestion_recetas);

        queue = Volley.newRequestQueue(this);

        etNombreReceta = (EditText)findViewById(R.id.etNombreReceta);
        etCantidadProducto = (EditText)findViewById(R.id.etCantidadProducto);

        tvProductosReceta = (TextView) findViewById(R.id.tvProductosReceta);
        tvProductosReceta.setMovementMethod(new ScrollingMovementMethod());

        spinner = (Spinner)findViewById(R.id.spinner);
        JsonArrayRequestProductos();

        /*
        String [] opciones = {"Arroz xxxxx, 25 gr, 200", "Frijoles xxxxx, 25 gr, 200",
                "Pan xxxxx, 25 gr, 200", "a","b","c","d","e","f","g","h","i","j","k"};
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(this,R.layout.spinner_item2, opciones);
        spinner.setAdapter(adapter);

        String correo_usuario = getIntent().getStringExtra("correo_usuario");
        Toast.makeText(this, "Correo del usuario: " + correo_usuario, Toast.LENGTH_SHORT ).show();

         */
    }

    public void AddProduct(View view){
        String correo_usuario = getIntent().getStringExtra("correo_usuario");
        String NombreReceta = etNombreReceta.getText().toString();
        String Producto = spinner.getSelectedItem().toString();
        String CantidadProducto = etCantidadProducto.getText().toString();
        String ProductosAñadidos = tvProductosReceta.getText().toString();

        tvProductosReceta.setText(ProductosAñadidos+"\n"+Producto +"\n"+"Cantidad: "+CantidadProducto+"\n");

    }

    public void JsonArrayRequestProductos(){

        JsonArrayRequest request = new JsonArrayRequest(Request.Method.GET, url2, null, new Response.Listener<JSONArray>() {
            @Override
            public void onResponse(JSONArray response) {
                int size = response.length();

                for (int i=0;i<size;i++){
                    try {
                        JSONObject jsonObject = new JSONObject(response.get(i).toString());
                        String nombre = jsonObject.getString("nombre");
                        String descripcion = jsonObject.getString("descripcion");
                        String porcion = jsonObject.getString("porcion");
                        String energia = jsonObject.getString("energia");
                        String producto = "Nombre: "+nombre+"\n"+"Descripcion: "+descripcion+"\n"+"Tamaño porcion: "+porcion+"\n"+"Energía: "+energia;
                        productos.add(producto);



                        Toast.makeText(MenuGestionRecetas.this,"Nombre: "+nombre,Toast.LENGTH_SHORT).show();

                    } catch (JSONException e) {
                        e.printStackTrace();
                    }
                }

                String array [] = new String[productos.size()];
                productos.toArray(array);

                ArrayAdapter<String> adapter = new ArrayAdapter<String>(MenuGestionRecetas.this,R.layout.spinner_item2, array);
                spinner.setAdapter(adapter);


            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                if (error instanceof ServerError){
                    Toast.makeText(MenuGestionRecetas.this,"SERVER ERROR" ,Toast.LENGTH_SHORT).show();
                }
                if (error instanceof NoConnectionError){
                    Toast.makeText(MenuGestionRecetas.this,"No hay conexión a internet" ,Toast.LENGTH_SHORT).show();
                    Toast.makeText(MenuGestionRecetas.this,"error: "+error.getMessage() ,Toast.LENGTH_LONG).show();
                }

            }
        });
        queue.add(request);


    }

}
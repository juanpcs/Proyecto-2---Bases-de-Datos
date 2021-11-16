package com.example.appnutritec;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Spinner;
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

public class MenuAgregarProducto extends AppCompatActivity {
    private RequestQueue queue;
    private Spinner spinner;
    private List<String> productos = new ArrayList<String>();

    private static final String url2="http://192.168.100.22:3000/api/producto";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu_agregar_producto);

        queue = Volley.newRequestQueue(this);

        spinner = (Spinner)findViewById(R.id.spinner);
        JsonArrayRequestProductos();

    }

    public void Volver(View view) {
        /*
        Intent i = new Intent(this, RegistroConsumo.class);
        i.putExtra("correo_usuario",getIntent().getStringExtra("correo_usuario"));
        startActivity(i);
         */
        finish();
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



                        Toast.makeText(MenuAgregarProducto.this,"Nombre: "+nombre,Toast.LENGTH_SHORT).show();

                    } catch (JSONException e) {
                        e.printStackTrace();
                    }
                }

                String array [] = new String[productos.size()];
                productos.toArray(array);

                ArrayAdapter<String> adapter = new ArrayAdapter<String>(MenuAgregarProducto.this,R.layout.spinner_item2, array);
                spinner.setAdapter(adapter);


            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                if (error instanceof ServerError){
                    Toast.makeText(MenuAgregarProducto.this,"SERVER ERROR" ,Toast.LENGTH_SHORT).show();
                }
                if (error instanceof NoConnectionError){
                    Toast.makeText(MenuAgregarProducto.this,"No hay conexión a internet" ,Toast.LENGTH_SHORT).show();
                    Toast.makeText(MenuAgregarProducto.this,"error: "+error.getMessage() ,Toast.LENGTH_LONG).show();
                }

            }
        });
        queue.add(request);


    }

}
package com.example.appnutritec;

import androidx.appcompat.app.AppCompatActivity;

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

public class MenuAgregarReceta extends AppCompatActivity {
    private RequestQueue queue;
    private Spinner spinner;
    private List<String> recetas = new ArrayList<String>();

    private static final String url2="http://192.168.100.22:3000/api/receta";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu_agregar_receta);

        queue = Volley.newRequestQueue(this);

        spinner = (Spinner)findViewById(R.id.spinner);

        JsonArrayRequestRecetas();
        /*
        String [] opciones = {"Pinto, 25 gr, 200", "Batido, 25 gr, 200",
                "Ensalada, 25 gr, 200", "a","b","c","d","e","f","g","h","i","j","k"};
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(this,R.layout.spinner_item2, opciones);
        spinner.setAdapter(adapter);

        String correo_usuario = getIntent().getStringExtra("correo_usuario");
        Toast.makeText(this, "Correo del usuario: " + correo_usuario, Toast.LENGTH_SHORT ).show();

         */
    }

    public void Volver(View view) {
        /*
        Intent i = new Intent(this, RegistroConsumo.class);
        i.putExtra("correo_usuario",getIntent().getStringExtra("correo_usuario"));
        startActivity(i);
         */
        finish();
    }

    public void JsonArrayRequestRecetas(){

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
                        recetas.add(producto);



                        Toast.makeText(MenuAgregarReceta.this,"Nombre: "+nombre,Toast.LENGTH_SHORT).show();

                    } catch (JSONException e) {
                        e.printStackTrace();
                    }
                }

                String array [] = new String[recetas.size()];
                recetas.toArray(array);

                ArrayAdapter<String> adapter = new ArrayAdapter<String>(MenuAgregarReceta.this,R.layout.spinner_item2, array);
                spinner.setAdapter(adapter);


            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                if (error instanceof ServerError){
                    Toast.makeText(MenuAgregarReceta.this,"SERVER ERROR" ,Toast.LENGTH_SHORT).show();
                }
                if (error instanceof NoConnectionError){
                    Toast.makeText(MenuAgregarReceta.this,"No hay conexión a internet" ,Toast.LENGTH_SHORT).show();
                    Toast.makeText(MenuAgregarReceta.this,"error: "+error.getMessage() ,Toast.LENGTH_LONG).show();
                }

            }
        });
        queue.add(request);


    }

}
package com.example.appnutritec;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
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

public class LoginActivity extends AppCompatActivity {
    private RequestQueue queue;
    private EditText etCorreoLogin;
    private EditText etContraseñaLogin;

    private static final String url1="https://10.0.2.2:5001/api/mensaje";
    private static final String url2="http://192.168.100.22:3000/api/cliente";
    private static final String url3="http://192.168.137.1:3000/api/mensaje";
    private static final String url4="https://my-json-server.typicode.com/typicode/demo/posts";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
/*
        Button btnLogin = (Button)findViewById(R.id.btnLogin);

 */
        etCorreoLogin = (EditText)findViewById(R.id.etCorreoLogin);

        etContraseñaLogin = (EditText)findViewById(R.id.etContraseñaLogin);

        Toast.makeText(this, "Bienvenido: ", Toast.LENGTH_SHORT ).show();

        queue = Volley.newRequestQueue(this);
        //JsonArrayRequestClientes();
/*
        btnLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent menuOptions = new Intent(LoginActivity.this, MenuOpciones.class);
                menuOptions.putExtra("correo_cliente","hola mundo");
                LoginActivity.this.startActivity(menuOptions);

            }
        });

 */
    }

    //metodo que se encarga de pasar el correo del cliente logueado  al siguiente activity
    public void Continuar(View view) {
        Intent i = new Intent(this, MenuOpciones.class);
        i.putExtra("correo_usuario",etCorreoLogin.getText().toString());
        startActivity(i);

    }

    public void JsonArrayRequestClientes(View view){
        String CorreoLogin = etCorreoLogin.getText().toString();
        String ContraseñaLogin = etContraseñaLogin.getText().toString();

        JsonArrayRequest request = new JsonArrayRequest(Request.Method.GET, url2, null, new Response.Listener<JSONArray>() {
            @Override
            public void onResponse(JSONArray response) {
                int size = response.length();
                for (int i=0;i<=size;i++){
                    if(i==size){
                        Toast.makeText(LoginActivity.this,"Correo no encontrado",Toast.LENGTH_SHORT).show();
                        break;
                    }
                    try {
                        JSONObject jsonObject = new JSONObject(response.get(i).toString());
                        String email = jsonObject.getString("correo_electronico");
                        String contraseña = jsonObject.getString("contraseña");
                        if (email.equals(CorreoLogin) && contraseña.equals(ContraseñaLogin)){

                            Intent menuopciones = new Intent(LoginActivity.this, MenuOpciones.class);
                            menuopciones.putExtra("correo_usuario",etCorreoLogin.getText().toString());
                            LoginActivity.this.startActivity(menuopciones);
                            LoginActivity.this.finish();
                            break;


                        }
                        if (email.equals(CorreoLogin) && contraseña != ContraseñaLogin){
                            Toast.makeText(LoginActivity.this,"Contraseña incorrecta",Toast.LENGTH_SHORT).show();
                            break;
                        }
                        
                    } catch (JSONException e) {
                        e.printStackTrace();
                    }
                }

            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                if (error instanceof ServerError){
                    Toast.makeText(LoginActivity.this,"SERVER ERROR" ,Toast.LENGTH_SHORT).show();
                }
                if (error instanceof NoConnectionError){
                    Toast.makeText(LoginActivity.this,"No hay conexión a internet" ,Toast.LENGTH_SHORT).show();
                    Toast.makeText(LoginActivity.this,"error: "+error.getMessage() ,Toast.LENGTH_LONG).show();
                }

            }
        });

        queue.add(request);
        //Toast.makeText(LoginActivity.this,"Correo no encontrado",Toast.LENGTH_SHORT).show();

    }


}
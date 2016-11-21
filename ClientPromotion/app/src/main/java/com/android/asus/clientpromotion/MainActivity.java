package com.android.asus.clientpromotion;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        final EditText txt_username = (EditText)findViewById(R.id.input_username);
        final EditText txt_password = (EditText)findViewById(R.id.password_login);

        Button bt_login = (Button) findViewById(R.id.bt_sign_in);
        bt_login.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (txt_username.getText().toString().equals("username") &&
                        txt_password.getText().toString().equals("password"))
                {
                    setContentView(R.layout.activity_menu);
                }
                else
                    Toast.makeText(getApplicationContext(), "Sai thong tin dang nhap",Toast.LENGTH_SHORT).show();
            }
        });
    }
}

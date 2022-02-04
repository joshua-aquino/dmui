module com.example.dmui {
    requires javafx.controls;
    requires javafx.fxml;


    opens com.example.dmui to javafx.fxml;
    exports com.example.dmui;
}
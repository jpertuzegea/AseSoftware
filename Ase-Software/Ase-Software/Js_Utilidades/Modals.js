// llamado de modales para los modulos


// -------- inicio cliente --------
function crear_cliente(){
    $("#contenido").load("/Clientes/ClientesAdd");
}
function modi_cliente(id) {
    $("#contenido").load("/Clientes/ClientesUpdt/" + id);
} // -------- fin cliente --------

// -------- inicio mecanico --------
function crear_mecanico() {
    $("#contenido").load("/Mecanico/MecanicoAdd");
}
function modi_mecanico(id) {
    $("#contenido").load("/Mecanico/MecanicoUpdt/" + id);
} // -------- fin mecanico --------


// -------- inicio Vehiculo --------
function crear_vehiculo() {
    $("#contenido").load("/Vehiculos/VehiculoAdd");
}
function modi_vehiculo(id) {
    $("#contenido").load("/Vehiculos/VehiculoUpdt/" + id);
} // -------- fin Vehiculo --------


// -------- inicio Repuesto --------
function crear_repuesto() {
    $("#contenido").load("/Repuestos/RepuestoAdd");
}
function modi_repuesto(id) {
    $("#contenido").load("/Repuestos/RepuestoUpdt/" + id);
} // -------- fin Repuesto --------


// -------- inicio Servicio --------
function crear_servicio() {
    $("#contenido").load("/Servicios/ServicioAdd");
}
function modi_servicio(id) {
    $("#contenido").load("/Servicios/ServicioUpdt/" + id);
} // -------- fin Servicio --------

// -------- inicio Repu_servicio --------
function Repu_servicio(id) {
    $("#contenido").load("/Servicios/Repu_servicio/" + id);
}
function factura_servicio(id) {
    $("#contenido").load("/Servicios/factura_servicio/" + id);
}


 // -------- fin Repu_servicio --------


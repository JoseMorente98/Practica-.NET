window.onload = function () {
    getAllOrders();
    getAllSelectClient();
    getAllSelectGroup();
}

function getAllOrders() {
    let orderJSON = {
        url: "Orders/GetOrders",
        encabezados: ["No.", "Número de Documento", "Cliente", "Grupo", "Fecha y Hora", "Total"],
        propiedades: ["docEntry", "docNum", "cardName", "groupName", "docDate", "docTotal"],
        idPintado: "orders",
        visualizacion: true,
        id: "docEntry"
    }
    console.log(orderJSON)

    print(orderJSON)
}

function Visualizar(pedido) {
    console.log(pedido);
    let orderJSON = {
        url: "Orders/GetOrder?docEntry=" + pedido,
        encabezados: ["Código", "Artículo", "Total", "IVA"],
        propiedades: ["itemCode", "itemName", "lineTotal", "vatSum"],
        idPintado: "detalle",
    }
    printDetalle(orderJSON);
}

function getAllSelectClient() {
    fetchGet("Client/GetClients", "json", function (res) {
        printSelect(res, "selectClient", "cardCode", "cardName")
    })
}

function getAllSelectGroup() {
    fetchGet("GroupClients/GetGroupClients", "json", function (res) {
        printSelect(res, "selectGroup", "groupNum", "groupName")
    })
}

function limpiarFormulario() {
    limpiarForm("formFilterOrder");
    getAllOrders();
}

function filtrar() {
    var formData = document.getElementById("formFilterOrder");
    var data = new FormData(formData);
    printFilter(data);
}
